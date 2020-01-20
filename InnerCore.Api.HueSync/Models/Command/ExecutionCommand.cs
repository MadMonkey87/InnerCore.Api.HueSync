using InnerCore.Api.HueSync.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class ExecutionCommand
	{
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

		[DataMember(Name = "ambient")]
		public ModeOptionsAmbientCommand AmbientOptions { get; set; }
	}
}
