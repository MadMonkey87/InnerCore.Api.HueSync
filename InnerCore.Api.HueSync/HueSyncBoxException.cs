using InnerCore.Api.HueSync.Models;
using System;

namespace InnerCore.Api.HueSync
{
	public class HueSyncBoxException : Exception
	{
		public HueSyncBoxException(GenericError error) : base($"the hue sync box responded with {error.Code}, '{error.Message}'") { }
	}
}
