﻿using System;
using Android.Views;

namespace SCS.Droid
{
    public class RecyclerClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}