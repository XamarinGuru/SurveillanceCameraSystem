using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using SCS.Activities;
using SCS.CustomComponents;
using SCS.Helpers;
using SCS.ViewModels;
using static SCS.Constants;

namespace SCS.Fragments
{
	public class DashboardFragment : BaseFragment
	{
        CheckBox btnCamera1, btnCamera2;
        TextView lblRecentActivity, lblSymbolNumber;
        ImageView imgSymbolNumber;

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			rootActivity = this.Activity as BaseActivity;
            return inflater.Inflate(Resource.Layout.DashboardFragment, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			mView = view;

			InitUISettings();
			InitTheme();
		}

		private void InitUISettings()
		{
            btnCamera1 = mView.FindViewById<CheckBox>(Resource.Id.btnCamera1);
            btnCamera2 = mView.FindViewById<CheckBox>(Resource.Id.btnCamera2);
            btnCamera1.Click += ActionCameraRecord;
            btnCamera2.Click += ActionCameraRecord;

            lblRecentActivity = mView.FindViewById<TextView>(Resource.Id.lblRecentActivity);
			lblSymbolNumber = mView.FindViewById<TextView>(Resource.Id.lblSymbolNumber);

            imgSymbolNumber = mView.FindViewById<ImageView>(Resource.Id.imgSymbolNumber);

			var gridview = mView.FindViewById<GridView>(Resource.Id.listViewCamera);
			var dummyData = GetDummyData();
			gridview.Adapter = new CamerViewListAdapter(rootActivity, dummyData);
			SetGridViewHeightBasedOnChildren(gridview, 3);

            lblSymbolNumber.Text = dummyData.Count.ToString();
		}



        public override void InitTheme()
        {
            var cameraResource = AppSettings.CurrentTheme == TYPE_THEME.DARK ? Resource.Drawable.item_btnCameraRecord_dark : Resource.Drawable.item_btnCameraRecord_light;
            btnCamera1.SetBackgroundResource(cameraResource);
			btnCamera2.SetBackgroundResource(cameraResource);

            lblRecentActivity.SetTextColor(rootActivity.GetTextColorByTheme());

            imgSymbolNumber.SetImageResource(rootActivity.GetImageByTheme(FN_BG_BTN_SYMBOL_NUMBER));
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

		private void ActionCameraRecord(object sender, EventArgs e)
		{
			var cameraRecord = sender as CheckBox;
			var nCamera = int.Parse(cameraRecord.Tag.ToString());
			if (cameraRecord.Checked)
			{
				if (nCamera == 0)
					HandlerCamera1StartRecord();
				else
					HandlerCamera2StartRecord();
			}
			else
			{
				if (nCamera == 0)
					HandlerCamera1StopRecord();
				else
					HandlerCamera2StopRecord();
			}
		}

		#region Handlers
		void HandlerCamera1StartRecord()
		{
			//ShowMessageBox("Started Record.", "Camera1 started record.");
		}
		void HandlerCamera1StopRecord()
		{
			//ShowMessageBox("Stoped Record", "Camera1 stoped record.");
		}
		void HandlerCamera2StartRecord()
		{
			//ShowMessageBox("Started Record.", "Camera2 started record.");
		}
		void HandlerCamera2StopRecord()
		{
			//ShowMessageBox("Stoped Record", "Camera2 stoped record.");
		}
		#endregion

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
