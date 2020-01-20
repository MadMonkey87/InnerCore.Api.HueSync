using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	public enum InputStatus
	{
		[EnumMember(Value = "unplugged")]
		Unplugged,

		[EnumMember(Value = "plugged")]
		Plugged,

		[EnumMember(Value = "linked")]
		Linked
	}
}