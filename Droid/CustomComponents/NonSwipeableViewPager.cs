using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Util;
using Android.Views;

namespace SCS.CustomComponents
{
	public class NonSwipeableViewPager : ViewPager
	{
		bool isEnable;

		public NonSwipeableViewPager(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{

		}

		public NonSwipeableViewPager(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			this.isEnable = true;
		}


		public override bool OnTouchEvent(MotionEvent e)
		{
			if (this.isEnable)
			{
				return base.OnTouchEvent(e);
			}
			return false;
		}

		public override bool OnInterceptTouchEvent(MotionEvent ev)
		{
			if (this.isEnable)
			{
				return base.OnInterceptTouchEvent(ev);
			}
			return false;
		}

		public void SetPagingEnabled(bool enabled)
		{
			this.isEnable = enabled;
		}
	}
}
