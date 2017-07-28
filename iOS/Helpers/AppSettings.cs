using System;
using Foundation;
using static SCS.Constants;

namespace SCS.iOS.Helpers
{
	public static class AppSettings
	{
        private const string themeKey = "themeKey";
        public static TYPE_THEME CurrentTheme
        {
            get
            {
                var currentTheme = NSUserDefaults.StandardUserDefaults.IntForKey(themeKey);
                return (TYPE_THEME)Enum.ToObject(typeof(TYPE_THEME), currentTheme);
            }
            set
            {
                NSUserDefaults.StandardUserDefaults.SetInt((int)value, themeKey);
            }
        }
	}
}
