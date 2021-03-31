using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using StoresManagementApp.Model;
using Xamarin.Forms;

namespace StoresManagementApp.Services
{
    public class AddProductDataService
    {
        FirebaseClient client;

        public AddProductDataService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
        }


     
        public async Task<bool> AddProduct(string CategoryName, string subcategoryName, string productName, string description, decimal price, string size, string color, int quantity)
        {
            await client.Child("AddProduct").PostAsync(new Product()
            {
                ProductId= Guid.NewGuid(),
                CategoryName= CategoryName,
                SubcategoryName= subcategoryName,
            
                ProductName=productName,
                Description=description,
                Price=price,
                Size=size,
                Color=color,
                Quantity= quantity

            });
            return true;
        }
    }
}