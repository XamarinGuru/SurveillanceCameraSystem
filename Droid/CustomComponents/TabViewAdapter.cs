using System;
using Android.Support.V4.App;
using SCS.Fragments;

namespace SCS.CustomComponents
{
	public class TabViewAdapter : FragmentPagerAdapter
	{
		public event EventHandler TabChanged;

		public TabViewAdapter(FragmentManager fm, FragmentActivity activity) : base(fm)
		{
		}

		public override int Count
		{
			get { return 4; }
		}

		public override Fragment GetItem(int position)
		{
            if (position == 0) return new DashboardFragment();
            if (position == 1) return new CameraFragment();
            if (position == 2) return new SettingsFragment();
            if (position == 3) return new HelpFragment();

			TabChanged?.Invoke(position, null);

			return null;
		}
	}
}
