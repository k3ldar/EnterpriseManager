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
 *  File: WebsiteInitialisationThreadManager.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Threading;

using Shared.Classes;

using Library.BOL.Websites;

using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Threads
{
    /// <summary>
    /// Thread that only initialises other threads required by the website
    /// 
    /// This thread will wait 30 seconds after loaded, then load other 
    /// threads, once other threads have loaded it will close itself
    /// </summary>
    internal sealed class WebsiteInitialisationThreadManager : ThreadManager
    {
        #region Private Members

        private readonly IBaseWebApplication _baseWebApplication;
        private readonly IBaseServices _baseServices;
        private readonly ILogging _logging;

        #endregion Private Members

        internal WebsiteInitialisationThreadManager(IBaseWebApplication baseWebApplication, IBaseServices baseServices, ILogging logging)
            : base(null, new TimeSpan(0, 0, 30))
        {
            _baseWebApplication = baseWebApplication ?? throw new ArgumentNullException(nameof(baseWebApplication));
            _baseServices = baseServices ?? throw new ArgumentNullException(nameof(baseServices));
            _logging = logging ?? throw new ArgumentNullException(nameof(logging));
            RunAtStartup = false;
        }

        protected override bool Run(object parameters)
        {
            if (!WebsiteSettings.StaticWebSite)
            {
                try
                {
                    if (WebsiteSettings.WebFarm.WebFarmMaster())
                    {
                        ThreadManager.ThreadStart(new UpdateAutoRulesThread(_logging),
                            "Auto Rule Update", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new UpdateCustomPagesThread(_logging),
                            "Update Custom Pages", ThreadPriority.Lowest);
                    }

                    if (!WebsiteSettings.WebFarm.IsWebFarm && WebsiteSettings.Maintenance.AllowRoutineMaintenance)
                    {
                        // if the site is part of a web farm then routine maintenance must be handled via a task scheduler
                        ThreadManager.ThreadStart(new RoutineMaintenanceThread(),
                            "Routine Maintenance", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new RoutineMaintenanceCampaignsThread(_logging),
                            "Routine Maintenance Campaigns", ThreadPriority.Lowest);
                    }

                    if (WebsiteSettings.WebFarm.WebFarmMaster())
                    {
#if GeoIPUpdates
                        if (BaseWebApplication.AllowWebsiteGeoUpdate)
                            ThreadManager.ThreadStart(new GeoIPUpdateThread(),
                                "GeoIP Update", ThreadPriority.Lowest);
#endif

                        if (WebsiteSettings.Email.SendEmails)
                            ThreadManager.ThreadStart(new SendEmailThread(_baseWebApplication, _logging),
                                "Email Send Thread", ThreadPriority.Lowest);

                        ThreadManager.ThreadStart(new UpdateSiteMapThread(), "Update Site Map", ThreadPriority.Lowest);
                    }
                }
                catch (Exception err)
                {
                    Shared.EventLog.Add(err);
                }
            }

            return (false);
        }
    }
}
