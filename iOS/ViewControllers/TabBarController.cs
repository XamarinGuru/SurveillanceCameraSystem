using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace SCS.iOS
{
    public partial class TabBarController : BaseViewController
    {
		List<UINavigationController> subControllers = new List<UINavigationController>();
		int nCurrentIndex = -1;

		public TabBarController() : base()
        {
		}
		public TabBarController(IntPtr handle) : base(handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//AppDelegate myDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			//myDelegate.baseVC = this;

			AddSubController("DashboardViewController");
			AddSubController("CameraViewController");
			AddSubController("SettingsViewController");
            AddSubController("HelpViewController");

			SetCurrentPage(0);
		}

		void AddSubController(string vcIdentifier)
		{
			var tabVC = (BaseViewController)this.Storyboard.InstantiateViewController(vcIdentifier);
			//tabVC.rootVC = this;
			var tabNavVC = new UINavigationController(tabVC);

			tabNavVC.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			tabNavVC.View.BackgroundColor = UIColor.Clear;
			tabNavVC.NavigationBar.BackgroundColor = UIColor.Clear;
			tabNavVC.NavigationBar.ShadowImage = new UIImage();

			tabVC.NavigationItem.LeftBarButtonItem = null;

			subControllers.Add(tabNavVC);

            tabNavVC.View.Frame = new CGRect(CGPoint.Empty, viewContent.Frame.Size);

			viewContent.AddSubview(tabNavVC.View);

			tabNavVC.View.Hidden = true;
		}

		partial void ActionTab(UIButton sender)
		{
			SetCurrentPage((int)sender.Tag);
		}

		public void SetCurrentPage(int pIndex)
		{
			if (nCurrentIndex == pIndex) return;

			if (nCurrentIndex != -1)
				subControllers[nCurrentIndex].View.Hidden = true;

			nCurrentIndex = pIndex;

			subControllers[nCurrentIndex].View.Hidden = false;

			TabBarAnimation(pIndex);

			//AppDelegate myDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			//myDelegate.navVC = subControllers[nCurrentIndex];
		}

		public void TabBarAnimation(int pageNumber)
		{
            imgTabIconDashboard.Image = UIImage.FromFile("icon_tab_dashboard_inactive_dark.png");
            imgTabIconCamera.Image = UIImage.FromFile("icon_tab_camera_inactive_dark.png");
            imgTabIconSettings.Image = UIImage.FromFile("icon_tab_settings_inactive_dark.png");
            imgTabIconHelp.Image = UIImage.FromFile("icon_tab_help_inactive_dark.png");

            imgTabBottomDashboard.Hidden = true;
            imgTabBottomCamera.Hidden = true;
            imgTabBottomSettings.Hidden = true;
            imgTabBottomHelp.Hidden = true;

			switch (pageNumber)
			{
				case 0:
					imgTabIconDashboard.Image = UIImage.FromFile("icon_tab_dashboard_active_dark.png");
                    imgTabBottomDashboard.Hidden = false;
					break;
				case 1:
					imgTabIconCamera.Image = UIImage.FromFile("icon_tab_camera_active_dark.png");
					imgTabBottomCamera.Hidden = false;
					break;
				case 2:
					imgTabIconSettings.Image = UIImage.FromFile("icon_tab_settings_active_dark.png");
					imgTabBottomSettings.Hidden = false;
					break;
				case 3:
					imgTabIconHelp.Image = UIImage.FromFile("icon_tab_help_active_dark.png");
					imgTabBottomHelp.Hidden = false;
					break;
			}
		}
    }
}
