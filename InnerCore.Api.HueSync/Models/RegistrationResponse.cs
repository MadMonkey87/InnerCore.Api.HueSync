using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class RegistrationResponse
	{
		// todo: this is entirely unclear

		[DataMember(Name = "success")]
		public bool Success { get; set; }

		[DataMember(Name = "token")]
		public string AccessToken { get; set; }


		//"code": 16
		//"message": "invalid state"
	}
}
