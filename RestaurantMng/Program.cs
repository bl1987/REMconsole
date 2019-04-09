using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMng
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryController inventoryControl = new InventoryController();
            RecipeController recipeControl = new RecipeController();
            MenuController menuControl = new MenuController();
            SalesController salesControl = new SalesController();
            ConsoleKeyInfo input = new ConsoleKeyInfo();

            Console.WriteLine("Welcome to Restaurant Expense Manager!");
            while (input.KeyChar != '7')
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Add Ingredient");
                Console.WriteLine("2 - Add Menu");
                Console.WriteLine("3 - View Menu");
                Console.WriteLine("4 - Add Today's Sale");
                Console.WriteLine("5 - Check Today's Sale");
                Console.WriteLine("6 - Check Inventory");
                Console.WriteLine("7 - exit");
                input = Console.ReadKey();
                Console.Clear();
                switch (input.KeyChar)
                {
                    case '1':
                        inventoryControl.AddInventorySequence();
                        break;                                                           
                    case '2':
                        menuControl.AddMenuSequence(inventoryControl, recipeControl);
                        break;
                    case '3':
                        menuControl.DisplayMenu(recipeControl);
                        break;
                    case '4':
                        salesControl.AddSaleSequence(menuControl, inventoryControl, recipeControl);
                        break;
                    case '5':
                        salesControl.DisplayTotalSales(menuControl);
                        break;
                    case '6':
                        inventoryControl.DisplaytTotalInventory();
                        break;
                    default:
                        Console.WriteLine("Select a number 1 ~ 7");
                        break;
                }
            }
        }
    }
}
