﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.BOL.Invoices;
using Library.BOL.Products;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileOrders : BaseControlClass
    {
        private Library.BOL.Orders.Orders _orders;

        protected void Page_Load(object sender, EventArgs e)
        {
            _orders = Library.BOL.Orders.Orders.Get(GetUser());

            BuildOrders();
        }

        private void BuildOrders()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();

            int Start = GetFormValue("Page", 1);

            int Finish = (Start * 10) -1;
            Start = Finish - 9;
            int i = 0;

            foreach (Order order in _orders)
            {
                if (i >= Start && i <= Finish)
                {
                    OrderItem firstItem = order.OrderItems.First();
                    HtmlTableRow r = new HtmlTableRow();
                    tblOrders.Rows.Add(r);

                    HtmlTableCell cOrderDate = new HtmlTableCell();
                    cOrderDate.InnerText = SharedUtils.DateToStr(order.PurchaseDateTime, WebCulture);
                    r.Cells.Add(cOrderDate);

                    HtmlTableCell cImage = new HtmlTableCell();
                    r.Cells.Add(cImage);
                    cImage.Width = "14%";

                    if (firstItem != null)
                    {
                        ProductCost costs = ProductCosts.Get(firstItem.ItemID);
                        Product prod = null;

                        if (costs != null)
                            prod = Library.BOL.Products.Products.Get(costs.ProductID);

                        string image = SharedUtils.ResizeImage(prod.Image, 89);


                        cImage.InnerHtml = String.Format("<img src=\"/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>", prod == null ? "blank.jpg" : image);
                    }
                    else
                        cImage.InnerHtml = "<img src=\"/Images/Products/blank.jpg\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>";

                    HtmlTableCell cDescription = new HtmlTableCell();
                    r.Cells.Add(cDescription);
                    cDescription.Width = "46%";

                    int itemCount = order.OrderItems.Count - 1;
                    string otherItems = "";

                    if (itemCount > 0)
                        otherItems = String.Format(" (+ {0} {2}{1})", itemCount, itemCount > 1 ? "s" : "", Languages.LanguageStrings.Item);

                    if (firstItem != null)
                        cDescription.InnerHtml = String.Format("<a href=\"/Account/Orders/View/{1}/\"><strong>{0}{2}</strong><br />{3} #{1}</a>", 
                            firstItem.Description, order.ID, otherItems, Languages.LanguageStrings.Order);
                    else
                        cDescription.InnerHtml = String.Format("<strong>{2}</strong><br /><a href=\"/Account/Orders/View/{0}/\">{1} #{0}</a>",
                            order.ID, Languages.LanguageStrings.Order, Languages.LanguageStrings.Unknown);

                    HtmlTableCell cDispatched = new HtmlTableCell();
                    r.Cells.Add(cDispatched);
                    cDispatched.InnerHtml = SharedUtils.SplitCamelCase(order.ProcessStatus.ToString());

                    if (order.ProcessStatus == Library.ProcessStatus.Dispatched)
                    {
                        Library.BOL.Invoices.Invoice invoice = Library.BOL.Invoices.Invoices.Get(order);

                        if (invoice != null)
                            cDispatched.InnerHtml += String.Format("<br />{0}", SharedUtils.DateToStr(invoice.Dateshipped, WebCulture));
                    }
                }

                i++;
            }
        }
    }
}