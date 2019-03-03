/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: TicketEntry.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SharedBase.Utils;
using SharedBase.BOL.Helpdesk;
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
