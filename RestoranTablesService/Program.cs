// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Classes;

string FilePath = "C:\\Users\\tomas.ceida\\source\\repos\\RestoranTablesService\\RestoranTablesService\\Data\\FoodMenu.json";
string jsonString = File.ReadAllText(FilePath);
List<Food> FoodList = JsonSerializer.Deserialize<List<Food>>(jsonString);


FoodReposiroty menu = new FoodReposiroty();
DrinkRepository drinks = new DrinkRepository();

//Console.WriteLine(FoodList[0].FoodName);
Console.WriteLine(drinks.Retrieve(1).DrinkName);

string workingDirectory = Environment.CurrentDirectory;
string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

Console.WriteLine(projectDirectory);

