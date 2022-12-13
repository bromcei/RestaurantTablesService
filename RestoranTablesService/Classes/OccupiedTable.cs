using RestaurantTablesService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Classes
{
    public class OccupiedTable
    {
        public int OccupiedTableID { get; set; }
        public int TableID { get; set; }
        public DateTime DateTime { get; set; }
        public int PersonCount { get; set; }
        public int? OrderID { get; set; }
        public int? CheckOutID { get; set; }
        public bool IsOccupied { get; set; }    
        public OccupiedTable(int occupiedTableID, int tableID, DateTime dateTime, int personCount)
        {
            OccupiedTableID = occupiedTableID;
            TableID = tableID;
            DateTime = dateTime;
            PersonCount = personCount;
            OrderID = null;
            CheckOutID = null;
            IsOccupied = true;
        }
        public bool FreeTable()
        {
            IsOccupied = false;
            return true;
        }
        public bool AssignOrder(int orderID)
        {
            OrderID = orderID;
            return true;
        }
        public bool AssignCheckout(int checkOutID)
        {
            CheckOutID = checkOutID;
            return true;
        }
    }
}
