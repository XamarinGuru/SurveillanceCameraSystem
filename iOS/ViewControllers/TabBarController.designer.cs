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
    [Register ("TabBarController")]
    partial class TabBarController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnDashboard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint constraintTabBarHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomDashboard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabBottomSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabIconCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabIconDashboard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabIconHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTabIconSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTopBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView tabBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewBGTabCamera { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewBGTabDashboard { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewBGTabHelp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewBGTabSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewContent { get; set; }

        [Action ("ActionTab:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionTab (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCamera != null) {
                btnCamera.Dispose ();
                btnCamera = null;
            }

            if (btnDashboard != null) {
                btnDashboard.Dispose ();
                btnDashboard = null;
            }

            if (btnHelp != null) {
                btnHelp.Dispose ();
                btnHelp = null;
            }

            if (btnSettings != null) {
                btnSettings.Dispose ();
                btnSettings = null;
            }

            if (constraintTabBarHeight != null) {
                constraintTabBarHeight.Dispose ();
                constraintTabBarHeight = null;
            }

            if (imgTabBottomCamera != null) {
                imgTabBottomCamera.Dispose ();
                imgTabBottomCamera = null;
            }

            if (imgTabBottomDashboard != null) {
                imgTabBottomDashboard.Dispose ();
                imgTabBottomDashboard = null;
            }

            if (imgTabBottomHelp != null) {
                imgTabBottomHelp.Dispose ();
                imgTabBottomHelp = null;
            }

            if (imgTabBottomSettings != null) {
                imgTabBottomSettings.Dispose ();
                imgTabBottomSettings = null;
            }

            if (imgTabIconCamera != null) {
                imgTabIconCamera.Dispose ();
                imgTabIconCamera = null;
            }

            if (imgTabIconDashboard != null) {
                imgTabIconDashboard.Dispose ();
                imgTabIconDashboard = null;
            }

            if (imgTabIconHelp != null) {
                imgTabIconHelp.Dispose ();
                imgTabIconHelp = null;
            }

            if (imgTabIconSettings != null) {
                imgTabIconSettings.Dispose ();
                imgTabIconSettings = null;
            }

            if (imgTopBar != null) {
                imgTopBar.Dispose ();
                imgTopBar = null;
            }

            if (tabBar != null) {
                tabBar.Dispose ();
                tabBar = null;
            }

            if (viewBGTabCamera != null) {
                viewBGTabCamera.Dispose ();
                viewBGTabCamera = null;
            }

            if (viewBGTabDashboard != null) {
                viewBGTabDashboard.Dispose ();
                viewBGTabDashboard = null;
            }

            if (viewBGTabHelp != null) {
                viewBGTabHelp.Dispose ();
                viewBGTabHelp = null;
            }

            if (viewBGTabSettings != null) {
                viewBGTabSettings.Dispose ();
                viewBGTabSettings = null;
            }

            if (viewContent != null) {
                viewContent.Dispose ();
                viewContent = null;
            }
        }
    }
}