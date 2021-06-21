using System;
using System.Collections.Generic;

namespace Assignment2.Models
{
    public class FoodDataList
    {
        public List<FoodData> branded { get; set; }

        public FoodDataList()
        {
            branded = new List<FoodData>();
        }
    }
}
