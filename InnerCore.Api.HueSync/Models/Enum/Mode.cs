using System;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Enum
{
	public enum Mode
	{
		/// <summary>
		/// the sync box is powered on and passes the video signal to the tv but no light synchronization is being performed
		/// </summary>
		[EnumMember(Value = "passthrough")]
		Passthrough = 1,

		/// <summary>
		/// the sync box is in standby and no video signal passes trough to the tv
		/// </summary>
		[EnumMember(Value = "powersave")]
		PowerSave = 2,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "video" preset
		/// </summary>
		[EnumMember(Value = "video")]
		Video = 3,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "game" preset
		/// </summary>
		[EnumMember(Value = "game")]
		Game = 4,

		/// <summary>
		/// the sync box is powered on and performs the light synchronization in the "music" preset
		/// </summary>
		[EnumMember(Value = "music")]
		Music = 5,

		/// <summary>
		/// the sync box is powered on and performs some animations by itself, not depending on any input
		/// </summary>
		[EnumMember(Value = "ambient")]
		[Obsolete("will be removed in the future")]
		Ambient = 6
	}
}
