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
 *  File: TicketDepartment.cs
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
    public sealed class TicketDepartment : BaseObject
    {
        #region Constructors / Destructors

        public TicketDepartment(int id, string description)
        {
            ID = id;
            Description = description;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.HelpdeskTicketDepartmentSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.HelpdeskTicketDepartmentDelete(this);
        }

        #endregion Overridden Methods
    }
}