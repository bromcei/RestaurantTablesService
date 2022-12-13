using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class Check
    {
        public int CheckID { get; set; }
        public int TableID { get; set; }
        public int PersonCount { get; set; }
        public List<int> FoodIDList { get; set; }
        public List<int> DrinkIDList { get; set; }
        public Check(int checkID, int tableID, int personCount, List<int> foodIDList, List<int> drinkIDList)
        {
            CheckID = checkID;
            TableID = tableID;
            PersonCount = personCount;
            FoodIDList = foodIDList;
            DrinkIDList = drinkIDList;
        }
    }
}
