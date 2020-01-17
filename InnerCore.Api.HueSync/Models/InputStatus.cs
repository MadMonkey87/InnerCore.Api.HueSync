using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	// todo: check if there are further values possible
	public enum InputStatus
	{
		[EnumMember(Value = "unplugged")]
		Unplugged,

		[EnumMember(Value = "plugged")]
		Plugged
	}
}