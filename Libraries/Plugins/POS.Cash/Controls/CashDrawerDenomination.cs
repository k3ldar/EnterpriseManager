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
 *  File: CashDrawerDenomination.cs
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

using Library.Utils;
using Library.BOL.CashDrawer;
using POS.Base.Classes;

namespace POS.CashManager.Classes
{
    public partial class CashDrawerDenomination : UserControl
    {
        public CashDrawerDenomination(CashDenomination denomination)
        {
            InitializeComponent();
            Denomination = denomination;

            lblValue.Text = Library.Utils.SharedUtils.FormatMoney(denomination.Value, AppController.LocalCurrency, false);
            txtValue.Text = StringConstants.SYMBOL_ZERO;
        }

        #region Properties

        /// <summary>
        /// Current Cash Denomination
        /// </summary>
        public CashDenomination Denomination { get; private set; }

        /// <summary>
        /// Value input by user
        /// </summary>
        public int UserQuantity
        {
            get
            {
                return (Shared.Utilities.StrToIntDef(txtValue.Text, 0));
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Event handler for user value changed
        /// </summary>
        public event EventHandler OnValueChanged;

        #endregion Events

        #region Private Methods

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (OnValueChanged != null)
                OnValueChanged(this, e);
        }

        #endregion Private Methods
    }
}
