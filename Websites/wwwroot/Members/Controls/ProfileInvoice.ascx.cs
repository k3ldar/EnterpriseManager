using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Invoices;
using Library.BOL.Products;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileInvoice : BaseControlClass
    {
        private Library.BOL.Invoices.Invoices _invoices;

        protected void Page_Load(object sender, EventArgs e)
        {
            _invoices = Library.BOL.Invoices.Invoices.Get(GetUser());

            BuildInvoices();
        }

        private void BuildInvoices()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();

            int Start = GetFormValue("Page", 1);

            int Finish = (Start * 10) - 1;
            Start = Finish - 9;
            int i = 0;

            foreach (Library.BOL.Invoices.Invoice invoice in _invoices)
            {
                if (i >= Start && i <= Finish)
                {
                    InvoiceItem firstItem = invoice.InvoiceItems.First();
                    HtmlTableRow r = new HtmlTableRow();
                    tblInvoices.Rows.Add(r);

                    HtmlTableCell cOrderDate = new HtmlTableCell();
                    cOrderDate.InnerText = SharedUtils.DateToStr(invoice.PurchaseDateTime, WebCulture);
                    r.Cells.Add(cOrderDate);

                    HtmlTableCell cImage = new HtmlTableCell();
                    r.Cells.Add(cImage);
                    cImage.Width = "14%";

                    if (firstItem == null)
                        cImage.InnerHtml = "<img src=\"/Images/Products/blank.jpg\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>";
                    else
                    {
                        ProductCost costs = ProductCosts.Get(firstItem.ItemID);

                        if (costs == null)
                            cImage.InnerHtml = "Unknown";
                        else
                        {
                            Product prod = Library.BOL.Products.Products.Get(costs.ProductID);
                            string image = SharedUtils.ResizeImage(prod.Image, 89);
                            cImage.InnerHtml = String.Format("<img src=\"/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>", prod == null ? "blank.jpg" : image);
                        }
                    }

                    int itemCount = invoice.InvoiceItems.Count -1;
                    string otherItems = "";

                    if (itemCount > 0)
                        otherItems = String.Format(" (+ {0} {2}{1})", itemCount, itemCount > 1 ? "s" : "", Languages.LanguageStrings.Item);

                    HtmlTableCell cDescription = new HtmlTableCell();
                    r.Cells.Add(cDescription);
                    cDescription.Width = "46%";
                    cDescription.InnerHtml = String.Format("<a href=\"/Account/Invoices/View/{1}/\"><strong>{0}{2}</strong><br />{3}{1}</a>", firstItem == null ? "Unknown" : firstItem.Description, invoice.ID, otherItems, Languages.LanguageStrings.InvoicePrefix);

                    HtmlTableCell cDispatched = new HtmlTableCell();
                    r.Cells.Add(cDispatched);
                    cDispatched.InnerHtml = SharedUtils.SplitCamelCase(invoice.ProcessStatus.ToString());

                    if (invoice.ProcessStatus == Library.ProcessStatus.Dispatched)
                    {
                        if (invoice.TrackingReference != "")
                            cDispatched.InnerHtml += String.Format("<br /><a href=\"http://www.postoffice.co.uk/track-trace?trackNumber={0}&page_type=rml-tracking-details\" target=\"_blank\">{1}</a>", invoice.TrackingReference, SharedUtils.DateToStr(invoice.Dateshipped, WebCulture));
                        else
                            cDispatched.InnerHtml += String.Format("<br />{0}", SharedUtils.DateToStr(invoice.Dateshipped, WebCulture));
                    }
                }

                i++;
            }
        }
    }
}