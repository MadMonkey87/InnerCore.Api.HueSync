using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	/// <summary>
	/// Describes the entire state of the Hue Sync Box
	/// </summary>
	[DataContract]
	public class State
	{
		/// <summary>
		/// Details about the device like version, updates, network state etc.
		/// </summary>
		[DataMember(Name = "device")]
		public Device Device { get; set; }

		/// <summary>
		/// Details about the connection to the Hue bridge
		/// </summary>
		[DataMember(Name = "hue")]
		public Hue Hue { get; set; }

		/// <summary>
		/// Details about the current sync state like the selected input, the sync mode, brightness etc
		/// </summary>
		[DataMember(Name = "execution")]
		public Execution Execution { get; set; }

		/// <summary>
		/// Details about all hdmi inputs and outputs like if they are plugged in or not, the name etc.
		/// </summary>
		[DataMember(Name = "hdmi")]
		public Hdmi Hdmi { get; set; }

		/// <summary>
		/// Details about the currently applied settings
		/// </summary>
		[DataMember(Name = "behavior")]
		public Behavior Behavior { get; set; }

		/// <summary>
		/// Details about the registered apps
		/// </summary>
		[DataMember(Name = "registrations")]
		public Registrations Registrations { get; set; }
	}
}
