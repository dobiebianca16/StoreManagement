using System;
using System.Collections.ObjectModel;
using StoresManagementApp.Model;
using StoresManagementApp.Services;
using StoresManagementApp.Views;


namespace StoresManagementApp.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedCategory;
            }
        }
        private Subcategory _Selectedsubcategory;
        public Subcategory Selectedsubcategory
        {
            set
            {
                _Selectedsubcategory = value;
                OnPropertyChanged();
            }
            get
            {
                return _Selectedsubcategory;
            }
        }

        public ObservableCollection<Subcategory> SubcategoriesByCategory { get; set;}

        private int _TotalSubcategories;
        public int TotalSubcategories
        {
            set
            {
                _TotalSubcategories = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalSubcategories;
            }
        }
        public ObservableCollection<Subcategory> Subcategories { get; set; }


        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            SubcategoriesByCategory = new ObservableCollection<Subcategory>();
            GetSubcategories(category.CategoryName);



            
        }
        
        private async void GetSubcategories(string categoryname)
        {
            var data = await new SubcategoryService().GetSubcategoriesByCategoryAsync(categoryname);
            SubcategoriesByCategory.Clear();
            foreach( var item in data)
            {
                SubcategoriesByCategory.Add(item);
            }
            TotalSubcategories = SubcategoriesByCategory.Count;
        }


        private async void GetProduct()
        {
            var data = await new SubcategoryService().GetSubcategoriesAsync();
            Subcategories.Clear();
            foreach (var item in data)
            {
                Subcategories.Add(item);
            }
        }
    }
}
