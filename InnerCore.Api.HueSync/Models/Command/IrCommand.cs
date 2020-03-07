using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class IrCommand
	{
		[DataMember(Name = "scan")]
		public ScanCommand Scan { get; set; }

		// todo: codes
	}
}
