using InnerCore.Api.HueSync.Models;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;
using System;

namespace InnerCore.Api.HueSync.Extensions
{
	public static class ExecutionExtensions
	{
		public static ExecutionCommand SetMode(this ExecutionCommand action, Mode mode)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Mode = mode;
			return action;
		}

		public static ExecutionCommand SetBrightness(this ExecutionCommand action, int brightness)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Brightness = brightness;
			return action;
		}

		public static ExecutionCommand SetHdmiSource(this ExecutionCommand action, HdmiSource source)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.HdmiSource = source;
			return action;
		}
		// todo: nested input actions
	}
}
