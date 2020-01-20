using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class HdmiCommand
	{
		[DataMember(Name = "input1")]
		public InputCommand Input1 { get; set; }

		[DataMember(Name = "input2")]
		public InputCommand Input2 { get; set; }

		[DataMember(Name = "input3")]
		public InputCommand Input3 { get; set; }

		[DataMember(Name = "input4")]
		public  InputCommand Input4 { get; set; }
	}
}
