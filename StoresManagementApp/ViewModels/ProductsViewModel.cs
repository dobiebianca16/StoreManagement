using System;
using System.Collections.ObjectModel;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using Xamarin.Forms;

namespace StoresManagementApp.ViewModels
{
    public class ProductsViewModel :BaseViewModel
    {

        private Subcategory _SelectedSubcategoryProduct;
        public Subcategory SelectedSubcategoryProduct
        {
            set
            {
                _SelectedSubcategoryProduct = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedSubcategoryProduct;
            }
        }

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
      
        public ObservableCollection<Product> ProductsBySubcategory { get; set; }

        public ObservableCollection<Product> AllProducts { get; set; }

        public ProductsViewModel(Subcategory subcategory)
        {
            SelectedSubcategoryProduct = subcategory;
            ProductsBySubcategory = new ObservableCollection<Product>();
            GetProducts(subcategory.SubcategoryName);
        }
        public ProductsViewModel()
        {
            AllProducts = new ObservableCollection<Product>();
            GetAllProducts();
        }

        private async void GetAllProducts()
        {
            var data = await new ProductService().GetProductsAsync();
            AllProducts.Clear();
            foreach(var item in data)
            {
                AllProducts.Add(item);
            }
            TotalProducts = AllProducts.Count;
        }

        private async void GetProducts(string subcatgoryname)
        {
            var data = await new ProductService().GetProductsbysubcateasync(subcatgoryname);
            ProductsBySubcategory.Clear();
            foreach (var item in data)
            {
                ProductsBySubcategory.Add(item);
            }
            TotalProducts = ProductsBySubcategory.Count;
        }
    }
}
