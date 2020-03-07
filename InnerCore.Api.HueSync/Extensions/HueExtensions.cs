using System;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;

namespace InnerCore.Api.HueSync.Extensions
{
    public static class HueExtensions
    {
        public static HueCommand SetBridge(this HueCommand command, string bridgeUniqueId, string username, string clientKey)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.BridgeUniqueId = bridgeUniqueId;
            command.ClientKey = clientKey;
            command.Username = username;
            
            return command;
        }
    }
}
