
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SCS.Activities;
using static SCS.Constants;

namespace SCS.Fragments
{
    public class CameraFragment : Android.Support.V4.App.Fragment
    {
        BaseActivity rootActivity;

        int nCurrentIndex = -1;

        public View mView;
        ImageView imgTabBottomKitchen, imgTabBottomBackdoor,
            imgZoomControl, imgZoomBar, imgMotionInactive, imgCameraInactive, imgTripwireInactive, imgNotificationInactive, imgSounderInactive;
        TextView lblTabIconKitchen, lblTabIconBackdoor;
        CheckBox btnCamera;
        ImageButton btnSliderThumb, btnZoomIn, btnZoomOut;
        LinearLayout viewBottomBar;
        RelativeLayout viewMotionActive, viewCameraActive, viewTripwireActive, viewNotificationActive, viewSounderActive,
            viewBottomBarMotion, viewBottomBarCamera, viewBottomBarNotification, viewBottomBarTripwire, viewBottomBarSounder;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            rootActivity = this.Activity as BaseActivity;
            return inflater.Inflate(Resource.Layout.CameraFragment, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);

            mView = view;

            InitUISettings();
			InitTheme();
			SetCurrentPage(0);
		}

        void InitUISettings()
        {
			imgTabBottomKitchen = mView.FindViewById<ImageView>(Resource.Id.imgTabBottomKitchen);
			imgTabBottomBackdoor = mView.FindViewById<ImageView>(Resource.Id.imgTabBottomBackdoor);

            lblTabIconKitchen = mView.FindViewById<TextView>(Resource.Id.lblTabIconKitchen);
            lblTabIconBackdoor = mView.FindViewById<TextView>(Resource.Id.lblTabIconBackdoor);

            imgZoomControl = mView.FindViewById<ImageView>(Resource.Id.imgZoomControl);
            btnCamera = mView.FindViewById<CheckBox>(Resource.Id.btnCamera);
            imgZoomBar = mView.FindViewById<ImageView>(Resource.Id.imgZoomBar);
            btnSliderThumb = mView.FindViewById<ImageButton>(Resource.Id.btnSliderThumb);
            btnZoomIn = mView.FindViewById<ImageButton>(Resource.Id.btnZoomIn);
            btnZoomOut = mView.FindViewById<ImageButton>(Resource.Id.btnZoomOut);

            imgMotionInactive = mView.FindViewById<ImageView>(Resource.Id.imgMotionInactive);
            imgCameraInactive = mView.FindViewById<ImageView>(Resource.Id.imgCameraInactive);
            imgTripwireInactive = mView.FindViewById<ImageView>(Resource.Id.imgTripwireInactive);
            imgNotificationInactive = mView.FindViewById<ImageView>(Resource.Id.imgNotificationInactive);
            imgSounderInactive = mView.FindViewById<ImageView>(Resource.Id.imgSounderInactive);

            viewBottomBar = mView.FindViewById<LinearLayout>(Resource.Id.viewBottomBar);

            viewMotionActive = mView.FindViewById<RelativeLayout>(Resource.Id.viewMotionActive);
            viewCameraActive = mView.FindViewById<RelativeLayout>(Resource.Id.viewCameraActive);
            viewTripwireActive = mView.FindViewById<RelativeLayout>(Resource.Id.viewTripwireActive);
            viewNotificationActive = mView.FindViewById<RelativeLayout>(Resource.Id.viewNotificationActive);
            viewSounderActive = mView.FindViewById<RelativeLayout>(Resource.Id.viewSounderActive);

            viewBottomBarMotion = mView.FindViewById<RelativeLayout>(Resource.Id.viewBottomBarMotion);
            viewBottomBarCamera = mView.FindViewById<RelativeLayout>(Resource.Id.viewBottomBarCamera);
            viewBottomBarNotification = mView.FindViewById<RelativeLayout>(Resource.Id.viewBottomBarNotification);
            viewBottomBarTripwire = mView.FindViewById<RelativeLayout>(Resource.Id.viewBottomBarTripwire);
            viewBottomBarSounder = mView.FindViewById<RelativeLayout>(Resource.Id.viewBottomBarSounder);

            mView.FindViewById(Resource.Id.ActionTabKitchen).Click += ActionTab;
            mView.FindViewById(Resource.Id.ActionTabBackdoor).Click += ActionTab;

            mView.FindViewById(Resource.Id.ActionCameraExpand).Click += ActionCameraExpand;
            mView.FindViewById(Resource.Id.ActionCameraDirection0).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection1).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection2).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection3).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection4).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection5).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection6).Click += ActionCameraDirection;
            mView.FindViewById(Resource.Id.ActionCameraDirection7).Click += ActionCameraDirection;

			viewBottomBarMotion.Click += ActionAction;
			viewBottomBarCamera.Click += ActionAction;
			viewBottomBarNotification.Click += ActionAction;
			viewBottomBarTripwire.Click += ActionAction;
			viewBottomBarSounder.Click += ActionAction;
        }



        public void InitTheme()
		{
            imgZoomControl.SetBackgroundResource(rootActivity.GetImageByTheme(FN_BG_ZOOM_CONTROL));
            //btnCamera.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_CAMERA_BACK));
            imgZoomBar.SetBackgroundResource(rootActivity.GetImageByTheme(FN_BG_ZOOM_BAR));
			btnSliderThumb.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_SLIDER_THUMB));
			btnZoomIn.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_ZOOM_IN));
			btnZoomOut.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_ZOOM_OUT));

            imgMotionInactive.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_MOTION_DETECT_INACTIE));
            imgCameraInactive.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_CAMERA_DISCONNECT_INACTIE));
            imgTripwireInactive.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_TRIPWIRE_INACTIE));
            imgNotificationInactive.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_NOTIFICATION_INACTIE));
            imgSounderInactive.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_SOUNDER_INACTIE));

            viewBottomBar.SetBackgroundColor(rootActivity.GetBottomBarBorderColorByTheme());
            viewBottomBarMotion.SetBackgroundColor(rootActivity.GetBottomBarBackgroundColorByTheme());
            viewBottomBarCamera.SetBackgroundColor(rootActivity.GetBottomBarBackgroundColorByTheme());
            viewBottomBarNotification.SetBackgroundColor(rootActivity.GetBottomBarBackgroundColorByTheme());
            viewBottomBarTripwire.SetBackgroundColor(rootActivity.GetBottomBarBackgroundColorByTheme());
            viewBottomBarSounder.SetBackgroundColor(rootActivity.GetBottomBarBackgroundColorByTheme());

			TabBarAnimation();
		}


		private void ActionTab(object sender, EventArgs e)
		{
            SetCurrentPage(int.Parse((sender as RelativeLayout).Tag.ToString()));
		}

		public void SetCurrentPage(int pIndex)
		{
			if (nCurrentIndex == pIndex) return;

			nCurrentIndex = pIndex;

			TabBarAnimation();
		}

		void TabBarAnimation()
		{
            imgTabBottomKitchen.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_SUBTAB_BOTTOM));
            imgTabBottomBackdoor.SetBackgroundResource(rootActivity.GetImageByTheme(FN_ICON_SUBTAB_BOTTOM));

            lblTabIconKitchen.SetTextColor(rootActivity.GetSubtabColorByTheme(true));
            lblTabIconBackdoor.SetTextColor(rootActivity.GetSubtabColorByTheme(true));

            imgTabBottomKitchen.Visibility = ViewStates.Gone;
			imgTabBottomBackdoor.Visibility = ViewStates.Gone;

            switch (nCurrentIndex)
            {
                case 0:
                    lblTabIconKitchen.SetTextColor(rootActivity.GetSubtabColorByTheme());
                    imgTabBottomKitchen.Visibility = ViewStates.Visible;
                    break;
                case 1:
                    lblTabIconBackdoor.SetTextColor(rootActivity.GetSubtabColorByTheme());
                    imgTabBottomBackdoor.Visibility = ViewStates.Visible;
                    break;
            }
		}

		private void ActionCameraExpand(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void ActionCameraDirection(object sender, EventArgs e)
		{
            //var direction = int.Parse((sender as ImageButton).Tag.ToString());
		}

		private void ActionAction(object sender, EventArgs e)
		{
            switch (int.Parse((sender as RelativeLayout).Tag.ToString()))
			{
				case 0:
                    viewMotionActive.Visibility = viewMotionActive.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
					break;
				case 1:
					viewCameraActive.Visibility = viewCameraActive.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
					break;
				case 2:
					viewTripwireActive.Visibility = viewTripwireActive.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
					break;
				case 3:
					viewNotificationActive.Visibility = viewNotificationActive.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
					break;
				case 4:
					viewSounderActive.Visibility = viewSounderActive.Visibility == ViewStates.Visible ? ViewStates.Gone : ViewStates.Visible;
					break;
			}
		}
    }
}
