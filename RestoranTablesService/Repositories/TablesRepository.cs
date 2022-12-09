using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoranTablesService.Classes;

namespace RestoranTablesService.Repositories
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
