using RestaurantTablesService.Classes;
using RestaurantTablesService.Interfaces;
using RestaurantTablesService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTablesService.Services
{
    public class SendCheckCompany : ICheckSender
    {
        public string Env { get; set; }
        public DrinkRepository Drinks { get; set; }
        public FoodReposiroty Foods { get; set; }
        public CheckRepository Checks { get; set; }

        public SendCheckCompany(string env)
        {
            Env = env;
            Drinks = new DrinkRepository(Env);
            Foods = new FoodReposiroty(Env);
            Checks = new CheckRepository(Env);
        }
        public void DataRefresh()
        {
            Drinks = new DrinkRepository(Env);
            Foods = new FoodReposiroty(Env);
            Checks = new CheckRepository(Env);
        }
        public string CheckPrint(int orderID)
        {
            DataRefresh();
            string HTMLUpperPart = $@"
                <!DOCTYPE html>
                <html>
                <body>
                <h1>Check for order {orderID} </h1>
                <table>
                  <tr>
                    <th>ProductName</th>
                    <th>ProductPrimeCost</th>
                    <th>ProductPrice</th>
                  </tr>
                        ";


            string HTMLLowerPart = @"
                </table>
                </body>
                </html>
                ";

            string HTMLTable = "";
            Check currCheck = Checks.RetrieveByOrderID(orderID);
            List<int> foodIds = currCheck.FoodIDList;
            List<int> drinkIds = currCheck.DrinkIDList;

            foreach (int foodID in foodIds)
            {

                HTMLTable += $@"
                <td>{Foods.Retrieve(foodID).FoodName}</td>
                <td>{Foods.Retrieve(foodID).FoodPrimeCost}</td>
                <td>{Foods.Retrieve(foodID).FoodPrice}</td>
                </tr>
                ";
            }
            foreach (int drinkID in drinkIds)
            {

                HTMLTable += $@"
                <td>{Drinks.Retrieve(drinkID).DrinkName}</td>
                <td>{Drinks.Retrieve(drinkID).DrinkPrimePrice}</td>
                <td>{Drinks.Retrieve(drinkID).DrinkPrice}</td>
                </tr>
                ";
            }
            string HTMLTotalPart = $@"
                <!DOCTYPE html>
                <html>
                <body>
                <h3>Total sum before taxes: {currCheck.TotalPaymentBeforeTax} </h3>
                <h2>Total: {currCheck.TotalPayment} </h2>
                <h2>Total prime cost: {currCheck.TotalPrimeCost} </h2>
                <h2>Total revenue: {currCheck.TotalPayment - currCheck.TotalPrimeCost} </h2>
                        ";
            StringBuilder str = new StringBuilder();
            str.Append(HTMLUpperPart);
            str.Append(HTMLTable);
            str.Append(HTMLLowerPart);
            str.Append(HTMLTotalPart);
            return str.ToString();
        }
        public void CheckSend(int orderID)
        {
            DataRefresh();
            string emailString = CheckPrint(orderID);
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + $"\\Reports\\CompanyChecks\\{orderID}_CompanyCheck.html";
            File.WriteAllText(filePath, emailString);
        }
    }
}

