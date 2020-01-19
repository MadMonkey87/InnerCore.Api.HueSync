using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ActionCommand
	{
		[DataMember(Name = "mode")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Mode? Mode { get; set; }

		[DataMember(Name = "intensity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Intensity? Intensity { get; set; }

		/// <summary>
		/// 0-200
		/// </summary>
		[DataMember(Name = "brightness")]
		public int? Brightness { get; set; }

		[DataMember(Name = "hdmiSource")]
		[JsonConverter(typeof(StringEnumConverter))]
		public HdmiSource? HdmiSource { get; set; }

		[DataMember(Name = "video")]
		public ModeOptionsVideo VideoOptions { get; set; }

		[DataMember(Name = "game")]
		public ModeOptionsVideo GameOptions { get; set; }

		[DataMember(Name = "music")]
		public ModeOptionsMusic MusicOptions { get; set; }

		[DataMember(Name = "music")]
		public ModeOptionsAmbient AmbientOptions { get; set; }
	}
}
