
using System;
using System.Timers;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using SCS.Activities;
using SCS.Helpers;
using static SCS.Constants;

namespace SCS.Fragments
{
    public class CameraFragment : BaseFragment
    {
        int nCurrentIndex = -1;

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

            StartTimer();

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

            btnZoomIn.Touch += ActionCameraZoom;
            btnZoomOut.Touch += ActionCameraZoom;

			viewBottomBarMotion.Click += ActionAction;
			viewBottomBarCamera.Click += ActionAction;
			viewBottomBarNotification.Click += ActionAction;
			viewBottomBarTripwire.Click += ActionAction;
			viewBottomBarSounder.Click += ActionAction;
        }

		Timer _timer = new Timer();
		int nZoomType = -1;

		void StartTimer()
		{
			_timer.Interval = 200;
			_timer.Elapsed -= OnTimedEvent;
			_timer.Elapsed += OnTimedEvent;
			_timer.Enabled = true;
		}

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            rootActivity.RunOnUiThread(() =>
                {
                    var viewZoomBarContent = mView.FindViewById<RelativeLayout>(Resource.Id.viewZoomBarContent);
                    var barWidth = imgZoomBar.Width;
                    var barPosX = imgZoomBar.GetX();
                    var btnWidth = btnSliderThumb.Width;
                    var btnPosX = btnSliderThumb.GetX();

                    var step = imgZoomBar.Width / 8.0f;

                    if (nZoomType != -1)
                    {
                        if (nZoomType == 0)
                        {
                            btnPosX -= step;
                            if (btnPosX < barPosX - btnWidth / 2)
                                btnPosX = barPosX - btnWidth / 2;
                        }
                        else
                        {
                            btnPosX += step;
                            if (btnPosX > barPosX + barWidth - btnWidth / 2)
                                btnPosX = barPosX + barWidth - btnWidth / 2;
                        }
                        btnSliderThumb.SetX(btnPosX);
                    }
                    else
                    {
                        btnPosX = (viewZoomBarContent.Width - btnWidth) / 2;
                    }

                    btnSliderThumb.SetX(btnPosX);
                });
        }

        private void ActionCameraZoom(object sender, View.TouchEventArgs e)
        {
            
            switch(e.Event.Action)
            {
                case MotionEventActions.Down:
                    nZoomType = int.Parse((sender as ImageButton).Tag.ToString());
                    break;
                case MotionEventActions.Up:
                    nZoomType = -1;
					break;
            }
        }

        public override void InitTheme()
		{
			var imgResource = Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait ? rootActivity.GetImageByTheme(FN_BG_ZOOM_CONTROL) : rootActivity.GetImageByTheme(FN_BG_ZOOM_CONTROL_LAND);
			imgZoomControl.SetImageResource(imgResource);

			var cameraResource = AppSettings.CurrentTheme == TYPE_THEME.DARK ? Resource.Drawable.item_btnCameraRecord_dark : Resource.Drawable.item_btnCameraRecord_light;
			btnCamera.SetBackgroundResource(cameraResource);

            imgZoomBar.SetImageResource(rootActivity.GetImageByTheme(FN_BG_ZOOM_BAR));
            btnSliderThumb.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_SLIDER_THUMB));
			btnZoomIn.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_ZOOM_IN));
			btnZoomOut.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_ZOOM_OUT));

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
            imgTabBottomKitchen.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_SUBTAB_BOTTOM));
            imgTabBottomBackdoor.SetImageResource(rootActivity.GetImageByTheme(FN_ICON_SUBTAB_BOTTOM));

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
            var orientation = Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;
            rootActivity.RequestedOrientation = orientation;
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
