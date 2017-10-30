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
