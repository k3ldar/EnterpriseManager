using System;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class Voucher : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DoRedirect("/Offers/Offers.aspx", true);
        }

        protected string GetVoucher()
        {
            string Result = Languages.LanguageStrings.NoVouchers;


            return (Result);
        }
    }
}