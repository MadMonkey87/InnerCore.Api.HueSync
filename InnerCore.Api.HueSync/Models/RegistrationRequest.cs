using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class RegistrationRequest
	{
		[DataMember(Name = "appName")]
		public string ApplicationName { get; set; }

		[DataMember(Name = "instanceName")]
		public string ClientName { get; set; }
	}
}
