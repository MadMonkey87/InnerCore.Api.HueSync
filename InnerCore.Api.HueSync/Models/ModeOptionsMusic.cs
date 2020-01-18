using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ModeOptionsMusic
	{
		[DataMember(Name = "intensity")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Intensity? Intensity { get; set; }

		[DataMember(Name = "palette")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Palette Palette { get; set; }
	}
}
