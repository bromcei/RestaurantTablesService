using RestaurantTablesService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Repositories
{
    public class OccupiedTablesRepositories
    {
        public List<OccupiedTable> OccupiedTablesList { get; set; }
        public string FilePath { get; }
        public OccupiedTablesRepositories()
        {
            FilePath = "OccupiedTables.json";
            OccupiedTablesList = new List<OccupiedTable>();
        }
    }
    
}
