using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class DeviceCommand
	{
		[DataMember(Name = "action")]
		[JsonConverter(typeof(StringEnumConverter))]
		public DeviceAction Action { get; set; }

		// todo: seems like this would be the way to apply the following values
		//{     "update": {         "autoUpdateEnabled": true,         "autoUpdateTime": 2     } }
}
}
