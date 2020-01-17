using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	public enum Mode
	{
		/// <summary>
		/// the sync box is powered on and passes the video signal to the tv but no light synchronization is being performed
		/// </summary>
		[EnumMember(Value = "passthrough")]
		Passthrough,

		/// <summary>
		/// the sync box is in standby and no video signal passes trough to the tv
		/// </summary>
		[EnumMember(Value = "powersave")]
		PowerSave,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "video" preset
		/// </summary>
		[EnumMember(Value = "video")]
		Video,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "game" preset
		/// </summary>
		[EnumMember(Value = "game")]
		Game,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "music" preset
		/// </summary>
		[EnumMember(Value = "music")]
		Music
	}
}
