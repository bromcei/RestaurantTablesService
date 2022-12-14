using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;
using RestaurantTablesService.Repositories;

namespace RestaurantTablesService.Services
{
    public class OrderService
    {
        public string Env { get; set; }
        public DrinkRepository Drinks { get; set; }
        public FoodReposiroty Foods { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }
        public OrderRepository Orders { get; set; }

        public OrderService(string env) 
        { 
            Env = env;
            Foods = new FoodReposiroty(Env);
            Drinks = new DrinkRepository(Env);
            OccupiedTables  = new OccupiedTablesRepositories(Env);  
            Orders = new OrderRepository(Env);  
        
        }
        public void DataRefresh()
        {
            Foods = new FoodReposiroty(Env);
            Drinks = new DrinkRepository(Env);
            OccupiedTables = new OccupiedTablesRepositories(Env);
            Orders = new OrderRepository(Env);
        }
        public bool NewOrderToTable(int tableID, List<int> foodIDList, List<int> drinkIDList)
        {
            //Assig order id to occupied table
            DataRefresh();
            OccupiedTable occTable = OccupiedTables.Retrieve(tableID);
              
            if (occTable != null)
            {
                int newOrderID = Orders.NextOrderID();
                Order newOrder = new Order(newOrderID, occTable.OccupiedTableID, occTable.PersonCount, foodIDList, drinkIDList);
                OccupiedTables.AssignOrderID(tableID, newOrderID);
                Orders.NewOrder(newOrder);
                DataRefresh();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddFoodsToTable(int tableID, List<int> foodIDList)
        {
            //Method to add food to occupied table
            DataRefresh();
            OccupiedTable occTable = OccupiedTables.Retrieve(tableID);

            if (occTable != null && occTable.OrderID != null)
            {
                Order order = Orders.Retrieve((int)occTable.OrderID);
                order.FoodIDList.AddRange(foodIDList);
                Orders.WriteToFile();
                DataRefresh();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddDrinksToTable(int tableID, List<int> drinkIDList)
        {
            //Method to add food to occupied table
            DataRefresh();
            OccupiedTable occTable = OccupiedTables.Retrieve(tableID);

            if (occTable != null && occTable.OrderID != null)
            {
                Order order = Orders.Retrieve((int)occTable.OrderID);
                order.DrinkIDList.AddRange(drinkIDList);
                Orders.WriteToFile();
                DataRefresh();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
