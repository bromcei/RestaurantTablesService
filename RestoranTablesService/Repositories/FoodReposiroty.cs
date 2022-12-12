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
        public FoodReposiroty()
        {
            FilePath = "C:\\Users\\tomas.ceida\\source\\repos\\RestoranTablesService\\RestoranTablesService\\Data\\FoodMenu.json";
            string jsonString = File.ReadAllText(FilePath);
            FoodList = JsonSerializer.Deserialize<List<Food>>(jsonString);
        }
        public List<Food> Retrieve()
        {
            return FoodList;
        }

        public Food Retrieve(int foodID)
        {
            return FoodList.Where(item => item.FoodID == foodID).FirstOrDefault();
        }

    }
}
