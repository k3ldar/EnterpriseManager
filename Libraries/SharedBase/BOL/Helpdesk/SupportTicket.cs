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
 *  File: SupportTicket.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace SharedBase.BOL.Helpdesk
{
    [Serializable]
    public sealed class SupportTicket
    {
        #region Private / Protected Members

        private int _ID;
        private string _TicketKey;
        private DateTime _LastUpdated;
        private string _LastUpdatedBy;
        private string _Subject;
        private string _Department;
        private string _Status;
        private string _Priority;
        private DateTime _Created;
        private string _CreatedBy;
        private string _CreatedByEmail;
        private SupportTicketMessages _Messages;


        #endregion Private / Protected Members

        #region Constructors / Destructors

        public SupportTicket(int ID, string TicketKey, DateTime LastUpdated, string LastUpdatedBy, string Subject,
            string Department, string Status, string Priority, DateTime Created, string CreatedBy, string CreatedByEmail)
        {
            _ID = ID;
            _TicketKey = TicketKey;
            _LastUpdated = LastUpdated;
            _LastUpdatedBy = LastUpdatedBy;
            _Subject = Subject;
            _Department = Department;
            _Status = Status;
            _Priority = Priority;
            _Created = Created;
            _CreatedBy = CreatedBy;
            _CreatedByEmail = CreatedByEmail;
        }

        #endregion Constructors / Destructors

        #region Public Methods

        public void Reply(string ResponseContent, string ReplierName, bool IsAdmin)
        {
            Hooks.Hooks.HookNotification(HookEvent.HelpDeskTicketReplied,
                String.Format("Ticket: {0}; Subject: {1}; Replier: {2}",
                TicketKey, Subject, ReplierName));

            DAL.FirebirdDB.HelpdeskSupportTicketSubmitResponse(this, ResponseContent, ReplierName, IsAdmin);
            _Messages = null;
        }

        public void SetDepartment(TicketDepartment department)
        {
            DAL.FirebirdDB.HelpdeskSupportTicketDepartmentUpdate(this, department);
        }

        public void SetStatus(TicketStatus status)
        {
            DAL.FirebirdDB.HelpdeskSupportTicketStatusUpdate(this, status);
            this.Status = status.Description;
        }

        #endregion Public Methods

        #region Properties

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public SupportTicketMessages Messages
        {
            get
            {
                SupportTicketMessages Result = _Messages;

                if (_Messages == null)
                {
                    Result = DAL.FirebirdDB.HelpdeskSupportTicketMessagesGet(this);
                }

                return Result;
            }
        }

        public string TicketKey
        {
            get
            {
                return _TicketKey;
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
        }

        public string LastUpdatedBy
        {
            get
            {
                return _LastUpdatedBy;
            }
        }

        public string Subject
        {
            get
            {
                return _Subject;
            }
        }

        public string Department
        {
            get
            {
                return _Department;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }

            set
            {
                TicketStatuses statuses = DAL.FirebirdDB.HelpdeskTicketStatusesGet();

                foreach (TicketStatus status in statuses)
                {
                    if (status.Description == value)
                    {
                        _Status = value;
                        DAL.FirebirdDB.HelpdeskSupportTicketStatusUpdate(this, status);
                        break;
                    }
                }
            }
        }

        public string Priority
        {
            get
            {
                return _Priority;
            }
        }

        public DateTime Created
        {
            get
            {
                return _Created;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
        }

        public string CreatedByEmail
        {
            get
            {
                return _CreatedByEmail;
            }
        }



        #endregion Properties

    }
}