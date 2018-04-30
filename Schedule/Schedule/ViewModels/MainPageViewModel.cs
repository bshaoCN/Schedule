using Schedule.Models;
using Schedule.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedule.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command<Item> DeleteItemCommand { get; set; }

        public MainPageViewModel()
        {
            Items = new ObservableCollection<Item>();

            DeleteItemCommand = new Command<Item>((item) =>
            {
                var _item = Items.Where((Item arg) => arg.Id == (item as Item).Id).FirstOrDefault();
                if (_item != null)
                {
                    Items.Remove(_item);
                }
            });

            MessagingCenter.Subscribe<ItemPage, Item>(this, "SaveItem", (obj, item) =>
            {
                Item newItem = item as Item;
                var _item = Items.Where((Item arg) => arg.Id == newItem.Id).FirstOrDefault();
                if (_item == null)
                {
                    Items.Add(newItem);
                }
            });

        }

        void Delete(Item item)
        {
            if (item == null) return;
            var _item = Items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            if (_item != null)
            {
                Items.Remove(_item);
            }

        }
    }
}
