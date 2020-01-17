using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Input
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "type")]
		public InputType Type { get; set; }

		[DataMember(Name = "status")]
		public InputStatus Status { get; set; }

		[DataMember(Name = "lastSyncMode")]
		public Mode LastSyncMode { get; set; }
	}
}