using System;
using System.Web.UI;

using Library.Utils;
using Library.BOL.Websites;

using Website.Library.Classes;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Members
{
    public partial class SalonAppointments : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!WebsiteSettings.CreditCards.AllowCreditCards)
            {
                DoRedirect("/Error/InvalidPermissions", true);
            }

            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnNewAppointment.Text = Languages.LanguageStrings.BookNewAppointment;
        }

        protected void btnNewAppointment_Click(object sender, EventArgs e)
        {
            DoRedirect("/Appointments/Index.aspx");
        }

        protected int GetAppointmentPage()
        {
            return (SharedUtils.StrToIntDef((string)Page.RouteData.Values["page"], 1));
        }

    }
}