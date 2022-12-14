using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;
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
        public bool NewCheckOut(int orderID)
        {
            Order orderToCheckOut = Orders.Retrieve(orderID);
            //https://social.msdn.microsoft.com/Forums/en-US/1eca3fdd-8669-40de-a9d9-0e0164c88772/get-list-by-ids?forum=aspgettingstarted
        }
    }
}
