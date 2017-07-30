using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using SCS.ViewModels;
using CoreGraphics;

namespace SCS.iOS
{
    public partial class CameraListView : UIView
    {
		public CameraListView(IntPtr handle) : base (handle)
        {
		}

		public static CameraListView Create(CGRect rect)
		{
			var arr = NSBundle.MainBundle.LoadNib("CameraListView", null, null);
			var v = Runtime.GetNSObject<CameraListView>(arr.ValueAt(0));
            v.Frame = rect;
			return v;
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

        public void SetView(CameraListItem item = null)
        {
            imgBackground.Image = UIImage.FromFile(item.image);
            imgAction.Image = null;
            lblAction.Text = item.image;
            lblTime.Text = item.time;
        }

		//public void SetHighlight(BaseViewController baseVC)
		//{
		//	lblCommentDate.TextColor = baseVC.FromHexString(PortableLibrary.Constants.COLOR_NEW_NOTIFICATION);
		//	imgNewSymbol.Hidden = false;
		//}

		//override public void LayoutSubviews()
		//{
		//	base.LayoutSubviews();

		//	imgPhoto.LayoutIfNeeded();
		//	imgPhoto.Layer.CornerRadius = imgPhoto.Frame.Size.Width / 2;
		//	imgPhoto.Layer.MasksToBounds = true;
		//	imgPhoto.Layer.BorderWidth = 1;
		//	imgPhoto.Layer.BorderColor = UIColor.Gray.CGColor;
		//}
    }
}