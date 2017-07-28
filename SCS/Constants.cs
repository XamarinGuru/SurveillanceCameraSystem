using System;
namespace SCS
{
    public static class Constants
    {
        public const string COLOR_TAB_TEXT_ACTIVE = "48A9FF";
        public const string COLOR_TAB_TEXT_INACTIVE = "A5A5A5";

        public enum TYPE_THEME
        {
            DARK,
            LIGHT
        }
		public enum TYPE_ACTION
		{
			MOTION,
			CAMERA,
			TRIPWIRE,
			NOTIFICATION,
			SOUNDER
		}
    }
}
