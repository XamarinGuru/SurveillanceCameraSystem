using System;
using UIKit;

namespace SCS.iOS
{
    public partial class LoginViewController : BaseViewController
	{
		//public LoginViewModel ViewModel;

		public LoginViewController(IntPtr handle) : base(handle)
		{
			//ViewModel = new LoginViewModel();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//NavigationItem.Title = ViewModel.Title;
		}

        partial void ActionLogin(UIButton sender)
        {
			UIViewController nextVC = Storyboard.InstantiateViewController("TabBarController") as TabBarController;
			
			PresentViewController(nextVC, true, null);
        }
	}
}
