using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Hdmi
	{
		[DataMember(Name = "input1")]
		public Input Input1 { get; set; }

		[DataMember(Name = "input2")]
		public Input Input2 { get; set; }

		[DataMember(Name = "input3")]
		public Input Input3 { get; set; }

		[DataMember(Name = "input4")]
		public Input Input4 { get; set; }

		[DataMember(Name = "output")]
		public Input Output { get; set; }

		[DataMember(Name = "contentSpecs")]
		public string ContentSpecs { get; set; }

		[DataMember(Name = "videoSyncSupported")]
		public bool VideoSyncSupported { get; set; }

		[DataMember(Name = "audioSyncSupported")]
		public bool AudioSyncSupported { get; set; }
	}
}
