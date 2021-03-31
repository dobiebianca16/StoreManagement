using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using StoresManagementApp.Model;
using Xamarin.Forms;

namespace StoresManagementApp.Helpers
{
    public class AddSubcategoriesData
    {
        public List<Subcategory> Subcategories { get; set; }
        FirebaseClient client;
      
        public AddSubcategoriesData()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
            Subcategories = new List<Subcategory>()
            {
                    new Subcategory()
                    {
                    CategoryID=1,
                     SubcategoryID=11,
                     Photo="sweater.png",
                    SubcategoryName="F.Bluze",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                     CategoryID=1,
                     SubcategoryID=12,
                     Photo="top.png",
                    SubcategoryName="F.Tricouri",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                     CategoryID=1,
                    SubcategoryID=13,
                    Photo="jeans.png",
                    SubcategoryName="F.Pantaloni",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                     CategoryID=1,
                     SubcategoryID=14,
                     Photo="pencilskirt.png",
                    SubcategoryName="F.Fuste",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                    CategoryID=1,
                    SubcategoryID=15,
                    Photo="dress.png",
                    SubcategoryName="F.Rochii",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                     CategoryID=1,
                     SubcategoryID=16,
                     Photo="heels.png",
                    SubcategoryName="F.Pantofi",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                    CategoryID=1,
                    Photo="underwear.png",
                    SubcategoryName="F.Lenjerie",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                    CategoryID=1,
                    SubcategoryID=17,
                    Photo="bag.png",
                    SubcategoryName="F.Accesorii",
                    CategoryName="Femei"
                    },
                    new Subcategory()
                    {
                    CategoryID=2,
                    SubcategoryID=21,
                    Photo="hoodie.png",
                    SubcategoryName="B.Bluze",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                     CategoryID=2,
                     SubcategoryID=22,
                    Photo="poloshirt.png",
                    SubcategoryName="B.Tricouri",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                    CategoryID=2,
                    SubcategoryID=23,
                    Photo="pantalon.png",
                    SubcategoryName="B.Pantaloni",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                    CategoryID=2,
                    SubcategoryID=24,
                    Photo="socks.png",
                    SubcategoryName="B.Accesorii",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                    CategoryID=2,
                    SubcategoryID=25,
                    Photo="boxers.png",
                    SubcategoryName="B.Lenjerie",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                    CategoryID=2,
                    SubcategoryID=26,
                    Photo="shoes.png",
                    SubcategoryName="B.Pantofi",
                    CategoryName="Barbati"
                    },
                    new Subcategory()
                    {
                    CategoryID=3,
                    SubcategoryID=31,
                    Photo="cardigan.png",
                    SubcategoryName="C.Bluze",
                    CategoryName="Copii"
                    },
                    new Subcategory()
                    {
                    CategoryID=3,
                    SubcategoryID=32,
                    Photo="ttshirt.png",
                    SubcategoryName="C.Tricouri",
                    CategoryName="Copii"
                    },
                   new Subcategory()
                    {
                   CategoryID=3,
                   SubcategoryID=33,
                   Photo="jeans.png",
                    SubcategoryName="C.Pantaloni",
                    CategoryName="Copii"
                    },
                     new Subcategory()
                    {
                     CategoryID=3,
                     SubcategoryID=34,
                     Photo="dress.png",
                    SubcategoryName="C.Rochite",
                    CategoryName="Copii"
                    },
                     new Subcategory()
                    {
                     CategoryID=3,
                     SubcategoryID=35,
                     Photo="skirt.png",
                    SubcategoryName="C.Fuste",
                    CategoryName="Copii"
                    },
                    new Subcategory()
                    {
                    CategoryID=3,
                    SubcategoryID=36,
                    Photo="converse.png",
                    SubcategoryName="C.Pantofi",
                    CategoryName="Copii"
                    },
                    new Subcategory()
                    {
                    CategoryID=3,
                    SubcategoryID=37,
                    Photo="hat.png",
                    SubcategoryName="C.Accesorii",
                    CategoryName="Copii"
                    },
                    new Subcategory()
                    {
                    CategoryID=3,
                    SubcategoryID=38,
                    Photo="bra.png",
                    SubcategoryName="C.Lenjerie",
                    CategoryName="Copii"
                    },
            };

        }



        public async Task AddSubcategoriesAsync()
        {
            try
            {
                foreach (var subcategory in Subcategories)
                {
                    await client.Child("Subcategories").PostAsync(new Subcategory()
                    {
                        CategoryID = subcategory.CategoryID,
                        CategoryName = subcategory.CategoryName,
                        Photo= subcategory.Photo,
                        SubcategoryID=subcategory.SubcategoryID,
                        SubcategoryName = subcategory.SubcategoryName,

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

