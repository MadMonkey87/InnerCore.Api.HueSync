using InnerCore.Api.HueSync.Models;
using System;

namespace InnerCore.Api.HueSync.Extensions
{
	public static class BehaviourExtensions
	{
		public static Behaviour SetInactivePowerSave(this Behaviour behaviour, bool enable)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}

			behaviour.InactivePowerSave = enable ? 0 : 1;
			return behaviour;
		}

		public static Behaviour SetCecPowerSave(this Behaviour behaviour, bool enable)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}

			behaviour.CecPowerSave = enable ? 0 : 1;
			return behaviour;
		}

		public static Behaviour SetUsbPowerSave(this Behaviour behaviour, bool enable)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}

			behaviour.UsbPowerSave = enable ? 0 : 1;
			return behaviour;
		}

		public static Behaviour SetHpdInputSwitch(this Behaviour behaviour, bool enable)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}

			behaviour.HpdInputSwitch = enable ? 0 : 1;
			return behaviour;
		}

		public static Behaviour SetArcBypass(this Behaviour behaviour, bool enable)
		{
			if (behaviour == null)
			{
				throw new ArgumentNullException(nameof(behaviour));
			}

			behaviour.ArcBypassMode = enable ? 0 : 1;
			return behaviour;
		}

		// todo: nested input behaviours
	}
}
