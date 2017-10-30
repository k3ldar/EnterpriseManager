using System;
using System.Collections.Generic;
using System.Text;

using SieraDelta.Library.BOL.Products;

namespace SieraDelta.POS.Administration.Classes
{
    internal class ComboItem
    {
        ProductCost _cost;
        string _text;

        internal ComboItem(ProductCost cost, string Text)
        {
            _text = Text;
            _cost = cost;
        }

        internal ProductCost Cost { get { return (_cost); } }
        internal string Text { get { return (_text); } }
    }

}
