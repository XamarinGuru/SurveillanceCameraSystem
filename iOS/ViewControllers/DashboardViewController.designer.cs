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
    [Register ("DashboardViewController")]
    partial class DashboardViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCameraBack { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCameraFront { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSymbolNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint heightViewCameraListView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRecentActivity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewCameraListView { get; set; }

        [Action ("ActionCameraRecord:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionCameraRecord (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCameraBack != null) {
                btnCameraBack.Dispose ();
                btnCameraBack = null;
            }

            if (btnCameraFront != null) {
                btnCameraFront.Dispose ();
                btnCameraFront = null;
            }

            if (btnSymbolNumber != null) {
                btnSymbolNumber.Dispose ();
                btnSymbolNumber = null;
            }

            if (heightViewCameraListView != null) {
                heightViewCameraListView.Dispose ();
                heightViewCameraListView = null;
            }

            if (lblRecentActivity != null) {
                lblRecentActivity.Dispose ();
                lblRecentActivity = null;
            }

            if (viewBackground != null) {
                viewBackground.Dispose ();
                viewBackground = null;
            }

            if (viewCameraListView != null) {
                viewCameraListView.Dispose ();
                viewCameraListView = null;
            }
        }
    }
}