using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assignment2.Models;
using Assignment2.Pages;
using Assignment2.Persistance;
using Xamarin.Forms;

namespace Assignment2
{
    public partial class FoodLogPage : ContentPage
    {
        DBManager dbManager = new DBManager();
        ObservableCollection<FoodDataDB> AllFoodData;

        public FoodLogPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            AllFoodData = await dbManager.CreateTable();
            FoodDataListView.ItemsSource = AllFoodData;
            base.OnAppearing();
        }

        async void FoodDataListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var currentSelectedFood = (FoodDataDB)e.SelectedItem;

            await Navigation.PushAsync(new SearchDetailsPage(currentSelectedFood.nix_item_id, currentSelectedFood.food_name, currentSelectedFood.brand_name, currentSelectedFood.photoUrl));
        }

        async void OnDelete_Clicked(System.Object sender, System.EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var foodToDelete = menuItem?.BindingContext as FoodDataDB;

            dbManager.deleteFoodData(foodToDelete);
            AllFoodData.Remove(foodToDelete);

            await DisplayAlert("Success!", "You have deleted " + foodToDelete.food_name + " from your log!", "OK");
        }
    }
}
