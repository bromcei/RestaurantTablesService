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
        public bool OccupieTable(int tableID, int personCount)
        {
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
