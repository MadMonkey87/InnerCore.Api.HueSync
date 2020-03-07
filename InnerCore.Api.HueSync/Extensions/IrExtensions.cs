using System;
using InnerCore.Api.HueSync.Models;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;

namespace InnerCore.Api.HueSync.Extensions
{
    public static class IrExtensions
    {
        public static IrCommand StartScanning(this IrCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.Scan = EnsureExists(command.Scan);
            command.Scan.Scanning = true;

            return command;
        }
        private static ScanCommand EnsureExists(ScanCommand scan)
        {
            return scan ?? new ScanCommand();
        }
    }
}
