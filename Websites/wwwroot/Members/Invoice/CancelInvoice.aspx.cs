using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website;
using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Invoices;

namespace SieraDelta.Website.Members.Invoice
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
            //SieraDeltaUtils u = new SieraDeltaUtils();
            return (SharedUtils.DateToStr(_invoice.PurchaseDateTime, WebCulture));
        }

        protected string GetInvoiceTotal()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
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
            //SieraDeltaUtils u = new SieraDeltaUtils();
            try
            {
                //validate the reason
                switch (cmbReason.SelectedIndex)
                {
                    case 0:
                        throw new Exception("Please specify a reason");
                    case 3:
                    case 4:
                        if (SharedUtils.ReplaceHTMLElements(txtOtherInformation.Text).Trim() == "")
                            throw new Exception("Please specify other information");
                        break;
                }
                string Message = String.Format("User cancelled invoice, please issue refund:<p>Invoice number: {0}</p>" +
                    "<p>Reason: {1}</p><p>Other information: {2}</p>", _invoice.ID, cmbReason.SelectedValue, txtOtherInformation.Text);

                Message = SharedUtils.PreProcessPost(Global.RootURL, Message);

                //send email to accounts
                SieraDelta.Website.Global.SendEMail("karen@SieraDelta.com", "karen@SieraDelta.com", "User Cancelled Invoice", Message);

                //send email to sales
                SieraDelta.Website.Global.SendEMail("sales@SieraDelta.com", "sales@SieraDelta.com", "User Cancelled Invoice", Message);

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