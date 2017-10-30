using System;
using System.Collections.Generic;

using POS.Base.Plugins;
using Shared.Classes;

namespace POS.Base.Classes
{
    public class PluginAlertsThread : ThreadManager
    {
        #region Constructors

        public PluginAlertsThread()
            : base (null, new TimeSpan(0, 1, 0), null, 10000)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            List<BasePlugin> modules = PluginManager.PluginsGetAlert();

            foreach (BasePlugin module in modules)
            {
                TimeSpan span = DateTime.Now - module.AlertLastRun;

                if (span.TotalSeconds >= module.AlertFrequency.TotalSeconds)
                {
                    module.Alert();
                    module.AlertLastRun = DateTime.Now;
                }
            }

            return (true);
        }

        #endregion Overridden Methods
    }
}
