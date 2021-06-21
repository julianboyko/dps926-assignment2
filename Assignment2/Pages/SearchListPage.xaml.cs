using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assignment2.Models;
using Xamarin.Forms;

namespace Assignment2.Pages
{
    public partial class SearchListPage : ContentPage
    {
        ObservableCollection<FoodData> foodList;

        public ObservableCollection<FoodData> SearchResults { get { return foodList; } }

        public SearchListPage(List<FoodData> foodList, String searchValue)
        {
            InitializeComponent();

            Title = searchValue;

            this.foodList = new ObservableCollection<FoodData>(foodList);
            SearchResultsListView.ItemsSource = foodList;
        }

        async void SearchResultsListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var currentSelectedFood = (FoodData)e.SelectedItem;

            await Navigation.PushAsync(new SearchDetailsPage(currentSelectedFood));
        }
    }
}
