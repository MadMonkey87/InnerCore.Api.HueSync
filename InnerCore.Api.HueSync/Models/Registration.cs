using System;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Registration
	{
		[DataMember(Name = "registrationId")]
		public string RegistrationId { get; set; }

		[DataMember(Name = "appName")]
		public string AppName { get; set; }

		[DataMember(Name = "instanceName")]
		public string InstanceName { get; set; }

		[DataMember(Name = "created")]
		public DateTimeOffset? Created { get; set; }

		[DataMember(Name = "lastUsed")]
		public DateTimeOffset? LastUsed { get; set; }

		[DataMember(Name = "role")]
		public string Role { get; set; }
	}
}
