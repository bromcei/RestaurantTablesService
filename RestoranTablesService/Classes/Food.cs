using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class Food
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public decimal FoodPrice { get; set; }
        public decimal FoodPrimeCost { get; set; }

        public Food(int foodID, string foodName, decimal foodPrice, decimal foodPrimeCost)
        {
            FoodID = foodID;
            FoodName = foodName;
            FoodPrice = foodPrice;
            FoodPrimeCost = foodPrimeCost;
        }
    }
}
