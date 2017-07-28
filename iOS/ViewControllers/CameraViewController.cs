using Foundation;
using System;
using UIKit;

namespace SCS.iOS
{
    public partial class CameraViewController : BaseViewController
    {
        public CameraViewController (IntPtr handle) : base (handle)
        {
        }

		partial void ActionTab(UIButton sender)
		{
            lblTabIconKitchen.TextColor = GetColor(Constants.COLOR_TAB_TEXT_INACTIVE);
            lblTabIconBackdoor.TextColor = GetColor(Constants.COLOR_TAB_TEXT_INACTIVE);
            imgTabBottomKitchen.Hidden = true;
            imgTabBottomBackdoor.Hidden = true;

			switch ((int)sender.Tag)
			{
				case 0:
                    lblTabIconKitchen.TextColor = GetColor(Constants.COLOR_TAB_TEXT_ACTIVE);
                    imgTabBottomKitchen.Hidden = false;
					break;
				case 1:
                    lblTabIconBackdoor.TextColor = GetColor(Constants.COLOR_TAB_TEXT_ACTIVE);
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