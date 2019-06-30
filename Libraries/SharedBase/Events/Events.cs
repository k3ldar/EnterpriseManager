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
 *  File: Events.cs
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

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Users;
using SharedBase.BOL.SEO;
using SharedBase.BOL.FileBackup;
using SharedBase.BOL.Therapists;

namespace SharedBase.BOLEvents
{
    /// <summary>
    /// Working Day Event args
    /// </summary>
    public sealed class WorkingDayEventArgs
    {
        public WorkingDayEventArgs(WorkingDay day)
        {
            Day = day;
        }

        /// <summary>
        /// Working Day Property
        /// </summary>
        public WorkingDay Day { get; private set; }
    }

    /// <summary>
    /// Event delegate for working day event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void WorkingDayEventDelegate(object sender, WorkingDayEventArgs e);

    /// <summary>
    /// select user event arguments
    /// </summary>
    public sealed class SelectUserEventArgs
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public SelectUserEventArgs()
        {

        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// Delegate used when selecting user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SelectUserEventDelegate(object sender, SelectUserEventArgs e);

    public sealed class Progress
    {
        public event ProgressEventHandler OnProgress;

        public void RaiseOnProgress(ProgressEventArgs args)
        {
            args.Cancel = false;

            if (OnProgress != null)
                OnProgress(this, args);
        }

    }

    public sealed class ProgressEventArgs
    {
        public ProgressEventArgs(int max, int percent) { Max = max; Percent = percent; }

        private int _max;
        public int Max 
        {
            set { _max = value; }
            get { return _max; }
        }

        private int _percent;

        public int Percent
        {
            set { _percent = value; }
            get { return _percent; }
        }

        public User User { get; internal set; }

        public bool Cancel { get; set; }
    }

    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    /// <summary>
    /// Event arguments for internal erros
    /// </summary>
    public sealed class InternalErrorEventArgs
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="method">Name of method where exception occured</param>
        /// <param name="message">Error Message</param>
        /// <param name="parameters">Parameters passed to Method</param>
        /// <param name="callstack">Callstack leading to the Method</param>
        public InternalErrorEventArgs (string method, string message, string source, string parameters, string callstack)
        {
            Message = String.IsNullOrEmpty(message) ? "null value " : message;
            Method = String.IsNullOrEmpty(method) ? "null value " : method;
            Parameters = String.IsNullOrEmpty(parameters) ? "null value " : parameters;
            CallStack = String.IsNullOrEmpty(callstack) ? "null value " : callstack;
            Source = String.IsNullOrEmpty(source) ? "null value" : source;
            IgnoreError = false;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// If true the error can be ignored
        /// </summary>
        public bool IgnoreError { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Source of exception
        /// </summary>
        public string Source { private set; get; }

        /// <summary>
        /// Name of Method where exception occured
        /// </summary>
        public string Method { private set; get; }

        /// <summary>
        /// Parameters used with Method
        /// </summary>
        public string Parameters { private set; get; }

        /// <summary>
        /// Call stack for method
        /// </summary>
        public string CallStack { private set; get; }

        #endregion Properties
    }

    /// <summary>
    /// Event handler for internal errors
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void InternalErrorEventHandler(object sender, InternalErrorEventArgs e);


    /// <summary>
    /// Event arguments for new appointments
    /// </summary>
    public sealed class NewAppointmentArgs
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appointment">Appointment being created</param>
        public NewAppointmentArgs (Appointment appointment)
        {
            Appointment = appointment;
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// New appointment being created
        /// </summary>
        public Appointment Appointment { get; private set; }

        #endregion Properties
    }

    /// <summary>
    /// New Appointment Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NewAppointmentHandler(object sender, NewAppointmentArgs e);



}
