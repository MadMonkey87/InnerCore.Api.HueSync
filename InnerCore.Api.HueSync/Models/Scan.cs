using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Scan
	{
		[DataMember(Name = "scanning")]
		public bool? Scanning { get; set; }

		[DataMember(Name = "code")]
		public string Code { get; set; }
	}
}
