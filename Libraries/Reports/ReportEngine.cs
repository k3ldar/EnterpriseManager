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
 *  File: ReportEngine.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Reports
{
    public class ReportEngine
    {
        #region Public Methods

        public ReportItems Reports()
        {
            ReportItems Result = new ReportItems();

            Result.Add(new ReportItem("Client Birthday Offer", 
                typeof(Reports.Members.frmBirthdayReport), 
                "ViewConfirmList", 
                SharedBase.SecurityEnums.SecurityPermissionsReports.BirthdayList, false,
                "reportsclientbirthday"));

            Result.Add(new ReportItem("Salon Reports", 
                typeof(Reports.Salons.CalendarReports), 
                "ViewSalonReports", 
                SharedBase.SecurityEnums.SecurityPermissionsReports.SalonReports, false,
                "reportssalon"));

            Result.Add(new ReportItem("Voucher Codes", 
                typeof(Reports.Vouchers.CreateVouchers), 
                "ShowVoucherForm", 
                SharedBase.SecurityEnums.SecurityPermissionsReports.CreateVouchers, false,
                "voucherscreatevouchers"));

            Result.Add(new ReportItem("Stock Control", 
                typeof(Reports.Stock.StockReports), 
                "ViewStockReports", 
                SharedBase.SecurityEnums.SecurityPermissionsReports.StockReports, true,
                "reportsstockcontrol"));

            Result.Add(new ReportItem("Product Reports",
                typeof(Reports.Products.ProductReportsForm), 
                "ViewProductReports",
                SharedBase.SecurityEnums.SecurityPermissionsReports.ProductReports, true,
                "reportsproducts"));

            return (Result);
        }

        #endregion Public Methods
    }
}
