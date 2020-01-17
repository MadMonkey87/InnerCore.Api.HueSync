using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class ActionCommand
	{
		[DataMember(Name = "mode")]
		public Mode? Mode { get; set; }

		[DataMember(Name = "intensity")]
		public Intensity? Intensity { get; set; }

		/// <summary>
		/// 0-200
		/// </summary>
		[DataMember(Name = "brightness")]
		public int? Brightness { get; set; }

		[DataMember(Name = "hdmiSource")]
		public HdmiSource HdmiSource { get; set; }

		[DataMember(Name = "video")]
		public ModeOptions VideoOptions { get; set; }

		[DataMember(Name = "game")] 
		public ModeOptions GameOptions { get; set; }

		// todo: looks like this would be the place to provide the options for the music and the ambient mode:
		//"music": {
		//	"intensity": "intense",
		//	"palette": "melancholicEnergetic"
		//},
		//"ambient": {
		//	"ambientShowType": 0,
	}
}
