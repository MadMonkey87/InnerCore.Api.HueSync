using InnerCore.Api.HueSync.Extensions;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InnerCore.Api.HueSync.Sample
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// 1. discover device(s)
			// =====================

			Console.WriteLine("searching for hue sync boxes in the local network");
			var discoveryResults = await DiscoveryService.Discover(TimeSpan.FromSeconds(3));
			if (!discoveryResults.Any())
			{
				Console.WriteLine("no device could be found in the local network");
				Console.ReadLine();
				return;
			}

			Console.WriteLine($"found {discoveryResults.Count()} device(s) -> the first one will be used for this demo");
			foreach (var discoveryResult in discoveryResults)
			{
				Console.WriteLine($"{discoveryResult.Name} ({discoveryResult.IpAddress})");
			}

			// 2. retrieve access token
			// ========================

			var ip = discoveryResults.First().IpAddress;
			var client = new HueSyncBoxClient(ip);

			// you can validate the connection by calling for device details (no access token needed yet)
			var device = await client.GetDeviceAsync();
			Console.WriteLine($"connected to {device.Name}");

			Console.WriteLine("if you already have an access token you can enter it now or press enter to start the registration progress");
			string accessToken = Console.ReadLine();

			if (!string.IsNullOrEmpty(accessToken))
			{
				client.Initialize(accessToken);
			}
			else
			{
				const string appName = "Demo";
				string applicationDevice = Environment.MachineName;

				// start the registration
				accessToken = await client.RegisterAsync(appName, applicationDevice);

				while (string.IsNullOrEmpty(accessToken))
				{
					Console.WriteLine("please press and hold the button on the Hue Sync Box until the led turns green");
					Console.WriteLine("press enter to continue the registration (be quick!)");
					Console.ReadLine();
					accessToken = await client.RegisterAsync(appName, applicationDevice);
				}
				// here you would usually persist the token and for the next app start you would call client.Initialize(accessToken) directly instead of registering
			}

			// 3. read device details and state
			// ================================

			var state = await client.GetStateAsync();
			Console.WriteLine("Here are some details about your Hue Sync Box:");
			Console.WriteLine($"firmware: {state.Device.FirmwareVersion}");
			Console.WriteLine($"current mode: {state.Execution.Mode}");
			Console.WriteLine($"current input: {state.Execution.HdmiSource}");
			Console.WriteLine($"current content: {state.Hdmi.ContentSpecs}");

			// 4. perform some actions on the device
			// =====================================

			Console.WriteLine("press enter to set the mode to 'game, intense', apply the max brightness and change the source to hdmi 2");
			Console.ReadLine();
			var action = new ExecutionCommand()
				.SetMode(Mode.Game)
				.SetBrightness(200)
				.SetHdmiSource(HdmiSource.Input2);
			await client.ApplyExecutionCommandAsync(action);

			Console.WriteLine("press enter start syncing");
			Console.ReadLine();
			action = new ExecutionCommand().SetSyncActive(true);
			await client.ApplyExecutionCommandAsync(action);

			Console.WriteLine("press enter stop syncing");
			Console.ReadLine();
			action = new ExecutionCommand().SetSyncActive(false);
			await client.ApplyExecutionCommandAsync(action);

			Console.WriteLine("press enter put the box into standby mode");
			Console.ReadLine();
			action = new ExecutionCommand().SetMode(Mode.PowerSave);
			await client.ApplyExecutionCommandAsync(action);

			Console.WriteLine("press enter to complete this demo");
			Console.ReadLine();
		}
	}
}
