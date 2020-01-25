using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class DiscoveryResult
	{
		[DataMember(Name = "operation")]
		public int Operation { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "deviceType")]
		public string DeviceType { get; set; }

		[DataMember(Name = "uniqueId")]
		public string UniqueId { get; set; }

		[DataMember(Name = "ipAddress")]
		public string IpAddress { get; set; }
	}
}
