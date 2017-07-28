using System;
using UIKit;
using SCS.iOS.Helpers;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class SettingsViewController : BaseViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            //InitSettings();
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			InitSettings();
		}

        void InitSettings()
        {
            sliderEventsMax.UpperValue = 0.53f;

            sliderDiskStatus.UpperValue = 0.3f;

            btnToggleTheme.Selected = AppSettings.CurrentTheme == TYPE_THEME.DARK;
            AnimationToggleTheme(btnToggleTheme.Selected);
        }

        partial void ActionToggleTheme(UIButton sender)
        {
			sender.Selected = !sender.Selected;

            AnimationToggleTheme(sender.Selected);

            AppSettings.CurrentTheme = sender.Selected ? TYPE_THEME.DARK : TYPE_THEME.LIGHT;
        }

        void AnimationToggleTheme(bool isDark)
        {
			//View.LayoutIfNeeded();

			UIView.BeginAnimations("ds");
			UIView.SetAnimationDuration(0.5f);

			var posX = isDark ? 2 : viewThemeToggleContent.Frame.Width - imgThemeToggleThumb.Frame.Size.Width;
			var rect = imgThemeToggleThumb.Frame;
			rect.X = posX;
			imgThemeToggleThumb.Frame = rect;

			//View.LayoutIfNeeded();
			UIView.CommitAnimations();
        }
    }
}