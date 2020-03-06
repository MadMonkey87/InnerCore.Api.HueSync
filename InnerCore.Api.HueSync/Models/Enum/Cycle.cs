using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum Cycle
	{
		[EnumMember(Value = "previous")]
		Previous = 1,

		[EnumMember(Value = "next")]
		NExt = 2,
	}
}