using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.Utils;
using Library.BOL.Invoices;
using Library.BOL.Orders;
using POS.Base.Classes;

namespace POS.Base.Controls
{
    public partial class InvoiceOrderItem : UserControl
    {
        public InvoiceOrderItem(Invoice invoice, InvoiceItem item)
        {
            InitializeComponent();

            lblCost.Text = item.CostStr;

            string description = item.Description;

            if (AppController.LocalSettings.InvoiceShowProductDiscount && item.UserDiscount > 0.00m)
            {
                description = String.Format(LanguageStrings.AppProductDiscount, 
                    description, item.UserDiscount);
            }

            lblDescription.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE, 
                item.SKU, description);

            lblPrice.Text = item.PriceStr;
            lblQuantity.Text = item.Quantity.ToString();
        }

        public InvoiceOrderItem(Order order, Library.BOL.Orders.OrderItem item)
        {
            InitializeComponent();

            string description = item.Description;

            if (AppController.LocalSettings.InvoiceShowProductDiscount && item.UserDiscount > 0.00m)
            {
                description = String.Format(LanguageStrings.AppProductDiscount, 
                    description, item.UserDiscount);
            }

            lblCost.Text = item.CostStr;
            lblDescription.Text = description;
            lblPrice.Text = item.PriceStr;
            lblQuantity.Text = item.Quantity.ToString();
        }
    }
}
