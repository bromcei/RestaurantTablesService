// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Classes;

/*
string FilePath = "C:\\Users\\tomas.ceida\\source\\repos\\RestoranTablesService\\RestoranTablesService\\Data\\FoodMenu.json";
string json_output = File.ReadAllText(FilePath);
List<Food> FoodList = JsonSerializer.Deserialize<List<Food>>(jsonString);
*/

Order orederTest = new Order(1, 1, 2, new List<int>() { 1, 2, 3 }, new List<int>() { 4, });
Console.WriteLine(JsonSerializer.Serialize(orederTest));
/*
FoodReposiroty menu = new FoodReposiroty();
DrinkRepository drinks = new DrinkRepository();
*/
//Console.WriteLine(FoodList[0].FoodName);

/*
string workingDirectory = Environment.CurrentDirectory;
string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

Console.WriteLine(projectDirectory);
*/


OrderRepository Orders = new OrderRepository("prod");

Console.WriteLine(Orders.Retrieve(2));





