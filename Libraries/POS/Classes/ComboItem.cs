using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Products;

namespace POS.Base.Classes
{
    public class ComboItem
    {
        ProductCost _cost;
        string _text;

        public ComboItem(ProductCost cost, string Text)
        {
            _text = Text;
            _cost = cost;
        }

        public ProductCost Cost { get { return (_cost); } }
        public string Text { get { return (_text); } }
    }

}
