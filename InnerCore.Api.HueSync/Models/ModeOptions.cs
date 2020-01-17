using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ModeOptions
	{
		[DataMember(Name = "intensity")]
		public Intensity? Intensity { get; set; }

		[DataMember(Name = "backgroundLighting")]
		public bool? BackgroundLighting { get; set; }
	}
}
