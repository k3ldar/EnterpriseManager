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
 *  File: StockReports.cs
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

using SharedBase.BOL.Locations;
using SharedBase;
using SharedBase.BOL.StockControl;
using SharedBase.BOL.Users;
using SharedBase.BOL.Products;

using SharedControls.Forms;

namespace Reports.Stock
{
    public partial class StockReports : BaseForm
    {
        #region Private Members

        private User _activeUser;

        #endregion Private Members

        #region Constructors

        public StockReports()
        {
            InitializeComponent();

            LoadSettings();
            dtpSetDate.Value = DateTime.Now;
        }

        #endregion Constructors

        #region Public Static Methods

        /// <summary>
        /// Launches the view stock reports form
        /// </summary>
        public static void ViewStockReports(User activeUser)
        {
            try
            {
                StockReports reports = new StockReports();
                try
                {
                    reports._activeUser = activeUser;
                    reports.ShowDialog();
                }
                finally
                {
                    reports.Dispose();
                    reports = null;
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            }
        }

        #endregion Public Static Methods


        /// <summary>
        /// Loads all settings 
        /// </summary>
        protected override void LoadSettings()
        {
            cmbStoreLocations.Items.Clear();

            foreach(StoreLocation location in Locations.Get())
            {
                cmbStoreLocations.Items.Add(location);
            }

            cmbStockTypes.Items.Clear();
            cmbStockTypes.Items.Add(new ProductCostType(-1, Languages.LanguageStrings.AppAll, ProductCostItemType.Product));

            foreach (ProductCostType type in ProductCostTypes.Get())
            {
                cmbStockTypes.Items.Add(type);
            }

            cmbStoreLocations.SelectedIndex = 0;
            cmbStockTypes.SelectedIndex = 0;
            cmbOptions.SelectedIndex = 0;
        }

        private void cmbStoreLocations_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((StoreLocation)e.ListItem).StoreName;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            switch (cmbOptions.SelectedIndex)
            {
                case 0: // all stock
                case 1: // hide no stock items
                case 2: // low/out of stock
                    ShowStockReport();

                    break;

                case 3: //stock in
                    ShowStockInReport();

                    break;

                case 4: // stock out
                    ShowStockOutReport();

                    break;
                case 5: // specific size
                    ShowStockReport(txtSize.Text);

                    break;
            }
        }

        private void ShowStockInReport()
        {
            StoreLocation location = (StoreLocation)cmbStoreLocations.SelectedItem;
            StockIn stock = StockIn.Get(location.ID, cmbStockTypes.SelectedIndex > 0 ? ((ProductCostType)cmbStockTypes.SelectedItem).ID : -1, new DateTime(1900, 1, 1));
            DateTime date = cmbStockInOutDate.SelectedIndex == 0 ? new DateTime(1900, 1, 1) : Convert.ToDateTime(cmbStockInOutDate.SelectedItem);
            PdfStockInReport report = new PdfStockInReport(location.StoreName, stock, date, cbInOutFromDate.Checked);
            report.View();
        }

        private void ShowStockOutReport()
        {
            StoreLocation location = (StoreLocation)cmbStoreLocations.SelectedItem;
            StockOut stock = StockOut.Get(location.ID,  cmbStockTypes.SelectedIndex > 0 ? ((ProductCostType)cmbStockTypes.SelectedItem).ID : -1, new DateTime(1900, 1, 1));
            DateTime date = cmbStockInOutDate.SelectedIndex == 0 ? new DateTime(1900, 1, 1) : Convert.ToDateTime(cmbStockInOutDate.SelectedItem);
            PdfStockOutReport report = new PdfStockOutReport(location.StoreName, stock, date, cbInOutFromDate.Checked);
            report.View();
        }

        private void ShowStockReport(string size = "")
        {
            StoreLocation location = (StoreLocation)cmbStoreLocations.SelectedItem;
            PdfStockReport report = null;
            SharedBase.BOL.StockControl.Stock stock = null;

            if (cmbStockTypes.SelectedIndex == 0)
                stock = SharedBase.BOL.StockControl.Stock.Get(_activeUser, location.ID);
            else
                stock = SharedBase.BOL.StockControl.Stock.Get(_activeUser, location.ID, ((ProductCostType)cmbStockTypes.SelectedItem).ID);


            if (cmbStockTypes.SelectedIndex > 0)
            {
                for (int i = stock.Count - 1; i >= 0; i--)
                {
                    if (stock[i].ProductType.ID != ((ProductCostType)cmbStockTypes.SelectedItem).ID)
                        stock.RemoveAt(i);
                }
            }
            
            
            if (cmbOptions.SelectedIndex == 5 && !String.IsNullOrEmpty(size))
            {
                for (int i = stock.Count - 1; i >= 0; i--)
                {
                    if (!stock[i].Size.ToUpper().Contains(size.ToUpper()))
                        stock.RemoveAt(i);
                }
            }

            report = new PdfStockReport(location.StoreName, stock, cmbOptions.SelectedIndex, dtpSetDate.Value, size);
            report.View();
        }

        private void cmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreLocation location = (StoreLocation)cmbStoreLocations.SelectedItem;
            cmbStockInOutDate.Items.Clear();

            txtSize.Enabled = false;

            switch (cmbOptions.SelectedIndex)
            {
                case 0: // all stock
                case 1: // hide when non available
                case 2: // low stock report
                    cmbStockInOutDate.Enabled = false;
                    lblStockInOut.Enabled = false;
                    cbInOutFromDate.Enabled = false;
                    
                    break;
                case 3: // stock in
                    cmbStockInOutDate.Enabled = true;
                    lblStockInOut.Enabled = true;
                    cbInOutFromDate.Enabled = true;

                    cmbStockInOutDate.Items.Add("All");

                    foreach (StockInItem item in StockIn.Get(location.ID, cmbStockTypes.SelectedIndex > 0 ? ((ProductCostType)cmbStockTypes.SelectedItem).ID : -1, new DateTime(1900, 1, 1)))
                    {
                        if (!cmbStockInOutDate.Items.Contains(item.Date.Date))
                            cmbStockInOutDate.Items.Add(item.Date.Date);
                    }


                    break;
                case 4: // stock out
                    cmbStockInOutDate.Enabled = true;
                    lblStockInOut.Enabled = true;
                    cbInOutFromDate.Enabled = true;

                    cmbStockInOutDate.Items.Add("All");
             
                    foreach (StockOutItem item in StockOut.Get(location.ID, cmbStockTypes.SelectedIndex > 0 ? ((ProductCostType)cmbStockTypes.SelectedItem).ID : -1, new DateTime(1900, 1, 1)))
                    {
                        if (!cmbStockInOutDate.Items.Contains(item.Date.Date))
                            cmbStockInOutDate.Items.Add(item.Date.Date);
                    }

                    break;
                case 5: // size option
                    txtSize.Enabled = true;

                    break;
                default:
                    throw new Exception("Invalid Selection");
            }

            if (cmbStockInOutDate.Items.Count > 0)
                cmbStockInOutDate.SelectedIndex = 0;
        }

        private void cmbStockTypes_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ProductCostType)e.ListItem).Description;
        }
    }
}
