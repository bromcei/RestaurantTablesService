using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data;
using System.Reflection.PortableExecutable;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class FoodReposiroty
    {
        public List<Food> FoodList { get; set; }
        public string FilePath { get; }
        public string Env { get; set; }
        public FoodReposiroty(string env)
        {
            Env = env;
            if (Env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\FoodMenu.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\FoodMenu.json";
            }
            
            string jsonString = File.ReadAllText(FilePath);
            FoodList = JsonSerializer.Deserialize<List<Food>>(jsonString);
            Env = env;
        }
        public List<Food> Retrieve()
        {
            return FoodList;
        }

        public Food Retrieve(int foodID)
        {
            return FoodList.Where(item => item.FoodID == foodID).FirstOrDefault();
        }
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(FoodList);
                File.WriteAllText(FilePath, json_output);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
