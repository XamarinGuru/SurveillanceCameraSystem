
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

namespace SCS.Fragments
{
    public class HelpFragment : Android.Support.V4.App.Fragment
    {
		BaseActivity rootActivity;
		View mView;

		TextView lblVersion, lblDescription;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			rootActivity = this.Activity as BaseActivity;
            return inflater.Inflate(Resource.Layout.HelpFragment, container, false);
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
            lblVersion = mView.FindViewById<TextView>(Resource.Id.lblVersion);
            lblDescription = mView.FindViewById<TextView>(Resource.Id.lblDescription);
        }

        void InitTheme()
        {
            lblVersion.SetTextColor(rootActivity.GetTextColorByTheme());
            lblDescription.SetTextColor(rootActivity.GetDescriptionColorByTheme());
        }
	}
}
