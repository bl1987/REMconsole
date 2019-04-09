using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMng
{
    class RecipeController
    {
        public List<Recipe> Recipes { get; set; }

        public RecipeController ()
        {
            Recipes = new List<Recipe> { };
        }

        public Recipe AddRecipeSequence(string menuName, InventoryController invControl)
        {
            List<Ingredient> recipe = new List<Ingredient> { };
            ConsoleKeyInfo input = new ConsoleKeyInfo() {};
            while (input.KeyChar != 'n')
            {
                Console.Clear();
                Console.WriteLine("What is the name of ingredient?");
                var ingName = Console.ReadLine();
                Console.WriteLine("How much of it are you using?");
                var ingUsed = float.Parse(Console.ReadLine());
                recipe.Add(new Ingredient(ingName, ingUsed));
                var lastIndex = recipe.Count - 1;
                Console.WriteLine($"{ingName} was added to {menuName}!");
                Console.WriteLine("Would you like to add more ingredient to this recipe?(y/n)");
                input = Console.ReadKey();
                Console.Clear();
                if (input.KeyChar != 'n' || input.KeyChar != 'y')
                {
                    Console.Clear();
                    Console.WriteLine("Please press 'y' or 'n'");
                    Console.WriteLine("Would you like to add more ingredient to this recipe?(y/n)");
                }
            }
            var newRecipe = new Recipe(menuName, recipe, invControl.TotalInv);
            AddRecipe (newRecipe);
            return newRecipe;
        }
        public void AddRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }
    }
}
