using Android.OS;
using Android.Views;
using SCS.Activities;

namespace SCS.Fragments
{
	public class BaseFragment : Android.Support.V4.App.Fragment
	{
        public virtual void InitTheme() { }
		public BaseActivity rootActivity;
		public View mView;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			rootActivity = this.Activity as BaseActivity;
			return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			mView = view;
		}
    }
}
