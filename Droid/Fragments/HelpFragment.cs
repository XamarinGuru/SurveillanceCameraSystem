
using Android.OS;
using Android.Views;
using Android.Widget;
using SCS.Activities;

namespace SCS.Fragments
{
    public class HelpFragment : BaseFragment
    {
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

        public override void InitTheme()
        {
            lblVersion.SetTextColor(rootActivity.GetTextColorByTheme());
            lblDescription.SetTextColor(rootActivity.GetDescriptionColorByTheme());
        }
	}
}
