using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.Utils;
using Library.BOL.Helpdesk;
using POS.Base.Classes;

namespace POS.HelpDesk.Controls
{
    public partial class TicketEntry : UserControl
    {
        public TicketEntry()
        {
            InitializeComponent();
        }

        public void Refresh(SupportTicketMessage TicketMessage)
        {
            lblReplier.Text = TicketMessage.Username;
            lblReplyDate.Text = TicketMessage.CreateDate.ToString(StringConstants.SYMBOL_DATE_FORMAT_G);

            txtMessage.Text = Shared.Utilities.RemoveHTMLElements(TicketMessage.Content);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size size = Shared.Utilities.MeasureText(txtMessage.Text, txtMessage.Font, 80);
            txtMessage.Height = Shared.Utilities.MinimumValue(40, size.Height);
            this.Height = txtMessage.Height + 40;
        }

        private void TicketEntry_SizeChanged(object sender, EventArgs e)
        {
            Size size = Shared.Utilities.MeasureText(txtMessage.Text, txtMessage.Font, 80);
            txtMessage.Height = Shared.Utilities.MinimumValue(40, size.Height);
            this.Height = txtMessage.Height + 40;
        }
    }
}
