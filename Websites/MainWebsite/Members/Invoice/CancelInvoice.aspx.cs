using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Heavenskincare.WebsiteTemplate;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Invoices;

namespace Heavenskincare.WebsiteTemplate.Members.Invoice
{
    public partial class CancelInvoice : BaseWebFormMember
    {
        private Library.BOL.Invoices.Invoice _invoice;

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            lblError.Visible = false;
            User user = GetUser();

            _invoice = user.Invoices.Find(GetFormValue("ID", -1));

            //if (_invoice == null)
            DoRedirect("/Members/Invoices.aspx", true);

        }

        protected string GetInvoiceNumber()
        {
            return (_invoice.ID.ToString());
        }

        protected string GetInvoiceDate()
        {
            return (Shared.Utilities.DateToStr(_invoice.PurchaseDateTime, WebCulture.Name));
        }

        protected string GetInvoiceTotal()
        {
            return (SharedUtils.FormatMoney(_invoice.TotalCost, GetWebsiteCurrency()));
        }

        protected string GetFirstItem()
        {
            string Result = _invoice.InvoiceItems.First().Description;

            if (_invoice.InvoiceItems.Count - 1 > 0)
                Result += String.Format("{0} (+ {1} other items)", Result, _invoice.InvoiceItems.Count - 1);

            return (Result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                //validate the reason
                switch (cmbReason.SelectedIndex)
                {
                    case 0:
                        throw new Exception("Please specify a reason");
                    case 3:
                    case 4:
                        if (HSCUtils.ReplaceHTMLElements(txtOtherInformation.Text).Trim() == "")
                            throw new Exception("Please specify other information");
                        break;
                }
                string Message = String.Format("User cancelled invoice, please issue refund:<p>Invoice number: {0}</p>" +
                    "<p>Reason: {1}</p><p>Other information: {2}</p>", _invoice.ID, cmbReason.SelectedValue, txtOtherInformation.Text);

                Message = HSCUtils.PreProcessPost(Message);

                //send email to accounts
                Heavenskincare.WebsiteTemplate.Global.SendEMail("karen@heavenskincare.com", "karen@heavenskincare.com", "User Cancelled Invoice", Message);

                //send email to sales
                Heavenskincare.WebsiteTemplate.Global.SendEMail("sales@heavenskincare.com", "sales@heavenskincare.com", "User Cancelled Invoice", Message);

                //cancel the order
                _invoice.CancelInvoice(GetUser());

                //return to invoices page
                DoRedirect("/Members/Invoices.aspx");
            }
            catch (Exception err)
            {
                lblError.Text = err.Message;
                lblError.Visible = true;
            }
        }

    }
}