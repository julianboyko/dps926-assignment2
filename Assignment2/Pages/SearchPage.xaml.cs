using System;
using System.Collections.Generic;
using Assignment2.Models;
using Assignment2.Pages;
using Xamarin.Forms;

namespace Assignment2
{
    public partial class SearchPage : ContentPage
    {
        public NetworkingManager networkingManager;

        public SearchPage()
        {
            InitializeComponent();

            networkingManager = new NetworkingManager();
        }

        async void SearchButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var searchFor = SearchTextbox.Text;

            if (searchFor == null || searchFor.Equals(""))
            {
                await DisplayAlert("Hold Up!", "You must first enter an item to search for before continuing.", "OK");
                return;
            }

            var foodList = await networkingManager.GetFoodList(searchFor);

            await Navigation.PushAsync(new SearchListPage(foodList, searchFor));
        }

        async void LogButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FoodLogPage());
        }
    }
}
