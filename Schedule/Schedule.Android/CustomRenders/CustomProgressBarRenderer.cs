using Android.Content;
using Xamarin.Forms.Platform.Android;
using Schedule.Droid.CustomRenders;
using Xamarin.Forms;
using Schedule.CustomViews;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRender))]
namespace Schedule.Droid.CustomRenders
{

    class CustomProgressBarRender : ProgressBarRenderer
    {
        public CustomProgressBarRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ScaleY = 8;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomProgressBar.ColorProperty.PropertyName)
            {
                SetColor();
            }
        }


        void SetColor()
        {
            var element = Element as CustomProgressBar;
            Control.IndeterminateDrawable.SetColorFilter(element.Color.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
            Control.ProgressDrawable.SetColorFilter(element.Color.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
        }
    }

}