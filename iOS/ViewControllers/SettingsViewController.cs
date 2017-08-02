using System;
using UIKit;
using SCS.iOS.Helpers;
using static SCS.Constants;
using SCS.iOS.CustomComponents;
using Foundation;
using CoreGraphics;

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

			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardDownNotification);

            InitTheme();
            InitSettings();
		}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            btnToggleTheme.Selected = AppSettings.CurrentTheme == TYPE_THEME.DARK;
            View.LayoutIfNeeded();
            thumbLeadingSpace.Constant = btnToggleTheme.Selected ? 2 : viewThemeToggleContent.Frame.Width - imgThemeToggleThumb.Frame.Size.Width;
        }

		public override void InitTheme()
		{
            lblEventsMax.TextColor = GetTextColorByTheme();
            lblEventsDuration.TextColor = GetTextColorByTheme();
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
			sliderDiskStatus.TrackImage = GetImageByTheme(FN_BG_SLIDER_TRACK1);

            imgEventsMaxSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
            imgEventsDurationSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
            imgDiskStatusSliderTrackBG.Image = GetImageByTheme(FN_BG_SLIDER1);
		}

        private void SetSliderTheme(RangeSliderControl slider)
        {
            slider.TrackImage = GetImageByTheme(FN_BG_SLIDER_TRACK1);
            slider.TrackCrossedOverImage = GetImageByTheme(FN_ICON_SLIDER_THUMB);
            slider.UpperHandleImageNormal = GetImageByTheme(FN_ICON_SLIDER_THUMB);
            slider.UpperHandleImageHighlighted = GetImageByTheme(FN_ICON_SLIDER_THUMB);
            slider.UpperValueChanged += SliderValueChanged;

            slider.LayoutSubviews();
        }

        private void SliderValueChanged(object sender, EventArgs e)
        {
            var slider = sender as RangeSliderControl;
            var val = ((int)(slider.UpperValue * 100)).ToString();
            if ((int)slider.Tag == 0)
                lblEventsMaxValue.Text = val;
            else
                lblEventsDurationValue.Text = val;
        }

        void InitSettings()
        {
            sliderEventsMax.UpperValue = 0.53f;
            sliderEventsDuration.UpperValue = 0.2f;
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
                vc.InitTheme();
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

		#region keyboard process
        float scroll_amount = 0.0f;
        bool moveViewUp = false;

		void KeyBoardUpNotification(NSNotification notification)
		{
			//if (!txtEmail.IsEditing && !txtPassword.IsEditing)
				//return;

			CGRect r = UIKeyboard.BoundsFromNotification(notification);

			scroll_amount = (float)r.Height / 2;

			if (scroll_amount > 0)
			{
				moveViewUp = true;
				ScrollTheView(moveViewUp);
			}
			else
			{
				moveViewUp = false;
			}
		}
		void KeyBoardDownNotification(NSNotification notification)
		{
			if (moveViewUp) { ScrollTheView(false); }
		}
		void ScrollTheView(bool move)
		{
			UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration(0.3);

			CGRect frame = contentView.Frame;

			if (move)
			{
				frame.Y = -(scroll_amount);
			}
			else
			{
				frame.Y = 0;
			}

			contentView.Frame = frame;
			UIView.CommitAnimations();
		}
		#endregion
	}
}