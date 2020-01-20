using InnerCore.Api.HueSync.Models.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class InputCommand
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public InputType Type { get; set; }
	}
}