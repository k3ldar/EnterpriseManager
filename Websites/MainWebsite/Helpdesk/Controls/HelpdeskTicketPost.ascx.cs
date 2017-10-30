using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.Utils;
using Library.BOL.Helpdesk;
using Website.Library.Classes;

namespace Heavenskincare.Helpdesk.Controls
{
    public partial class HelpdeskTicketPost : BaseControlClass
    {
        SupportTicketMessage _ticketMessage;

        public void Refresh(SupportTicketMessage message)
        {
            _ticketMessage = message;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetTicketPostReplier()
        {
            return (_ticketMessage.Username);
        }

        protected string GetTicketPostDate()
        {
            string Result = Shared.Utilities.DateTimeToStr(_ticketMessage.CreateDate, WebCulture);

            return (Result);
        }

        protected string GetTicketPostText()
        {
            string Result = HSCUtils.PreProcessPost(_ticketMessage.Content);

            return (Result);
        }
    }
}