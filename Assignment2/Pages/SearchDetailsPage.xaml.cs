using Assignment2.Models;
using Assignment2.Persistance;
using Xamarin.Forms;

namespace Assignment2.Pages
{
    public partial class SearchDetailsPage : ContentPage
    {
        DBManager dbManager = new DBManager();

        NetworkingManager networkingManager;

        FoodData selectedFood;
        FoodDetailedData selectedFoodDetails;
        string nix_item_id;

        public SearchDetailsPage(FoodData selectedFood)
        {
            InitializeComponent();

            Title = selectedFood.food_name;

            this.networkingManager = new NetworkingManager();
            this.selectedFood = selectedFood;

            InitialSetupUI();
        }

        public SearchDetailsPage(string nix_item_id, string food_name, string brand_name, string photo_url)
        {
            InitializeComponent();

            Title = food_name;
            this.nix_item_id = nix_item_id;

            this.networkingManager = new NetworkingManager();

            InitialSetupUIFromDB(food_name, brand_name, photo_url);
        }

        protected async override void OnAppearing()
        {
            this.selectedFoodDetails = await networkingManager.GetFoodDetails(selectedFood == null ? nix_item_id : selectedFood.nix_item_id);
            SetupRestOfUI();

            base.OnAppearing();
        }

        void InitialSetupUI() {
            FoodNameLabel.Text = selectedFood.food_name;
            BrandNameLabel.Text = selectedFood.brand_name;
            FoodImage.Source = selectedFood.photo.thumb;
        }

        void InitialSetupUIFromDB(string food_name, string brand_name, string photo_url) {
            FoodNameLabel.Text = food_name;
            BrandNameLabel.Text = brand_name;
            FoodImage.Source = photo_url;
            AddToLogButton.IsVisible = false;
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

        async void AddToLogButton_Clicked(System.Object sender, System.EventArgs e)
        {
            FoodDataDB foodToAdd = new FoodDataDB();
            foodToAdd.food_name = selectedFood.food_name;
            foodToAdd.nix_brand_id = selectedFood.nix_brand_id;
            foodToAdd.nf_calories = selectedFood.nf_calories;
            foodToAdd.photoUrl = selectedFood.photo.thumb;
            foodToAdd.brand_name = selectedFood.brand_name;
            foodToAdd.nix_item_id = selectedFood.nix_item_id;

            dbManager.insertFoodData(foodToAdd);

            await DisplayAlert("Success!", "You have added " + foodToAdd.food_name + " to your log!", "OK");
            AddToLogButton.IsEnabled = false;
        }
    }
}
