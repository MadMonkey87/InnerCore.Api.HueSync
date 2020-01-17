using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Update
	{
		[DataMember(Name = "autoUpdateEnabled")]
		public bool AutoUpdateEnabled { get; set; }

		// todo: clarify the meaning of this (might this be the amount of days?)
		[DataMember(Name = "autoUpdateTime")]
		public int AutoUpdateTime { get; set; }
	}
}