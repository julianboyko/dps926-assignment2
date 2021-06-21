using System;
using System.Collections.Generic;
using Assignment2.Models;
using Xamarin.Forms;

namespace Assignment2.Pages
{
    public partial class SearchDetailsPage : ContentPage
    {
        public NetworkingManager networkingManager;

        FoodData selectedFood;
        FoodDetailedData selectedFoodDetails;

        public SearchDetailsPage(FoodData selectedFood)
        {
            InitializeComponent();

            Title = selectedFood.food_name;

            this.networkingManager = new NetworkingManager();
            this.selectedFood = selectedFood;

            InitialSetupUI();
        }

        protected async override void OnAppearing()
        {
            this.selectedFoodDetails = await networkingManager.GetFoodDetails(selectedFood);
            base.OnAppearing();

            SetupRestOfUI();
        }

        void InitialSetupUI() {
            FoodNameLabel.Text = selectedFood.food_name;
            BrandNameLabel.Text = selectedFood.brand_name;
            FoodImage.Source = selectedFood.photo.thumb;
        }

        void SetupRestOfUI()
        {
            CaloriesLabel.Text = selectedFoodDetails.nf_calories.ToString();
            ProteinLabel.Text = selectedFoodDetails.nf_protein != null ? selectedFoodDetails.nf_protein.ToString() + " g"
                : "Unknown";
            CarbLabel.Text = selectedFoodDetails.nf_total_carbohydrate != null ? selectedFoodDetails.nf_total_carbohydrate.ToString() + " g"
                : "Unknown";
            FatLabel.Text = selectedFoodDetails.nf_total_fat != null ? selectedFoodDetails.nf_total_fat.ToString() + " g"
                : "Unknown";
            FiberLabel.Text = selectedFoodDetails.nf_dietary_fiber != null ? selectedFoodDetails.nf_dietary_fiber.ToString() + " g"
                : "Unknown";
        }

        void AddToLogButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
