using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class RegistrationResponse: GenericError
    {
		[DataMember(Name = "registrationId")]
		public string RegistrationId { get; set; }

		[DataMember(Name = "accessToken")]
		public string AccessToken { get; set; }
	}
}
