using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantMng
{
    class InventoryController
    {
        public List<Ingredient> InventoryList { get; set; }
        public List<Ingredient> TotalInv { get; set; }

        public InventoryController()
        {
            InventoryList = new List<Ingredient> ();
            TotalInv = new List<Ingredient> ();
        }
        public void AddInventorySequence()
        {
            Console.WriteLine("What is the Name of Ingredient?");
            var name = Console.ReadLine();
            Console.WriteLine("How much does it weight?");
            var weight = float.Parse(Console.ReadLine());
            Console.WriteLine("How much did it cost?");
            var cost = decimal.Parse(Console.ReadLine());
            AddInventory(new Ingredient(name, weight, cost));
            Console.WriteLine($"{weight}oz of {name} was added to inventory at ${cost}!");
        }
        private void AddInventory(Ingredient ingredient)
        {
            InventoryList.Add(new Ingredient(ingredient.Name, ingredient.Weight, ingredient.Price));
            var match = TotalInv.Where(i => i.Name == ingredient.Name).Count();
            if (match == 0)
            {
                TotalInv.Add(new Ingredient(ingredient.Name, ingredient.Weight, ingredient.Price));
            }
            else
            {
                AdjustTotalInventory(ingredient);
            }
        }

        public void UseInventory(Ingredient ingredient)
        {
            var totalIndex = TotalInv.IndexOf(TotalInv.Where(i => i.Name == ingredient.Name).FirstOrDefault());
            if (totalIndex == -1 || TotalInv[totalIndex].Weight < ingredient.Weight)
            {
                Console.WriteLine($"There is not enough {ingredient.Name} in your inventory");
                return;
            }
            var usedWeight = ingredient.Weight;
            while (usedWeight > 0)
            {
                var listIndex = InventoryList.IndexOf(InventoryList.Where(i => i.Name == ingredient.Name).FirstOrDefault());
                if (InventoryList[listIndex].Weight < usedWeight)
                {
                    usedWeight -= InventoryList[listIndex].Weight;
                    InventoryList.RemoveAt(listIndex);
                }
                else
                {
                    InventoryList[listIndex].Weight -= usedWeight;
                    usedWeight = 0;
                }
            }
            AdjustTotalInventory(ingredient);
        }

        public void DisplaytTotalInventory()
        {
            Console.WriteLine("You have following ingredients in inventory");
            foreach (var ingredient in TotalInv)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Weight}oz at $ {Math.Round(ingredient.Value, 2)} per oz");
            }
        }

        private void AdjustTotalInventory(Ingredient ingredient)
        {
            var index = TotalInv.FindIndex(i => i.Name == ingredient.Name);
            var totalWeight = InventoryList.Where(i => i.Name == ingredient.Name).Sum(i => i.Weight);

            if (totalWeight > 0)
            {
                decimal avgCost = Math.Round(InventoryList.Where(i => i.Name == ingredient.Name).Select(i => i.getCurrentTotalValue()).Sum(), 2) / (decimal)(totalWeight);
                TotalInv[index].Weight = totalWeight;
                TotalInv[index].Value = avgCost;
            }
            else
            {
                TotalInv.RemoveAt(TotalInv.IndexOf(TotalInv.Where(i => i.Name == ingredient.Name).First()));
            }
            foreach (var ing in InventoryList)
            {
                Console.WriteLine($"{ing.Name} - {ing.Weight}");
            }
        }
    }
}
