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
        public List<int> FoodIDList { get; }
        public List<int> DrinkIDList { get; }

        public double TotalPayment { get; }
        public double Tips { get; }
        public double TotalPrimeCost { get; }
        public Check(int checkID, int tableID, int personCount, List<int> foodIDList, List<int> drinkIDList, double totalPayment, double tips, double totalPrimeCost)
        {
            CheckID = checkID;
            TableID = tableID;
            PersonCount = personCount;
            FoodIDList = foodIDList;
            DrinkIDList = drinkIDList;
            TotalPayment = totalPayment;
            Tips = tips;
            TotalPrimeCost = totalPrimeCost;
        }
    }
}
