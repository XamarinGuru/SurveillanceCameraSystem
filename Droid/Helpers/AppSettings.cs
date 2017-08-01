using System;
using Android.App;
using Android.Content;
using static SCS.Constants;

namespace SCS.Helpers
{
	public static class AppSettings
	{
		static ISharedPreferences _appSettings = Application.Context.GetSharedPreferences("App_settings", FileCreationMode.Private);

		private const string themeKey = "themeKey";
		public static TYPE_THEME CurrentTheme
        {
            get
            {
                try
                {
                    var currentTheme = _appSettings.GetString(themeKey, "");
                    return (TYPE_THEME)Enum.ToObject(typeof(TYPE_THEME), currentTheme);
                }catch{
                    return TYPE_THEME.DARK;
                }
            }
            set
            {
                ISharedPreferencesEditor editor = _appSettings.Edit();
                editor.PutInt(themeKey, (int)value);
                editor.Apply();
            }
        }
	}
}
