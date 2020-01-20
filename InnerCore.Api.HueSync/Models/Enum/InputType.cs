using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
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

		[EnumMember(Value = "phone")]
		Smartphone,

		[EnumMember(Value = "desktop")]
		Desktop,

		[EnumMember(Value = "laptop")]
		Laptop,

		[EnumMember(Value = "appletv")]
		AppleTv,

		[EnumMember(Value = "roku")]
		Roku,

		[EnumMember(Value = "shield")]
		NvidiaShield,

		[EnumMember(Value = "chromecast")]
		ChromeCast,

		[EnumMember(Value = "firetv")]
		FireTv,

		[EnumMember(Value = "diskplayer")]
		DvDPlayer,

		[EnumMember(Value = "settopbox")]
		SetTopBox,

		[EnumMember(Value = "satellite")]
		Satellite,

		[EnumMember(Value = "avreceiver")]
		AvReceiver,

		[EnumMember(Value = "soundbar")]
		Soundbar
	}
}