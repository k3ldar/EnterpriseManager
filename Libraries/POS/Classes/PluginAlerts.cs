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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: PluginAlerts.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
