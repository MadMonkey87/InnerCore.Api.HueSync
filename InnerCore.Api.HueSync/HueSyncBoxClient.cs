using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using InnerCore.Api.HueSync.Models;
using InnerCore.Api.HueSync.Models.Command;
using Newtonsoft.Json;

namespace InnerCore.Api.HueSync
{
	public class HueSyncBoxClient
	{
		private string _accessToken;

		private readonly string _apiBase;

		private HttpClient _httpClient;

		private JsonSerializerSettings _serializerSettings =
			new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

		public HueSyncBoxClient(string ip)
		{
			if (ip == null)
				throw new ArgumentNullException(nameof(ip));

			_apiBase = $"https://{ip}";
		}

		public void Initialize(string accessToken)
		{
			_accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
			if (_httpClient != null)
			{
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
			}
		}

		/// <summary>
		/// Retrieves an access token from the box. Ensure that the box is turned on (led is white) and then press and hold the physical button (~1 sec) on your sync box until the led flashes green.
		/// Calling RegisterAsync then will return the access token which should be kept safe for further use
		/// </summary>
		/// <param name="applicationName">any application name</param>
		/// <param name="clientName">any client name</param>
		/// <returns>null if the user needs to press the physical button on the box or the access token if the registration was successful</returns>
		public async Task<string> RegisterAsync(string applicationName, string clientName)
		{
			if (applicationName == null)
				throw new ArgumentNullException(nameof(applicationName));
			if (clientName == null)
				throw new ArgumentNullException(nameof(clientName));

			var request = new RegistrationRequest() { ApplicationName = applicationName, ClientName = clientName };
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PostAsync(new Uri($"{_apiBase}/api/v1/registrations"), SerializeRequest(request)).ConfigureAwait(false);

			var registrationResponse = await HandleResponseAsync<RegistrationResponse>(response, false);

			// all good, but the physical button has not yet been pressed
			if (registrationResponse.Code == 16)
			{
				return null;
			}

			Initialize(registrationResponse.AccessToken);

			return registrationResponse.AccessToken;
		}

		public async Task RemoveRegistration(string registrationId)
		{
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.DeleteAsync(new Uri($"{_apiBase}/api/v1/registrations/{registrationId}")).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task<State> GetStateAsync()
		{
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1")).ConfigureAwait(false);
			return await HandleResponseAsync<State>(response);
		}

		public async Task<Device> GetDeviceAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/device")).ConfigureAwait(false);
			return await HandleResponseAsync<Device>(response);
		}

		public async Task<Hue> GetHueAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/hue")).ConfigureAwait(false);
			return await HandleResponseAsync<Hue>(response);
		}

		public async Task<HdmiCommand> GetHdmiAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/hdmi")).ConfigureAwait(false);
			return await HandleResponseAsync<HdmiCommand>(response);
		}

		public async Task<Execution> GetExecutionAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/execution")).ConfigureAwait(false);
			return await HandleResponseAsync<Execution>(response);
		}

		public async Task<BehaviorCommand> GetBehaviorAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/behavior")).ConfigureAwait(false);
			return await HandleResponseAsync<BehaviorCommand>(response);
		}

		public async Task<Ir> GetIrAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/ir")).ConfigureAwait(false);
			return await HandleResponseAsync<Ir>(response);
		}

		public async Task<IEnumerable<Preset>> GetPresetsAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/presets")).ConfigureAwait(false);
			var result = await HandleResponseAsync<Dictionary<string, Preset>>(response);

			if (result == null)
			{
				return new List<Preset>();
			}

			foreach (var rawCode in result)
			{
				rawCode.Value.PresetId = rawCode.Key;
			}
			return result.Select(e => e.Value).ToList();
		}

		public async Task<string> CreatePreset(string name, ExecutionCommand executionCommand)
		{
			CheckInitialized();

			var device = await GetDeviceAsync();
			var presets = await GetPresetsAsync();

			if (presets.Count() >= device.Capabilities.MaxPresets)
			{
				throw new InvalidOperationException($"the max amount of presets ({device.Capabilities.MaxPresets}) has been reached.");
			}

			var preset = new Preset()
			{
				ExecutionCommand = executionCommand,
				Name = name
			};

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PostAsync(new Uri($"{_apiBase}/api/v1/presets"), SerializeRequest(preset)).ConfigureAwait(false);
			return (await HandleResponseAsync<Preset>(response)).PresetId;
		}

		public async Task UpdatePreset(Preset preset)
		{
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/presets/{preset.PresetId}"), SerializeRequest(preset)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task RemovePreset(string presetId)
		{
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.DeleteAsync(new Uri($"{_apiBase}/api/v1/presets/{presetId}")).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyExecutionCommandAsync(ExecutionCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/execution"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyBehaviourCommandAsync(BehaviorCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/behavior"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyHdmiCommandAsync(HdmiCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/hdmi"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyDeviceCommandAsync(DeviceCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/device"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyHueCommandAsync(HueCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/hue"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyIrCommandAsync(IrCommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException(nameof(command));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/ir"), SerializeRequest(command)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		// todo: delete codes

		private HttpContent SerializeRequest(Object request)
		{
			return new StringContent(JsonConvert.SerializeObject(request, _serializerSettings), Encoding.UTF8, "application/json");
		}

		private async Task HandleResponseAsync(HttpResponseMessage response, bool throwOnError = true)
		{
			if (!response.IsSuccessStatusCode && throwOnError)
			{
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					throw new HueSyncBoxException(new GenericError() { Message = content });
				}

				var error = JsonConvert.DeserializeObject<GenericError>(content);
				throw new HueSyncBoxException(error);
			}
		}

		private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response, bool throwOnError = true)
		{
			await HandleResponseAsync(response, throwOnError);

			var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
			return JsonConvert.DeserializeObject<T>(content);
		}

		private Task<HttpClient> GetHttpClient()
		{
			// return per-thread HttpClient
			if (_httpClient == null)
			{
				var handler = new HttpClientHandler();
				handler.ClientCertificateOptions = ClientCertificateOption.Manual;
				handler.ServerCertificateCustomValidationCallback =
					(httpRequestMessage, cert, cetChain, policyErrors) =>
					{
						return true;
					};

				_httpClient = new HttpClient(handler);
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
			}

			return Task.FromResult(_httpClient);
		}

		private void CheckInitialized()
		{
			if (string.IsNullOrEmpty(_accessToken))
				throw new InvalidOperationException("HueSyncBoxClient is not initialized. First call RegisterAsync or Initialize.");
		}
	}
}
