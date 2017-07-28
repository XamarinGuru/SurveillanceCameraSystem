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
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnToggleTheme { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgThemeToggleThumb { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SCS.iOS.CustomComponents.RangeSliderControl sliderDiskStatus { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SCS.iOS.CustomComponents.RangeSliderControl sliderDiskUsage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SCS.iOS.CustomComponents.RangeSliderControl sliderEventsDuration { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SCS.iOS.CustomComponents.RangeSliderControl sliderEventsMax { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView viewThemeToggleContent { get; set; }

        [Action ("ActionToggleTheme:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ActionToggleTheme (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnToggleTheme != null) {
                btnToggleTheme.Dispose ();
                btnToggleTheme = null;
            }

            if (imgThemeToggleThumb != null) {
                imgThemeToggleThumb.Dispose ();
                imgThemeToggleThumb = null;
            }

            if (sliderDiskStatus != null) {
                sliderDiskStatus.Dispose ();
                sliderDiskStatus = null;
            }

            if (sliderDiskUsage != null) {
                sliderDiskUsage.Dispose ();
                sliderDiskUsage = null;
            }

            if (sliderEventsDuration != null) {
                sliderEventsDuration.Dispose ();
                sliderEventsDuration = null;
            }

            if (sliderEventsMax != null) {
                sliderEventsMax.Dispose ();
                sliderEventsMax = null;
            }

            if (viewThemeToggleContent != null) {
                viewThemeToggleContent.Dispose ();
                viewThemeToggleContent = null;
            }
        }
    }
}