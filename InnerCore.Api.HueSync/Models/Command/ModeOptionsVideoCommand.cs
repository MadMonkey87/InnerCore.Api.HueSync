using InnerCore.Api.HueSync.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class ModeOptionsVideoCommand
	{
		[DataMember(Name = "intensity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Intensity? Intensity { get; set; }

		[DataMember(Name = "backgroundLighting")]
		public bool? BackgroundLighting { get; set; }
	}
}
