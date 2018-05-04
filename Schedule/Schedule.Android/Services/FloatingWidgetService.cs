using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Schedule.Droid.Services
{
    [Service]
    class FloatingWidgetService : Service, View.IOnTouchListener
    {
        private IWindowManager _windowManager;
        private WindowManagerLayoutParams _layoutParams;
        private View _floatingView;
        private View _expandedContainer;

        private int _initialX;
        private int _initialY;
        private float _initialTouchX;
        private float _initialTouchY;
        public override void OnCreate()
        {
            base.OnCreate();

            _floatingView = LayoutInflater.From(this).Inflate(Resource.Layout.layout_floating_widget, null);
            //SetTouchListener();

            _layoutParams = new WindowManagerLayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent,
                WindowManagerTypes.Phone,
                WindowManagerFlags.NotFocusable,
                Format.Translucent)
            {
                Gravity = GravityFlags.Left | GravityFlags.Top
            };

            _windowManager = GetSystemService(WindowService).JavaCast<IWindowManager>();
            _windowManager.AddView(_floatingView, _layoutParams);
            _expandedContainer = _floatingView.FindViewById(Resource.Id.flyout);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public bool OnTouch(View view, MotionEvent motion)
        {
            switch (motion.Action)
            {
                case MotionEventActions.Down:
                    //initial position
                    _initialX = _layoutParams.X;
                    _initialY = _layoutParams.Y;

                    //touch point
                    _initialTouchX = motion.RawX;
                    _initialTouchY = motion.RawY;
                    return true;

                case MotionEventActions.Up:
                    int offsetX = (int)motion.RawX - (int)_initialTouchX;
                    int offsetY = (int)motion.RawY - (int)_initialTouchY;

                    if (offsetX < 10 && offsetY < 10)
                    {
                        _expandedContainer.Visibility = _expandedContainer.Visibility == ViewStates.Gone ?
                            ViewStates.Visible :
                            ViewStates.Gone;
                    }
                    return true;

                case MotionEventActions.Move:
                    //Calculate the X and Y coordinates of the view.
                    _layoutParams.X = _initialX + (int)(motion.RawX - _initialTouchX);
                    _layoutParams.Y = _initialY + (int)(motion.RawY - _initialTouchY);

                    //Update the layout with new X & Y coordinate
                    _windowManager.UpdateViewLayout(_floatingView, _layoutParams);
                    return true;
            }

            return false;
        }
    }
}
