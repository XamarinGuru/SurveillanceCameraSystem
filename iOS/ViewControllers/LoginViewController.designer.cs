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
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bgEditPort { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bgEditPSW { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView bgEditServerIp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnScanQR { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgLogo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblOR { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPort { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblQRDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblServerIP { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtPort { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtServerIP { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewLSeperator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewRSeperator { get; set; }

        [Action ("ActionLogin:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionLogin (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (bgEditPort != null) {
                bgEditPort.Dispose ();
                bgEditPort = null;
            }

            if (bgEditPSW != null) {
                bgEditPSW.Dispose ();
                bgEditPSW = null;
            }

            if (bgEditServerIp != null) {
                bgEditServerIp.Dispose ();
                bgEditServerIp = null;
            }

            if (btnLogin != null) {
                btnLogin.Dispose ();
                btnLogin = null;
            }

            if (btnScanQR != null) {
                btnScanQR.Dispose ();
                btnScanQR = null;
            }

            if (imgBackground != null) {
                imgBackground.Dispose ();
                imgBackground = null;
            }

            if (imgLogo != null) {
                imgLogo.Dispose ();
                imgLogo = null;
            }

            if (lblOR != null) {
                lblOR.Dispose ();
                lblOR = null;
            }

            if (lblPassword != null) {
                lblPassword.Dispose ();
                lblPassword = null;
            }

            if (lblPort != null) {
                lblPort.Dispose ();
                lblPort = null;
            }

            if (lblQRDescription != null) {
                lblQRDescription.Dispose ();
                lblQRDescription = null;
            }

            if (lblServerIP != null) {
                lblServerIP.Dispose ();
                lblServerIP = null;
            }

            if (txtPassword != null) {
                txtPassword.Dispose ();
                txtPassword = null;
            }

            if (txtPort != null) {
                txtPort.Dispose ();
                txtPort = null;
            }

            if (txtServerIP != null) {
                txtServerIP.Dispose ();
                txtServerIP = null;
            }

            if (viewLSeperator != null) {
                viewLSeperator.Dispose ();
                viewLSeperator = null;
            }

            if (viewRSeperator != null) {
                viewRSeperator.Dispose ();
                viewRSeperator = null;
            }
        }
    }
}