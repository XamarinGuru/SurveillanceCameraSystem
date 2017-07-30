using System;
using UIKit;
using CoreGraphics;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class DashboardViewController : BaseViewController
    {
        public DashboardViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			InitTheme();
            InitCameraSystem();
		}

        public override void InitTheme()
		{
            btnCameraFront.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_FRONT), UIControlState.Normal);
            btnCameraBack.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_BACK), UIControlState.Normal);

            lblRecentActivity.TextColor = GetTextColorByTheme();

            btnSymbolNumber.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SYMBOL_NUMBER), UIControlState.Normal);
		}

		void InitCameraSystem()
		{
            btnSymbolNumber.SetTitle("20", UIControlState.Normal);

            viewCameraListView.LayoutIfNeeded();
            nfloat posX = 0;
			nfloat posY = 0;
            var width = View.Frame.Size.Width / 3;
            var height = 80;

			for (var i = 0; i < 20; i++)
			{
				posX = i % 3 == 0 ? 0 : posX + width;
				posY = i % 3 != 0 || i == 0 ? posY : posY + height + 1;
                var rect = new CGRect(posX, posY, width, height);

                CameraListView cv = CameraListView.Create(rect);
                viewCameraListView.AddSubview(cv);
            }

            heightViewCameraListView.Constant = posY + height;
            viewCameraListView.BackgroundColor = UIColor.White;
		}

        partial void ActionCameraRecord(UIButton sender)
        {
            var msgTitle = sender.Tag == 0 ? "Front" : "Back";
            ShowMessageBox("Camera button clicked.", "in line 59 of CameraViewController(ActionCameraRecord).");
        }
    }
}