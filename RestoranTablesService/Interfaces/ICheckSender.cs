using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Interfaces
{
    public interface ICheckSender
    {

        string CheckPrint(int orderID);
        void CheckSend(int orderID, string emailAddress);
    }
}
