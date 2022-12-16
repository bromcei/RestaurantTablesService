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
        public List<Order> OrderList { get; set; }
        public string FilePath { get; }
        public string Env { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }
        public OrderRepository(string env)
        {
            Env = env;
            OccupiedTables = new OccupiedTablesRepositories(Env);
            if (Env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\Orders.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\Orders.json";
            }

             string jsonString = File.ReadAllText(FilePath);
            if (jsonString.Length == 0)
            {
                OrderList = new List<Order>();
            }
            else
            {
                OrderList = JsonSerializer.Deserialize<List<Order>>(jsonString);
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
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(OrderList);
                File.WriteAllText(FilePath, json_output);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public int NextOrderID()
        {

            if (OrderList.Count > 0)
            {
                int maxID = OrderList.Max(order => order.OrderID);
                return maxID + 1;
            }
            else
            {
                return 1;
            }

        }
        public bool NewOrder(Order order)
        {
            OrderList.Add(order);
            WriteToFile();
            return true;
        }
    }
    
}
