using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Hue : HueCommand
	{
		[DataMember(Name = "bridgeIpAddress")]
		public string BridgeIpAddress { get; set; }

		[DataMember(Name = "connectionState")]
		public ConnectionState ConnectionState { get; set; }

		[DataMember(Name = "groups")]
		internal Dictionary<string, Group> RawGroups { get; set; }

		public ICollection<Group> Groups
		{
			get
			{
				if (RawGroups == null)
				{
					return new List<Group>();
				}

				foreach (var rawGroup in RawGroups)
				{
					rawGroup.Value.Id = rawGroup.Key;
				}
				return RawGroups.Select(e => e.Value).ToList();
			}
		}
	}
}
