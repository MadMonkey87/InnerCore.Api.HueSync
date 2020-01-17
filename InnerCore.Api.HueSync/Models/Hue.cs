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


		// todo: complete groups and the connection state

		/*"groups": {
			"8": {
				"name": "Entertainment Light",
				"numLights": 3,
				"active": false
			}
		},*/

		//"connectionState": "connected"
	}
}
