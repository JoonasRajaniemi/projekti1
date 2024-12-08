using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MyHybridApp.Models;

namespace MyHybridApp.ViewModels
{
    public class ItemViewModel : ObservableObject
    {
        int _id;
        String _name;
        String _imagePath;

        public int id
        {
            get { return _id; }
            set => SetProperty(ref _id, value);
        }
        public String name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
        }

        public String ImagePath
        {
            get { return _imagePath; }
            set => SetProperty(ref _imagePath, value);
        }

        public ItemViewModel(Item item)
        {
            _id = item.Id;
            _name = item.Name;
            _imagePath = item.ImagePath;
        }
    }
}
