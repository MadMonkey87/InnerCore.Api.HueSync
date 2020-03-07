using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class HueCommand
	{
		[DataMember(Name = "bridgeUniqueId")]
		public string BridgeUniqueId { get; set; }

		[DataMember(Name = "username")]
		public string Username { get; set; }

		[DataMember(Name = "clientKey")]
		public string ClientKey { get; set; }
	}
}
