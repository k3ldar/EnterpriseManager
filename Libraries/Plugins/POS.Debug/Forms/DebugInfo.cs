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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: DebugInfo.cs
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
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Shared.Classes;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Debug.Classes;

namespace POS.Debug.Forms
{
    public partial class DebugInfo : POS.Base.Controls.BaseTabControl
    {
        public DebugInfo()
        {
            InitializeComponent();

            Trace.Listeners.Add(new ListBoxTraceListener(lstTrace));
        }

        internal void EventRaised(NotificationEventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = DateTime.Now.ToString(StringConstants.SYMBOL_DATE_FORMAT_G);
            item.SubItems.Add(e.EventName);
            item.SubItems.Add(e.Param1 == null ? StringConstants.NULL : e.Param1.ToString());
            item.SubItems.Add(e.Param2 == null ? StringConstants.NULL : e.Param2.ToString());
            item.SubItems.Add(e.Param3 == null ? StringConstants.NULL : e.Param3.ToString());
            item.SubItems.Add(e.Param4 == null ? StringConstants.NULL : e.Param4.ToString());
            item.SubItems.Add(e.Result == null ? StringConstants.NULL : e.Result.ToString());

            lvEvents.Items.Add(item);
        }

        private void btnLoadModules_Click(object sender, EventArgs e)
        {
            lstModules.Items.Clear();
            ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;

            foreach (ProcessModule module in modules)
            {
                lstModules.Items.Add(module.ModuleName);
            }
        }

        private void btnRefreshThreads_Click(object sender, EventArgs e)
        {
            lstThreads.Items.Clear();

            for (int i = 0; i < ThreadManager.ThreadCount; i++)
            {
                ThreadManager thread = ThreadManager.Get(i);
                lstThreads.Items.Add(thread.ToString());
            }
        }

        private void btnRefreshCache_Click(object sender, EventArgs e)
        {
            lstCache.Items.Clear();

            
        }
    }
}
