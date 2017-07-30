using System;
using SCS.iOS.Helpers;
using UIKit;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class BaseViewController : UIViewController
    {
        public virtual void InitTheme(){}
        public TabBarController rootVC;

		public BaseViewController() : base()
		{
		}
		public BaseViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			View.AddGestureRecognizer(g);
		}

		public void ShowMessageBox(string title, string message)
		{
			InvokeOnMainThread(() =>
			{
				var alertView = new UIAlertView(title, message, null, "Ok", null);
                alertView.Clicked += (sender, e) => { };
				alertView.Show();
			});
		}

        #region image
        public string GetFileNameByTheme(string name)
        {
            return AppSettings.CurrentTheme == TYPE_THEME.DARK ? name + "_dark.png" : name + "_light.png";
        }

        public UIImage GetImageByTheme(string imgName)
        {
            var fileNameByTheme = GetFileNameByTheme(imgName);
            return UIImage.FromFile(fileNameByTheme);
        }
		#endregion

		#region color
		public UIColor GetColor(string color)
		{
			var red = Convert.ToInt32(color.Substring(0, 2), 16) / 255f;
			var green = Convert.ToInt32(color.Substring(2, 2), 16) / 255f;
			var blue = Convert.ToInt32(color.Substring(4, 2), 16) / 255f;
			return UIColor.FromRGB(red, green, blue);
		}

        public UIColor GetTextColorByTheme(bool isDarkText = true)
        {
			string colorByTheme;
			if (isDarkText)
			{
				colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_DARK_TEXT_DARK : COLOR_DARK_TEXT_LIGHT;
			}
			else
			{
				colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_LIGHT_TEXT_DARK : COLOR_LIGHT_TEXT_LIGHT;
			}
			return GetColor(colorByTheme);
        }

        public UIColor GetRecentTextColorByTheme()
        {
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_INACTIVE_DARK : COLOR_DARK_TEXT_LIGHT;
			return GetColor(colorByTheme);
        }

        public UIColor GetBackgroundColorByTheme()
        {
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BACKGROUND_DARK : COLOR_BACKGROUND_LIGHT;
            return GetColor(colorByTheme);
        }

        public UIColor GetSubtabColorByTheme(bool isInactive = false)
        {
            string colorByTheme;
            if (isInactive)
				colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_INACTIVE_DARK : COLOR_SUBTAB_INACTIVE_LIGHT;
            else
				colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_ACTIVE_DARK : COLOR_SUBTAB_ACTIVE_LIGHT;
            return GetColor(colorByTheme);
        }

		public UIColor GetBottomBarBackgroundColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BOTTOM_BAR_BACKGROUND_DARK : COLOR_BOTTOM_BAR_BACKGROUND_LIGHT;
			return GetColor(colorByTheme);
		}

        public UIColor GetBottomBarBorderColorByTheme()
        {
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BOTTOM_BAR_BORDER_DARK : COLOR_BOTTOM_BAR_BORDER_LIGHT;
            return GetColor(colorByTheme);
        }

		public UIColor GetDescriptionColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_INACTIVE_DARK : COLOR_LIGHT_TEXT_LIGHT;
			return GetColor(colorByTheme);
		}

        public UIColor GetToggleTextColorByTheme(bool isDarkText)
        {
            string colorByTheme;
            if (isDarkText)
                colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_TOGGLE_DARK_TEXT_DARK : COLOR_TOGGLE_DARK_TEXT_LIGHT;
            else
				colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_TOGGLE_DARK_TEXT_DARK : COLOR_TOGGLE_LIGHT_TEXT_LIGHT;
			return GetColor(colorByTheme);
        }

        public UIColor GetLineSeperatorColorByTheme()
        {
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_LINE_SEPERATOR_DARK : COLOR_LINE_SEPERATOR_LIGHT;
			return GetColor(colorByTheme);
        }
        #endregion

        #region tab
        public void SetActiveTab(UIImageView img, UIView view)
        {
            if (AppSettings.CurrentTheme == TYPE_THEME.DARK)
                img.Hidden = false;
            else
                view.BackgroundColor = GetColor(COLOR_BG_TAP_ACTIVE_LIGHT);
        }
        #endregion


    }
}

