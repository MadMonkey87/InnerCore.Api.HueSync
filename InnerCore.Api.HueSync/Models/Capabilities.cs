using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Capabilities
	{
		[DataMember(Name = "maxIrCodes")]
		public int MaxIrCodes { get; set; }

		[DataMember(Name = "maxPresets")]
		public int MaxPresets { get; set; }
	}
}
