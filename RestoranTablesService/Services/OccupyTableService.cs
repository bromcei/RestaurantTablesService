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
        public bool OccupieTable(int tableID, int personCount)
        {
            if(Tables.Retrieve(tableID) != null && Tables.Retrieve(tableID).TableSize >= personCount && OccupiedTables.IsTableFree(tableID))
            {
                int occupiedTableID = OccupiedTables.NextOccupiedTableID();
                OccupiedTable newOccupiedTable = new OccupiedTable(occupiedTableID, tableID, DateTime.Now, personCount);
                OccupiedTables.OccupyNewTable(newOccupiedTable);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetTableFree(int tableID)
        {
            if (Tables.Retrieve(tableID) != null && OccupiedTables.IsTableFree(tableID) == false)
            {
                return OccupiedTables.SetTableFree(tableID);
            }
            else
            {
                return false;
            }
        }

    }
}
