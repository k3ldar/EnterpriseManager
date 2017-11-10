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
 *  File: ProductReports.cs
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
using Library.BOL.Locations;
using Library;
using Library.BOL.Statistics;
using Library.BOL.Users;
using Library.BOL.Products;

using SharedControls.Forms;

namespace Reports.Products
{
    public partial class ProductReportsForm : BaseForm
    {
        public ProductReportsForm()
        {
            InitializeComponent();

            LoadReportTypes();
        }

        #region Static Methods


        public static void ViewProductReports()
        {
            try
            {
                ProductReportsForm reports = new ProductReportsForm();
                try
                {
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
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            }
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.ProductReports;
            btnView.Text = LanguageStrings.AppMenuButtonView;
            lblReportType.Text = LanguageStrings.ReportType;
            lblNumberOfDays.Text = LanguageStrings.NumberOfDays;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadReportTypes()
        {
            cmbReportType.Items.Clear();

            foreach (ProductReportType reportType in Enum.GetValues(typeof(ProductReportType)))
            {
                cmbReportType.Items.Add(reportType);
            }

            cmbReportType.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ProductReportType reportType = (ProductReportType)cmbReportType.SelectedItem;
            SimpleStatistics results = null;

            switch (reportType)
            {
                case ProductReportType.Top10SellingProducts:
                    results = Statistics.TopProducts(10, (int)udDays.Value);
                    break;
                case ProductReportType.Top20SellingProducts:
                    results = Statistics.TopProducts(20, (int)udDays.Value);
                    break;
                case ProductReportType.TopSellingProducts:
                    results = Statistics.TopProducts(100000, (int)udDays.Value);
                    break;
                default:
                    throw new Exception("Invalid ProductReportType");
            }

            PdfTopProductReports report = new PdfTopProductReports(reportType, results);
            report.View();
        }

        private void cmbReportType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductReportType reportType = (ProductReportType)e.ListItem;
            e.Value = TranslatedEnums.TranslateProductReportType(reportType);
        }

        #endregion Private Methods
    }
}
