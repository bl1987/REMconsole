using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantMng
{
    class MenuController
    {
        public List<Menu> Menus { get; set; }

        public MenuController()
        {
            Menus = new List<Menu> { };
        }
        public void AddMenuSequence(InventoryController invControl, RecipeController recControl)
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            Console.WriteLine("What is it called?");
            var menuName = Console.ReadLine();
            Console.WriteLine("How much are you going to charge for this?");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Do you need recipe for this? (y/n)");
            input = Console.ReadKey();
            Console.Clear();
            switch (input.KeyChar)
            {
                case 'y':
                    AddMenu(new Menu(menuName, price, recControl.AddRecipeSequence(menuName, invControl)));
                    break;
                case 'n':
                    AddMenu(new Menu(menuName, price));
                    break;
                default:
                    Console.WriteLine("You did not answer the question");
                    break;
            }
        }
        private void AddMenu(Menu menu)
        {
            Menus.Add(menu);
        }

        public void DisplayMenu(RecipeController recControl)
        {
            foreach (var menu in Menus)
            {
                Console.WriteLine($"{menu.Name} - $ {menu.Price}");
                if (menu.NeedRecipe)
                {
                    var recipeCost = recControl.Recipes.Where(m => m.Name == menu.Name).First().calRecipeCost();
                    var costMsg = recipeCost == -1 ? "no inventory avaliable to calculate the cost" : "$" + recipeCost.ToString();
                    var r = recControl.Recipes.Where(m => m.Name == menu.Name).First().Ingredients;
                    Console.WriteLine("Cost : " + costMsg);
                    foreach (var ingredient in r)
                    {
                        Console.WriteLine($"{ingredient.Name} - {ingredient.Weight} oz");
                    }
                }

            }
        }
    }
}
