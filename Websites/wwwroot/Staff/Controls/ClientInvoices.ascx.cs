using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;
using Library.BOL.Invoices;

namespace SieraDelta.Website.Controls
{
    public partial class ClientInvoices : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(Client client, User user)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            decimal TotalInvoices = 0.00m;

            if (user == null)
                AddRow ("Client has not got an account");
            else
            {
                foreach (Invoice inv in user.Invoices)
                {
                    TotalInvoices += inv.TotalCost;
                    AddRow(inv);
                }
            }

            cellFooter.Text = String.Format("Total Invoice Value: {0}", SharedUtils.FormatMoney(TotalInvoices, GetWebsiteCurrency()));
        }

        private void AddRow(string Text)
        {
            TableRow row = new TableRow();
            tblInvoices.Rows.AddAt(tblInvoices.Rows.Count -1, row);
            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            cell.ColumnSpan = 4;
            cell.Text = Text;
        }

        private void AddRow(Invoice invoice)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = invoice.PurchaseDateTime.ToString("dd/MM/yyyy");

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = invoice.ID.ToString();

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = invoice.InvoiceItems.Count.ToString();

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = SharedUtils.FormatMoney(invoice.TotalCost, GetWebsiteCurrency());

            tblInvoices.Rows.AddAt(tblInvoices.Rows.Count -1, row);
        }
    }
}