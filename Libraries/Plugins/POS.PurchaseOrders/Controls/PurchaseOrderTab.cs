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
 *  File: PurchaseOrderTab.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Globalization;

using Languages;

namespace POS.PurchaseOrders.Controls
{
    public partial class PurchaseOrderTab : POS.Base.Controls.BaseOptionsControl
    {
        #region Constructors

        public PurchaseOrderTab()
        {
            InitializeComponent();

            AllowAddNew = true;
            AllowRefresh = true;
            AllowDelete = lvPurchaseOrders.SelectedItems.Count > 0;
            AllowEdit = lvPurchaseOrders.SelectedItems.Count > 0;
            UpdateUI(AllowEdit);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            colPODate.Text = LanguageStrings.Date;
            colPOID.Text = LanguageStrings.AppPurchaseOrderID;
            colPOStatus.Text = LanguageStrings.Status;
            colPOSupplier.Text = LanguageStrings.AppSupplierName;
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        protected override void OnCreateClicked()
        {
            base.OnCreateClicked();
        }

        protected override void OnEditClicked()
        {
            base.OnEditClicked();
        }

        #endregion Overridden Methods
    }
}
