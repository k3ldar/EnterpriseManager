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
 *  File: SupportTickets.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SharedBase.BOL.Users;
using SharedBase.Utils;

namespace SharedBase.BOL.Helpdesk
{
    [Serializable]
    public sealed class SupportTickets : BaseCollection
    {
        #region Static Methods

        public static TicketPriorities PrioritiesGet()
        {
            return (DAL.FirebirdDB.HelpdeskTicketPrioritiesGet());
        }

        public static TicketDepartments DepartmentsGet()
        {
            return (DAL.FirebirdDB.HelpdeskTicketDepartmentsGet());
        }

        public static TicketStatuses StatusesGet()
        {
            return (DAL.FirebirdDB.HelpdeskTicketStatusesGet());
        }

        public static SupportTicket Get(string TicketKey, string EMail)
        {
            return (DAL.FirebirdDB.HelpdeskSupportTicketGet(TicketKey, EMail));
        }

        public static SupportTicket Create(string TicketKey, string Subject, string Content,
            string UserName, int Department, int Status, int Priority, string Email)
        {
            Hooks.Hooks.HookNotification(HookEvent.HelpDeskTicketCreated,
                String.Format("Ticket: {0}; Subject: {1}; UserName: {2}", 
                TicketKey, Subject, UserName));

            return (DAL.FirebirdDB.HelpdeskSupportTicketCreate(TicketKey, Subject, Content, UserName, Department, Status, Priority, Email));
        }

        public static SupportTicketMessages Get(SupportTicket Ticket)
        {
            return (DAL.FirebirdDB.HelpdeskSupportTicketMessagesGet(Ticket));
        }

        public static SupportTicket Get(int TicketID)
        {
            return (DAL.FirebirdDB.HelpdeskSupportTicketGet(TicketID));
        }

        public static void Maintenance()
        {
            DAL.FirebirdDB.HelpdeskSupportTicketsMaintenance();
        }

        public static SupportTickets Get(User user, string TicketKey)
        {
            LibUtils.IsStaffMember(user);
            return (DAL.FirebirdDB.HelpdeskSupportTicketsGet(user, TicketKey));
        }

        public static SupportTickets Get(User user)
        {
            return (DAL.FirebirdDB.HelpdeskSupportTicketsGet(user));
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public SupportTicket this[int Index]
        {
            get
            {
                return ((SupportTicket)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(SupportTicket value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(SupportTicket value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, SupportTicket value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(SupportTicket value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(SupportTicket value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.Helpdesk.SupportTicket";
        private const string OBJECT_TYPE_ERROR = "Must be of type SupportTicket";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}
