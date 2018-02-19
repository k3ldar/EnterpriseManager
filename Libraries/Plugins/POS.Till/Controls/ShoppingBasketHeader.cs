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
 *  File: ShoppingBasketHeader.cs
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

namespace POS.Till.Controls
{
    public partial class ShoppingBasketHeader : SharedControls.BaseControl
    {
        #region Constructors

        public ShoppingBasketHeader()
        {
            InitializeComponent();

            if (!DesignMode && POS.Base.Classes.AppController.ApplicationRunning)
                lblVAT.Visible = POS.Base.Classes.AppController.LocalSettings.ShowPricesWithoutVAT;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblCost.Text = LanguageStrings.AppCost;
            lblDescription.Text = LanguageStrings.AppProduct;
            lblDiscount.Text = LanguageStrings.AppDiscountTypePercent;
            lblPrice.Text = LanguageStrings.AppPrice;
            lblQuantity.Text = LanguageStrings.AppQuantity;
            lblVAT.Text = LanguageStrings.AppVAT;
            lblStaffMember.Text = LanguageStrings.AppStaffMember;
        }

        #endregion Overridden Methods
    }
}
