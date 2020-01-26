InnerCore.Api.HueSync [![Build Status][azure build]][project]	[![NuGet][nuget badge]][nuget package]	  [![.NET Standard][dotnet-standard badge]][dotnet-standard doc]
=====================

Open source library for communication with the Philips Hue Sync Box. This library allows you to perform the same actions as you could do with the official app and even more!

Important: there is no official documentation available yet. Most features have been discovered however (credit: https://github.com/ebaauw/homebridge-hue/issues/552). 
 
## Usage
First you need to know the ip address of your hue sync box. The following code will search for devices in your network:

	var discoveryResults = await DiscoveryService.Discover(TimeSpan.FromSeconds(3));
	var ip = discoveryResults.First().IpAddress;

After that you can use the retrieved ip address to instanciate the actual client:

	var client = new HueSyncBoxClient(ip);

If you want to test the connection you might fetch some basic details of your device (no authorization needed so far):

	var device = await  client.GetDeviceAsync();

Next you'll need to register on the sync box in order to retrieve an access token for further request. Enusre that the box is turned on (led is white) and then press and hold the physical button (~1 sec) on your sync box until the led flashes green. After that you can retrieve the access token using

	accessToken = await client.RegisterAsync("Demo", "MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI=", Environment.MachineName);

*Note 1: you can choose whatever you like as the app- and the client name but you need a proper app secret. I guess later on you'll have to register at philips in order to get one but for now you can use the one above.*

*Note 2: the returned access token will be null if the button has not yet been pressed.*

Keep the access token save as you can use it later on! Instead of registering you can simply call HueSyncBoxClient.Initialize() with your token instead.

As the client is now authorized you can retrieve all details of your device (check the descriptions in the code for more details):

	var state = await client.GetStateAsync();

You also can perform some actions on the sync box. They are splitted into the following:

### Execution commands
These commands allow you to change the current state, i.e enable/disable syncing, change the input, mode or intensity. You can send them one by one but you also can combine them:

	var command = new ExecutionCommand()
		.SetMode(Mode.Game)
		.SetIntensity(Intensity.Intense)
		.SetSyncActive(true)
		.SetBrightness(200)
		.SetHdmiSource(HdmiSource.Input2);
	await client.PerformExecutionCommandAsync(command);

### Behavior command
These are equivalent to settings and just like execution commands, they also can get combined:

	var command = new BehaviorCommand()
		.SetArcBypass(true)
		.SetCecPowerSave(false);
	client.PerformBehaviorCommandAsync(command);

### Device commands
These commands directly affect the device, like rebooting it or checking for firmware updates:

    await client.PerformDeviceCommandAsync(DeviceAction.Restart);

### Findings
The api reveals a few features that the official app does not yet provide but that are already availabke trough the api:
 - characteristics of the current input: in the State.Hdmi.ContentSpecs field you can see the resolution, colormode and refreshrate of the current input (seems a little buggy, sdr and hdr are correct, dolby vision however is indicated as 'sdr' although it gets passed trough just fine inclusive syncing).
 - in the music mode there is also the possability to choose a color palette, but currently only one is known (maybe it will be possible to create custom ones)
 - ledMode: enable/disable the led
 - there is an ambient mode where the box performs some animations at it's own, not depending on the input. It is not yet clear how that works exactly, but the effect can be controlled using two parameters:
   ambientShowType: somehow controlls the speed and colors of the animations. Value 1 & 2 are flickering, 3 & 4 is almost a solid blue, 5 & 6 is a slowly changing animation between two colors. Bigger values change the used colors and speed. 
   ambientModeType: this one is even more unclear and does not seem to have a direct effect, but 1 seems to be a good value as ambientShowType has no effect otherwise.
 - start/stopping the light sync seems to work only if it is the only command

 ## Limitations
 - this api is not yet official and thus there is no warranty at all and you are acting at your own risk
 - it is not yet known how and where to retrieve an appSecret officially, but the provided one seems to work just fine
 - the api reveals a few features that are not yet available in the official app, like an "ambient mode" and "patterns" for the music mode. As not all values are known yet this remains unusable for now

## License

InnerCore.Api.HueSync is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to [license.txt](https://github.com/MadMonkey87/InnerCore.Api.HueSync/blob/master/LICENSE.txt) for more information.

## Contributions
Contributions are welcome. Fork this repository and send a pull request if you have something useful to add.

[azure build]: https://innercore.visualstudio.com/InnerCore.Api.HueSync/_apis/build/status/InnerCore.Api.HueSync?branchName=master
[project]: https://github.com/MadMonkey87/InnerCore.Api.HueSync
[nuget badge]: https://img.shields.io/nuget/v/InnerCore.Api.HueSync.svg
[nuget package]: https://www.nuget.org/packages/InnerCore.Api.HueSync
[dotnet-standard badge]: http://img.shields.io/badge/.NET_Standard-v2.0-green.svg
[dotnet-standard doc]: https://docs.microsoft.com/da-dk/dotnet/articles/standard/library