using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class TabBarController : BaseViewController
    {
		public List<BaseViewController> subControllers = new List<BaseViewController>();
		int nCurrentIndex = -1;

        public Action<CGRect, CGRect> DeviceOrientationChangedHandler;
        CGRect _contentRectPort, _contentRectLand;

		public TabBarController() : base()
        {
		}
		public TabBarController(IntPtr handle) : base(handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_contentRectPort = new CGRect(CGPoint.Empty, new CGSize(View.Frame.Width, View.Frame.Height - 90));
            _contentRectLand = new CGRect(CGPoint.Empty, new CGSize(View.Frame.Height, View.Frame.Width));

            AddSubController("DashboardViewController");
            AddSubController("CameraViewController");
            AddSubController("SettingsViewController");
            AddSubController("HelpViewController");

			InitTheme();
			SetCurrentPage(0);
		}

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            DeviceOrientationChangedHandler?.Invoke(_contentRectPort, _contentRectLand);
            if (nCurrentIndex == 1)
                if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft || UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight)
                    return UIInterfaceOrientationMask.Landscape;
            return UIInterfaceOrientationMask.Portrait;
        }

		public override void InitTheme()
		{
            viewContent.BackgroundColor = GetBackgroundColorByTheme();
			imgTopBar.Image = GetImageByTheme(Constants.FN_BG_TOP_BAR);

            TabBarAnimation();
		}

		void AddSubController(string vcIdentifier)
		{
			var tabVC = (BaseViewController)this.Storyboard.InstantiateViewController(vcIdentifier);
            tabVC.rootVC = this;
            tabVC.View.Frame = new CGRect(CGPoint.Empty, viewContent.Frame.Size);
			tabVC.View.Hidden = true;

            viewContent.AddSubview(tabVC.View);
            subControllers.Add(tabVC);
		}

		partial void ActionTab(UIButton sender)
		{
			SetCurrentPage((int)sender.Tag);
		}

		public void SetCurrentPage(int pIndex)
		{
			if (nCurrentIndex == pIndex) return;

            if (nCurrentIndex != -1)
            {
                subControllers[nCurrentIndex].View.Hidden = true;
                subControllers[nCurrentIndex].View.EndEditing(true);
            }

            nCurrentIndex = pIndex;

            DeviceOrientationChangedHandler1();

            subControllers[nCurrentIndex].View.Hidden = false;

			TabBarAnimation();
		}

		public void TabBarAnimation()
		{
            imgTabIconDashboard.Image = GetImageByTheme(FN_ICON_TAB_DASHBOARD_INACTIVE);
            imgTabIconCamera.Image = GetImageByTheme(FN_ICON_TAB_CAMERA_INACTIVE);
            imgTabIconSettings.Image = GetImageByTheme(FN_ICON_TAB_SETTINGS_INACTIVE);
            imgTabIconHelp.Image = GetImageByTheme(FN_ICON_TAB_HELP_INACTIVE);

            imgTabBottomDashboard.Hidden = true;
            imgTabBottomCamera.Hidden = true;
            imgTabBottomSettings.Hidden = true;
            imgTabBottomHelp.Hidden = true;

            viewBGTabDashboard.BackgroundColor = UIColor.Clear;
            viewBGTabCamera.BackgroundColor = UIColor.Clear;
            viewBGTabSettings.BackgroundColor = UIColor.Clear;
            viewBGTabHelp.BackgroundColor = UIColor.Clear;

			switch (nCurrentIndex)
			{
				case 0:
					imgTabIconDashboard.Image = GetImageByTheme(FN_ICON_TAB_DASHBOARD_ACTIVE);
                    SetActiveTab(imgTabBottomDashboard, viewBGTabDashboard);
					break;
				case 1:
					imgTabIconCamera.Image = GetImageByTheme(FN_ICON_TAB_CAMERA_ACTIVE);
                    SetActiveTab(imgTabBottomCamera, viewBGTabCamera);
					break;
				case 2:
					imgTabIconSettings.Image = GetImageByTheme(FN_ICON_TAB_SETTINGS_ACTIVE);
                    SetActiveTab(imgTabBottomSettings, viewBGTabSettings);
					break;
				case 3:
					imgTabIconHelp.Image = GetImageByTheme(FN_ICON_TAB_HELP_ACTIVE);
                    SetActiveTab(imgTabBottomHelp, viewBGTabHelp);
					break;
			}
		}
    }
}
