using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	// todo: check all api values
	public enum InputType
	{
		[EnumMember(Value = "generic")]
		Generic,

		[EnumMember(Value = "xbox")]
		Xbox,

		[EnumMember(Value = "playstation")]
		Playstation,

		[EnumMember(Value = "nintendoswitch")]
		NintendoSwitch,

		[EnumMember(Value = "smartphone")]
		Smartphone,

		[EnumMember(Value = "desktop")]
		Desktop,

		[EnumMember(Value = "laptop")]
		Laptop,

		[EnumMember(Value = "appletv")]
		AppleTv,

		[EnumMember(Value = "roku")]
		Roku,

		[EnumMember(Value = "nvidiashield")]
		NvidiaShield,

		[EnumMember(Value = "chromecast")]
		ChromeCast,

		[EnumMember(Value = "firetv")]
		FireTv,

		[EnumMember(Value = "dvdplayer")]
		DvDPlayer,

		[EnumMember(Value = "settopbox")]
		SetTopBox,

		[EnumMember(Value = "satellite")]
		Satellite,

		[EnumMember(Value = "av receiver")]
		AvReceiver,

		[EnumMember(Value = "soundbar")]
		Soundbar
	}
}