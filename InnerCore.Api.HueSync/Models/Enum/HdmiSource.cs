using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum HdmiSource
	{
		[EnumMember(Value = "input1")]
		Input1 = 1,

		[EnumMember(Value = "input2")]
		Input2 = 2,

		[EnumMember(Value = "input3")]
		Input3 = 3,

		[EnumMember(Value = "input4")]
		Input4 = 4,
	}
}