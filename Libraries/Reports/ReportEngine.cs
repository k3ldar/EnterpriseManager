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
                Library.SecurityEnums.SecurityPermissionsReports.BirthdayList, false,
                "reportsclientbirthday"));

            Result.Add(new ReportItem("Salon Reports", 
                typeof(Reports.Salons.CalendarReports), 
                "ViewSalonReports", 
                Library.SecurityEnums.SecurityPermissionsReports.SalonReports, false,
                "reportssalon"));

            Result.Add(new ReportItem("Voucher Codes", 
                typeof(Reports.Vouchers.CreateVouchers), 
                "ShowVoucherForm", 
                Library.SecurityEnums.SecurityPermissionsReports.CreateVouchers, false,
                "voucherscreatevouchers"));

            Result.Add(new ReportItem("Stock Control", 
                typeof(Reports.Stock.StockReports), 
                "ViewStockReports", 
                Library.SecurityEnums.SecurityPermissionsReports.StockReports, true,
                "reportsstockcontrol"));

            Result.Add(new ReportItem("Product Reports",
                typeof(Reports.Products.ProductReportsForm), 
                "ViewProductReports",
                Library.SecurityEnums.SecurityPermissionsReports.ProductReports, true,
                "reportsproducts"));

            return (Result);
        }

        #endregion Public Methods
    }
}
