using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class InputBehaviour
	{
		/// <summary>
		/// Automatically switch to this input if a new signal is detected
		/// </summary>
		[DataMember(Name = "cecInputSwitch")]
		public int? CecInputSwitch { get; set; }

		/// <summary>
		/// Automatically start the light synchronization if this is the active input and if a video signal is detected
		/// </summary>
		[DataMember(Name = "linkAutoSync")]
		public int? LinkAutoSync { get; set; }
	}
}