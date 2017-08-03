using System;
using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Util;
using SCS.Fragments;

namespace SCS.CustomComponents
{
	public class TabViewAdapter : FragmentPagerAdapter
	{
		public event EventHandler TabChanged;
        public SparseArray<BaseFragment> registeredFragments = new SparseArray<BaseFragment>();

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

        public override Java.Lang.Object InstantiateItem(Android.Views.ViewGroup container, int position)
        {
            var fragment = base.InstantiateItem(container, position) as BaseFragment;
            registeredFragments.Put(position, fragment);
            return fragment;
        }

        public override void DestroyItem(Android.Views.ViewGroup container, int position, Java.Lang.Object objectValue)
        {
            registeredFragments.Remove(position);
            base.DestroyItem(container, position, objectValue);
        }

        public BaseFragment GetRegisteredFragment(int position)
        {
            return registeredFragments.Get(position);
        }
	}
}
