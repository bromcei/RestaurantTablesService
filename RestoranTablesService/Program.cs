// See https://aka.ms/new-console-template for more information
using RestaurantTablesService.Services;

string env = "prod";
OccupyTableService TableSitter = new OccupyTableService(env);
OrderService OrderService = new OrderService(env);
CheckOutService CheckOutService = new CheckOutService(env);
SendCheckCompany SendCheckCompanyService = new SendCheckCompany(env);
SendCheckClient SendCheckClient = new SendCheckClient(env);


/*
TableSitter.OccupieTable(1, 2);
Console.WriteLine("Pasodinimas");


OrderService.NewOrderToTable(1, new List<int>() { 1, 1 }, new List<int>());


Console.WriteLine("Order ir maistas");
OrderService.AddDrinksToTable(1, new List<int>() { 2, 2 });
Console.WriteLine("Gerimai");
int orderID = TableSitter.RetrieveOrderID(1);
CheckOutService.NewCheckOut(orderID, "test@gmail.com");
Console.WriteLine("Check out");
SendCheckClient.CheckSend(orderID);
SendCheckCompanyService.CheckSend(orderID);
Console.WriteLine("Check Send");
*/

//TableSitter.OccupieTable(1, 2);
OrderService.NewOrderToTable(1, new List<int>() { 3, 2, 4 }, new List<int>());
int orderID = TableSitter.RetrieveOrderID(1);
CheckOutService.NewCheckOut(orderID, "alio@gmail.com");