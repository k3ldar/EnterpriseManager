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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CustomVATRateForm.cs
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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedControls.Forms;
using Library.BOL.Basket;

namespace POS.Till.Forms
{
    public partial class CustomVATRateForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private ShoppingBasket _basket;

        #endregion Private Members

        #region Constructors

        public CustomVATRateForm()
        {
            InitializeComponent();
        }

        public CustomVATRateForm(ShoppingBasket basket)
        {
            InitializeComponent();
            _basket = basket;

            if (basket.OverrideVATRate)
                txtVATRate.Text = basket.OverriddenVatRate.ToString();
        }

        #endregion Constructors

        #region Static Methods

        public static void CustomVATRateShow(Form parent, ShoppingBasket basket)
        {
            CustomVATRateForm frm = new CustomVATRateForm(basket);
            try
            {
                frm.ShowDialog(parent);
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TillCustomVATRate;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppOrderCustomVATRate;

            lblDescription.Text = LanguageStrings.AppOrderCustomVATRate;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnClear.Text = LanguageStrings.AppMenuButtonClear;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        private void btnClear_Click(object sender, EventArgs e)
        {
            _basket.OverrideVATRate = false;
            _basket.OverriddenVatRate = 0.00;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _basket.OverrideVATRate = true;
            _basket.OverriddenVatRate = Shared.Utilities.StrToDblDef(txtVATRate.Text, 0.00);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
