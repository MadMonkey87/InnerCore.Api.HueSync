using System;
using InnerCore.Api.HueSync.Models;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;

namespace InnerCore.Api.HueSync.Extensions
{
    public static class DeviceExtensions
    {
        public static DeviceCommand SetName(this DeviceCommand device, string name)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            device.Name = name;
            return device;
        }

        public static DeviceCommand SetAction(this DeviceCommand device, DeviceAction action)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            device.Action = action;
            return device;
        }

        public static DeviceCommand SetLedMode(this DeviceCommand device, bool enable)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            device.LedMode = enable ? 1 : 0;
            return device;
        }

        public static DeviceCommand SetAutoUpdate(this DeviceCommand device, bool enable)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            if (device.Update == null)
            {
                device.Update = new Update();
            }
            device.Update.AutoUpdateEnabled = enable;
            return device;
        }
    }
}
