using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Interfaces;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Classes;


namespace RestaurantTablesService.Services
{
    public class SendCheckClient : ICheckSender
    {
        public string Env { get; set; }
        public DrinkRepository Drinks { get; set; }
        public FoodReposiroty Foods { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }
        public OrderRepository Orders { get; set; }
        public CheckRepository Checks { get; set; }

        public string CheckPrint(int orderID)
        {
            string HTMLUpperPart = $@"
                <!DOCTYPE html>
                <html>
                <body>
                <h1>Check for order {orderID} </h1>
                <table>
                  <tr>
                    <th>Nr</th>
                    <th>ProductName</th>
                    <th>ProductPrice</th>
                  </tr>
                        ";


            string HTMLLowerPart = @"
                </table>
                </body>
                </html>
                ";

            string HTMLTable = "";
            string backGroundColor;
            Check check = Checks.RetrieveByOrderID(orderID);

            foreach (ReportItem reportItem in ReportList)
            {
                if (reportItem.IsEu)
                {
                    backGroundColor = "#00FFFF";
                }
                else
                {
                    backGroundColor = "#AA4A44";
                }
                HTMLTable += $@"
                <tr style=""background-color:{backGroundColor}"">
                <td>{reportItem.TailNumber}</td>
                <td>{reportItem.AircraftModel}</td>
                <td>{reportItem.CompanyName}</td>
                <td>{reportItem.Country}</td>
                </tr>
                ";
            }
            return "sgfg";
        }
        public void CheckSend(int orderID, string emailAddress)
        {
            Console.WriteLine("sdfdfsgdf");
        }
    }


}
