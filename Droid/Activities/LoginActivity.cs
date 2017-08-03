
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using static SCS.Constants;

namespace SCS.Activities
{
	[Activity(Label = "LoginActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class LoginActivity : BaseActivity
	{
		ImageView imgBackground, imgLogo, bgEditServerIp, bgEditPort, bgEditPSW;
        ImageButton btnLogin, btnScanQR;
        TextView lblServerIP, lblPort, lblPassword, lblOR, lblQRDescription;
        EditText txtServerIP, txtPort, txtPassword;
        LinearLayout viewLSeperator, viewRSeperator;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LoginActivity);

            InitUISettings();
			InitTheme();
		}

		void InitUISettings()
		{
            imgBackground = FindViewById<ImageView>(Resource.Id.imgBackground);
            imgLogo = FindViewById<ImageView>(Resource.Id.imgLogo);
            bgEditServerIp = FindViewById<ImageView>(Resource.Id.bgEditServerIp);
            bgEditPort = FindViewById<ImageView>(Resource.Id.bgEditPort);
            bgEditPSW = FindViewById<ImageView>(Resource.Id.bgEditPSW);

            btnLogin = FindViewById<ImageButton>(Resource.Id.btnLogin);
			btnScanQR = FindViewById<ImageButton>(Resource.Id.btnScanQR);

            btnLogin.Click += ActionLogin;

			lblServerIP = FindViewById<TextView>(Resource.Id.lblServerIP);
			lblPort = FindViewById<TextView>(Resource.Id.lblPort);
			lblPassword = FindViewById<TextView>(Resource.Id.lblPassword);

			txtServerIP = FindViewById<EditText>(Resource.Id.txtServerIP);
			txtPort = FindViewById<EditText>(Resource.Id.txtPort);
			txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

			lblOR = FindViewById<TextView>(Resource.Id.lblOR);
			lblQRDescription = FindViewById<TextView>(Resource.Id.lblQRDescription);

            viewLSeperator = FindViewById<LinearLayout>(Resource.Id.viewLSeperator);
			viewRSeperator = FindViewById<LinearLayout>(Resource.Id.viewRSeperator);
		}

		public override void InitTheme()
		{
            imgBackground.SetImageResource(GetImageByTheme(FN_BACKGROUND));
            imgLogo.SetImageResource(GetImageByTheme(FN_LOGO));

            bgEditServerIp.SetImageResource(GetImageByTheme(FN_BG_EDIT_SERVER_IP));
            bgEditPort.SetImageResource(GetImageByTheme(FN_BG_EDIT_PORT));
            bgEditPSW.SetImageResource(GetImageByTheme(FN_BG_EDIT_PSW));

			btnLogin.SetImageResource(GetImageByTheme(FN_BG_BTN_LOGIN));
			btnScanQR.SetImageResource(GetImageByTheme(FN_BG_BTN_SCAN_QR));

            lblServerIP.SetTextColor(GetTextColorByTheme());
            lblPort.SetTextColor(GetTextColorByTheme());
            lblPassword.SetTextColor(GetTextColorByTheme());

            txtServerIP.SetTextColor(GetTextColorByTheme());
            txtPort.SetTextColor(GetTextColorByTheme());
            txtPassword.SetTextColor(GetTextColorByTheme());

            lblOR.SetTextColor(GetTextColorByTheme(false));
            lblQRDescription.SetTextColor(GetTextColorByTheme(false));

            viewLSeperator.SetBackgroundColor(GetTextColorByTheme(false));
            viewRSeperator.SetBackgroundColor(GetTextColorByTheme(false));
		}

        void ActionLogin(object sender, EventArgs e)
        {
            Intent nextIntent = new Intent(this, typeof(TabBarActivity));
            StartActivityForResult(nextIntent, 0);
            Finish();
        }
	}
}
