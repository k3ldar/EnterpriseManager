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
 *  File: UpdateAutoRulesThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using lib = Library;

using Shared.Classes;

using Website.Library.Core.Interfaces;

namespace Website.Library.Core.Threads
{
    /// <summary>
    /// Thread that runs every hour and performs routine maintenance
    /// </summary>
    internal class UpdateAutoRulesThread : ThreadManager
    {
        #region Private Members

        private readonly ILogging _logging;

        #endregion Private Members

        #region Constructors

        internal UpdateAutoRulesThread(ILogging logging)
            : base(null, new TimeSpan(0, 10, 0), null, 0)
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
                lib.BOL.DatabaseUpdates.AutoUpdateRules.ExecuteSQL();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(lib.StringConsts.ERROR_THREAD_ABORTED))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (true);
        }

        #endregion Overridden Methods
    }
}
