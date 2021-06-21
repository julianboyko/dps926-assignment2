using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment2.Models
{
    public class NetworkingManager
    {
        private string urlBase;
        private HttpClient client;

        public NetworkingManager()
        {
            urlBase = "https://trackapi.nutritionix.com/v2";
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("x-app-id", "8a734e3a");
            client.DefaultRequestHeaders.Add("x-app-key", "4282c4854a6cd323a48e6fe6ab49567d");
        }

        public async Task<List<FoodData>> GetFoodList(string searchValue)
        {
            var url = urlBase + "/search/instant?common=false&query=" + searchValue;

            var response = await client.GetAsync(url);

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<FoodData>();
            } else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var foodDataList = JsonConvert.DeserializeObject<FoodDataList>(stringResponse);

                return foodDataList.branded;
            }
        }

        public async Task<FoodDetailedData> GetFoodDetails(String nix_item_id)
        {
            var url = urlBase + "/search/item?nix_item_id=" + nix_item_id;

            var response = await client.GetAsync(url);

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new FoodDetailedData();
            } else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var foodDataDetailedList = JsonConvert.DeserializeObject<FoodDetailedDataList>(stringResponse);

                return foodDataDetailedList.foods.ElementAt(0);
            }
        }
    }
}
