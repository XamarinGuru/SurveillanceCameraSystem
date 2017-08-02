using System;
using System.Timers;
using CoreGraphics;
using Foundation;
using UIKit;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class CameraViewController : BaseViewController
    {
        int nCurrentIndex = -1;

        public CameraViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            rootVC.DeviceOrientationChangedHandler = DeviceOrientationChangedHandler;

            StartTimer();

            InitTheme();
            SetCurrentPage(0);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            viewBackground.LayoutIfNeeded();
        }

		public override void InitTheme()
        {
            imgZoomControl.Image = GetImageByTheme(FN_BG_ZOOM_CONTROL);
            btnCamera.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_BACK), UIControlState.Normal);
            btnCamera.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_FRONT), UIControlState.Selected);
            imgZoomBar.Image = GetImageByTheme(FN_BG_ZOOM_BAR);
            btnSliderThumb.SetBackgroundImage(GetImageByTheme(FN_ICON_SLIDER_THUMB), UIControlState.Normal);
            btnZoomIn.SetBackgroundImage(GetImageByTheme(FN_ICON_ZOOM_IN), UIControlState.Normal);
            btnZoomOut.SetBackgroundImage(GetImageByTheme(FN_ICON_ZOOM_OUT), UIControlState.Normal);

            imgMotionInactive.Image = GetImageByTheme(FN_ICON_MOTION_DETECT_INACTIE);
            imgCameraInactive.Image = GetImageByTheme(FN_ICON_CAMERA_DISCONNECT_INACTIE);
            imgTripwireInactive.Image = GetImageByTheme(FN_ICON_TRIPWIRE_INACTIE);
            imgNotificationInactive.Image = GetImageByTheme(FN_ICON_NOTIFICATION_INACTIE);
            imgSounderInactive.Image = GetImageByTheme(FN_ICON_SOUNDER_INACTIE);

            viewBottomBar.BackgroundColor = GetBottomBarBorderColorByTheme();
            viewBottomBarMotion.BackgroundColor = GetBottomBarBackgroundColorByTheme();
            viewBottomBarCamera.BackgroundColor = GetBottomBarBackgroundColorByTheme();
            viewBottomBarNotification.BackgroundColor = GetBottomBarBackgroundColorByTheme();
            viewBottomBarTripwire.BackgroundColor = GetBottomBarBackgroundColorByTheme();
            viewBottomBarSounder.BackgroundColor = GetBottomBarBackgroundColorByTheme();

            TabBarAnimation();
        }

        partial void ActionTab(UIButton sender)
        {
            SetCurrentPage((int)sender.Tag);
        }

        public void SetCurrentPage(int pIndex)
        {
            if (nCurrentIndex == pIndex) return;

            nCurrentIndex = pIndex;

            TabBarAnimation();
        }

        void TabBarAnimation()
        {
            imgTabBottomKitchen.Image = GetImageByTheme(FN_ICON_SUBTAB_BOTTOM);
            imgTabBottomBackdoor.Image = GetImageByTheme(FN_ICON_SUBTAB_BOTTOM);

            lblTabIconKitchen.TextColor = GetSubtabColorByTheme(true);
            lblTabIconBackdoor.TextColor = GetSubtabColorByTheme(true);

            imgTabBottomKitchen.Hidden = true;
            imgTabBottomBackdoor.Hidden = true;

            switch (nCurrentIndex)
            {
                case 0:
                    lblTabIconKitchen.TextColor = GetSubtabColorByTheme();
                    imgTabBottomKitchen.Hidden = false;
                    break;
                case 1:
                    lblTabIconBackdoor.TextColor = GetSubtabColorByTheme();
                    imgTabBottomBackdoor.Hidden = false;
                    break;
            }
        }

		System.Timers.Timer _timer = new System.Timers.Timer();
        int nZoomType = -1;

		void StartTimer()
		{
			_timer.Interval = 200;
			_timer.Elapsed -= OnTimedEvent;
			_timer.Elapsed += OnTimedEvent;
			_timer.Enabled = true;
		}
		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
            if (nZoomType != -1)
            {
                InvokeOnMainThread(() =>
	            {
	                var rectBar = imgZoomBar.Frame;
	                var rectBtn = btnSliderThumb.Frame;
	                var step = rectBar.Width / 8.0f;

	                if (nZoomType == 0)
	                {
	                    rectBtn.X -= step;
	                    if (rectBtn.X < -rectBtn.Width / 2)
	                        rectBtn.X = -rectBtn.Width / 2;
	                }
	                else
	                {
	                    rectBtn.X += step;
	                    if (rectBtn.X > rectBar.Width - rectBtn.Width / 2)
	                        rectBtn.X = rectBar.Width - rectBtn.Width / 2;
	                }
	                btnSliderThumb.Frame = rectBtn;
	            });
				
            }
		}

		partial void ActionCameraZoomDown(UIButton sender)
		{
            nZoomType = (int)sender.Tag;
		}
		partial void ActionCameraZoomUp(UIButton sender)
		{
			nZoomType = -1;

			var rect = btnSliderThumb.Frame;
			rect.X = imgZoomBar.Frame.Width / 2 - rect.Width / 2;
			btnSliderThumb.Frame = rect;
		}

		#region Handlers
		partial void ActionCameraExpand(UIButton sender)
		{
            var orientation = UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait ? UIInterfaceOrientation.LandscapeLeft : UIInterfaceOrientation.Portrait;
			NSNumber orientationValue = new NSNumber((int)orientation);
			NSString orientationKey = new NSString("orientation");

			UIDevice.CurrentDevice.SetValueForKey(orientationValue, orientationKey);
			//ShowMessageBox("Camera Zoom button" + sender.Tag + " clicked!", "in line 110 of CameraViewController(ActionCameraZoom).");
		}

        public void DeviceOrientationChangedHandler(CGRect rectPort, CGRect rectLand)
        {
            imgZoomControl.Image = UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait ? GetImageByTheme(FN_BG_ZOOM_CONTROL) : GetImageByTheme(FN_BG_ZOOM_CONTROL_LAND);
            View.Frame = UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait ? rectPort : rectLand;
        }

        partial void ActionCameraDirection(UIButton sender)
        {
            //ShowMessageBox("Camera Direction button" + sender.Tag + " clicked!", "in line 115 of CameraViewController(ActionCameraDirection).");
        }

        partial void ActionCameraRecord(UIButton sender)
        {
            sender.Selected = !sender.Selected;
            //ShowMessageBox("Camera Record button clicked!", "in line 120 of CameraViewController(ActionCameraRecord).");
        }

		partial void ActionAction(UIButton sender)
		{
			switch ((int)sender.Tag)
			{
				case 0:
					viewMotionActive.Hidden = sender.Selected;
					break;
				case 1:
					viewCameraActive.Hidden = sender.Selected;
					break;
				case 2:
					viewTripwireActive.Hidden = sender.Selected;
					break;
				case 3:
					viewNotificationActive.Hidden = sender.Selected;
					break;
				case 4:
					viewSounderActive.Hidden = sender.Selected;
					break;
			}

			sender.Selected = !sender.Selected;
		}
		#endregion
    }
}