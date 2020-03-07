using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum ConnectionState
	{
		[EnumMember(Value = "uninitialized")]
		Uninitialized = 1,

		[EnumMember(Value = "disconnected")]
		Disconnected = 2,

		[EnumMember(Value = "connecting")]
		Connecting = 3,

		[EnumMember(Value = "unauthorized")]
		Unauthorized = 4,

		[EnumMember(Value = "connected")]
		Connected = 4,

		[EnumMember(Value = "invalidgroup")]
		Invalidgroup = 4,

		[EnumMember(Value = "streaming")]
		Streaming = 4
	}
}