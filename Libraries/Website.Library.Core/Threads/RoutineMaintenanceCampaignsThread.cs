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
 *  File: RoutineMaintenanceCampaignsThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Shared.Classes;

using Website.Library.Core.Classes;
using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Threads
{
    /// <summary>
    /// Thread that runs every hour and performs routine maintenance for campaigns
    /// </summary>
    internal class RoutineMaintenanceCampaignsThread : ThreadManager
    {
        #region Private Members

        private readonly ILogging _logging;

        #endregion Private Members

        #region Constructors

        internal RoutineMaintenanceCampaignsThread(ILogging logging)
            : base(null, new TimeSpan(1, 0, 0), null, 30000)
        {
            _logging = logging ?? throw new ArgumentNullException(nameof(logging));

            HangTimeout = 0;
            RunAtStartup = true;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            try
            {
                //run the background tasks
                RoutineMaintenance rm = new RoutineMaintenance();
                try
                {
                    rm.RunCampaigns();
                }
                finally
                {
                    rm = null;
                }
            }
            catch (Exception err)
            {
                _logging.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }

        #endregion Overridden Methods
    }
}
