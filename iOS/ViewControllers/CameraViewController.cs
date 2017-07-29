using System;
using UIKit;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class CameraViewController : BaseViewController
    {
        int nCurrentIndex = -1;

        public CameraViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			InitTheme();
            SetCurrentPage(0);
		}

        public override void InitTheme()
        {
            imgZoomControl.Image = GetImageByTheme(FN_BG_ZOOM_CONTROL);
            btnCamera.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_BACK), UIControlState.Normal);
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

        partial void ActionCameraZoom(UIButton sender)
        {
            Console.WriteLine("Camera Zoom button clicked!");
        }

        partial void ActionCameraDirection(UIButton sender)
        {
            Console.WriteLine("Camera Direction button" + sender.Tag + " clicked!");
        }
    }
}