using System;
using SQLite;
namespace Assignment2.Models
{
    public class FoodDataDB
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string food_name { get; set; }
        public string nix_brand_id { get; set; }
        public Double nf_calories { get; set; }
        public string photoUrl { get; set; }
        public string brand_name { get; set; }
        public string nix_item_id { get; set; }
    }
}
