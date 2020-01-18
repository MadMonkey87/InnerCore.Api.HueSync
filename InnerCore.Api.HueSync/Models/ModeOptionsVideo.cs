using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ModeOptionsVideo
	{
		[DataMember(Name = "intensity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Intensity? Intensity { get; set; }

		[DataMember(Name = "backgroundLighting")]
		public bool? BackgroundLighting { get; set; }
	}
}
