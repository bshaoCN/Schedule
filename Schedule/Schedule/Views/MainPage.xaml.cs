using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Schedule.ViewModels;
using Schedule.Views;
using Schedule.Models;

namespace Schedule
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemPage(null) { Title = "New" }));
        }
        async void EditItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            await Navigation.PushModalAsync(new NavigationPage(new ItemPage(menuItem.CommandParameter as Item) { Title = "Edit" }));
        }

        //void SaveItems_Clicked(object sender, EventArgs e)
        //{


        //}

    }
}
