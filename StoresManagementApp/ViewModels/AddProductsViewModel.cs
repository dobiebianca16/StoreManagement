using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Firebase.Database;
using Firebase.Database.Query;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.Views;
using Xamarin.Forms;
using StoresManagementApp.Helpers;

namespace StoresManagementApp.ViewModels
{
   

    public class AddProductsViewModel:BaseViewModel
    {
      

        private string _ProductName;
        public string ProductName
        {
            set
            {
                this._ProductName = value;
                OnPropertyChanged();
            }
            get
            {
                return this._ProductName;
            }
        }

        private int _Quantity;
        public int  Quantity
        {
            set
            {
                this._Quantity = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Quantity;
            }
        }


        private string _CategoryName;
        public string CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {   if(_CategoryName != value)
                {
                    _CategoryName = value;
                     OnPropertyChanged();
                }
                
               
            }
           
        }

        private string _SubcategoryName;
        public string SubcategoryName
        {
            set
            {
                this._SubcategoryName = value;
                OnPropertyChanged();
            }
            get
            {
                return this._SubcategoryName;
            }
        }

        private string _Description;
        public string Description
        {
            set
            {
                this._Description = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Description;
            }
        }

        private string _Size;
        public string Size
        {
            set
            {
                this._Size = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Size;
            }
        }

        private decimal _Price;
        public decimal Price
        {
            set
            {
                this._Price = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Price;
            }
        }

        private string _Color;
        public string Color
        {
            set
            {
                this._Color = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Color;
            }
        }

        private string _Image;
        public string Image
        {
            set
            {
                this._Image = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Image;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

       // public IList<Subcategory> CategoryFromViewSelector { get { return AddSubcategoriesData.SubcategoriesADD; } }
      

        public Command AddProductCommand { get; set; }
        public Command HomeCommand { get; set; }

        public AddProductsViewModel()
        {
            HomeCommand = new Command(() => GoToHomeAsync());
            AddProductCommand = new Command(async () => await AddProductCommandAsync());
        }

        private async void GoToHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new StocView());
        }

        private async Task AddProductCommandAsync()
            {
                
                try
                {
                    var addProductService = new AddProductDataService();
                    Result = await addProductService.AddProduct(CategoryName, SubcategoryName, ProductName,Description, Price, Size, Color, Quantity);
                if (Result)
                { await Application.Current.MainPage.DisplayAlert("Succes", "Product add", "Ok");
                   
                }


                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User Already exists ", "Ok");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                }
                
            }
       
    }
}
