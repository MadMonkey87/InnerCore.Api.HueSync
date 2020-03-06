using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Update
	{
		[DataMember(Name = "autoUpdateEnabled")]
		public bool AutoUpdateEnabled { get; set; }

		/// <summary>
		/// hour of the day when checking for updates, valid values are 0-23, deault is 10
		/// </summary>
		[DataMember(Name = "autoUpdateTime")]
		public int AutoUpdateTime { get; set; }
	}
}