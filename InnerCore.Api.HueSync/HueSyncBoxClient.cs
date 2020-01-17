using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using InnerCore.Api.HueSync.Models;
using Newtonsoft.Json;

namespace InnerCore.Api.HueSync
{
	// todo: extend s.t the hue bridge details can be changed too
	// todo: allow to rename the hdmi inputsA
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
		}

		/// <summary>
		/// Retrieves an access token from the box. This needs to be called first to initiate the registration progress and will return null. The user then has to
		/// press and hold the physical button on the box until the led turns green. A further registration attempt then will return the access token which should be kept
		/// safe for further authorization
		/// </summary>
		/// <param name="applicationName">any application name</param>
		/// <param name="applicationSecret">it is not yet known how and where to register an application, but MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI= seems to work fine</param>
		/// <param name="clientName">any client name</param>
		/// <returns>null if the user needs to press the physical button on the box or the access token if the registration was successful</returns>
		public async Task<string> RegisterAsync(string applicationName, string applicationSecret, string clientName)
		{
			if (applicationName == null)
				throw new ArgumentNullException(nameof(applicationName));
			if (applicationSecret == null)
				throw new ArgumentNullException(nameof(applicationSecret));
			if (clientName == null)
				throw new ArgumentNullException(nameof(clientName));

			var request = new RegistrationRequest() { ApplicationName = applicationName, ApplicationSecret = applicationSecret, ClientName = clientName };
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PostAsync(new Uri($"{_apiBase}/api/v1/registrations"), SerializeRequest(request)).ConfigureAwait(false);

			var registrationResponse = await HandleResponseAsync<RegistrationResponse>(response);

			Initialize(registrationResponse.AccessToken);

			return registrationResponse.Success ? registrationResponse.AccessToken : null;
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

		public async Task<Hdmi> GetHdmiAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/hdmi")).ConfigureAwait(false);
			return await HandleResponseAsync<Hdmi>(response);
		}

		public async Task<Execution> GetExecutionAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/execution")).ConfigureAwait(false);
			return await HandleResponseAsync<Execution>(response);
		}

		public async Task<Behaviour> GetBehaviourAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/behaviour")).ConfigureAwait(false);
			return await HandleResponseAsync<Behaviour>(response);
		}

		public async Task<Registrations> GetRegistrationsAsync()
		{
			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.GetAsync(new Uri($"{_apiBase}/api/v1/registrations")).ConfigureAwait(false);
			return await HandleResponseAsync<Registrations>(response);
		}

		public async Task PerformActionAsync(ActionCommand action)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/execution"), SerializeRequest(action)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task ApplyBehaviourAsync(Behaviour behaviour)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/behaviour"), SerializeRequest(behaviour)).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		public async Task PerformDeviceActionAsync(DeviceAction action)
		{
			CheckInitialized();

			var client = await GetHttpClient().ConfigureAwait(false);
			var response = await client.PutAsync(new Uri($"{_apiBase}/api/v1/behaviour"), SerializeRequest(new DeviceCommand() { Action = action })).ConfigureAwait(false);
			await HandleResponseAsync(response);
		}

		private HttpContent SerializeRequest(Object request)
		{
			return new StringContent(JsonConvert.SerializeObject(request, _serializerSettings), Encoding.UTF8, "application/json");
		}

		private async Task HandleResponseAsync(HttpResponseMessage response)
		{
			if (!response.IsSuccessStatusCode)
			{
				var error = JsonConvert.DeserializeObject<GenericError>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
				throw new HueSyncBoxException(error);
			}
		}

		private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
		{
			await HandleResponseAsync(response);

			return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
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
