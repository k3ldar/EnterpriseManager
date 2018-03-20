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
 *  File: RoutineMaintenanceThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Website.Library.Core.Classes;
using lib = Library;
using Shared.Classes;

namespace Website.Library.Core.Threads
{
    /// <summary>
    /// Thread that runs every hour and performs routine maintenance
    /// </summary>
    internal sealed class RoutineMaintenanceThread : ThreadManager
    {
        internal RoutineMaintenanceThread()
            : base(null, new TimeSpan(1, 0, 0), null, 30000)
        {
            HangTimeout = 0;
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            try
            {
                //run the background tasks
                RoutineMaintenance rm = new RoutineMaintenance();
                try
                {
                    rm.Run();
                }
                finally
                {
                    rm = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(lib.StringConsts.ERROR_THREAD_ABORTED))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }
    }
}
