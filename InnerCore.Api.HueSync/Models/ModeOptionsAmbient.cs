using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ModeOptionsAmbient
	{
		[DataMember(Name = "ambientShowType")]
		public int? AmbientShowType { get; set; }

		[DataMember(Name = "ambientModeType")]
		public int? AmbientModeType { get; set; }
	}
}
