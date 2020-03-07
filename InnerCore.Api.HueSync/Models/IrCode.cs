using InnerCore.Api.HueSync.Models.Command;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class IrCode
	{
		[DataMember(Name = "code")]
		public string Code { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "execution")]
		public ExecutionCommand ExecutionCommand { get; set; }
	}
}
