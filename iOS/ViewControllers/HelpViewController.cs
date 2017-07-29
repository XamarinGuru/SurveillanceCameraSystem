using System;

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

			InitTheme();
		}

		public override void InitTheme()
		{
            lblVersion.TextColor = GetTextColorByTheme();
            lblDescription.TextColor = GetDescriptionColorByTheme();
		}
    }
}