
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
    public class SettingsFragment : Android.Support.V4.App.Fragment
    {
        BaseActivity rootActivity;
        View mView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			rootActivity = this.Activity as BaseActivity;
            return inflater.Inflate(Resource.Layout.SettingsFragment, container, false);
        }

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			mView = view;

			//SetUISettings();
		}
    }
}
