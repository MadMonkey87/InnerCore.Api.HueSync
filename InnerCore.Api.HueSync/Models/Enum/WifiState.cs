using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	public enum WifiState
	{
		[EnumMember(Value = "wan")]
		Wan,

		[EnumMember(Value = "lan")]
		Lan
	}
}
