using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMng
{
    class Ingredient:Expense
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public decimal Price { get; set; }

        public Ingredient() : base("Food") { }
        public Ingredient(string name, float weight) : base("Food")
        {
            Name = name;
            Weight = weight;
        }
        public Ingredient(string name, float weight, decimal cost) : base("Food")
        {
            Name = name;
            Weight = weight;
            Price = cost;
            Value = cost/(decimal)weight;
        }

        public decimal getCurrentTotalValue()
        {
            return Value * (decimal)Weight;
        }

    }
}
