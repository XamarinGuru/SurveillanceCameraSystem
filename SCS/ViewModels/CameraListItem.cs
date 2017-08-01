using System;
using static SCS.Constants;

namespace SCS.ViewModels
{
	public class CameraListItem
	{
        public CameraListItem(TYPE_ACTION type = TYPE_ACTION.TRIPWIRE, byte[] imgData = null, string time = "")
        {
            this.type = type;
            this.imgData = imgData;
            this.time = time;
        }
		public TYPE_ACTION type { get; set; }
		public byte[] imgData { get; set; }
		public string time { get; set; }
	}
}
