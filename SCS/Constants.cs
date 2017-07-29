using System;
namespace SCS
{
    public static class Constants
    {
        #region image
        //login
        public const string FN_BACKGROUND = "bg";
        public const string FN_LOGO = "icon_logo";
        public const string FN_BG_EDIT_SERVER_IP = "bg_edit_server_ip";
        public const string FN_BG_EDIT_PORT = "bg_edit_port";
        public const string FN_BG_EDIT_PSW = "bg_edit_psw";
        public const string FN_BG_BTN_LOGIN = "bg_btn_login";
        public const string FN_BG_BTN_SCAN_QR = "bg_btn_scan_qr";
        public const string FN_BG_BTN_SYMBOL_NUMBER = "bg_symbol_number";
        //tab
        public const string FN_BG_TOP_BAR = "bg_top";
        public const string FN_BG_TAP_ACTIVE_LIGHT = "bg_tab_active_light.png";
        public const string FN_ICON_TAB_DASHBOARD_ACTIVE = "icon_tab_dashboard_active";
        public const string FN_ICON_TAB_CAMERA_ACTIVE = "icon_tab_camera_active";
        public const string FN_ICON_TAB_SETTINGS_ACTIVE = "icon_tab_settings_active";
        public const string FN_ICON_TAB_HELP_ACTIVE = "icon_tab_help_active";
        public const string FN_ICON_TAB_DASHBOARD_INACTIVE = "icon_tab_dashboard_inactive";
        public const string FN_ICON_TAB_CAMERA_INACTIVE = "icon_tab_camera_inactive";
        public const string FN_ICON_TAB_SETTINGS_INACTIVE = "icon_tab_settings_inactive";
        public const string FN_ICON_TAB_HELP_INACTIVE = "icon_tab_help_inactive";

        //dashboard
        public const string FN_ICON_CAMERA_FRONT = "icon_camera_front";
        public const string FN_ICON_CAMERA_BACK = "icon_camera_back";

		//camera
		public const string FN_ICON_SUBTAB_BOTTOM = "bg_tab_bottom";
        public const string FN_BG_ZOOM_CONTROL = "bg_zoom_control";
        public const string FN_BG_ZOOM_BAR = "bg_zoom_bar";
        public const string FN_ICON_SLIDER_THUMB = "icon_slider_thumb";
        public const string FN_ICON_ZOOM_IN = "icon_zoom_in";
        public const string FN_ICON_ZOOM_OUT = "icon_zoom_out";

        public const string FN_ICON_MOTION_DETECT_INACTIE = "icon_motiondetect_inactie";
        public const string FN_ICON_CAMERA_DISCONNECT_INACTIE = "icon_cameradisconnect_inactive";
        public const string FN_ICON_TRIPWIRE_INACTIE = "icon_tripwire_inactie";
        public const string FN_ICON_NOTIFICATION_INACTIE = "icon_notification_inactie";
        public const string FN_ICON_SOUNDER_INACTIE = "icon_sounder_inactie";

        //settings
        public const string FN_BG_TEXT_SLIDER = "bg_txt_slider";
        public const string FN_BG_TEXT_SETTINGS = "bg_txt_settings";
        public const string FN_BG_TOGGLE = "bg_toggle";
        public const string FN_BG_TOGGLE_THUMB = "bg_toggle_thumb";
        public const string FN_BG_BTN_SCAN_QR_SETTINGS = "bg_btn_scan_qr_settings";
        public const string FN_BG_SLIDER_TRACK1 = "bg_slider_track1";
        public const string FN_BG_SLIDER1 = "bg_slider1";
        public const string FN_BG_SLIDER2 = "bg_slider2";
        #endregion

        #region color
        public const string COLOR_BACKGROUND_DARK = "1d1e2a";
        public const string COLOR_BACKGROUND_LIGHT = "e9f0f5";

        public const string COLOR_DARK_TEXT_DARK = "a6b1cc";
		public const string COLOR_LIGHT_TEXT_DARK = "5f6280";

        public const string COLOR_DARK_TEXT_LIGHT = "363636";
        public const string COLOR_LIGHT_TEXT_LIGHT = "738396";

        public const string COLOR_BG_TAP_ACTIVE_LIGHT = "07c6df";

        public const string COLOR_SUBTAB_ACTIVE_DARK = "57baff";
        public const string COLOR_SUBTAB_ACTIVE_LIGHT = "07c6df";
        public const string COLOR_SUBTAB_INACTIVE_DARK = "b4b4b4";
        public const string COLOR_SUBTAB_INACTIVE_LIGHT = "738396";

        public const string COLOR_BOTTOM_BAR_BACKGROUND_DARK = "1A1A26";
        public const string COLOR_BOTTOM_BAR_BACKGROUND_LIGHT = "FFFFFF";
        public const string COLOR_BOTTOM_BAR_BORDER_DARK = "393b4f";
        public const string COLOR_BOTTOM_BAR_BORDER_LIGHT = "dfe1e6";

        public const string COLOR_TOGGLE_DARK_TEXT_DARK = "FFFFFF";
        public const string COLOR_TOGGLE_DARK_TEXT_LIGHT = "363636";
		public const string COLOR_TOGGLE_LIGHT_TEXT_DARK = "202136";
		public const string COLOR_TOGGLE_LIGHT_TEXT_LIGHT = "e3eaef";

        public const string COLOR_LINE_SEPERATOR_DARK = "474957";
        public const string COLOR_LINE_SEPERATOR_LIGHT = "9fafbd";
        #endregion

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
