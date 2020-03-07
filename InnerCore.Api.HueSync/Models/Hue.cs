using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Hue : HueCommand
	{
		[DataMember(Name = "bridgeIpAddress")]
		public string BridgeIpAddress { get; set; }

		[DataMember(Name = "connectionState")]
		public ConnectionState ConnectionState { get; set; }

		// todo: groups
	}
}
