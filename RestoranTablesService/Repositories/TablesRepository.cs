using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class TablesRepository
    {
        public string FilePath { get; }
        public List<Table> TableList { get; set; }
        public TablesRepository()
        {
            FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Tables.json";
            
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                TableList = JsonSerializer.Deserialize<List<Table>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(TableList);
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
