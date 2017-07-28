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
        UIKit.NSLayoutConstraint heightViewCameraListView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewCameraListView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (heightViewCameraListView != null) {
                heightViewCameraListView.Dispose ();
                heightViewCameraListView = null;
            }

            if (viewCameraListView != null) {
                viewCameraListView.Dispose ();
                viewCameraListView = null;
            }
        }
    }
}