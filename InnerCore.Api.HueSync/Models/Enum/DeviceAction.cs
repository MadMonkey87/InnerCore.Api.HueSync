using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum DeviceAction
	{
		[EnumMember(Value = "none")]
		None = 1,

		[EnumMember(Value = "doFirmwareUpdate")]
		CheckFirmwareUpdates = 2,

		[EnumMember(Value = "doSoftwareRestart")]
		Restart = 3
	}
}
