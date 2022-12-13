using RestaurantTablesService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantTablesService.Repositories
{
    public class CheckRepository
    {
        public List<Check> CheckList { get; set; }
        public string FilePath { get; }
        public string Env { get; set; }
        public CheckRepository(string env)
        {
            Env = env;
            if (Env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\CheckOuts.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\CheckOuts.json";
            }
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                CheckList = JsonSerializer.Deserialize<List<Check>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        public List<Check> Retrieve()
        {
            return CheckList;
        }
        public <Check>
    }
}
