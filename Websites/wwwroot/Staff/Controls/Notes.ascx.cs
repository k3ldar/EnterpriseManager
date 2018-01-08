using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Trade;

namespace SieraDelta.Website.Controls
{
    public partial class Notes : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(ClientNote note)
        {
            pNotes.InnerHtml = note.Notes.Replace("\r", "<br />");
            sAuthor.InnerText = String.Format("{0} - {1}", note.NotesDate.ToString("dd/MM/yyyy"), note.User.UserName);
        }
    }
}