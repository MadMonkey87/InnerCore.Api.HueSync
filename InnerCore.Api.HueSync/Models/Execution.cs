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
	}
}
