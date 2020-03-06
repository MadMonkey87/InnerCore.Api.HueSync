using InnerCore.Api.HueSync.Models.Command;
using System;
using InnerCore.Api.HueSync.Models.Enum;

namespace InnerCore.Api.HueSync.Extensions
{
    public static class BehaviorExtensions
    {
        public static BehaviorCommand SetInactivePowerSave(this BehaviorCommand behavior, TimeSpan threshold)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.InactivePowerSave = Convert.ToInt32(threshold.TotalMinutes);
            return behavior;
        }

        public static BehaviorCommand SetCecPowerSave(this BehaviorCommand behavior, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.CecPowerSave = enable ? 1 : 0;
            return behavior;
        }

        public static BehaviorCommand SetUsbPowerSave(this BehaviorCommand behavior, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.UsbPowerSave = enable ? 1 : 0;
            return behavior;
        }

        public static BehaviorCommand SetHpdInputSwitch(this BehaviorCommand behavior, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.HpdInputSwitch = enable ? 1 : 0;
            return behavior;
        }

        public static BehaviorCommand SetDoviNative(this BehaviorCommand behavior, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.ForceDoviNative = enable ? 1 : 0;
            return behavior;
        }

        public static BehaviorCommand SetArcBypass(this BehaviorCommand behavior, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            behavior.ArcBypassMode = enable ? 1 : 0;
            return behavior;
        }

        public static BehaviorCommand SetCecInputSwitch(this BehaviorCommand behavior, HdmiSource? hdmiSource, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            if (hdmiSource == null || hdmiSource == HdmiSource.Input1)
            {
                behavior.Input1 = EnsureExists(behavior.Input1);
                behavior.Input1.CecInputSwitch = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input2)
            {
                behavior.Input2 = EnsureExists(behavior.Input2);
                behavior.Input2.CecInputSwitch = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input3)
            {
                behavior.Input3 = EnsureExists(behavior.Input2);
                behavior.Input3.CecInputSwitch = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input4)
            {
                behavior.Input4 = EnsureExists(behavior.Input4);
                behavior.Input4.CecInputSwitch = enable ? 1 : 0;
            }

            return behavior;
        }

        public static BehaviorCommand SetLinkAutoSync(this BehaviorCommand behavior, HdmiSource? hdmiSource, bool enable)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior));
            }

            if (hdmiSource == null || hdmiSource == HdmiSource.Input1)
            {
                behavior.Input1 = EnsureExists(behavior.Input1);
                behavior.Input1.LinkAutoSync = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input2)
            {
                behavior.Input2 = EnsureExists(behavior.Input2);
                behavior.Input2.LinkAutoSync = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input3)
            {
                behavior.Input3 = EnsureExists(behavior.Input2);
                behavior.Input3.LinkAutoSync = enable ? 1 : 0;
            }
            if (hdmiSource == null || hdmiSource == HdmiSource.Input4)
            {
                behavior.Input4 = EnsureExists(behavior.Input4);
                behavior.Input4.LinkAutoSync = enable ? 1 : 0;
            }

            return behavior;
        }

        private static InputBehaviorCommand EnsureExists(InputBehaviorCommand inputBehavior)
        {
            return inputBehavior ?? new InputBehaviorCommand();
        }
    }
}
