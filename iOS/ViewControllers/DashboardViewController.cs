using Foundation;
using System;
using UIKit;
using CoreGraphics;

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

			//InitCameraSystem();
		}

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            InitCameraSystem();
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