using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Base
{
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            Name = name.Trim();
            Allowed = false;
        }

        public NameChangeEventArgs(string name, Int64 id)
            : this(name)
        {
            ID = id;
        }

        public string Name { get; private set; }

        public Int64 ID { get; private set; }

        public bool Allowed { get; set; }
    }

    public delegate void NameChangeHandler(object sender, NameChangeEventArgs e);
}
