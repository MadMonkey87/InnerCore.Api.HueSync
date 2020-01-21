﻿using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum DeviceAction
	{
		[EnumMember(Value = "none")]
		None,

		[EnumMember(Value = "checkForFirmwareUpdates")]
		CheckFirmwareUpdates,

		[EnumMember(Value = "doSoftwareRestart")]
		Restart
	}
}