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
 *  File: SavedBasketOrdersForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library.BOL.Basket;

namespace SieraDelta.POS.Orders.Forms
{
    public partial class SavedBasketOrdersForm : SieraDelta.POS.Forms.BaseForm
    {
        #region Constructors

        public SavedBasketOrdersForm()
        {
            InitializeComponent();

            LoadSavedOrders();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppOrderCreateSelect;

            lblSavedOrders.Text = LanguageStrings.AppOrderSavedOrdersDescription;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOpenSelected.Text = LanguageStrings.AppMenuButtonOpen;
        }

        #endregion Overridden Methods

        #region Properties

        public Int64 BasketID
        {
            get
            {
                SavedBasket basket = (SavedBasket)lstSavedOrders.SelectedItem;
                return (basket.BasketID);
            }
        }


        public Int64 UserID
        {
            get
            {
                SavedBasket basket = (SavedBasket)lstSavedOrders.SelectedItem;
                return (basket.UserID);
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadSavedOrders()
        {
            lstSavedOrders.Items.Clear();

            SavedBaskets saved = SavedBaskets.Get();

            foreach (SavedBasket basket in saved)
            {
                lstSavedOrders.Items.Add(basket);
            }
        }

        private void btnOpenSelected_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void lstSavedOrders_Format(object sender, ListControlConvertEventArgs e)
        {
            SavedBasket basket = (SavedBasket)e.ListItem;
            e.Value = basket.Description;
        }

        private void lstSavedOrders_DoubleClick(object sender, EventArgs e)
        {
            if (lstSavedOrders.SelectedItem != null)
                DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        #endregion Private Methods
    }
}
