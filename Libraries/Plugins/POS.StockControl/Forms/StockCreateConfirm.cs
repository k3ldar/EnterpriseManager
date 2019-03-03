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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: StockCreateConfirm.cs
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
using System.Text;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;
using POS.Base.Forms;
using POS.StockControl.Classes;

namespace POS.StockControl.Forms
{
    public partial class StockCreateConfirm : BaseForm
    {
        #region Constructors

        public StockCreateConfirm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Static Methods

        public static bool ConfirmStockCreate(string stockAdd, List<StockRemoveItem> items)
        {
            bool Result = false;

            StockCreateConfirm frm = new StockCreateConfirm();
            try
            {
                frm.lblStockCreate.Text = stockAdd;

                foreach (StockRemoveItem item in items)
                {
                    ListViewItem itm = new ListViewItem();
                    itm.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE, item.Product, item.Name);
                    itm.SubItems.Add(item.Count.ToString());
                    frm.lvRemoveItems.Items.Add(itm);
                }

                Result = frm.ShowDialog() == DialogResult.OK;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockCreateConfirm;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppStockCreate;

            lblStockRemove.Text = LanguageStrings.AppStockItemsToBeRemoved;

            btnCancel.Text = LanguageStrings.AppCancel;
            btnOK.Text = LanguageStrings.AppOK;

            chStockName.Text = LanguageStrings.AppStockName;
            chStockQuantity.Text = LanguageStrings.AppStockRemoveQuantity;
        }

        #endregion Overridden Methods
    }
}
