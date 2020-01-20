using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Input : InputCommand
	{
		[DataMember(Name = "status")]
		[JsonConverter(typeof(StringEnumConverter))]
		public InputStatus Status { get; set; }

		[DataMember(Name = "lastSyncMode")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Mode LastSyncMode { get; set; }
	}
}