using System.Data;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Hue
	{
		[DataMember(Name = "bridgeUniqueId")]
		public string BridgeUniqueId { get; set; }

		[DataMember(Name = "bridgeIpAddress")]
		public string BridgeIpAddress { get; set; }

		[DataMember(Name = "groupId")]
		public string GroupId { get; set; }

		[DataMember(Name = "connectionState")]
		public ConnectionState ConnectionState { get; set; }
	}
}
