using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum InputType
	{
		[EnumMember(Value = "generic")]
		Generic = 1,

		[EnumMember(Value = "xbox")]
		Xbox = 2,

		[EnumMember(Value = "playstation")]
		Playstation = 3,

		[EnumMember(Value = "nintendoswitch")]
		NintendoSwitch = 4,

		[EnumMember(Value = "phone")]
		Smartphone = 5,

		[EnumMember(Value = "desktop")]
		Desktop = 6,

		[EnumMember(Value = "laptop")]
		Laptop = 7,

		[EnumMember(Value = "appletv")]
		AppleTv = 8,

		[EnumMember(Value = "roku")]
		Roku = 9,

		[EnumMember(Value = "shield")]
		NvidiaShield = 10,

		[EnumMember(Value = "chromecast")]
		ChromeCast = 11,

		[EnumMember(Value = "firetv")]
		FireTv = 12,

		[EnumMember(Value = "diskplayer")]
		DvDPlayer = 13,

		[EnumMember(Value = "settopbox")]
		SetTopBox = 14,

		[EnumMember(Value = "satellite")]
		Satellite = 15,

		[EnumMember(Value = "avreceiver")]
		AvReceiver = 16,

		[EnumMember(Value = "soundbar")]
		Soundbar = 17,

		[EnumMember(Value = "hdmiswitch")]
		HdmiSwitch = 17,

		[EnumMember(Value = "video")]
		Video = 17,

		[EnumMember(Value = "game")]
		Game = 17,

		[EnumMember(Value = "music")]
		Music = 17
	}
}