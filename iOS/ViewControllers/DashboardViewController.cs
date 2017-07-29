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
            imgCameraFront.Image = GetImageByTheme(FN_ICON_CAMERA_FRONT);
            imgCameraBack.Image = GetImageByTheme(FN_ICON_CAMERA_BACK);

            lblRecentActivity.TextColor = GetTextColorByTheme();

            btnSymbolNumber.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SYMBOL_NUMBER), UIControlState.Normal);
		}

		void InitCameraSystem()
		{
            viewCameraListView.LayoutIfNeeded();
            nfloat posX = 0;
			nfloat posY = 0;
            var width = viewCameraListView.Frame.Size.Width / 3;
            var height = 80;

			for (var i = 0; i < 20; i++)
			{
				posX = i % 3 == 0 ? 0 : posX + width + 1;
				posY = i % 3 != 0 || i == 0 ? posY : posY + height + 1;
                var rect = new CGRect(posX, posY, width, height);

                CameraListView cv = CameraListView.Create(rect);
                viewCameraListView.AddSubview(cv);
            }

            heightViewCameraListView.Constant = posY + height;
            viewCameraListView.LayoutIfNeeded();
		}
    }
}