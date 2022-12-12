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
        public DrinkRepository()
        {
            FilePath = "C:\\Users\\tomas.ceida\\source\\repos\\RestoranTablesService\\RestoranTablesService\\Data\\DrinkMenu.json";
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                DrinkList = JsonSerializer.Deserialize<List<Drink>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }
        public List<Drink> Retrieve()
        {
            return DrinkList;
        }
        public Drink Retrieve(int drinkID)
        {
            return DrinkList.Where(drink => drink.DrinkID == drinkID).FirstOrDefault();
        }
    }
}
