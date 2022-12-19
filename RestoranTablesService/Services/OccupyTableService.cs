using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;
using RestaurantTablesService.Repositories;

namespace RestaurantTablesService.Services
{
    public class OccupyTableService
    {
        public string Env { get; set; }
        public TablesRepository Tables { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }
        
        public OccupyTableService(string env)
        {
            Env = env;
            Tables = new TablesRepository(Env);
            OccupiedTables = new OccupiedTablesRepositories(Env);
        }
        public void DataRefresh()
        {
            Tables = new TablesRepository(Env);
            OccupiedTables = new OccupiedTablesRepositories(Env);
        }

        public List<Table> ListFreeTables()
        {
            //Method Shows free tables
            DataRefresh();
            List<Table> freeTables = new List<Table>();
            foreach (int tableID in Tables.TableList.Select(table => table.TableID).ToList())
            {
                if (OccupiedTables.IsTableFree(tableID))
                {
                    freeTables.Add(Tables.Retrieve(tableID));
                }
            }
            return freeTables;
        }
        public bool OccupieTable(int tableID, int personCount)
        {
            //Method occupies free table
            DataRefresh();
            if (Tables.Retrieve(tableID) != null && Tables.Retrieve(tableID).TableSize >= personCount && OccupiedTables.IsTableFree(tableID))
            {
                int occupiedTableID = OccupiedTables.NextOccupiedTableID();
                OccupiedTable newOccupiedTable = new OccupiedTable(occupiedTableID, tableID, DateTime.Now, personCount);
                OccupiedTables.OccupyNewTable(newOccupiedTable);
                DataRefresh();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetTableFree(int tableID)
        {
            //Method makes occupied table free
            DataRefresh();
            if (Tables.Retrieve(tableID) != null && OccupiedTables.IsTableFree(tableID) == false)
            {
                OccupiedTables.SetTableFreeByTableID(tableID);
                DataRefresh();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RetrieveOrderID(int tableID)
        {
            //Method returns order ID from occupied table
            DataRefresh();
            if (Tables.Retrieve(tableID) != null && OccupiedTables.IsTableFree(tableID) == false)
            {
                OccupiedTable table = OccupiedTables.Retrieve(tableID);
                return (int)table.OrderID.Value;
            }
            else
            {
                return -1;
            }
            
        }

    }
}
