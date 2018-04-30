using Xamarin.Forms;

namespace Schedule.CustomViews
{
    public class CustomProgressBar : ProgressBar
    {
        
        public static BindableProperty ColorProperty = 
            BindableProperty.Create("Color",typeof(Color),typeof(CustomProgressBar),default(Color));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        
    }
}
