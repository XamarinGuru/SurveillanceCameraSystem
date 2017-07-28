using System;

using UIKit;

namespace SCS.iOS
{
    public partial class BaseViewController : UIViewController
    {
		public BaseViewController() : base()
		{
		}
		public BaseViewController(IntPtr handle) : base(handle)
		{
		}

        public UIColor GetColor(string color)
		{
			var red = Convert.ToInt32(color.Substring(0, 2), 16) / 255f;
			var green = Convert.ToInt32(color.Substring(2, 2), 16) / 255f;
			var blue = Convert.ToInt32(color.Substring(4, 2), 16) / 255f;
			return UIColor.FromRGB(red, green, blue);
		}
    }
}

