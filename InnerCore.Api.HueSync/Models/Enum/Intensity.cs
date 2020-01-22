using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum Intensity
	{
		[EnumMember(Value = "subtle")]
		Subtle = 1,

		[EnumMember(Value = "moderate")]
		Moderate = 2,

		[EnumMember(Value = "high")]
		High = 3,

		[EnumMember(Value = "intense")]
		Intense = 4
	}
}
