using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum WifiState
	{
		[EnumMember(Value = "wan")]
		Wan = 1,

		[EnumMember(Value = "lan")]
		Lan = 2
	}
}
