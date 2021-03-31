using System;
using System.Collections.ObjectModel;
using StoresManagementApp.Model;
using StoresManagementApp.Services;

namespace StoresManagementApp.ViewModels
{
    public class SearchResultViewModel:BaseViewModel
    {

        public ObservableCollection<Product> ProductsByQuery { get; set; }

        private int _TotalProducts;
        public int TotalProducts
        {
            set
            {
                _TotalProducts = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalProducts;
            }
        }

        public SearchResultViewModel(string searchText)
        {
            ProductsByQuery = new ObservableCollection<Product>();
            GetProductsByQueryAsync(searchText);
        }

        private async void GetProductsByQueryAsync(string searchText)
        {
            var data = await new ProductService().GetProductsByQueryAsync(searchText);
            ProductsByQuery.Clear();
            foreach(var item in data)
            {
                ProductsByQuery.Add(item);
            }
            TotalProducts = ProductsByQuery.Count;
        }
    }
}
