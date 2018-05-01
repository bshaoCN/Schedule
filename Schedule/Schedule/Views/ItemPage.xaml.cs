using Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Schedule.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        public List<Severity> Severities
        {
            get
            {
                return new List<Severity>
                {
                    new Severity(){Text="Low",Color="Green"},
                    new Severity(){Text="Medium",Color="Orange "},
                    new Severity(){Text="High",Color="Red"}
                };
            }
        }
        public Item Item { get; set; }

        public ItemPage(Item item)
        {
            if (item == null)
            {
                Item = NewItem();
            }
            else
            {
                Item = item;
            }
            InitializeComponent();
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "SaveItem", Item);
            await Navigation.PopModalAsync();
        }

        private Item NewItem()
        {
            DateTime dt = DateTime.Now;

            Item item = new Item() { StartTime = dt - dt.Date };

            if (dt.Minute > 30)
            {
                item.StartTime = new TimeSpan(dt.Hour + 1, 0, 0);
            }
            else
            {
                item.StartTime = new TimeSpan(dt.Hour, 30, 0);
            }
            item.EndTime = item.StartTime + new TimeSpan(0, 30, 0);

            item.SeverityID = 2;
            return item;
        }

        void OnSeveritySelectedIndexChanged(object sender, SelectedItemChangedEventArgs args)
        {
            Picker picker = sender as Picker;
            Item.Color = (picker.SelectedItem as Severity).Color;
        }
    }

}