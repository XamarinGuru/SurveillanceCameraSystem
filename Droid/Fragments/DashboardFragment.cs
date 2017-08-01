using System;
using Android.Animation;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SCS.Fragments
{
	public class DashboardFragment : Android.Support.V4.App.Fragment
	{
		//SwipeTabActivity rootActivity;

		public View mView;

		TextView lblCycleDuration, lblRunDuration, lblSwimDuration, lblCycleDistance, lblRunDistance, lblSwimDistance, lblCycleStress, lblRunStress, lblSwimStress;
		ImageView btnCycle, btnRun, btnSwim;
		LinearLayout viewCycle, viewRun, viewSwim;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			//rootActivity = this.Activity as SwipeTabActivity;
            return inflater.Inflate(Resource.Layout.DashboardFragment, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			mView = view;

			SetUISettings();
		}

		private void SetUISettings()
		{
			#region UI Variables
			//lblCycleDuration = mView.FindViewById<TextView>(Resource.Id.lblCycleDuration);
			//lblRunDuration = mView.FindViewById<TextView>(Resource.Id.lblRunDuration);
			//lblSwimDuration = mView.FindViewById<TextView>(Resource.Id.lblSwimDuration);
			//lblCycleDistance = mView.FindViewById<TextView>(Resource.Id.lblCycleDistance);
			//lblRunDistance = mView.FindViewById<TextView>(Resource.Id.lblRunDistance);
			//lblSwimDistance = mView.FindViewById<TextView>(Resource.Id.lblSwimDistance);
			//lblCycleStress = mView.FindViewById<TextView>(Resource.Id.lblCycleStress);
			//lblRunStress = mView.FindViewById<TextView>(Resource.Id.lblRunStress);
			//lblSwimStress = mView.FindViewById<TextView>(Resource.Id.lblSwimStress);

			//mView.FindViewById<TextView>(Resource.Id.lblCycleDurationTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblRunDurationTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblSwimDurationTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblCycleDistanceTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblRunDistanceTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblSwimDistanceTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblCycleStressTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblRunStressTitle).SetTextColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<TextView>(Resource.Id.lblSwimStressTitle).SetTextColor(rootActivity.GROUP_COLOR);

			//lblCycleDuration.SetTextColor(rootActivity.GROUP_COLOR);
			//lblRunDuration.SetTextColor(rootActivity.GROUP_COLOR);
			//lblSwimDuration.SetTextColor(rootActivity.GROUP_COLOR);
			//lblCycleDistance.SetTextColor(rootActivity.GROUP_COLOR);
			//lblRunDistance.SetTextColor(rootActivity.GROUP_COLOR);
			//lblSwimDistance.SetTextColor(rootActivity.GROUP_COLOR);
			//lblCycleStress.SetTextColor(rootActivity.GROUP_COLOR);
			//lblRunStress.SetTextColor(rootActivity.GROUP_COLOR);
			//lblSwimStress.SetTextColor(rootActivity.GROUP_COLOR);

			//mView.FindViewById<LinearLayout>(Resource.Id.bgSymbolCycling).SetBackgroundColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<LinearLayout>(Resource.Id.bgSymbolRunning).SetBackgroundColor(rootActivity.GROUP_COLOR);
			//mView.FindViewById<LinearLayout>(Resource.Id.bgSymbolSwimming).SetBackgroundColor(rootActivity.GROUP_COLOR);

			//btnCycle = mView.FindViewById<ImageView>(Resource.Id.btnCycle);
			//btnRun = mView.FindViewById<ImageView>(Resource.Id.btnRun);
			//btnSwim = mView.FindViewById<ImageView>(Resource.Id.btnSwim);

			//viewCycle = mView.FindViewById<LinearLayout>(Resource.Id.viewCycle);
			//viewRun = mView.FindViewById<LinearLayout>(Resource.Id.viewRun);
			//viewSwim = mView.FindViewById<LinearLayout>(Resource.Id.viewSwim);

            #endregion


			#region Actions
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsCycle).Click += ActionCollepse;
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsRun).Click += ActionCollepse;
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsSwim).Click += ActionCollepse;
			//mView.FindViewById<Button>(Resource.Id.ActionViewCalendar).Click += ActionViewCalendar;

			//mView.FindViewById<Button>(Resource.Id.ActionViewCalendar).SetBackgroundColor(rootActivity.GROUP_COLOR);
			#endregion
		}


	}
}
