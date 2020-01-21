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

        public static ExecutionCommand SetIntensity(this ExecutionCommand action, Intensity intensity)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            switch (action.Mode)
            {
                case Mode.Game:
                    if (action.GameOptions == null)
                    {
                        action.GameOptions = new ModeOptionsVideoCommand();
                    }
                    action.GameOptions.Intensity = intensity;
                    break;
                case Mode.Music:
                    if (action.MusicOptions == null)
                    {
                        action.MusicOptions = new ModeOptionsMusicCommand();
                    }
                    action.MusicOptions.Intensity = intensity;
                    break;
                case  Mode.Video:
                    if (action.VideoOptions == null)
                    {
                        action.VideoOptions = new ModeOptionsVideoCommand();
                    }
                    action.VideoOptions.Intensity = intensity;
                    break;
                default: throw new InvalidOperationException("Please set a mode first. Only the 'game', 'video' and the 'music' mode support setting the intensity!");
            }
            return action;
        }

        public static ExecutionCommand SetBackgroundLighting(this ExecutionCommand action, bool backgroundLighting)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            switch (action.Mode)
            {
                case Mode.Game:
                    if (action.GameOptions == null)
                    {
                        action.GameOptions = new ModeOptionsVideoCommand();
                    }
                    action.GameOptions.BackgroundLighting = backgroundLighting;
                    break;
                case Mode.Video:
                    if (action.VideoOptions == null)
                    {
                        action.VideoOptions = new ModeOptionsVideoCommand();
                    }
                    action.VideoOptions.BackgroundLighting = backgroundLighting;
                    break;
                default: throw new InvalidOperationException("Please set a mode first. Only the 'game' and the 'video' mode support setting the backgroundLighting!");
            }
            return action;
        }

        public static ExecutionCommand SetColorPalette(this ExecutionCommand action, Palette palette)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            switch (action.Mode)
            {
                case null:
                case Mode.Music:
                    action.Mode = Mode.Music;
                    if (action.MusicOptions == null)
                    {
                        action.MusicOptions = new ModeOptionsMusicCommand();
                    }
                    action.MusicOptions.Palette = palette;
                    break;
                default: throw new InvalidOperationException("Only the 'music' mode supports color palettes!");
            }
            return action;
        }

        public static ExecutionCommand SetShowType(this ExecutionCommand action, int showType)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            switch (action.Mode)
            {
                case null:
                case Mode.Ambient:
                    action.Mode = Mode.Ambient;
                    if (action.AmbientOptions == null)
                    {
                        action.AmbientOptions = new ModeOptionsAmbientCommand();
                    }

                    action.AmbientOptions.AmbientShowType = showType;
                    break;
                default: throw new InvalidOperationException("Only the 'ambient' mode supports an show type!");
            }
            return action;
        }

        public static ExecutionCommand SetModeType(this ExecutionCommand action, int modeType)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            switch (action.Mode)
            {
                case null:
                case Mode.Ambient:
                    action.Mode = Mode.Ambient;
                    if (action.AmbientOptions == null)
                    {
                        action.AmbientOptions = new ModeOptionsAmbientCommand();
                    }

                    action.AmbientOptions.AmbientModeType = modeType;
                    break;
                default: throw new InvalidOperationException("Only the 'ambient' mode supports an mode type!");
            }
            return action;
        }
    }
}
