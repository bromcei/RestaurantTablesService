using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class Table
    {
        public int TabledID { get; set; }
        public int TableSize { get; set; }

        public Table(int tabledID, int tableSize)
        {
            TabledID = tabledID;
            TableSize = tableSize;
        }
    }
}
