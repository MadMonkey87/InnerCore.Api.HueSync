using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Input
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public InputType Type { get; set; }

		[DataMember(Name = "status")]
		[JsonConverter(typeof(StringEnumConverter))]
		public InputStatus Status { get; set; }

		[DataMember(Name = "lastSyncMode")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Mode LastSyncMode { get; set; }
	}
}