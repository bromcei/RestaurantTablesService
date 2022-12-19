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
        public int OrderID { get; set; }
        public int PersonCount { get; set; }
        public List<int> FoodIDList { get; }
        public List<int> DrinkIDList { get; }

        public decimal TotalPayment { get; }
        public decimal TotalPaymentBeforeTax { get; }
        public decimal TotalPrimeCost { get; }
        public string ClientEmail { get; set; }
        public DateTime CheckDate { get; set; }
        public Check(int checkID, int orderID, int personCount, List<int> foodIDList, List<int> drinkIDList, decimal totalPayment,  decimal totalPrimeCost, string clientEmail)
        {
            CheckID = checkID;
            OrderID = orderID;
            PersonCount = personCount;
            FoodIDList = foodIDList;
            DrinkIDList = drinkIDList;
            TotalPayment = totalPayment;
            TotalPaymentBeforeTax = TotalPayment / 1.21m;
            TotalPrimeCost = totalPrimeCost;
            ClientEmail = clientEmail;
            CheckDate = DateTime.Now;
        }

    }
}
