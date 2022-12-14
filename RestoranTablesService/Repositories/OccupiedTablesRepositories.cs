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
        public TablesRepository TablesRepository { get; set; }
        public OccupiedTablesRepositories(string env)
        {
            Env = env;
            TablesRepository = new TablesRepository(Env);
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
        public bool IsTableFree(int tableID)
        {
            if(OccupiedTablesList.Where(table => table.TableID == tableID && table.IsOccupied == true).ToList().Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int NextOccupiedTableID()
        {
            
            if (OccupiedTablesList != null)
            {
                int maxID = OccupiedTablesList.Max(table => table.OccupiedTableID);
                return maxID + 1;
            }
            else
            {
                return 1;
            }
            
        }
        public bool OccupyNewTable(OccupiedTable occupiedTable)
        {
            OccupiedTablesList.Add(occupiedTable);
            WriteToFile();
            return true;
            /*
            if (IsTableFree(tableID) && TablesRepository.Retrieve(tableID).TableSize >= personCount)
            {
                OccupiedTable newOccTable = new OccupiedTable(NextOccupiedTableID(), tableID, DateTime.Now, personCount);
                OccupiedTablesList.Add(newOccTable);
                WriteToFile();
                return true;
            }
            else
            {
                return false;
            }
            */
        }
        public bool SetTableFree(int tableID)
        {
            if (IsTableFree(tableID))
            {
                return false;
            }
            else
            {
                Retrieve(tableID).IsOccupied = false;
                WriteToFile();
                return true;
            }
            
        }
    }
    
}
