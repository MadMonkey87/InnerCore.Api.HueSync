using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Execution
	{
		[DataMember(Name = "mode")]
		public Mode Mode { get; set; }

		[DataMember(Name = "lastSyncMode")]
		public Mode LastSyncMode { get; set; }

		[DataMember(Name = "syncActive")]
		public bool SyncActive { get; set; }

		[DataMember(Name = "hdmiActive")]
		public bool HdmiActive { get; set; }

		[DataMember(Name = "hdmiSource")]
		public HdmiSource HdmiSource { get; set; }

		[DataMember(Name = "brightness")]
		public int Brightness { get; set; }

		/*"video": {
			"intensity": "moderate",
			"backgroundLighting": true
		},
		"game": {
			"intensity": "intense",
			"backgroundLighting": true
		},
		"music": {
			"intensity": "intense",
			"palette": "melancholicEnergetic"
		},
		"ambient": {
			"ambientShowType": 0,
			"ambientModeType": 0
		}*/

	}
}
