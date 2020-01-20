using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class BehaviorCommand
	{
		/// <summary>
		/// Timespan in minutes
		/// </summary>
		[DataMember(Name = "inactivePowersave")]
		public int? InactivePowerSave { get; set; }

		[DataMember(Name = "cecPowersave")]
		public int? CecPowerSave { get; set; }

		[DataMember(Name = "usbPowersave")]
		public int? UsbPowerSave { get; set; }

		[DataMember(Name = "hpdInputSwitch")]
		public int? HpdInputSwitch { get; set; }

		[DataMember(Name = "arcBypassMode")]
		public int? ArcBypassMode { get; set; }

		[DataMember(Name = "input1")]
		public InputBehaviorCommand Input1 { get; set; }

		[DataMember(Name = "input2")]
		public InputBehaviorCommand Input2 { get; set; }

		[DataMember(Name = "input3")]
		public InputBehaviorCommand Input3 { get; set; }

		[DataMember(Name = "input4")]
		public InputBehaviorCommand Input4 { get; set; }
	}
}
