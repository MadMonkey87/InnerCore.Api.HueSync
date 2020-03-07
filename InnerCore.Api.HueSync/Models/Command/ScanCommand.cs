using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models.Command
{
	[DataContract]
	public class ScanCommand
	{
		[DataMember(Name = "scanning")]
		public bool? Scanning { get; set; }
	}
}
