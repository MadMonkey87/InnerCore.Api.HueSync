using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Group
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "numLights")]
		public int LightCount { get; set; }

		[DataMember(Name = "active")]
		public bool Active { get; set; }
	}
}
