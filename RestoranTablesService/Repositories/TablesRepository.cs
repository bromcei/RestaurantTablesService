﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestaurantTablesService.Classes;

namespace RestaurantTablesService.Repositories
{
    public class TablesRepository
    {
        public string FilePath { get; }
        public List<Table> TableList { get; set; }
        public string Env { get;}
        public TablesRepository(string env)
        {
            Env = env;
            if(Env == "prod")
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Prod\\Tables.json";
            }
            else
            {
                FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\Test\\Tables.json";
            }
            
            
            try
            {
                string jsonString = File.ReadAllText(FilePath);
                TableList = JsonSerializer.Deserialize<List<Table>>(jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        public bool WriteToFile()
        {
            try
            {
                string json_output = JsonSerializer.Serialize(TableList);
                File.WriteAllText(FilePath, json_output);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public List<Table> Retrieve()
        {
            return TableList;
        }
        public Table Retrieve(int tableID)
        {
            return TableList.Where(table => table.TabledID == tableID).FirstOrDefault();
        }
    }
}
