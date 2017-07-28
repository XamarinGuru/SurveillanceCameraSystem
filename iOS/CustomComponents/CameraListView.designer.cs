// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SCS.iOS
{
    [Register ("CameraListView")]
    partial class CameraListView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgAction { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAction { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewContent { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgAction != null) {
                imgAction.Dispose ();
                imgAction = null;
            }

            if (imgBackground != null) {
                imgBackground.Dispose ();
                imgBackground = null;
            }

            if (lblAction != null) {
                lblAction.Dispose ();
                lblAction = null;
            }

            if (lblTime != null) {
                lblTime.Dispose ();
                lblTime = null;
            }

            if (viewContent != null) {
                viewContent.Dispose ();
                viewContent = null;
            }
        }
    }
}