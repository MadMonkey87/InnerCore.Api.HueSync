using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	// todo: there must be more modes, but they are currently unknown (maybe it is even possible to add custom palettes)
	public enum Palette
	{
		[EnumMember(Value = "melancholicEnergetic")]
		MelancholicEnergetic
	}
}
