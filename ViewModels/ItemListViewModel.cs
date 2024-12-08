using MyHybridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace MyHybridApp.ViewModels
{
    public class ItemListViewModel:ObservableObject
    {
        private  ItemViewModel _selectedItem;

        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);   
        }

        public ObservableCollection<ItemViewModel> Items {  get; set; }

        public ItemListViewModel() => Items = [];

        public async Task RefreshItem()
        {
            IEnumerable<Models.Item> itemsData = await Models.itemsDatabase.GetItems();

            foreach (Models.Item item in itemsData)
            {
                Items.Add(new ItemViewModel(item));
            }

        } 

        public void DeleteItem(ItemViewModel item) => Items.Remove(item);

        public void AddItem(ItemViewModel newItem) => Items.Add(newItem);

        public async Task SaveItems()
        {
            await Models.itemsDatabase.WriteItems(Items);
        }

    }
}
