using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	// todo: check if there are further actions possible
	public enum DeviceAction
	{
		[EnumMember(Value = "checkForFirmwareUpdates")]
		CheckFirmwareUpdates,

		[EnumMember(Value = "doSoftwareRestart")]
		Restart
	}
}
