using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using SCS.ViewModels;
using static SCS.Constants;

namespace SCS.CustomComponents
{
    public class CamerViewListAdapter : BaseAdapter
    {
        Context context;
        List<CameraListItem> _items;

        public CamerViewListAdapter(Context c, List<CameraListItem> items)
        {
            context = c;
            _items = items;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View viewCameraListItem = LayoutInflater.From(context).Inflate(Resource.Layout.item_cameraListView, null); ;

            var item = _items[position];
            var imgBackground = viewCameraListItem.FindViewById<ImageView>(Resource.Id.imgBackground);
            var imgAction = viewCameraListItem.FindViewById<ImageView>(Resource.Id.imgAction);
            var lblAction = viewCameraListItem.FindViewById<TextView>(Resource.Id.lblAction);
            var lblTime = viewCameraListItem.FindViewById<TextView>(Resource.Id.lblTime);

            if (item.imgData != null)
            {
                var imageBitmap = BitmapFactory.DecodeByteArray(item.imgData, 0, item.imgData.Length);
                imgBackground.SetImageBitmap(imageBitmap);
            }

			switch (item.type)
			{
				case TYPE_ACTION.MOTION:
                    imgAction.SetImageResource(Resource.Drawable.icon_motiondetect_inactie_dark);
					lblAction.Text = "MOTION";
					break;
				case TYPE_ACTION.CAMERA:
                    imgAction.SetImageResource(Resource.Drawable.icon_cameradisconnect_inactive_dark);
					lblAction.Text = "CAMERA";
					break;
				case TYPE_ACTION.NOTIFICATION:
					imgAction.SetImageResource(Resource.Drawable.icon_notification_inactie_dark);
					lblAction.Text = "NOTIFICATION";
					break;
				case TYPE_ACTION.TRIPWIRE:
					imgAction.SetImageResource(Resource.Drawable.icon_tripwire_inactie_dark);
					lblAction.Text = "TRIPWIRE";
					break;
				case TYPE_ACTION.SOUNDER:
					imgAction.SetImageResource(Resource.Drawable.icon_sounder_inactie_dark);
					lblAction.Text = "SOUNDER";
					break;
			}
			lblTime.Text = item.time;

            return viewCameraListItem;
        }
    }
}
