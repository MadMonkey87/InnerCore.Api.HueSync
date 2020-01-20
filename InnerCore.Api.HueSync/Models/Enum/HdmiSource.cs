using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	public enum HdmiSource
	{
		[EnumMember(Value = "input1")]
		Input1,

		[EnumMember(Value = "input2")]
		Input2,

		[EnumMember(Value = "input3")]
		Input3,

		[EnumMember(Value = "input4")]
		Input4
	}
}