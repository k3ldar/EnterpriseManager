using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalonDiary.Classes
{
    internal class AutoUpdateThread : Shared.Classes.ThreadManager
    {
        internal AutoUpdateThread()
            : base (null, new TimeSpan(0, 3, 0), null, 0, 200, false)
        {

        }

        protected override bool Run(object parameters)
        {
            return (false);
        }
    }
}
