
using System;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using SCS.Activities;
using SCS.Helpers;
using static SCS.Constants;

namespace SCS.Fragments
{
    public class SettingsFragment : BaseFragment
    {
        CheckBox btnToggleTheme;
        TextView lblEventsMax, lblEventsDuration, lblDiskStatus, lblTheme, lblServerConnection,
            lblEventsMaxValue, lblEventsDurationValue, lblDiskUsageValue,
            lblServerIP, lblPort, lblPassword;
        EditText txtServerIP, txtPort, txtPassword;
        ImageView bgEditEventsMax, bgEditEventsDuration, bgEditDiskUsage, bgEditServerIP, bgEditPort, bgEditPassword;
        LinearLayout viewLineSeperator1, viewLineSeperator2, viewLineSeperator3, viewLineSeperator4;
        SeekBar sliderEventsMax, sliderEventsDuration, sliderDiskStatus;
        ImageButton btnScanQR;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			rootActivity = this.Activity as BaseActivity;
            return inflater.Inflate(Resource.Layout.SettingsFragment, container, false);
        }

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			mView = view;

			InitUISettings();
            InitTheme();
		}

        void InitUISettings()
        {
            btnToggleTheme = mView.FindViewById<CheckBox>(Resource.Id.btnToggleTheme);
            btnToggleTheme.Checked = AppSettings.CurrentTheme != TYPE_THEME.DARK;
			btnToggleTheme.Click += ActionToggleTheme;

			lblEventsMax = mView.FindViewById<TextView>(Resource.Id.lblEventsMax);
			lblEventsDuration = mView.FindViewById<TextView>(Resource.Id.lblEventsDuration);
			lblDiskStatus = mView.FindViewById<TextView>(Resource.Id.lblDiskStatus);
			lblTheme = mView.FindViewById<TextView>(Resource.Id.lblTheme);
			lblServerConnection = mView.FindViewById<TextView>(Resource.Id.lblServerConnection);

			lblEventsMaxValue = mView.FindViewById<TextView>(Resource.Id.lblEventsMaxValue);
			lblEventsDurationValue = mView.FindViewById<TextView>(Resource.Id.lblEventsDurationValue);
			lblDiskUsageValue = mView.FindViewById<TextView>(Resource.Id.lblDiskUsageValue);

			lblServerIP = mView.FindViewById<TextView>(Resource.Id.lblServerIP);
			lblPort = mView.FindViewById<TextView>(Resource.Id.lblPort);
			lblPassword = mView.FindViewById<TextView>(Resource.Id.lblPassword);

			bgEditEventsMax = mView.FindViewById<ImageView>(Resource.Id.bgEditEventsMax);
			bgEditEventsDuration = mView.FindViewById<ImageView>(Resource.Id.bgEditEventsDuration);
			bgEditDiskUsage = mView.FindViewById<ImageView>(Resource.Id.bgEditDiskUsage);
			bgEditServerIP = mView.FindViewById<ImageView>(Resource.Id.bgEditServerIP);
			bgEditPort = mView.FindViewById<ImageView>(Resource.Id.bgEditPort);
			bgEditPassword = mView.FindViewById<ImageView>(Resource.Id.bgEditPassword);

			txtServerIP = mView.FindViewById<EditText>(Resource.Id.txtServerIP);
			txtPort = mView.FindViewById<EditText>(Resource.Id.txtPort);
			txtPassword = mView.FindViewById<EditText>(Resource.Id.txtPassword);

            viewLineSeperator1 = mView.FindViewById<LinearLayout>(Resource.Id.viewLineSeperator1);
			viewLineSeperator2 = mView.FindViewById<LinearLayout>(Resource.Id.viewLineSeperator2);
			viewLineSeperator3 = mView.FindViewById<LinearLayout>(Resource.Id.viewLineSeperator3);
			viewLineSeperator4 = mView.FindViewById<LinearLayout>(Resource.Id.viewLineSeperator4);

            sliderEventsMax = mView.FindViewById<SeekBar>(Resource.Id.sliderEventsMax);
            sliderEventsDuration = mView.FindViewById<SeekBar>(Resource.Id.sliderEventsDuration);
            sliderDiskStatus = mView.FindViewById<SeekBar>(Resource.Id.sliderDiskStatus);

			sliderEventsMax.ProgressChanged += (sender, e) =>
            {
                lblEventsMaxValue.Text = ((SeekBar)sender).Progress.ToString();
            };
			sliderEventsDuration.ProgressChanged += (sender, e) =>
			{
				lblEventsDurationValue.Text = ((SeekBar)sender).Progress.ToString();
			};

            btnScanQR = mView.FindViewById<ImageButton>(Resource.Id.btnScanQR);
            btnScanQR.Click += ActionScanQR;
		}

        public override void InitTheme()
        {
            lblEventsMax.SetTextColor(rootActivity.GetTextColorByTheme());
			lblEventsDuration.SetTextColor(rootActivity.GetTextColorByTheme());
			lblDiskStatus.SetTextColor(rootActivity.GetTextColorByTheme());
			lblTheme.SetTextColor(rootActivity.GetTextColorByTheme());
			lblServerConnection.SetTextColor(rootActivity.GetTextColorByTheme());

            lblEventsMaxValue.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));
            lblEventsDurationValue.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));
            lblDiskUsageValue.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));

            lblServerIP.SetTextColor(rootActivity.GetTextColorByTheme(false));
            lblPort.SetTextColor(rootActivity.GetTextColorByTheme(false));
            lblPassword.SetTextColor(rootActivity.GetTextColorByTheme(false));

			bgEditEventsMax.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SLIDER));
			bgEditEventsDuration.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SLIDER));
			bgEditDiskUsage.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SLIDER));
			bgEditServerIP.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SETTINGS));
			bgEditPort.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SETTINGS));
			bgEditPassword.SetImageResource(rootActivity.GetImageByTheme(FN_BG_TEXT_SETTINGS));

            txtServerIP.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));
            txtPort.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));
            txtPassword.SetTextColor(rootActivity.GetToggleTextColorByTheme(true));

            btnScanQR.SetImageResource(rootActivity.GetImageByTheme(FN_BG_BTN_SCAN_QR_SETTINGS));

            viewLineSeperator1.SetBackgroundColor(rootActivity.GetLineSeperatorColorByTheme());
            viewLineSeperator2.SetBackgroundColor(rootActivity.GetLineSeperatorColorByTheme());
            viewLineSeperator3.SetBackgroundColor(rootActivity.GetLineSeperatorColorByTheme());
            viewLineSeperator4.SetBackgroundColor(rootActivity.GetLineSeperatorColorByTheme());

            var progressResource = AppSettings.CurrentTheme == TYPE_THEME.DARK ? Resource.Drawable.item_seekBar_dark : Resource.Drawable.item_seekBar_light;
            sliderEventsMax.ProgressDrawable = Resources.GetDrawable(progressResource);
            sliderEventsDuration.ProgressDrawable = Resources.GetDrawable(progressResource);
            sliderDiskStatus.ProgressDrawable = Resources.GetDrawable(progressResource);

            var thumbResource = AppSettings.CurrentTheme == TYPE_THEME.DARK ? Resource.Drawable.item_seekBarThumb_dark : Resource.Drawable.item_seekBarThumb_light;
            sliderEventsMax.SetThumb(Resources.GetDrawable(thumbResource));
            sliderEventsDuration.SetThumb(Resources.GetDrawable(thumbResource));
        }

        private void ActionToggleTheme(object sender, EventArgs e)
        {
            var toggle = sender as CheckBox;

            AppSettings.CurrentTheme = toggle.Checked ? TYPE_THEME.LIGHT : TYPE_THEME.DARK;

			InitTheme();
            rootActivity.InitTheme();

			rootActivity.RequestedOrientation = ScreenOrientation.Portrait;
        }

		private void ActionScanQR(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}
	}
}
