using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SCS.iOS.CustomComponents
{
	[Preserve(AllMembers = true), Register("RangeSliderControl"), DesignTimeVisible(true)]
	public partial class RangeSliderControl : UIControl
	{
		private const string KeyPath = "frame";

		private UIImageView _lowerHandle;

		private bool _lowerHandleHidden;

		private float _lowerHandleHiddenWidth;
		private UIImage _lowerHandleImageHighlighted;

		private UIImage _lowerHandleImageNormal;

		private float _lowerMaximumValue;

		private UIEdgeInsets _lowerTouchEdgeInsets;

		private float _lowerTouchOffset;
		private float _stepValueInternal;

		private UIImageView _track;
		private UIImageView _trackBackground;

		private UIImage _trackBackgroundImage;

		private UIImage _trackCrossedOverImage;

		private UIImage _trackImage;

		private UIImageView _upperHandle;
		private bool _upperHandleHidden;
		private float _upperHandleHiddenWidth;
		private UIImage _upperHandleImageHighlighted;

		private UIImage _upperHandleImageNormal;

		private float _upperMinimumValue;

		private UIEdgeInsets _upperTouchEdgeInsets;
		private float _upperTouchOffset;

		public RangeSliderControl()
		{
			ConfigureView();
		}

		public RangeSliderControl(IntPtr handle) : base(handle)
		{
			ConfigureView();
		}

		public RangeSliderControl(NSCoder coder) : base(coder)
		{
			ConfigureView();
		}

		public RangeSliderControl(CGRect frame) : base(frame)
		{
			ConfigureView();
		}

		/// <summary>
		///     defafult true, indicating whether changes in the sliders value generate continuous update events.
		/// </summary>
		[Export("Continuous")]
		[Browsable(true)]
		public bool Continuous { get; set; }

		/// <summary>
		///     default 0.0. this value will be pinned to min/max
		/// </summary>
		[Export("LowerValue")]
		[Browsable(true)]
		public float LowerValue { get; set; }

		/// <summary>
		///     default 1.0
		/// </summary>
		[Export("MaximumValue")]
		[Browsable(true)]
		public float MaximumValue { get; set; }

		/// <summary>
		///     default 0.0. This is the minimum distance between between the upper and lower values
		/// </summary>
		[Export("MinimumRange")]
		[Browsable(true)]
		public float MinimumRange { get; set; }

		[Export("MinimumValue")]
		[Browsable(true)]
		public float MinimumValue { get; set; }

		/// <summary>
		///     default 0.0 (disabled)
		/// </summary>
		[Export("StepValue")]
		[Browsable(true)]
		public float StepValue { get; set; }

		/// <summary>
		/// If false the slider will move freely with the tounch. When the touch ends, the value will snap to the nearest step value
		/// If true the slider will stay in its current position until it reaches a new step value.
		/// default false
		/// </summary>
		[Export("StepValueContinuously")]
		[Browsable(true)]
		public bool StepValueContinuously { get; set; }

		/// <summary>
		///     default 1.0. this value will be pinned to min/max
		/// </summary>
		[Export("UpperValue")]
		[Browsable(true)]
		public float UpperValue { get; set; }

		[Export("LowerHandleHidden")]
		[Browsable(true)]
		public bool LowerHandleHidden
		{
			get { return _lowerHandleHidden; }
			set
			{
				_lowerHandleHidden = value;
				SetNeedsLayout();
			}
		}

		[Export("UpperHandleHidden")]
		[Browsable(true)]
		public bool UpperHandleHidden
		{
			get { return _upperHandleHidden; }
			set
			{
				_upperHandleHidden = value;
				SetNeedsLayout();
			}
		}

		[Export("TrackBackgroundImage")]
		[Browsable(true)]
		public UIImage TrackBackgroundImage
		{
			get
			{
				if (_trackBackgroundImage != null)
					return _trackBackgroundImage;

				var image = ImageFromBundle(@"bg_slider1_dark");
				image = image.CreateResizableImage(new UIEdgeInsets(0.0f, 2.0f, 0.0f, 2.0f));
				_trackBackgroundImage = image;

				return _trackBackgroundImage;
			}
		}

		[Export("TrackImage")]
		[Browsable(true)]
		public UIImage TrackImage
		{
			get
			{
				if (_trackImage != null)
					return _trackImage;

				var image = ImageFromBundle(@"bg_slider_track1_dark");
				image = image.CreateResizableImage(new UIEdgeInsets(0.0f, 2.0f, 0.0f, 2.0f));
				//image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
				_trackImage = image;

				return _trackImage;
			}
            set
            {
                _trackImage = value;
            }
		}

		[Export("TrackCrossedOverImage")]
		[Browsable(true)]
		private UIImage TrackCrossedOverImage
		{
			get
			{
				if (_trackCrossedOverImage != null)
					return _trackCrossedOverImage;
				var image = ImageFromBundle(@"icon_slider_thumb_dark");
				_trackCrossedOverImage = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(-1, 8, 1, 8));

				return _trackCrossedOverImage;
			}
		}

		[Export("LowerHandleImageNormal")]
		[Browsable(true)]
		private UIImage LowerHandleImageNormal
		{
			get
			{
				if (_lowerHandleImageNormal != null)
					return _lowerHandleImageNormal;
				var image = ImageFromBundle(@"icon_slider_thumb_dark");
				_lowerHandleImageNormal = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(-1, 8, 1, 8));

				return _lowerHandleImageNormal;
			}
		}

		[Export("LowerHandleImageHighlighted")]
		[Browsable(true)]
		private UIImage LowerHandleImageHighlighted
		{
			get
			{
				if (_lowerHandleImageHighlighted != null)
					return _lowerHandleImageHighlighted;
				var image = ImageFromBundle(@"icon_slider_thumb_dark");
				_lowerHandleImageHighlighted = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(-1, 8, 1, 8));

				return _lowerHandleImageHighlighted;
			}
		}

		[Export("UpperHandleImageNormal")]
		[Browsable(true)]
		private UIImage UpperHandleImageNormal
		{
			get
			{
				if (_upperHandleImageNormal != null)
					return _upperHandleImageNormal;

				var image = ImageFromBundle(@"icon_slider_thumb_dark");
				_upperHandleImageNormal = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(-1, 8, 1, 8));


				return _upperHandleImageNormal;
			}
		}

		[Export("UpperHandleImageHighlighted")]
		[Browsable(true)]
		private UIImage UpperHandleImageHighlighted
		{
			get
			{
				if (_upperHandleImageHighlighted != null)
					return _upperHandleImageHighlighted;

				var image = ImageFromBundle(@"icon_slider_thumb_dark");
				_upperHandleImageHighlighted = image.ImageWithAlignmentRectInsets(new UIEdgeInsets(-1, 8, 1, 8));

				return _upperHandleImageHighlighted;
			}
		}

		private UIImage TrackImageForCurrentValues => LowerValue <= UpperValue ? TrackImage : TrackCrossedOverImage;

		public event EventHandler LowerValueChanged;
		public event EventHandler UpperValueChanged;
		public event EventHandler DragStarted;
		public event EventHandler DragCompleted;

		private static bool IS_PRE_IOS7()
		{
			return int.Parse(UIDevice.CurrentDevice.SystemVersion.Split('.')[0]) < 7;
		}

		private void ConfigureView()
		{
			//Setup the default values
			MinimumValue = 0f;
			MaximumValue = 1f;
			MinimumRange = 0f;
			StepValue = 0f;
			_stepValueInternal = 0.0f;

			Continuous = true;

			LowerValue = MinimumValue;
			UpperValue = MaximumValue;

			_lowerMaximumValue = float.NaN;
			_upperMinimumValue = float.NaN;
			_upperHandleHidden = false;
			_lowerHandleHidden = false;

			_lowerHandleHiddenWidth = 2.0f;
			_upperHandleHiddenWidth = 2.0f;

			_lowerTouchEdgeInsets = new UIEdgeInsets(-5, -5, -5, -5);
			_upperTouchEdgeInsets = new UIEdgeInsets(-5, -5, -5, -5);

			AddSubviews();

			_lowerHandle.AddObserver(this, KeyPath, NSKeyValueObservingOptions.New, IntPtr.Zero);
			_upperHandle.AddObserver(this, KeyPath, NSKeyValueObservingOptions.New, IntPtr.Zero);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_lowerHandle.RemoveObserver(this, KeyPath);
				_upperHandle.RemoveObserver(this, KeyPath);
			}
		}

		public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		{
			if (keyPath == KeyPath)
			{
				if (Equals(ofObject, _lowerHandle))
				{
				}
				else if (Equals(ofObject, _upperHandle))
				{
				}
			}
		}


		private void SetLowerValue(float lowerValue)
		{
			var value = lowerValue;

			if (_stepValueInternal > 0)
			{
				value = (float)Math.Round(value / _stepValueInternal) * _stepValueInternal;
			}

			value = Math.Min(value, MaximumValue);
			value = Math.Max(value, MinimumValue);

			if (!float.IsNaN(_lowerMaximumValue))
			{
				value = Math.Min(value, _lowerMaximumValue);
			}

			value = Math.Min(value, UpperValue - MinimumRange);

			LowerValue = value;

			SetNeedsLayout();

			OnLowerValueChanged();
		}

		private void SetUpperValue(float upperValue)
		{
			var value = upperValue;

			if (_stepValueInternal > 0)
			{
				value = (float)Math.Round(value / _stepValueInternal) * _stepValueInternal;
			}

			value = Math.Max(value, MinimumValue);
			value = Math.Min(value, MaximumValue);

			if (!float.IsNaN(_upperMinimumValue))
			{
				value = Math.Max(value, _upperMinimumValue);
			}

			value = Math.Max(value, LowerValue + MinimumRange);

			UpperValue = value;

			SetNeedsLayout();

			OnUpperValueChanged();
		}


		private void SetLowerValue(float lowerValue, float upperValue, bool animated)
		{
			if (!animated && (float.IsNaN(lowerValue) || Math.Abs(lowerValue - LowerValue) < float.Epsilon) &&
				(float.IsNaN(upperValue) || Math.Abs(upperValue - UpperValue) < float.Epsilon))
			{
				//nothing to set
				return;
			}

			Action setValuesBlock = () =>
			{
				if (!float.IsNaN(lowerValue))
				{
					SetLowerValue(lowerValue);
				}
				if (!float.IsNaN(upperValue))
				{
					SetUpperValue(upperValue);
				}
			};

			if (animated)
			{
				AnimateNotify(0.25d, 0d, UIViewAnimationOptions.BeginFromCurrentState, () =>
				{
					setValuesBlock();
					LayoutSubviews();
				}, finished => { });
			}
			else
			{
				setValuesBlock();
			}
		}

		private void SetLowerValue(float lowerValue, bool animated)
		{
			SetLowerValue(lowerValue, float.NaN, animated);
		}

		private void SetUpperValue(float upperValue, bool animated)
		{
			SetLowerValue(float.NaN, upperValue, animated);
		}

		/// <summary>
		/// ON-Demand images. If the images are not set, then the default values are loaded.
		/// </summary>
		private UIImage ImageFromBundle(string imageName)
		{
			return UIImage.FromFile(imageName);
		}

		/// <summary>
		/// Returns the lower value based on the X potion
		/// The return value is automatically adjust to fit inside the valid range
		/// </summary>
		private float LowerValueForCenterX(float x)
		{
			var padding = (float)_lowerHandle.Frame.Size.Width / 2.0f;
			var value = MinimumValue +
						(x - padding) / ((float)Frame.Size.Width - padding * 2) * (MaximumValue - MinimumValue);

			value = Math.Max(value, MinimumValue);
			value = Math.Min(value, UpperValue - MinimumRange);

			return value;
		}

		/// <summary>
		/// Returns the upper value based on the X potion
		/// The return value is automatically adjust to fit inside the valid range
		/// </summary>
		private float UpperValueForCenterX(float x)
		{
			var padding = (float)_upperHandle.Frame.Size.Width / 2.0f;

			var value = MinimumValue +
						(x - padding) / ((float)Frame.Size.Width - padding * 2) * (MaximumValue - MinimumValue);

			value = Math.Min(value, MaximumValue);
			value = Math.Max(value, LowerValue + MinimumRange);

			return value;
		}

		private UIEdgeInsets TrackAlignmentInsets()
		{
			var lowerAlignmentInsets = LowerHandleImageNormal.AlignmentRectInsets;
			var upperAlignmentInsets = UpperHandleImageNormal.AlignmentRectInsets;

			var lowerOffset = Math.Max((float)lowerAlignmentInsets.Right, (float)upperAlignmentInsets.Left);
			var upperOffset = Math.Max((float)upperAlignmentInsets.Right, (float)lowerAlignmentInsets.Left);

			var leftOffset = Math.Max(lowerOffset, upperOffset);
			var rightOffset = leftOffset;
			var topOffset = (float)lowerAlignmentInsets.Top;
			var bottomOffset = (float)lowerAlignmentInsets.Bottom;

			return new UIEdgeInsets(topOffset, leftOffset, bottomOffset, rightOffset);
		}

		private CGRect TrackRect()
		{
			var retValue = new CGRect();

			var currentTrackImage = TrackImageForCurrentValues;

			retValue.Size = new CGSize(currentTrackImage.Size.Width, currentTrackImage.Size.Height);

			var lowerHandleWidth = _lowerHandleHidden
				? _lowerHandleHiddenWidth
				: (float)_lowerHandle.Frame.Size.Width;
			var upperHandleWidth = _upperHandleHidden
				? _upperHandleHiddenWidth
				: (float)_upperHandle.Frame.Size.Width;

			var xLowerValue = ((float)Bounds.Size.Width - lowerHandleWidth) * (LowerValue - MinimumValue) /
							  (MaximumValue - MinimumValue) + lowerHandleWidth / 2.0f;
			var xUpperValue = ((float)Bounds.Size.Width - upperHandleWidth) * (UpperValue - MinimumValue) /
							  (MaximumValue - MinimumValue) + upperHandleWidth / 2.0f;

			retValue.X = xLowerValue;
			retValue.Y = Bounds.Size.Height / 2.0f - retValue.Size.Height / 2.0f;
			retValue.Width = xUpperValue - xLowerValue;

			var alignmentInsets = TrackAlignmentInsets();
			retValue = alignmentInsets.InsetRect(retValue);

			return retValue;
		}

		private CGRect TrackBackgroundRect()
		{
			var rect = new CGRect
			{
				Size = new CGSize(TrackBackgroundImage.Size.Width, TrackBackgroundImage.Size.Height)
			};

			if (Math.Abs(TrackBackgroundImage.CapInsets.Left) > float.Epsilon ||
				Math.Abs(TrackBackgroundImage.CapInsets.Right) > float.Epsilon)
			{
				rect.Width = Bounds.Size.Width;
			}

			rect.X = 0;
			rect.Y = Bounds.Size.Height / 2.0f - rect.Size.Height / 2.0f;

			// Adjust the track rect based on the image alignment rects

			var alignmentInsets = TrackAlignmentInsets();
			rect = alignmentInsets.InsetRect(rect);

			return rect;
		}

		/// <summary>
		/// returms the rect of the tumb image for a given track rect and value
		/// </summary>
		private CGRect ThumbRectForValue(float value, UIImage thumbImage)
		{
			var thumbRect = new CGRect();
			var insets = thumbImage.CapInsets;

			thumbRect.Size = new CGSize(thumbImage.Size.Width, thumbImage.Size.Height);

			var xValue = ((float)Bounds.Size.Width - (float)thumbRect.Size.Width) *
						 ((value - MinimumValue) / (MaximumValue - MinimumValue));
			thumbRect.X = (float)Math.Round(xValue);
			thumbRect.Y = Bounds.Size.Height / 2.0f - thumbRect.Size.Height / 2.0f;

			return thumbRect.Integral();
		}

		private void AddSubviews()
		{
			//Frame = new CGRect(new CGPoint(0, 0), IntrinsicContentSize);
			//------------------------------
			// Lower Handle Handle
			_lowerHandle = new UIImageView(LowerHandleImageNormal, LowerHandleImageHighlighted)
			{
				Frame = ThumbRectForValue(LowerValue, LowerHandleImageNormal)
			};

			//------------------------------
			// Upper Handle Handle
			_upperHandle = new UIImageView(UpperHandleImageNormal, UpperHandleImageHighlighted)
			{
				Frame = ThumbRectForValue(UpperValue, UpperHandleImageNormal)
			};

			//------------------------------
			// Track
			_track = new UIImageView(TrackImageForCurrentValues) { Frame = TrackRect() };

			//------------------------------
			// Track Brackground
			_trackBackground = new UIImageView(TrackBackgroundImage) { Frame = TrackBackgroundRect() };

			AddSubview(_trackBackground);
			AddSubview(_track);
			AddSubview(_lowerHandle);
			AddSubview(_upperHandle);
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			_trackBackground.Frame = TrackBackgroundRect();
			_track.Frame = TrackRect();
			_track.Image = TrackImageForCurrentValues;

			// Layout the lower handle
			_lowerHandle.Frame = ThumbRectForValue(LowerValue, LowerHandleImageNormal);
			_lowerHandle.Image = LowerHandleImageNormal;
			_lowerHandle.HighlightedImage = LowerHandleImageHighlighted;
			_lowerHandle.Hidden = _lowerHandleHidden;

			// Layoput the upper handle
			_upperHandle.Frame = ThumbRectForValue(UpperValue, UpperHandleImageNormal);
			_upperHandle.Image = UpperHandleImageNormal;
			_upperHandle.HighlightedImage = UpperHandleImageHighlighted;
			_upperHandle.Hidden = _upperHandleHidden;
		}

		public override bool BeginTracking(UITouch uitouch, UIEvent uievent)
		{
			var touchPoint = uitouch.LocationInView(this);

			if (_lowerTouchEdgeInsets.InsetRect(_lowerHandle.Frame).Contains(touchPoint) && !LowerHandleHidden)
			{
				_lowerHandle.Highlighted = true;
				_lowerTouchOffset = (float)touchPoint.X - (float)_lowerHandle.Center.X;
			}

			if (_upperTouchEdgeInsets.InsetRect(_upperHandle.Frame).Contains(touchPoint) && !UpperHandleHidden)
			{
				_upperHandle.Highlighted = true;
				_upperTouchOffset = (float)touchPoint.X - (float)_upperHandle.Center.X;
			}

			_stepValueInternal = StepValueContinuously ? StepValue : 0.0f;

			DragStarted?.Invoke(this, EventArgs.Empty);

			return true;
		}

		public override bool ContinueTracking(UITouch uitouch, UIEvent uievent)
		{
			if (!_lowerHandle.Highlighted && !_upperHandle.Highlighted)
				return true;

			var touchPoint = uitouch.LocationInView(this); //[touch locationInView: self];

			if (_lowerHandle.Highlighted)
			{
				//get new lower value based on the touch location.
				//This is automatically contained within a valid range.
				var newValue = LowerValueForCenterX((float)touchPoint.X - _lowerTouchOffset);

				//if both upper and lower is selected, then the new value must be LOWER
				//otherwise the touch event is ignored.
				if (!_upperHandle.Highlighted || newValue < LowerValue)
				{
					_upperHandle.Highlighted = false;
					BringSubviewToFront(_lowerHandle);
					SetLowerValue(newValue, StepValueContinuously);
				}
				else
				{
					_lowerHandle.Highlighted = false;
				}
			}

			if (_upperHandle.Highlighted)
			{
				var newValue = UpperValueForCenterX((float)touchPoint.X - _upperTouchOffset);

				//if both upper and lower is selected, then the new value must be HIGHER
				//otherwise the touch event is ignored.
				if (!_lowerHandle.Highlighted || newValue > UpperValue)
				{
					_lowerHandle.Highlighted = false;
					BringSubviewToFront(_upperHandle);
					SetUpperValue(newValue, StepValueContinuously);
				}
				else
				{
					_upperHandle.Highlighted = false;
				}
			}


			//send the control event
			if (Continuous)
				SendActionForControlEvents(UIControlEvent.ValueChanged);

			//redraw
			SetNeedsLayout();

			return true;
		}

		public override void EndTracking(UITouch uitouch, UIEvent uievent)
		{
			_lowerHandle.Highlighted = false;
			_upperHandle.Highlighted = false;

			if (StepValue > 0)
			{
				_stepValueInternal = StepValue;

				SetLowerValue(LowerValue, true);
				SetUpperValue(UpperValue, true);
			}

			SendActionForControlEvents(UIControlEvent.ValueChanged);

			DragCompleted?.Invoke(this, EventArgs.Empty);
		}

		protected virtual void OnLowerValueChanged()
		{
			LowerValueChanged?.Invoke(this, EventArgs.Empty);
		}

		protected virtual void OnUpperValueChanged()
		{
			UpperValueChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
