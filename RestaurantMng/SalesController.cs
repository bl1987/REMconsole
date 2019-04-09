using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantMng
{
    class SalesController
    {
        public List<Menu> TotalSales { get; set; }

        public SalesController()
        {
            TotalSales = new List<Menu> { };
        }

        public void AddSaleSequence(MenuController menuControl, InventoryController invControl, RecipeController recControl)
        {
            Console.WriteLine("Which item was sold?");
            var soldItem = Console.ReadLine();
            Console.WriteLine("How many?");
            var qty = int.Parse(Console.ReadLine());
            try
            {
                for (int i = 0; i < qty; i++)
                {
                    AddSale(menuControl.Menus.Where(m => m.Name == soldItem).First());
                    foreach (var ingredient in recControl.Recipes.Where(r => r.Name == soldItem).First().Ingredients)
                    {
                        invControl.UseInventory(ingredient);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("That menu does not exist");
            }
            
        }

        private void AddSale(Menu menu)
        {
            TotalSales.Add(menu);
        }

        public void DisplayTotalSales(MenuController menuControl)
        {
            Console.WriteLine("You have sold following items : ");
            var saleList = TotalSales.GroupBy(s => s.Name).Select(s => new { Item = s.Key, Count = s.Count() });
            foreach (var sale in saleList)
            {
                Console.WriteLine($"{sale.Item} - {sale.Count} : $ {menuControl.Menus.Where(m => m.Name == sale.Item).First().Price * sale.Count}");
            }
        }
    }
}
