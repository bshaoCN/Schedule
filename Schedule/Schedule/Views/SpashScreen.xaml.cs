using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpashScreen : ContentPage
	{
		public SpashScreen ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            DelayedNaviagition();
           
        }

        async private void DelayedNaviagition()
        {
            await Task.Delay(5000);
            await Navigation.PushAsync(new MainPage());
        }
    }
}