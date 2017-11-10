/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: InvoiceOrderItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
