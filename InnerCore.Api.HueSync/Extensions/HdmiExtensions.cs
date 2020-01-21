using System;
using InnerCore.Api.HueSync.Models.Command;
using InnerCore.Api.HueSync.Models.Enum;

namespace InnerCore.Api.HueSync.Extensions
{
    public static class HdmiExtensions
    {
        public static HdmiCommand SetName(this HdmiCommand command, HdmiSource hdmiSource, string name)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            switch (hdmiSource)
            {
                case HdmiSource.Input1:
                    command.Input1 = EnsureExists(command.Input1);
                    command.Input1.Name = name;
                    break;
                case HdmiSource.Input2:
                    command.Input2 = EnsureExists(command.Input2);
                    command.Input2.Name = name;
                    break;
                case HdmiSource.Input3:
                    command.Input3 = EnsureExists(command.Input3);
                    command.Input3.Name = name;
                    break;
                case HdmiSource.Input4:
                    command.Input4 = EnsureExists(command.Input4);
                    command.Input4.Name = name;
                    break;
            }
            
            return command;
        }

        public static HdmiCommand SetType(this HdmiCommand command, HdmiSource hdmiSource, InputType inputType)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            switch (hdmiSource)
            {
                case HdmiSource.Input1:
                    command.Input1 = EnsureExists(command.Input1);
                    command.Input1.Type = inputType;
                    break;
                case HdmiSource.Input2:
                    command.Input2 = EnsureExists(command.Input2);
                    command.Input2.Type = inputType;
                    break;
                case HdmiSource.Input3:
                    command.Input3 = EnsureExists(command.Input3);
                    command.Input3.Type = inputType;
                    break;
                case HdmiSource.Input4:
                    command.Input4 = EnsureExists(command.Input4);
                    command.Input4.Type = inputType;
                    break;
            }

            return command;
        }

        private static InputCommand EnsureExists(InputCommand input)
        {
            return input ?? new InputCommand();
        }
    }
}
