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
        public void DataRefresh()
        {
            Drinks = new DrinkRepository(Env);
            Foods = new FoodReposiroty(Env);
            OccupiedTables = new OccupiedTablesRepositories(Env);
            Orders = new OrderRepository(Env);
            Checks = new CheckRepository(Env);
        }

        public decimal TotalOrderSum(int orderID)
        {
            //Calculate total order sum
            DataRefresh();
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
            return orderedFood.Select(order => order.FoodPrice).ToList().Sum() + orderedDrinks.Select(order => order.DrinkPrice).ToList().Sum();
        }
        public decimal TotalOrderPrimeSum(int orderID)
        {
            //Calculates total order prime sum
            DataRefresh();
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
            return orderedFood.Select(order => order.FoodPrimeCost).ToList().Sum() + orderedDrinks.Select(order => order.DrinkPrimePrice).ToList().Sum();

        }
        public void NewCheckOut(int orderID, string clientEmail)
        {
            //Creates new checkout object and adds it to CheckRepository
            DataRefresh();
            if (orderID != -1)
            {
                Order orderToCheckOut = Orders.Retrieve(orderID);
                int newCheckID = Checks.NextCheckID();
                decimal totalOrderSum = TotalOrderSum(orderID);
                decimal totalOrderPrimeSum = TotalOrderPrimeSum(orderID); ;

                Check newCheck = new Check(newCheckID, orderID, orderToCheckOut.PersonCount, orderToCheckOut.FoodIDList, orderToCheckOut.DrinkIDList, totalOrderSum, totalOrderPrimeSum, clientEmail);
                Checks.NewCheck(newCheck);
                Orders.Retrieve(orderID).CheckedOut = true;
                OccupiedTables.SetTableFreeByOccupiedTableID(orderToCheckOut.OccupiedTableID);
                Orders.WriteToFile();
                DataRefresh();
            }

        }
        public void NewCheckOutByTable(int tableID, string clientEmail)
        {
            //Creates new Checkout object with occupied TableID adds it to CheckRepository
            DataRefresh();
            
            try
            {
                OccupiedTable tableTocheckOut = OccupiedTables.Retrieve(tableID);
                int orderID = (int)tableTocheckOut.OrderID;
                int newCheckID = Checks.NextCheckID();
                Order orderToCheckOut = Orders.Retrieve(orderID);
                decimal totalOrderSum = TotalOrderSum(orderID);
                decimal totalOrderPrimeSum = TotalOrderPrimeSum(orderID); ;

                Check newCheck = new Check(newCheckID, orderID, tableTocheckOut.PersonCount, orderToCheckOut.FoodIDList, orderToCheckOut.DrinkIDList, totalOrderSum, totalOrderPrimeSum, clientEmail);
                Checks.NewCheck(newCheck);
                Orders.Retrieve(orderID).CheckedOut = true;
                Orders.WriteToFile();
                DataRefresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);           
            }

        }
    }
}
