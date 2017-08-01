
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace SCS.Activities
{
	[Activity(Label = "LoginActivity", ScreenOrientation = ScreenOrientation.Portrait)]
	public class LoginActivity : BaseActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.LoginActivity);

            InitUISettings();
			InitTheme();
		}

		void InitUISettings()
		{
            FindViewById<ImageButton>(Resource.Id.ActionLogin).Click += ActionLogin;
			//FindViewById<ImageView>(Resource.Id.ActionBack).Click += ActionBack;
			//FindViewById<Button>(Resource.Id.ActionForgotPassword).Click += ActionForgotPassword;

			//txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
			//txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

			//invalidEmail = FindViewById<ImageView>(Resource.Id.invalidEmail);
			//invalidPassword = FindViewById<ImageView>(Resource.Id.invalidPassword);
			//errorEmail = FindViewById<LinearLayout>(Resource.Id.errorEmail);
			//errorPassword = FindViewById<LinearLayout>(Resource.Id.errorPassword);

			//invalidEmail.Visibility = ViewStates.Invisible;
			//invalidPassword.Visibility = ViewStates.Invisible;
			//errorEmail.Visibility = ViewStates.Invisible;
			//errorPassword.Visibility = ViewStates.Invisible;

			//FindViewById<Button>(Resource.Id.ActionLogin).SetBackgroundColor(GROUP_COLOR);
		}

		public override void InitTheme()
		{
			//imgBackground.Image = GetImageByTheme(FN_BACKGROUND);
			//imgLogo.Image = GetImageByTheme(FN_LOGO);
			//bgEditServerIp.Image = GetImageByTheme(FN_BG_EDIT_SERVER_IP);
			//bgEditPort.Image = GetImageByTheme(FN_BG_EDIT_PORT);
			//bgEditPSW.Image = GetImageByTheme(FN_BG_EDIT_PSW);
			//btnLogin.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_LOGIN), UIControlState.Normal);
			//btnScanQR.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SCAN_QR), UIControlState.Normal);

			//lblServerIP.TextColor = GetTextColorByTheme();
			//lblPort.TextColor = GetTextColorByTheme();
			//lblPassword.TextColor = GetTextColorByTheme();
			//txtServerIP.TextColor = GetTextColorByTheme();
			//txtPort.TextColor = GetTextColorByTheme();
			//txtPassword.TextColor = GetTextColorByTheme();

			//lblOR.TextColor = GetTextColorByTheme(false);
			//lblQRDescription.TextColor = GetTextColorByTheme(false);

			//viewLSeperator.BackgroundColor = GetTextColorByTheme(false);
			//viewRSeperator.BackgroundColor = GetTextColorByTheme(false);
		}

        void ActionLogin(object sender, EventArgs e)
        {
            Intent nextIntent = new Intent(this, typeof(TabBarActivity));
            StartActivityForResult(nextIntent, 0);
            Finish();
        }
	}
}
