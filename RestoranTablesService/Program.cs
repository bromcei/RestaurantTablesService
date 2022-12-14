// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Classes;

OccupiedTablesRepositories OccTables = new OccupiedTablesRepositories("prod");
DrinkRepository Drinks = new DrinkRepository("prod");

Console.WriteLine(OccTables.IsTableFree(1));

/*
int maxID = OccTables.OccupiedTablesList.Max(table => table.OccupiedTableID);

Console.WriteLine(maxID);
*/


var list1 = new List<int>() { 1, 2, 3, 4, 5 };
var list2 = new List<int>() { 1, 3, 5, 7, 9 };

// Use the Intersect method to get the intersection of the two lists.
var result = list1.Intersect(list2);


List<int> res1 = Drinks.Retrieve().Select(drink => drink.DrinkID).ToList();
foreach(var item in res1)
{
    Console.WriteLine(item);
}
