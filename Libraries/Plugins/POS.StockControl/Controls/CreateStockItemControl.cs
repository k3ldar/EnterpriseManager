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
 *  File: CreateStockItemControl.cs
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

using Library.BOL.Products;

using Languages;
using POS.StockControl.Classes;
using POS.Base.Classes;

using SharedControls;

namespace POS.StockControl.Controls
{
    public partial class CreateStockItemControl : BaseControl
    {
        private ProductCost _costItem;
        private ProductCost _primary;
        private double _quantity;
        private int _stockAvailable;

        public CreateStockItemControl()
        {
            InitializeComponent();
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblQuantity.Text = Languages.LanguageStrings.AppQuantity;
            lblStockAvailable.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE,
                _stockAvailable, Languages.LanguageStrings.AppStockAvailable);
        }

        public bool Reset(ProductCost primary, ProductCost cost, double quantity, int stockAvailable)
        {
            bool Result = true;
            _costItem = cost;
            _primary = primary;
            _quantity = quantity;
            _stockAvailable = stockAvailable;
            lblDescription.Text = String.Format(StringConstants.STOCK_ITEM_WITH_SKU, cost.SKU, cost.Product.Name, cost.Size);

            int count = BitConverter.GetBytes(decimal.GetBits((decimal)quantity)[3])[2];

            if (spinQuantity.DecimalPlaces != count)
                spinQuantity.DecimalPlaces = count;

            if (quantity > stockAvailable)
            {
                lblDescription.ForeColor = Color.Red;
                lblQuantity.ForeColor = Color.Red;
                lblStockAvailable.ForeColor = Color.Red;
                Result = false;
            }
            else
            {
                lblDescription.ForeColor = Color.Black;
                lblQuantity.ForeColor = Color.Black;
                lblStockAvailable.ForeColor = Color.Black;
            }

            spinQuantity.Value = (decimal)quantity;

            return (Result);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _costItem.StockCreationItems.Delete(_primary, _costItem);
            RaiseDeleteItem();
        }

        #region Events

        public event EventHandler DeleteItem;

        private void RaiseDeleteItem()
        {
            if (DeleteItem != null)
                DeleteItem(this, EventArgs.Empty);
        }

        #endregion Events

        private void spinQuantity_ValueChanged(object sender, EventArgs e)
        {
            int count = BitConverter.GetBytes(decimal.GetBits(spinQuantity.Value)[3])[2];

            if (spinQuantity.DecimalPlaces != count)
                spinQuantity.DecimalPlaces = count;

            if ((double)spinQuantity.Value != _quantity)
                _primary.StockCreationItems.Update(_primary, _costItem, (double)spinQuantity.Value);
        }

        private void spinQuantity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Zoom & spinQuantity.DecimalPlaces == 0)
                spinQuantity.DecimalPlaces = 3;
        }
    }
}
