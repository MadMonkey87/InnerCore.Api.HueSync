using InnerCore.Api.HueSync.Models;
using System;

namespace InnerCore.Api.HueSync.Extensions
{
	public static class BehaviorExtensions
	{
		public static Behavior SetInactivePowerSave(this Behavior behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.InactivePowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static Behavior SetCecPowerSave(this Behavior behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.CecPowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static Behavior SetUsbPowerSave(this Behavior behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.UsbPowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static Behavior SetHpdInputSwitch(this Behavior behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.HpdInputSwitch = enable ? 0 : 1;
			return behavior;
		}

		public static Behavior SetArcBypass(this Behavior behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.ArcBypassMode = enable ? 0 : 1;
			return behavior;
		}

		// todo: nested input behaviors
	}
}
