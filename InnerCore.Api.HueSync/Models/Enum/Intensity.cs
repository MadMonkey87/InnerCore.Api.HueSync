using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum Intensity
	{
		[EnumMember(Value = "subtle")]
		Subtle,

		[EnumMember(Value = "moderate")]
		Moderate,

		[EnumMember(Value = "high")]
		High,

		[EnumMember(Value = "intense")]
		Intense,
	}
}
