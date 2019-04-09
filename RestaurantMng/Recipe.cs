using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantMng
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Ingredient> CurrentInventory { get; set; }
        public Recipe() { }

        public Recipe(string name, List<Ingredient> ing, List<Ingredient> currentInv)
        {
            Name = name;
            Ingredients = ing;
            CurrentInventory = currentInv;
        }

        public decimal calRecipeCost()
        {
            decimal recipeCost = 0;
            foreach(var ing in Ingredients)
            {
                if( CurrentInventory.FirstOrDefault(i => i.Name == ing.Name) == null)
                {
                    return -1;
                }
                recipeCost += CurrentInventory.Where(i => i.Name == ing.Name).First().Value * (decimal)ing.Weight;
            }
            return recipeCost;
        }
    }
}
