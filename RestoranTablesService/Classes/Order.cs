using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public int PersonCount { get; set; }
        public List<int> FoodIDList { get; set; }
        public List<int> DrinkIDList { get; set; }
        public Order(int orderID, int tableID, int personCount, List<int> foodIDList, List<int> drinkIDList)
        {
            OrderID = orderID;
            TableID = tableID;
            PersonCount = personCount;
            FoodIDList = foodIDList;
            DrinkIDList = drinkIDList;
        }
    }

}
