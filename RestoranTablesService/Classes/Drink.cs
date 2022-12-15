using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        public decimal DrinkPrimePrice { get; set; }

        public Drink(int drinkID, string drinkName, decimal drinkPrice, decimal drinkPrimePrice)
        {
            DrinkID = drinkID;
            DrinkName = drinkName;
            DrinkPrice = drinkPrice;
            DrinkPrimePrice = drinkPrimePrice;
        }
    }
}
