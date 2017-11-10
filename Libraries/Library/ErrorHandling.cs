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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: ErrorHandling.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Library.BOLEvents;

namespace Library
{
    public sealed class ErrorHandling
    {
        #region Public Methods

        #region Log Errors

        /// <summary>
        /// Logs an internal error
        /// </summary>
        /// <param name="method">Method where error occured</param>
        /// <param name="ex">Ecxeption being raised</param>
        /// <param name="values">Parameter values within the method</param>
        /// <returns>bool, true if the error is to be ignored, otherwise false</returns>
        public static bool LogError(MethodBase method, Exception ex, params object[] values)
        {
            // hack for local development
            if (System.IO.File.Exists("T:\\IgnoreLogging.txt"))
                return (true);

            ParameterInfo[] parms = method.GetParameters();
            string parameters = String.Empty;

            for (int i = 0; i < parms.Length; i++)
            {
                if (i >= values.Length)
                    parameters += String.Format("{0} = {1}\r\n", parms[i].Name, "missing parameter value???");
                else
                    parameters += String.Format("{0} = {1}\r\n", parms[i].Name, values[i] == null ? "null" : values[i]);
            }

            bool Result = RaiseInternalException(method.Name, ex.Message, ex.Source == null ? "null" : ex.Source.ToString(), parameters,
                ex.StackTrace == null ? "No Stack Trace" : ex.StackTrace.ToString());

            return (Result);
        }


        public static bool LogError(MethodBase method, string error, params object[] values)
        {
            ParameterInfo[] parms = method.GetParameters();
            string parameters = String.Empty;

            for (int i = 0; i < parms.Length; i++)
            {
                if (i >= values.Length)
                    parameters += String.Format("{0} = {1}\r\n", parms[i].Name, "missing parameter value???");
                else
                    parameters += String.Format("{0} = {1}\r\n", parms[i].Name, values[i] == null ? "null" : values[i]);
            }

            parameters += "\r\n\r\nOther Values:\r\n\r\n";

            for (int i = 0; i < values.Length; i++)
            {
                    parameters += String.Format("{0}\r\n", values[i]);
            }

            return (RaiseInternalException(method.Name, error, "null", parameters, "No Stack Trace"));
        }

        #endregion Log Errors

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Raise an internal exception event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="method">Method where exception raised</param>
        /// <param name="message">Error Message</param>
        /// <param name="source">Soure of exception</param>
        /// <param name="parameters">Parameters passed to method</param>
        /// <param name="callstack">Callstack leading to method</param>
        internal static bool RaiseInternalException(string method, string message, string source, string parameters, string callstack)
        {
            InternalErrorEventArgs args = new InternalErrorEventArgs(method, message, source, parameters, callstack);

            if (InternalException != null)
                InternalException(null, args);

            return (args.IgnoreError);
        }

        #endregion Internal Methods

        #region Events

        /// <summary>
        /// Event raised when an Internal Exception is raised
        /// </summary>
        public static event InternalErrorEventHandler InternalException;

        #endregion Events

        #region Debug


        public static void DebugCreateError()
        {
            DAL.FirebirdDB.ThrowInternalError("a string", null, 487, 28.96, new BOL.Users.Users());
        }

        #endregion Debug
    }
}
