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
 *  File: CommissionPool.cs
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

using Library.BOL.Accounts;
using Library.BOL.Locations;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class CommissionPool : BaseObject
    {
        #region Constructors

        public CommissionPool(Int64 id, string name, decimal commissionRate, PaymentStatuses statuses, StoreLocation location)
        {
            ID = id;
            Name = name;
            CommissionRate = commissionRate;
            PaymentStatus = statuses;
            Location = location;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for pool
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Name of commission Pool
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The commission applied to the pool
        /// </summary>
        public decimal CommissionRate { get; set; }

        /// <summary>
        /// List of payment statuses applicable to this commission pool
        /// </summary>
        public PaymentStatuses PaymentStatus { get; set; }

        /// <summary>
        /// Store location, if any, null means applies across all stores
        /// </summary>
        public StoreLocation Location { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            if (this.ID == -1)
                DAL.FirebirdDB.StaffCommissionPoolCreate(this);
            else
                DAL.FirebirdDB.StaffCommissionPoolSave(this);
        }

        public override void Delete()
        {
            if (this.ID != -1)
                DAL.FirebirdDB.StaffCommissionPoolsDelete(this);
        }

        #endregion Overridden Methods
    }
}
