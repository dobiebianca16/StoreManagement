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
    public class SubcategoryService
    {
        FirebaseClient client;

        public SubcategoryService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
        }



        public async Task<List<Subcategory>> GetSubcategoriesAsync()
        {
            var subcategories = (await client.Child("Subcategories")
                .OnceAsync<Subcategory>())
                .Select(f => new Subcategory
                {
                    CategoryID = f.Object.CategoryID,
                    Photo= f.Object.Photo,
                    SubcategoryName = f.Object.SubcategoryName,
                    CategoryName = f.Object.CategoryName

                }).ToList();

            return subcategories;
        }


        public async Task<ObservableCollection<Subcategory>> GetSubcategoriesByCategoryAsync(string categoryname)
        {
            var subcategoriesByCategory = new ObservableCollection<Subcategory>();
            var items = (await GetSubcategoriesAsync()).Where(p => p.CategoryName == categoryname).ToList();
            foreach (var item in items)
            {
                subcategoriesByCategory.Add(item);
            }
            return subcategoriesByCategory;
        }
        

    }
}
