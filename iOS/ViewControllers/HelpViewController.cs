using Foundation;
using System;
using UIKit;

namespace SCS.iOS
{
    public partial class HelpViewController : BaseViewController
    {
        public HelpViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//NavigationItem.Title = ViewModel.Title;
		}
    }
}