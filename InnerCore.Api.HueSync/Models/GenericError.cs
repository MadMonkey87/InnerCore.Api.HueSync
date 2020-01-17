using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class GenericError
	{
		[DataMember(Name = "code")]
		public int Code { get; set; }

		[DataMember(Name = "message")]
		public string Message { get; set; }
	}
}
