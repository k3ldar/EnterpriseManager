using System;
using System.Collections.Generic;
using System.Text;

namespace POS.StockControl.Classes
{
    public sealed class StockRemoveItem
    {
        public StockRemoveItem(string product, string name, double count)
        {
            Product = product;
            Name = name;
            Count = count;
        }

        public string Product { get; set; }

        public string Name { get; set; }

        public double Count { get; set; }
    }
}
