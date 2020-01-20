using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class DeviceCommand
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "action")]
		[JsonConverter(typeof(StringEnumConverter))]
		public DeviceAction? Action { get; set; }

		/// <summary>
		/// Enable/disable the led
		/// </summary>
		[DataMember(Name = "ledMode")]
		public int? LedMode { get; set; }

		[DataMember(Name = "update")]
		public Update Update { get; set; }
	}
}
