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
        public double FoodPrice { get; set; }
        public double FoodPrimeCost { get; set; }

        public Food(int foodID, string foodName, double foodPrice, double foodPrimeCost)
        {
            FoodID = foodID;
            FoodName = foodName;
            FoodPrice = foodPrice;
            FoodPrimeCost = foodPrimeCost;
        }
    }
}
