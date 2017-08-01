using System;
using UIKit;
using CoreGraphics;
using static SCS.Constants;
using System.Collections.Generic;
using SCS.ViewModels;

namespace SCS.iOS
{
    public partial class DashboardViewController : BaseViewController
    {
        public DashboardViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitTheme();
            InitCameraSystem();
        }

        public override void InitTheme()
        {
            btnCameraFront.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_BACK), UIControlState.Normal);
            btnCameraFront.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_FRONT), UIControlState.Selected);
            btnCameraBack.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_BACK), UIControlState.Normal);
            btnCameraBack.SetBackgroundImage(GetImageByTheme(FN_ICON_CAMERA_FRONT), UIControlState.Selected);

            lblRecentActivity.TextColor = GetTextColorByTheme();

            btnSymbolNumber.SetBackgroundImage(GetImageByTheme(FN_BG_BTN_SYMBOL_NUMBER), UIControlState.Normal);
        }

        void InitCameraSystem()
        {
            #region get dummy data
            var dummyData = GetDummyData();
            #endregion

            btnSymbolNumber.SetTitle(dummyData.Count.ToString(), UIControlState.Normal);

            viewCameraListView.LayoutIfNeeded();
            nfloat posX = 0;
            nfloat posY = 0;
            var width = View.Frame.Size.Width / 3;
            var height = 80;

            for (var i = 0; i < dummyData.Count; i++)
            {
                posX = i % 3 == 0 ? 0 : posX + width;
                posY = i % 3 != 0 || i == 0 ? posY : posY + height + 1;
                var rect = new CGRect(posX, posY, width, height);

                CameraListView cv = CameraListView.Create(rect);
                #region binding data
                cv.SetView(dummyData[i]);
                #endregion
                viewCameraListView.AddSubview(cv);
            }

            heightViewCameraListView.Constant = posY + height;
        }

        partial void ActionCameraRecord(UIButton sender)
        {
            sender.Selected = !sender.Selected;
            if (sender.Selected)
            {
                if (sender.Tag == 0)
                    HandlerCamera1StartRecord();
                else
                    HandlerCamera2StartRecord();
            }
            else
            {
                if (sender.Tag == 0)
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

        #region Dummy data Generator
        public List<CameraListItem> GetDummyData()
        {
            var returnData = new List<CameraListItem>();
            for (int i = 0; i < 20; i++)
            {
                returnData.Add(new CameraListItem(TYPE_ACTION.TRIPWIRE, null, String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now)));
            }
            return returnData;
        }
        #endregion
    }
}