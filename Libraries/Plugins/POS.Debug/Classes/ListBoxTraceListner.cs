using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace POS.Debug.Classes
{
    public class ListBoxTraceListener : TraceListener
    {
        private ListBox list = null;

        public ListBoxTraceListener(ListBox list)
        {
            this.list = list;
        }

        public override void WriteLine(string s)
        {
            if (list != null) 
                list.SelectedIndex = list.Items.Add(s);
        }

        public override void Write(string s)
        {
            WriteLine(s);
        }
    }
}
