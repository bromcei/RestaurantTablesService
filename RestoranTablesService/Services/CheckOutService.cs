using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;
using RestaurantTablesService.Interfaces;
using RestaurantTablesService.Repositories;

namespace RestaurantTablesService.Services
{
    public class CheckOutService 
    {
        public string Env { get; set; }
        public DrinkRepository Drinks { get; set; }
        public FoodReposiroty Foods { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }
        public OrderRepository Orders { get; set; }
        public CheckRepository Checks { get; set; }

        public CheckOutService(string env)
        {
            Env = env;
            Drinks = new DrinkRepository(Env);
            Foods = new FoodReposiroty(Env);
            OccupiedTables = new OccupiedTablesRepositories(Env);
            Orders = new OrderRepository(Env);
            Checks = new CheckRepository(Env);
        }
        public void NewCheckOut(int orderID, string clientEmail)
        {
            Order orderToCheckOut = Orders.Retrieve(orderID);
            int newCheckID = Checks.NextCheckID();
            List<Food> orderedFood = new List<Food>();
            List<Drink> orderedDrinks = new List<Drink>();
            foreach (int foodID in orderToCheckOut.FoodIDList)
            {
                orderedFood.Add(Foods.Retrieve(foodID));
            }
            foreach (int drinkID in orderToCheckOut.DrinkIDList)
            {
                orderedDrinks.Add(Drinks.Retrieve(drinkID));    
            }
            decimal totalOrderSum = orderedFood.Select(order => order.FoodPrice).ToList().Sum() + orderedDrinks.Select(order => order.DrinkPrice).ToList().Sum();
            decimal totalOrderPrimeSum = orderedFood.Select(order => order.FoodPrimeCost).ToList().Sum() + orderedDrinks.Select(order => order.DrinkPrimePrice).ToList().Sum();

            Check newCheck = new Check(newCheckID, orderID, orderToCheckOut.PersonCount, orderToCheckOut.FoodIDList, orderToCheckOut.DrinkIDList, totalOrderSum, totalOrderPrimeSum, clientEmail);
            Checks.NewCheck(newCheck);
            orderToCheckOut.CheckedOut = true;
            Orders.WriteToFile();
            //https://social.msdn.microsoft.com/Forums/en-US/1eca3fdd-8669-40de-a9d9-0e0164c88772/get-list-by-ids?forum=aspgettingstarted
        }
    }
}
