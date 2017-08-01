using System;
using UIKit;
using static SCS.Constants;

namespace SCS.iOS
{
    public partial class LoginViewController : BaseViewController
	{
		public LoginViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            InitTheme();
        }

		public override bool ShouldAutorotate()
		{
            return false;
		}

        public override void InitTheme()
        {
            imgBackground.Image = GetImageByTheme(FN_BACKGROUND);
            imgLogo.Image = GetImageByTheme(FN_LOGO);
            bgEditServerIp.Image = GetImageByTheme(FN_BG_EDIT_SERVER_IP);
            bgEditPort.Image = GetImageByTheme(FN_BG_EDIT_PORT);
            bgEditPSW.Image = GetImageByTheme(FN_BG_EDIT_PSW);
            btnLogin.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_LOGIN), UIControlState.Normal);
            btnScanQR.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SCAN_QR), UIControlState.Normal);

            lblServerIP.TextColor = GetTextColorByTheme();
            lblPort.TextColor = GetTextColorByTheme();
            lblPassword.TextColor = GetTextColorByTheme();
            txtServerIP.TextColor = GetTextColorByTheme();
            txtPort.TextColor = GetTextColorByTheme();
            txtPassword.TextColor = GetTextColorByTheme();

            lblOR.TextColor = GetTextColorByTheme(false);
			lblQRDescription.TextColor = GetTextColorByTheme(false);

            viewLSeperator.BackgroundColor = GetTextColorByTheme(false);
            viewRSeperator.BackgroundColor = GetTextColorByTheme(false);
        }

        partial void ActionLogin(UIButton sender)
        {
			UIViewController nextVC = Storyboard.InstantiateViewController("TabBarController") as TabBarController;
			
			PresentViewController(nextVC, true, null);
        }
	}
}
