using System;
using System.Collections.Generic;
using System.Text;

namespace POS.AutoUpdate.Classes
{
    public sealed class RunAutoUpdatesThread : Shared.Classes.ThreadManager
    {
        public RunAutoUpdatesThread()
            : base (null, new TimeSpan(0, 5, 0))
        {
            ContinueIfGlobalException = true;
        }

        protected override bool Run(object parameters)
        {
            Library.BOL.DatabaseUpdates.AutoUpdateRules.ExecuteSQL();

            return (base.Run(parameters));
        }
    }
}
