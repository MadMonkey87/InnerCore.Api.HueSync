using InnerCore.Api.HueSync.Models;
using System;

namespace InnerCore.Api.HueSync.Extensions
{
	public static class BehaviorExtensions
	{
		public static BehaviorCommand SetInactivePowerSave(this BehaviorCommand behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.InactivePowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static BehaviorCommand SetCecPowerSave(this BehaviorCommand behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.CecPowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static BehaviorCommand SetUsbPowerSave(this BehaviorCommand behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.UsbPowerSave = enable ? 0 : 1;
			return behavior;
		}

		public static BehaviorCommand SetHpdInputSwitch(this BehaviorCommand behavior, bool enable)
		{
			if (behavior == null)
			{
				throw new ArgumentNullException(nameof(behavior));
			}

			behavior.HpdInputSwitch = enable ? 0 : 1;
			return behavior;
		}

		public static BehaviorCommand SetArcBypass(this BehaviorCommand behavior, bool enable)
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
