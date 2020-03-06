using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models.Command
{
	[Obsolete("will be removed in the future")]
	[DataContract]
	public class ModeOptionsAmbientCommand
	{
		[DataMember(Name = "ambientShowType")]
		public int? AmbientShowType { get; set; }

		[DataMember(Name = "ambientModeType")]
		public int? AmbientModeType { get; set; }
	}
}
