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

namespace Heavenskincare.WebsiteTemplate.Members.Controls
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
                    cOrderDate.InnerText = Shared.Utilities.DateToStr(invoice.PurchaseDateTime, WebCulture);
                    r.Cells.Add(cOrderDate);

                    HtmlTableCell cImage = new HtmlTableCell();
                    r.Cells.Add(cImage);
                    cImage.Width = "14%";

                    if (firstItem == null)
                        cImage.InnerHtml = "<img src=\"https://static.heavenskincare.com/Images/Products/no_image_89.gif\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>";
                    else
                    {
                        ProductCost costs = ProductCosts.Get(firstItem.ItemID);

                        if (costs == null)
                            cImage.InnerHtml = "Unknown";
                        else
                        {
                            Product prod = Library.BOL.Products.Products.Get(costs.ProductID);

                            cImage.InnerHtml = String.Format("<img src=\"https://static.heavenskincare.com/Images/Products/{0}\" alt=\"\" border=\"0\" width=\"89\" height=\"64\"/>", 
                                prod == null || prod.Image == "no_image" ? "no_image_89.gif" : prod.Image);
                            
                        }
                    }

                    int itemCount = invoice.InvoiceItems.Count -1;
                    string otherItems = "";

                    if (itemCount > 0)
                        otherItems = String.Format(" (+ {0} {2}{1})", itemCount, itemCount > 1 ? "s" : "", Languages.LanguageStrings.Item);

                    HtmlTableCell cDescription = new HtmlTableCell();
                    r.Cells.Add(cDescription);
                    cDescription.Width = "46%";
                    cDescription.InnerHtml = String.Format("<a href=\"/Members/InvoiceView.aspx?ID={1}\"><strong>{0}{2}</strong><br />{3}{1}</a>", firstItem == null ? "Unknown" : firstItem.Description, invoice.ID, otherItems, Languages.LanguageStrings.InvoicePrefix);

                    HtmlTableCell cDispatched = new HtmlTableCell();
                    r.Cells.Add(cDispatched);
                    cDispatched.InnerHtml = EnumTranslations.TranslatedText(invoice.ProcessStatus);

                    if (invoice.ProcessStatus == Library.ProcessStatus.Dispatched)
                    {
                        if (invoice.TrackingReference != "")
                            cDispatched.InnerHtml += String.Format("<br /><a href=\"http://www.postoffice.co.uk/track-trace?trackNumber={0}&page_type=rml-tracking-details\" target=\"_blank\">{1}</a>", invoice.TrackingReference, Shared.Utilities.DateToStr(invoice.Dateshipped, WebCulture));
                        else
                            cDispatched.InnerHtml += String.Format("<br />{0}", Shared.Utilities.DateToStr(invoice.Dateshipped, WebCulture));
                    }
                }

                i++;
            }
        }
    }
}