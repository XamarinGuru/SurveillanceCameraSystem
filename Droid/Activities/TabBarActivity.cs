﻿
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V4.View;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SCS.CustomComponents;
using static SCS.Constants;

namespace SCS.Activities
{
    [Activity(Label = "TabBarActivity", WindowSoftInputMode = SoftInput.AdjustPan, ScreenOrientation = ScreenOrientation.Portrait)]
    public class TabBarActivity : BaseActivity
    {
        NonSwipeableViewPager _pager;
        int _nCurrentPage = 0;

        ImageView imgTabIconDashboard, imgTabIconCamera, imgTabIconSettings, imgTabIconHelp,
            imgTabBottomDashboard, imgTabBottomCamera, imgTabBottomSettings, imgTabBottomHelp;
        RelativeLayout imgTopBar, viewBGTabDashboard, viewBGTabCamera, viewBGTabSettings, viewBGTabHelp;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.TabBarActivity);

			InitUISettings();
            InitTheme();
		}

		void InitUISettings()
		{
            imgTabIconDashboard = FindViewById<ImageView>(Resource.Id.imgTabIconDashboard);
            imgTabIconCamera = FindViewById<ImageView>(Resource.Id.imgTabIconCamera);
            imgTabIconSettings = FindViewById<ImageView>(Resource.Id.imgTabIconSettings);
            imgTabIconHelp = FindViewById<ImageView>(Resource.Id.imgTabIconHelp);

            imgTabBottomDashboard = FindViewById<ImageView>(Resource.Id.imgTabBottomDashboard);
            imgTabBottomCamera = FindViewById<ImageView>(Resource.Id.imgTabBottomCamera);
            imgTabBottomSettings = FindViewById<ImageView>(Resource.Id.imgTabBottomSettings);
            imgTabBottomHelp = FindViewById<ImageView>(Resource.Id.imgTabBottomHelp);

			imgTopBar = FindViewById<RelativeLayout>(Resource.Id.imgTopBar);
			viewBGTabDashboard = FindViewById<RelativeLayout>(Resource.Id.viewBGTabDashboard);
			viewBGTabCamera = FindViewById<RelativeLayout>(Resource.Id.viewBGTabCamera);
			viewBGTabSettings = FindViewById<RelativeLayout>(Resource.Id.viewBGTabSettings);
			viewBGTabHelp = FindViewById<RelativeLayout>(Resource.Id.viewBGTabHelp);

			TabViewAdapter _adaptor = new TabViewAdapter(SupportFragmentManager, this);
			_pager = FindViewById<NonSwipeableViewPager>(Resource.Id.pager);
			_pager.SetPagingEnabled(false);
			_pager.OffscreenPageLimit = 2;
			_pager.Adapter = _adaptor;
			_pager.PageSelected += PagerOnPageSelected;

			viewBGTabDashboard.Click += (sender, args) => { SetCurrentPage(0); };
			viewBGTabCamera.Click += (sender, args) => { SetCurrentPage(1); };
			viewBGTabSettings.Click += (sender, args) => { SetCurrentPage(2); };
            viewBGTabHelp.Click += (sender, args) => { SetCurrentPage(3); };
		}

        public override void InitTheme()
        {
            _pager.SetBackgroundColor(GetBackgroundColorByTheme());
            imgTopBar.SetBackgroundResource(GetImageByTheme(FN_BG_TOP_BAR));

            SetCurrentPage(_nCurrentPage);
            TabBarAnimation(_nCurrentPage);
        }

		public void SetCurrentPage(int position)
		{
			_pager.SetCurrentItem(position, true);
            _nCurrentPage = position;
		}

		private void PagerOnPageSelected(object sender, ViewPager.PageSelectedEventArgs e)
		{
			TabBarAnimation(e.Position);

            var currentFragment = ((sender as NonSwipeableViewPager).Adapter as TabViewAdapter).GetRegisteredFragment(e.Position);
            if (currentFragment != null)
                currentFragment.InitTheme();
		}

		private void TabBarAnimation(int position)
		{
            if (this.CurrentFocus != null && this.CurrentFocus.WindowToken != null)
            {
				InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
				imm.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
			}
			
            imgTabIconDashboard.SetImageResource(GetImageByTheme(FN_ICON_TAB_DASHBOARD_INACTIVE));
            imgTabIconCamera.SetImageResource(GetImageByTheme(FN_ICON_TAB_CAMERA_INACTIVE));
            imgTabIconSettings.SetImageResource(GetImageByTheme(FN_ICON_TAB_SETTINGS_INACTIVE));
            imgTabIconHelp.SetImageResource(GetImageByTheme(FN_ICON_TAB_HELP_INACTIVE));

            imgTabBottomDashboard.Visibility = ViewStates.Gone;
			imgTabBottomCamera.Visibility = ViewStates.Gone;
			imgTabBottomSettings.Visibility = ViewStates.Gone;
			imgTabBottomHelp.Visibility = ViewStates.Gone;

            viewBGTabDashboard.SetBackgroundColor(Color.Transparent);
			viewBGTabCamera.SetBackgroundColor(Color.Transparent);
			viewBGTabSettings.SetBackgroundColor(Color.Transparent);
			viewBGTabHelp.SetBackgroundColor(Color.Transparent);

            switch (position)
			{
				case 0:
                    imgTabIconDashboard.SetImageResource(GetImageByTheme(FN_ICON_TAB_DASHBOARD_ACTIVE));
					SetActiveTab(imgTabBottomDashboard, viewBGTabDashboard);
					break;
				case 1:
                    imgTabIconCamera.SetImageResource(GetImageByTheme(FN_ICON_TAB_CAMERA_ACTIVE));
					SetActiveTab(imgTabBottomCamera, viewBGTabCamera);
					break;
				case 2:
                    imgTabIconSettings.SetImageResource(GetImageByTheme(FN_ICON_TAB_SETTINGS_ACTIVE));
					SetActiveTab(imgTabBottomSettings, viewBGTabSettings);
					break;
				case 3:
                    imgTabIconHelp.SetImageResource(GetImageByTheme(FN_ICON_TAB_HELP_ACTIVE));
					SetActiveTab(imgTabBottomHelp, viewBGTabHelp);
					break;
			}
		}
    }
}
