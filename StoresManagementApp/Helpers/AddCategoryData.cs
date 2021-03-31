using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using StoresManagementApp.Model;
using Xamarin.Forms;

namespace StoresManagementApp.Helpers
{

    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }
        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
            Categories = new List<Category>()
            {
                new Category()
                    {
                        CategoryID = 1,
                        CategoryName= "Femei",
                        ImageUrl="hair.png"
                    },
                new Category()
                    {
                        CategoryID = 2,
                        CategoryName= "Barbati",
                        ImageUrl="man.png"
                    },
                new Category()
                    {
                        CategoryID = 3,
                        CategoryName= "Copii",
                        ImageUrl="boy.png"
               }     };

        }
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        
    }

}
