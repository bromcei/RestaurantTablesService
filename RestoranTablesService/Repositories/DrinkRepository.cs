using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class DrinkRepository
    {
        public List<Drink> DrinkList { get; set; }
        public string FilePath { get; }
        public string Env { get; set; }
        public DrinkRepository(string env)
        {
            Env = env;
            if (env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\DrinkMenu.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\DrinkMenu.json";
            }
            //FilePath = "C:\\Users\\tomas.ceida\\source\\repos\\RestoranTablesService\\RestoranTablesService\\Data\\DrinkMenu.json";
            
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                if (jsonString.Length == 0)
                {
                    DrinkList = new List<Drink>();
                }
                else
                {
                    DrinkList = JsonSerializer.Deserialize<List<Drink>>(jsonString);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            Env = env;
        }
        public List<Drink> Retrieve()
        {
            return DrinkList;
        }
        public Drink Retrieve(int drinkID)
        {
            return DrinkList.Where(drink => drink.DrinkID == drinkID).FirstOrDefault();
        }
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(DrinkList);
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
