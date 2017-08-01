using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SCS.Helpers;
using static SCS.Constants;

namespace SCS.Activities
{
	[Activity(Label = "BaseActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class BaseActivity : FragmentActivity
	{
        public virtual void InitTheme() { }
		AlertDialog.Builder alert;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			Window.RequestFeature(WindowFeatures.NoTitle);
			base.OnCreate(savedInstanceState);

			//SetGroupColor();
		}

		

		public override bool OnTouchEvent(MotionEvent e)
		{
			if (this.CurrentFocus == null) return true;

			InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
			imm.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, 0);
			return base.OnTouchEvent(e);
		}

		public void ShowMessageBox(string title, string message)
		{
			alert = new AlertDialog.Builder(this);
			alert.SetTitle(title);
			alert.SetMessage(message);
			alert.SetCancelable(false);
            alert.SetPositiveButton("OK", delegate { });
			RunOnUiThread(() =>
			{
				alert.Show();
			});
		}

		#region image
		public string GetFileNameByTheme(string name)
		{
			return AppSettings.CurrentTheme == TYPE_THEME.DARK ? name + "_dark" : name + "_light";
		}

		public int GetImageByTheme(string imgName)
		{
			var fileNameByTheme = GetFileNameByTheme(imgName);
            var resID = Resources.GetIdentifier(fileNameByTheme, "drawable", Application.Context.PackageName);
			return resID;
		}
		#endregion

		#region color
		public Color GetColor(string color)
		{
			return Color.ParseColor("#" + color);
		}

		public Color GetTextColorByTheme(bool isDarkText = true)
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

		public Color GetRecentTextColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_INACTIVE_DARK : COLOR_DARK_TEXT_LIGHT;
			return GetColor(colorByTheme);
		}

		public Color GetBackgroundColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BACKGROUND_DARK : COLOR_BACKGROUND_LIGHT;
			return GetColor(colorByTheme);
		}

		public Color GetSubtabColorByTheme(bool isInactive = false)
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

		public Color GetBottomBarBackgroundColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BOTTOM_BAR_BACKGROUND_DARK : COLOR_BOTTOM_BAR_BACKGROUND_LIGHT;
			return GetColor(colorByTheme);
		}

		public Color GetBottomBarBorderColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_BOTTOM_BAR_BORDER_DARK : COLOR_BOTTOM_BAR_BORDER_LIGHT;
			return GetColor(colorByTheme);
		}

		public Color GetDescriptionColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_SUBTAB_INACTIVE_DARK : COLOR_LIGHT_TEXT_LIGHT;
			return GetColor(colorByTheme);
		}

		public Color GetToggleTextColorByTheme(bool isDarkText)
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

		public Color GetLineSeperatorColorByTheme()
		{
			var colorByTheme = AppSettings.CurrentTheme == TYPE_THEME.DARK
										  ? COLOR_LINE_SEPERATOR_DARK : COLOR_LINE_SEPERATOR_LIGHT;
			return GetColor(colorByTheme);
		}
		#endregion

		#region tab
        public void SetActiveTab(ImageView img, RelativeLayout view)
		{
			if (AppSettings.CurrentTheme == TYPE_THEME.DARK)
                img.Visibility = ViewStates.Visible;
			else
                view.SetBackgroundColor(GetColor(Constants.COLOR_BG_TAP_ACTIVE_LIGHT));
		}
		#endregion
	}
}
