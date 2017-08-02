using System;
using System.Collections.Generic;
using Android.Animation;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using SCS.Activities;
using SCS.CustomComponents;
using SCS.ViewModels;
using static SCS.Constants;

namespace SCS.Fragments
{
	public class DashboardFragment : Android.Support.V4.App.Fragment
	{
		BaseActivity rootActivity;
        View mView;

        TextView lblSymbolNumber;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			rootActivity = this.Activity as BaseActivity;
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
            var gridview = mView.FindViewById<GridView>(Resource.Id.listViewCamera);

			#region get dummy data
			var dummyData = GetDummyData();
			#endregion
			gridview.Adapter = new CamerViewListAdapter(rootActivity, dummyData);
            SetGridViewHeightBasedOnChildren(gridview, 3);

			lblSymbolNumber = mView.FindViewById<TextView>(Resource.Id.lblSymbolNumber);
            lblSymbolNumber.Text = dummyData.Count.ToString();

            #endregion


			#region Actions
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsCycle).Click += ActionCollepse;
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsRun).Click += ActionCollepse;
			//mView.FindViewById<RelativeLayout>(Resource.Id.collapsSwim).Click += ActionCollepse;
			//mView.FindViewById<Button>(Resource.Id.ActionViewCalendar).Click += ActionViewCalendar;

			//mView.FindViewById<Button>(Resource.Id.ActionViewCalendar).SetBackgroundColor(rootActivity.GROUP_COLOR);
			#endregion
		}

		public List<CameraListItem> GetDummyData()
		{
			var returnData = new List<CameraListItem>();
			for (int i = 0; i < 20; i++)
			{
				returnData.Add(new CameraListItem(TYPE_ACTION.TRIPWIRE, null, String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now)));
			}
			return returnData;
		}

		public void SetGridViewHeightBasedOnChildren(GridView gridView, int columns)
		{
            IListAdapter listAdapter = gridView.Adapter;
			if (listAdapter == null)
			{
				// pre-condition
				return;
			}

			int totalHeight = 0;
            int items = listAdapter.Count;
			int rows = 0;

            View listItem = listAdapter.GetView(0, null, gridView);
            listItem.Measure(0, 0);
            totalHeight = listItem.MeasuredHeight;

			float x = 1;
			if (items > columns)
			{
				x = items / columns;
				rows = (int)(x + 1);
				totalHeight *= rows;
			}

            ViewGroup.LayoutParams p = gridView.LayoutParameters;
            p.Height = totalHeight;
            gridView.LayoutParameters = p;
		}
	}
}
