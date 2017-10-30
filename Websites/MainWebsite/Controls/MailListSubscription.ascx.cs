using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class MailListSubscription : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubscribe.Text = Languages.LanguageStrings.MailListSubscribe;
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            string parameters = String.Format("Name={0}&Email={1}", txtMailListName.Text, txtMailListEmail.Text);
            DoRedirect(String.Format("/Offers/MailLists.aspx?{0}", parameters));
        }
    }
}