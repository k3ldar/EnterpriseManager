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
 *  File: StockHistoryForm.cs
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
using SharedBase.Utils;
using SharedBase.BOL.StockControl;
using POS.Base.Classes;

namespace POS.StockControl.Forms
{
    public partial class StockHistoryForm : POS.Base.Forms.BaseForm
    {
        #region Private / Protected Members

        private StockHistory _history;
        private StockHistory _historyTotals;

        #endregion Private / Protected Members

        #region Constructors

        public StockHistoryForm(StockItem stockItem, StockHistory history, StockHistory historyTotals)
        {
            InitializeComponent();

            _history = history;
            _historyTotals = historyTotals;

            //get settings
            this.Text += String.Format(StringConstants.PREFIX_AND_SUFFIX_SPACE, stockItem.Name, stockItem.Size);

            Top = AppController.LocalSettings.StockHistoryTop;
            Left = AppController.LocalSettings.StockHistoryLeft;
            cbInternetSales.Checked = AppController.LocalSettings.StockHistoryShowInternet;

            //load history
            LoadStock();
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Displays the Stock History Form
        /// </summary>
        /// <param name="history"></param>
        public static void Show(StockItem stockItem, StockHistory history, StockHistory historyTotals)
        {
            StockHistoryForm stockHistoryForm = new StockHistoryForm(stockItem, history, historyTotals);
            try
            {
                stockHistoryForm.ShowDialog();
            }
            finally
            {
                stockHistoryForm.Dispose();
                stockHistoryForm = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockHistory;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colDate.Text = LanguageStrings.AppDate;
            colLocation.Text = LanguageStrings.AppLocation;
            colQuantity.Text = LanguageStrings.AppQuantity;
            colReason.Text = LanguageStrings.AppStockReason;
            colUser.Text = LanguageStrings.AppUser;

            tabPageHistory.Text = LanguageStrings.History;
            tabPageTotals.Text = LanguageStrings.Totals;

            colHeaderStockTotalsDate.Text = LanguageStrings.AppDate;
            colHeaderStockTotalsUser.Text = LanguageStrings.AppUser;
            colHeaderStockTotalsOldQuantity.Text = LanguageStrings.AppStockOldQuantity;
            colHeaderStockTotalsNewQuantity.Text = LanguageStrings.AppStockNewQuantity;

            btnClose.Text = LanguageStrings.AppMenuButtonClose;

            cbInternetSales.Text = LanguageStrings.AppStockShowInternetSales;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadStock()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                lvHistory.Items.Clear();

                foreach (StockHistoryItem item in _history)
                {
                    if (item.Store != StringConstants.STOCK_SALE_INTERNET ||
                        (item.Store == StringConstants.STOCK_SALE_INTERNET && 
                        cbInternetSales.Checked))
                    {
                        ListViewItem itm = new ListViewItem();
                        itm.Text = Shared.Utilities.FormatDate(item.Date, 
                            AppController.LocalSettings.CustomCulture);
                        itm.SubItems.Add(item.UserName);
                        itm.SubItems.Add(item.Store);
                        itm.SubItems.Add(item.Reason);
                        itm.SubItems.Add(item.Quantity.ToString());
                        lvHistory.Items.Add(itm);
                    }
                }

                lvStockTotals.Items.Clear();

                foreach (StockHistoryItem item in _historyTotals)
                {
                    ListViewItem totItem = new ListViewItem();
                    totItem.Text = Shared.Utilities.FormatDate(item.Date,
                            AppController.LocalSettings.CustomCulture);
                    totItem.SubItems.Add(item.UserName);
                    totItem.SubItems.Add(item.OldTotal.ToString());
                    totItem.SubItems.Add(item.NewTotal.ToString());
                    lvStockTotals.Items.Add(totItem);
                }
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void StockHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppController.LocalSettings.StockHistoryTop = Top;
            AppController.LocalSettings.StockHistoryLeft = Left;
            AppController.LocalSettings.StockHistoryShowInternet = cbInternetSales.Checked;
        }

        private void cbInternetSales_CheckedChanged(object sender, EventArgs e)
        {
            LoadStock();
        }

        #endregion Private Methods
    }
}
