# InnerCore.Api.HueSync [![.NET Standard][dotnet-standard badge]][dotnet-standard doc]

Open source library for communication with the Philips Hue Sync Box. This library allows you to perform the same actions as you could do with the official app and even more!

Important: there is no official documentation available yet. Most features have been discovered however (credit: https://github.com/ebaauw/homebridge-hue/issues/552). 

## Limitations
 - this api is not yet official and thus there is no warranty at all and you are acting at your own risk
 - it is not yet known how and where to retrieve an appSecret officially, but the provided one seems to work just fine
 - it is likely that there is a discovery mechanism similar to the one of the hue bridge but for now this remains unknown
 - the api reveals a few features that are not yet available in the official app, like an "ambient mode" and "patterns" for the music mode. As not all values are known yet this remains unusable for now

## Status
This library is currently under developement and intensive testing. Some parts work some not and many interfaces still might change a lot for the final releas
 
## Usage
First you need to know the ip address of your hue sync box (in the official app, go to settings -> devices) to instanciate the client:

	var client = new HueSyncBoxClient(ip);

If you want to test the connection you might fetch some basic details of your device (no authorization needed so far):

	var device = await  client.GetDeviceAsync();

Next you'll need to register on the sync box in order to retrieve an access token for further request. Press and hold the physical button on your sync box until the led turns green. After that you can retrieve the access token using

	accessToken = await client.RegisterAsync("Demo", "MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI=", Environment.MachineName);

Note 1: you can choose whatever you like as the app- and the client name but you need a proper app secret. I guess later on you'll have to register at philips in order to get one but for now you can use the one above.
Note 2: the returned access token will be null if the button has not yet been pressed

Keep the access token save as you can use it later on! Instead of registering you can simply call HueSyncBoxClient.Initialize() with your token instead.

As the client is now authorized you can retrieve all details of your device (check the descriptions in the code for more details):

	var state = await client.GetStateAsync();

You also can perform some actions on the sync box. They are splitted into the following:

### Actions
These command allow you to change the current state, i.e enable/disable syncing, change the input, mode or intensity. You can send them one by one but you also can combine them:

	var action = new ActionCommand()
		.SetMode(Mode.Game)
		.SetIntensity(Intensity.Intense)
		.SetBrightness(200)
		.SetHdmiSource(HdmiSource.Input2);
	await client.PerformActionAsync(action);

### Behaviours
These are equivalent to settings and just like actions, they also can get combined:

	var behaviour = new Behaviour().SetArcBypass(true).SetCecPowerSave(false);
	client.ApplyBehaviourAsync(behaviour);

### Device actions
These actions directly affect the device, like rebooting it or checking for firmware updates:

    await client.PerformDeviceActionAsync(DeviceAction.Restart);

## License

InnerCore.Api.DeConz is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to [license.txt](https://github.com/MadMonkey87/InnerCore.Api.DeConz/blob/master/LICENSE.txt) for more information.

## contributions
Contributions are welcome. Fork this repository and send a pull request if you have something useful to add.

[project]: https://github.com/MadMonkey87/InnerCore.Api.HueSync
[dotnet-standard badge]: http://img.shields.io/badge/.NET_Standard-v2.0-green.svg
[dotnet-standard doc]: https://docs.microsoft.com/da-dk/dotnet/articles/standard/library