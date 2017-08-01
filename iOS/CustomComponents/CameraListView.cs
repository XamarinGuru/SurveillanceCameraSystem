using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using SCS.ViewModels;
using CoreGraphics;
using static SCS.Constants;

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
            if (item.imgData != null)
                imgBackground.Image = new UIImage(NSData.FromArray(item.imgData));
            
            switch(item.type)
            {
                case TYPE_ACTION.MOTION:
					imgAction.Image = UIImage.FromFile("icon_motiondetect_inactie_dark.png");
					lblAction.Text = "MOTION";
                    break;
                case TYPE_ACTION.CAMERA:
					imgAction.Image = UIImage.FromFile("icon_cameradisconnect_inactie_dark.png"); ;
					lblAction.Text = "CAMERA";
					break;
                case TYPE_ACTION.NOTIFICATION:
					imgAction.Image = UIImage.FromFile("icon_notification_inactie_dark.png"); ;
					lblAction.Text = "NOTIFICATION";
					break;
                case TYPE_ACTION.TRIPWIRE:
					imgAction.Image = UIImage.FromFile("icon_tripwire_inactie_dark.png"); ;
					lblAction.Text = "TRIPWIRE";
					break;
                case TYPE_ACTION.SOUNDER:
					imgAction.Image = UIImage.FromFile("icon_sounder_inactie_dark.png"); ;
					lblAction.Text = "SOUNDER";
					break;
            }
            lblTime.Text = item.time;
        }
    }
}