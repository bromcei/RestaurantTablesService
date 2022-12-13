using RestaurantTablesService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class OrderRepository
    {
        public List<Order>OrderList { get; set; }
        public string FilePath { get; }
        public string Env { get; set; }
        public OrderRepository(string env)
        {
            Env = env;
            if (Env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\Orders.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\Orders.json";
            }
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                OrderList = JsonSerializer.Deserialize<List<Order>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }            
        }
        public List<Order> Retrieve()
        {
            return OrderList;
        }
        public Order Retrieve(int orderID)
        {
            return OrderList.Where(order => order.OrderID == orderID).SingleOrDefault();
        }
    }
    
}
