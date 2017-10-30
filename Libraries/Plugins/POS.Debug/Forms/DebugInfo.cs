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
