using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Trade;
using Library.BOL.Users;
using Library.BOL.Orders;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class ClientOrders : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(Client client, User user)
        {
            decimal TotalInvoices = 0.00m;

            if (user == null)
                AddRow("Client has not got an account");
            else
            {
                foreach (Order order in user.Orders)
                {
                    TotalInvoices += order.TotalCost;
                    AddRow(order);
                }
            }

            cellFooter.Text = String.Format("Total Order Value: {0}", SharedUtils.FormatMoney(TotalInvoices, GetWebsiteCurrency()));
        }

        private void AddRow(string Text)
        {
            TableRow row = new TableRow();
            tblOrders.Rows.AddAt(1, row);
            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            cell.ColumnSpan = 4;
            cell.Text = Text;
        }

        private void AddRow(Order order)
        {
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = order.PurchaseDateTime.ToString("dd/MM/yyyy");

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = String.Format("#{0}", order.ID);

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = order.OrderItems.Count.ToString();

            cell = new TableCell();
            row.Cells.Add(cell);
            cell.Text = SharedUtils.FormatMoney(order.TotalCost, GetWebsiteCurrency());

            tblOrders.Rows.AddAt(tblOrders.Rows.Count -1, row);
        }

    }
}