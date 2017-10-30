using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class NotesNew : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNewNotes.Text))
            {
                Client client = Clients.Get(GetFormValue("ClientID", -1));

                if (client != null)
                {
                    client.AddNote(GetUser(), txtNewNotes.Text);
                    DoRedirect(String.Format("/Staff/SalesLead/Index.aspx?ClientID={0}", GetFormValue("ClientID", -1)));
                }
            }
        }
    }
}