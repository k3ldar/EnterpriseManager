using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.BOL.Trade;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class ClosedAction : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(ClientAction action)
        {
            foreach (ClientNote note in action.Notes)
            {
                pNotes.InnerHtml += String.Format("{0} - {1}<br />{2}<br />", note.NotesDate.ToString("dd/MM/yyyy hh:mm"), note.User.UserName, note.Notes);
            }
        }
    }
}