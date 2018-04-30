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

            //var rootPage = Navigation.NavigationStack[0];
            //if (typeof(MainPage) == rootPage.GetType()) return;
            //Navigation.RemovePage(rootPage);
        }
    }
}