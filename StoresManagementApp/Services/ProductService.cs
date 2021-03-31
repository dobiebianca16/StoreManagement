using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using StoresManagementApp.Model;
using System.Linq;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace StoresManagementApp.Services
{
    public class ProductService
    {
        FirebaseClient client;

        public ProductService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");


        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var products = (await client.Child("AddProduct")
                .OnceAsync<Product>())
                .Select(f => new Product
                {
                    CategoryName= f.Object.CategoryName,
                    SubcategoryName=f.Object.SubcategoryName,
                    ProductId=f.Object.ProductId,
                    ProductName=f.Object.ProductName,
                    Description=f.Object.Description,
                    Price=f.Object.Price,

                    Size=f.Object.Size,
                    Color=f.Object.Color

                }).ToList();
            return products;
        }

        public async Task<List<Product>> GetProduct()
        {
            return (await client.Child("AddProducts").
                OnceAsync<Product>()).Select(item => new Product
                {
                    SubcategoryName = item.Object.SubcategoryName
                }).ToList();
        }

        public async Task<ObservableCollection<Product>> GetProductsbysubcateasync(string subcategoryname)
        {
            var productsbysubcateg = new ObservableCollection<Product>();
            var items = (await GetProductsAsync()).Where(p => p.SubcategoryName == subcategoryname).ToList();
            foreach (var item in items)
            {
                productsbysubcateg.Add(item);
            }
            return productsbysubcateg;
        }

        public async Task<ObservableCollection<Product>> GetProductsByQueryAsync(string searchText)
        {
            var productsByQuery = new ObservableCollection<Product>();
            var items = (await GetProductsAsync()).Where(p => p.ProductName.Contains(searchText)).ToList();
            foreach(var item in items)
            {
                productsByQuery.Add(item);
            }    
            return productsByQuery;
        }


    }
}
