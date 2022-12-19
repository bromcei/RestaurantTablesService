using RestaurantTablesService.Classes;
using RestaurantTablesService.Repositories;
using RestaurantTablesService.Services;
using Xunit.Sdk;

namespace UnitTests
{
    //Repositories tests

    public class TablesRepositoryTests
    {
        [Fact]
        public void TablesRepositoryTest1()
        {
            // Arrange
            TablesRepository testTables = new TablesRepository("test");

            int expectedNoOfTables = testTables.TableList.Count;

            int expectedTableSize = 4;
            // Act

            int noOfTables = testTables.Retrieve().Count;
            int tableSize = testTables.Retrieve(1).TableSize;
            // Assert
            Assert.Equal(expectedNoOfTables, noOfTables);

        }
        [Fact]
        public void TablesRepositoryTest2()
        {
            // Arrange
            TablesRepository testTables = new TablesRepository("test");

            int expectedTableSize = 4;
            // Act

            int tableSize = testTables.Retrieve(1).TableSize;
            // Assert
            Assert.Equal(expectedTableSize, tableSize);
        }
    }
    public class DrinkRepositoryTests
    {
        [Fact]
        public void DrinkRepositoryTest1()
        {
            // Arrange
            DrinkRepository drinks = new DrinkRepository("test");

            decimal expectedDrinkPrice = 2.6m;
            string expectedDrinkName = "Gira Test";
            // Act

            decimal drinkPrice = drinks.Retrieve(2).DrinkPrice;
            string drinkName = drinks.Retrieve(2).DrinkName;
            // Assert
            Assert.Equal(expectedDrinkPrice, drinkPrice);
            Assert.Equal(expectedDrinkName, drinkName);
        }

    }

    // Service tests
    public class CheckOutServiceTests
    {
        [Fact]
        public void CheckOutServiceTest1()
        {
            // Arrange
            CheckOutService checkoutService = new CheckOutService("test");

            decimal expectedOrderSum = 17.1m;
            // Act

            decimal orderSum = checkoutService.TotalOrderSum(1);

            // Assert
            Assert.Equal(expectedOrderSum, orderSum);

        }
        [Fact]
        public void CheckOutServiceTest2()
        {
            // Arrange
            CheckOutService checkoutService = new CheckOutService("test");

            decimal expectedPrimeOrderSum = 6.0m;
            // Act

            decimal orderPrimeSum = checkoutService.TotalOrderPrimeSum(1);

            // Assert
            Assert.Equal(expectedPrimeOrderSum, orderPrimeSum);

        }

    }
}