using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTablesService.Repositories;

namespace RestaurantTablesService.Services
{
    public class OrderService
    {
        public DrinkRepository DrinkRepository { get; set; }
        public FoodReposiroty FoodReposiroty { get; set; }
        public OccupiedTablesRepositories OccupiedTables { get; set; }

    }
}
