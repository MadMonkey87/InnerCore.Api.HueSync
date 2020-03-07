using InnerCore.Api.HueSync.Models.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace InnerCore.Api.HueSync.Models
{
	[DataContract]
	public class Ir : IrCommand
	{
		[DataMember(Name = "scan")]
		public Scan Scan { get; set; }

		[DataMember(Name = "groups")]
		internal Dictionary<string, IrCode> RawCodes { get; set; }

		public ICollection<IrCode> Codes
		{
			get
			{
				if(RawCodes == null)
				{
					return new List<IrCode>();
				}

				foreach (var rawCode in RawCodes)
				{
					rawCode.Value.Code = rawCode.Key;
				}
				return RawCodes.Select(e => e.Value).ToList();
			}
		}
	}
}
