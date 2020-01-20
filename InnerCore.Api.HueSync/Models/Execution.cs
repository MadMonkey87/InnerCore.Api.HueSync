using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Execution : ExecutionCommand
	{
		[DataMember(Name = "lastSyncMode")]
		public Mode LastSyncMode { get; set; }

		[DataMember(Name = "syncActive")]
		public bool SyncActive { get; set; }

		[DataMember(Name = "hdmiActive")]
		public bool HdmiActive { get; set; }
	}
}
