using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Device : DeviceCommand
	{
		[DataMember(Name = "deviceType")]
		public string DeviceType { get; set; }

		[DataMember(Name = "uniqueId")]
		public string UniqueId { get; set; }

		[DataMember(Name = "ipAddress")]
		public string IpAddress { get; set; }

		[DataMember(Name = "apiLevel")]
		public decimal ApiLevel { get; set; }

		[DataMember(Name = "firmwareVersion")]
		public string FirmwareVersion { get; set; }

		[DataMember(Name = "buildNumber")]
		public int BuildNumber { get; set; }

		[DataMember(Name = "lastCheckedUpdate")]
		public DateTimeOffset LastCheckedUpdate { get; set; }

		[DataMember(Name = "updateableFirmwareVersion")]
		public string UpdateableFirmwareVersion { get; set; }

		[DataMember(Name = "updateableBuildNumber")]
		public int? UpdateableBuildNumber { get; set; }

		[DataMember(Name = "wifiState")]
		[JsonConverter(typeof(StringEnumConverter))]
		public WifiState WifiState { get; set; }

		[DataMember(Name = "termsAgreed")]
		public bool TermsAgreed { get; set; }
	}
}
