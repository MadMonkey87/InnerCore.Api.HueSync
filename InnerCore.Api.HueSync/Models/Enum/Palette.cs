using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum Palette
	{
		[EnumMember(Value = "melancholicEnergetic")]
		MelancholicEnergetic = 1,

		[EnumMember(Value = "happyEnergetic")]
		HappyEnergetic = 2,

		[EnumMember(Value = "happyCalm")]
		HappyCalm = 3,

		[EnumMember(Value = "melancholicCalm")]
		MelancholicCalm = 4,

		[EnumMember(Value = "neutral")]
		Neutral = 5,

	}
}
