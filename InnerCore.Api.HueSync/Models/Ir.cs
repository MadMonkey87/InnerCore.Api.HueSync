using InnerCore.Api.HueSync.Models.Command;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Ir : IrCommand
	{
		[DataMember(Name = "scan")]
		public Scan Scan { get; set; }
	}
}
