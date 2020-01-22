using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum InputStatus
	{
		[EnumMember(Value = "unplugged")]
		Unplugged = 1,

		[EnumMember(Value = "plugged")]
		Plugged = 2,

		[EnumMember(Value = "linked")]
		Linked = 3
	}
}