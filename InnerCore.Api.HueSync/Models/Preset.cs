using InnerCore.Api.HueSync.Models.Command;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Preset
	{
		[DataMember(Name = "presetId")]
		public string PresetId { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "lastUsed")]
		public DateTimeOffset? LastUsed { get; set; }

		[DataMember(Name = "execution")]
		public ExecutionCommand ExecutionCommand { get; set; }
	}
}
