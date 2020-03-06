using InnerCore.Api.HueSync.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class ExecutionCommand
	{
		// todo: how can we handle further, unknown modes?
		[DataMember(Name = "mode")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Mode? Mode { get; set; }

		/// <summary>
		/// 0-200
		/// </summary>
		[DataMember(Name = "brightness")]
		public int? Brightness { get; set; }

		[DataMember(Name = "hdmiSource")]
		[JsonConverter(typeof(StringEnumConverter))]
		public HdmiSource? HdmiSource { get; set; }

		[DataMember(Name = "video")]
		public ModeOptionsVideoCommand VideoOptions { get; set; }

		[DataMember(Name = "game")]
		public ModeOptionsVideoCommand GameOptions { get; set; }

		[DataMember(Name = "music")]
		public ModeOptionsMusicCommand MusicOptions { get; set; }

		[Obsolete("will be removed in the future")]
		[DataMember(Name = "ambient")]
		public ModeOptionsAmbientCommand AmbientOptions { get; set; }

		[DataMember(Name = "syncActive")]
		public bool? SyncActive { get; set; }

		[DataMember(Name = "hdmiActive")]
		public bool? HdmiActive { get; set; }

		[DataMember(Name = "hueTarget")]
		public string HueTarget { get; set; }

		[DataMember(Name = "toggleSyncActive")]
		public bool? ToggleSyncActive { get; set; }

		[DataMember(Name = "toggleHdmiActive")]
		public bool? ToggleHdmiActive { get; set; }
	}
}
