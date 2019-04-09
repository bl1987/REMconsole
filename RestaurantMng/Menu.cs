using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMng
{
    class Menu
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool NeedRecipe { get; set; }
        public Recipe Recipe { get; set; }

        public Menu(string name, decimal price)
        {
            Name = name;
            Price = price;
            NeedRecipe = false;
        }

        public Menu(string name, decimal price, Recipe recipe)
        {
            Name = name;
            Price = price;
            NeedRecipe = true;
            Recipe = recipe;
        }
    }
}
