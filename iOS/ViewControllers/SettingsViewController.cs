using System;
using UIKit;
using SCS.iOS.Helpers;
using static SCS.Constants;
using SCS.iOS.CustomComponents;

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

            InitTheme();
            InitSettings();
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();

			btnToggleTheme.Selected = AppSettings.CurrentTheme == TYPE_THEME.DARK;
			AnimationToggleTheme(btnToggleTheme.Selected);
		}

		public override void InitTheme()
		{
            lblEventsMax.TextColor = GetTextColorByTheme();
            lblEventsDuration.TextColor = GetTextColorByTheme();
            lblDiskUsage.TextColor = GetTextColorByTheme();
            lblDiskStatus.TextColor = GetTextColorByTheme();
            lblTheme.TextColor = GetTextColorByTheme();
            lblServerConnection.TextColor = GetTextColorByTheme();

            bgEditEventsMax.Image = GetImageByTheme(FN_BG_TEXT_SLIDER);
            bgEditEventsDuration.Image = GetImageByTheme(FN_BG_TEXT_SLIDER);
            bgEditDiskUsage.Image = GetImageByTheme(FN_BG_TEXT_SLIDER);
            bgEditServerIP.Image = GetImageByTheme(FN_BG_TEXT_SETTINGS);
			bgEditPort.Image = GetImageByTheme(FN_BG_TEXT_SETTINGS);
			bgEditPassword.Image = GetImageByTheme(FN_BG_TEXT_SETTINGS);

            imgThemeToggleBackground.Image = GetImageByTheme(FN_BG_TOGGLE);
            imgThemeToggleThumb.Image = GetImageByTheme(FN_BG_TOGGLE_THUMB);

            lblThemeDark.TextColor = GetToggleTextColorByTheme(true);
            lblThemeLight.TextColor = GetToggleTextColorByTheme(false);

            lblEventsMaxValue.TextColor = GetToggleTextColorByTheme(true);
            lblEventsDurationValue.TextColor = GetToggleTextColorByTheme(true);
            lblDiskUsageValue.TextColor = GetToggleTextColorByTheme(true);
            txtServerIP.TextColor = GetToggleTextColorByTheme(true);
            txtPort.TextColor = GetToggleTextColorByTheme(true);
            txtPassword.TextColor = GetToggleTextColorByTheme(true);

            lblServerIP.TextColor = GetTextColorByTheme(false);
            lblPort.TextColor = GetTextColorByTheme(false);
            lblPassword.TextColor = GetTextColorByTheme(false);

            btnScanQR.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SCAN_QR_SETTINGS), UIControlState.Normal);

            viewLineSeperator1.BackgroundColor = GetLineSeperatorColorByTheme();
            viewLineSeperator2.BackgroundColor = GetLineSeperatorColorByTheme();
            viewLineSeperator3.BackgroundColor = GetLineSeperatorColorByTheme();
            viewLineSeperator4.BackgroundColor = GetLineSeperatorColorByTheme();

            SetSliderTheme(sliderEventsMax);
            SetSliderTheme(sliderEventsDuration);
            SetSliderTheme(sliderDiskUsage);

            imgEventsMaxSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
            imgEventsDurationSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
            imgDiskUsageSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
            imgDiskStatusSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER2);
		}

        private void SetSliderTheme(RangeSliderControl slider)
        {
            slider.TrackImage = GetImageByTheme(FN_BG_SLIDER_TRACK1);
            slider.TrackCrossedOverImage = GetImageByTheme(FN_ICON_SLIDER_THUMB);
            slider.UpperHandleImageNormal = GetImageByTheme(FN_ICON_SLIDER_THUMB);
            slider.UpperHandleImageHighlighted = GetImageByTheme(FN_ICON_SLIDER_THUMB);

            slider.LayoutSubviews();
        }

        void InitSettings()
        {
            sliderEventsMax.UpperValue = 0.53f;
            sliderEventsDuration.UpperValue = 0.2f;
            sliderDiskUsage.UpperValue = 0.5f;
            sliderDiskStatus.UpperValue = 0.3f;
        }

        partial void ActionToggleTheme(UIButton sender)
        {
			sender.Selected = !sender.Selected;

            AnimationToggleTheme(sender.Selected);

            AppSettings.CurrentTheme = sender.Selected ? TYPE_THEME.DARK : TYPE_THEME.LIGHT;

            InitTheme();
            rootVC.InitTheme();

            foreach (var vc in rootVC.subControllers)
                (vc.TopViewController as BaseViewController).InitTheme();
        }

        void AnimationToggleTheme(bool isDark)
        {
			UIView.BeginAnimations("ds");
			UIView.SetAnimationDuration(0.5f);

			var posX = isDark ? 2 : viewThemeToggleContent.Frame.Width - imgThemeToggleThumb.Frame.Size.Width;
			var rect = imgThemeToggleThumb.Frame;
			rect.X = posX;
			imgThemeToggleThumb.Frame = rect;

			UIView.CommitAnimations();
        }
    }
}