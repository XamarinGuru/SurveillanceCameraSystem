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
    [Register ("CameraViewController")]
    partial class CameraViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint constraintTabBarHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomBackdoor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomKitchen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTabIconBackdoor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTabIconKitchen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView tabBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewCameraActive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewCameraInactive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewContent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMotionActive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewMotionInactive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewNotificationActive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewNotificationInactive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewSounderActive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewSounderInactive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewTripwireActive { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewTripwireInactive { get; set; }

        [Action ("ActionAction:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionAction (UIKit.UIButton sender);

        [Action ("ActionTab:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionTab (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (constraintTabBarHeight != null) {
                constraintTabBarHeight.Dispose ();
                constraintTabBarHeight = null;
            }

            if (imgTabBottomBackdoor != null) {
                imgTabBottomBackdoor.Dispose ();
                imgTabBottomBackdoor = null;
            }

            if (imgTabBottomKitchen != null) {
                imgTabBottomKitchen.Dispose ();
                imgTabBottomKitchen = null;
            }

            if (lblTabIconBackdoor != null) {
                lblTabIconBackdoor.Dispose ();
                lblTabIconBackdoor = null;
            }

            if (lblTabIconKitchen != null) {
                lblTabIconKitchen.Dispose ();
                lblTabIconKitchen = null;
            }

            if (tabBar != null) {
                tabBar.Dispose ();
                tabBar = null;
            }

            if (viewCameraActive != null) {
                viewCameraActive.Dispose ();
                viewCameraActive = null;
            }

            if (viewCameraInactive != null) {
                viewCameraInactive.Dispose ();
                viewCameraInactive = null;
            }

            if (viewContent != null) {
                viewContent.Dispose ();
                viewContent = null;
            }

            if (viewMotionActive != null) {
                viewMotionActive.Dispose ();
                viewMotionActive = null;
            }

            if (viewMotionInactive != null) {
                viewMotionInactive.Dispose ();
                viewMotionInactive = null;
            }

            if (viewNotificationActive != null) {
                viewNotificationActive.Dispose ();
                viewNotificationActive = null;
            }

            if (viewNotificationInactive != null) {
                viewNotificationInactive.Dispose ();
                viewNotificationInactive = null;
            }

            if (viewSounderActive != null) {
                viewSounderActive.Dispose ();
                viewSounderActive = null;
            }

            if (viewSounderInactive != null) {
                viewSounderInactive.Dispose ();
                viewSounderInactive = null;
            }

            if (viewTripwireActive != null) {
                viewTripwireActive.Dispose ();
                viewTripwireActive = null;
            }

            if (viewTripwireInactive != null) {
                viewTripwireInactive.Dispose ();
                viewTripwireInactive = null;
            }
        }
    }
}