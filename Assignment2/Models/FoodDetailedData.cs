using System;

namespace Assignment2.Models
{
    public class FoodDetailedData
    {
        public string food_name { get; set; }
        public string brand_name { get; set; }
        public Double serving_qty { get; set; }
        public string serving_unit { get; set; }
        public Double? serving_weight_grams { get; set; }
        public Double? nf_calories { get; set; }
        public Double? nf_total_fat { get; set; }
        public Double? nf_saturated_fat { get; set; }
        public Double? nf_cholesterol { get; set; }
        public Double? nf_sodium { get; set; }
        public Double? nf_total_carbohydrate { get; set; }
        public Double? nf_dietary_fiber { get; set; }
        public Double? nf_sugars { get; set; }
        public Double? nf_protein { get; set; }
        public FoodDataPhoto photo { get; set; }
    }
}
