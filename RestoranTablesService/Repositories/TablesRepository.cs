using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class TablesRepository
    {
        public List<Table> TableList { get; set; }
        public TablesRepository(List<Table> tableList)
        {
            TableList = tableList;
        }
    }
}
