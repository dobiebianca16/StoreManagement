using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using StoresManagementApp.Model;
using System.Linq;
using Firebase.Database.Query;

namespace StoresManagementApp.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    CategoryName = c.Object.CategoryName,
                    ImageUrl = c.Object.ImageUrl
                }).ToList();
            return categories;
        }
       
    }

}
