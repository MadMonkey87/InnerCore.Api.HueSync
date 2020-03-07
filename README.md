InnerCore.Api.HueSync [![Build Status][azure build]][project]	[![NuGet][nuget badge]][nuget package]	  [![.NET Standard][dotnet-standard badge]][dotnet-standard doc]
=====================

Open source library for communication with the Philips Hue Sync Box. This library allows you to perform the same actions as you could do with the official app and even more!

**Update**: the api now has been made available official by signify! See https://developers.meethue.com/develop/hue-entertainment/hue-hdmi-sync-box-api/ (login required).
 
## Usage
First you need to know the ip address of your hue sync box. The following code will search for devices in your network:

	var discoveryResults = await DiscoveryService.Discover(TimeSpan.FromSeconds(3));
	var ip = discoveryResults.First().IpAddress;

After that you can use the retrieved ip address to instanciate the actual client:

	var client = new HueSyncBoxClient(ip);

If you want to test the connection you might fetch some basic details of your device (no authorization needed so far):

	var device = await  client.GetDeviceAsync();

Next you'll need to register on the sync box in order to retrieve an access token for further request. Ensure that the box is turned on (led is white) and then press and hold the physical button (~1 sec) on your sync box until the led flashes green. After that you can retrieve the access token using

	accessToken = await client.RegisterAsync("Demo", Environment.MachineName);

*Note 1: the returned access token will be null if the button has not yet been pressed.*

*Note 2: you might need to be quick!*

*Note 3: if the led turns red after a quick green flash: relax, all good!*

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
 - in the music mode there is also the possability to choose a color palette, but currently only one is known (maybe it will be possible to create custom ones) *update** the offical documentation mentions the missing patterns which now have been included
 - ledMode: enable/disable the led **update** the offical documentation confirms this and the new firmware provides a new mode that dimms the led
 - there is an ambient mode where the box performs some animations at it's own, not depending on the input. It is not yet clear how that works exactly, but the effect can be controlled using two parameters:
   ambientShowType: somehow controlls the speed and colors of the animations. Value 1 & 2 are flickering, 3 & 4 is almost a solid blue, 5 & 6 is a slowly changing animation between two colors. Bigger values change the used colors and speed. 
   ambientModeType: this one is even more unclear and does not seem to have a direct effect, but 1 seems to be a good value as ambientShowType has no effect otherwise. **update** the offical documentation mentions that this mode will be dropped
 - start/stopping the light sync seems to work only if it is the only command

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