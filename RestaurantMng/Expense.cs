using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantMng
{
    class Expense
    {
        public string Type { get; set; }
        public decimal Value { get; set; }
        public Expense(decimal value)
        {
            this.Type = "undefined";
            this.Value = value;
        }
        public Expense(string type)
        {
            Type = type;
            Value = 0;
        }
        public Expense(string type, decimal value)
        {
            Type = type;
            Value = value;
        }
    }
}
