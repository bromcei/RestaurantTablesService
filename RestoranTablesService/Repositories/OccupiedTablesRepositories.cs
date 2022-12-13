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
        public string Env { get; set; }
        public OccupiedTablesRepositories(string env)
        {
            Env = env;
            if (Env == "prod")
            {
                FilePath = FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\OccupiedTables.json";
            }
            else
            {
                FilePath = FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\OccupiedTables.json";
            }
            
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
        public bool OccupyTable(int tableID, int personCount)
        {
            //OccupiedTable newReservation = new OccupiedTable(tableID, DateTime.Now, personCount);
            //OccupiedTablesList.Add(newReservation);
            //WriteToFile();
            return true;
        }
    }
    
}
