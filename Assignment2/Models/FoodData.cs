using System;
namespace Assignment2.Models
{
    public class FoodData
    {
        public string food_name { get; set; }
        public string serving_unit { get; set; }
        public string nix_brand_id { get; set; }
        public Double serving_qty { get; set; }
        public int nf_calories { get; set; }
        public FoodDataPhoto photo { get; set; }
        public string brand_name { get; set; }
        public int region { get; set; }
        public int brand_type { get; set; }
        public string nix_item_id { get; set; }
        public string locale { get; set; }
    }

    public class FoodDataPhoto
    {
        public string thumb { get; set; }
    }
}
