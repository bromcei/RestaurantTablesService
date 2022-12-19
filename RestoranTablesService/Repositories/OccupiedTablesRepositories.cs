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
            

            string jsonString = File.ReadAllText(FilePath);
            if (jsonString.Length == 0)
            {
                OccupiedTablesList = new List<OccupiedTable>();
            }
            else
            {
                OccupiedTablesList = JsonSerializer.Deserialize<List<OccupiedTable>>(jsonString);
            }

            
             
        }
        public List<OccupiedTable> Retrieve()
        {
            return OccupiedTablesList;
        }
        public OccupiedTable Retrieve(int tableID)
        {
            return OccupiedTablesList.Where(table => table.TableID == tableID && table.IsOccupied == true).FirstOrDefault();
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
            
            if (OccupiedTablesList.Count > 0)
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
        }
        public bool SetTableFreeByTableID(int tableID)
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
        public bool SetTableFreeByOccupiedTableID(int occupiedTableID)
        {
            int tableID = OccupiedTablesList.Where(table => table.OccupiedTableID == occupiedTableID).FirstOrDefault().TableID;
            SetTableFreeByTableID(tableID);
            return true;

        }
        public bool AssignOrderID(int tableID, int orderID)
        {
            OccupiedTable table = Retrieve(tableID);
            table.OrderID = orderID;
            WriteToFile();
            return true;
        }

    }
    
}
