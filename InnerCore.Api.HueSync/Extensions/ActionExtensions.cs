using InnerCore.Api.HueSync.Models;
using System;

namespace InnerCore.Api.HueSync.Extensions
{
	public static class ActionExtensions
	{
		public static ActionCommand SetMode(this ActionCommand action, Mode mode)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Mode = mode;
			return action;
		}

		public static ActionCommand SetIntensity(this ActionCommand action, Intensity intensity)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Intensity = intensity;
			return action;
		}

		public static ActionCommand SetBrightness(this ActionCommand action, int brightness)
		{
			if (action == null)
			{
				throw new ArgumentNullException(nameof(action));
			}

			action.Brightness = brightness;
			return action;
		}

		public static ActionCommand SetHdmiSource(this ActionCommand action, HdmiSource source)
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
