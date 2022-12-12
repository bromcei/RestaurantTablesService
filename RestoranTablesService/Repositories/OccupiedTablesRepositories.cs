using RestaurantTablesService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantTablesService.Repositories
{
    public class OccupiedTablesRepositories
    {
        public List<OccupiedTable> OccupiedTablesList { get; set; }
        public string FilePath { get; }
        public OccupiedTablesRepositories()
        {
            FilePath = FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\OccupiedTables.json";
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                OccupiedTablesList = JsonSerializer.Deserialize<List<OccupiedTable>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        public List<OccupiedTable> Retrieve()
        {
            return OccupiedTablesList;
        }
        public OccupiedTable Retrieve(int tableID)
        {
            return OccupiedTablesList.Where(table => table.TableID == tableID).FirstOrDefault();
        }
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(OccupiedTablesList);
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
