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
 *  File: PayCommissionSettings.cs
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

using SharedBase.BOL.Basket;

namespace SharedBase.BOL.Staff
{
    [Serializable]
    public sealed class PayCommissionSettings
    {
        #region Constructors

        public PayCommissionSettings(Currency localCurrency)
        {
            LocalCurrency = localCurrency;
        }

        #endregion Constructors

        #region Properties

        public CommissionPool Pool { get; set; }

        public StaffCommission CommissionItems { get; set; }

        public SharedBase.BOL.Staff.StaffMembers StaffMembers { get; set; }

        public bool UseStartDate { get; set; }

        public bool UsePermanentDate { get; set; }

        public List<CommissionSplit> SplitAllStaff = new List<CommissionSplit>();

        private List<CommissionSplit> SplitAvailableStaff = new List<CommissionSplit>();

        public decimal TotalPoolValue;

        private Currency LocalCurrency { get; set; }

        #endregion Properties

        #region Public Methods

        public void Normalise()
        {
            foreach (CommissionSplit item in SplitAllStaff)
                item.NormaliseValues();
        }

        public void Save(Users.User authorisingUser, CommissionPaymentType paymentType)
        {
            DAL.FirebirdDB.StaffCommissionSave(authorisingUser, this, paymentType);
        }

        /// <summary>
        /// Split commission based on settings
        /// </summary>
        public void SplitCommission()
        {
            TotalPoolValue = 0.0m;
            SplitAllStaff.Clear();
            SplitAvailableStaff.Clear();

            foreach (StaffMember staff in StaffMembers)
            {
                CommissionSplit newSplit = new CommissionSplit(staff, LocalCurrency);
                SplitAllStaff.Add(newSplit);
                SplitAvailableStaff.Add(newSplit);
            }

            foreach (StaffCommissionItem item in CommissionItems)
            {
                GetAvailableStaff(item.DateAllocated);

                decimal split = item.CommissionDue / SplitAvailableStaff.Count;

                if (!item.IsPaid)
                    TotalPoolValue += item.CommissionDue;

                foreach (CommissionSplit splitItem in SplitAvailableStaff)
                {
                    if (item.IsPaid)
                    {
                        splitItem.PreviousAllocation += split;
                    }
                    else
                    {
                        splitItem.CurrentAllocation += split;
                    }
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void GetAvailableStaff(DateTime invoiceDate)
        {
            if (UseStartDate || UsePermanentDate)
            {
                SplitAvailableStaff.Clear();

                foreach (CommissionSplit split in SplitAllStaff)
                {
                    TimeSpan span = GetSplitDate(split) - invoiceDate;
                    if (GetSplitDate(split) <= invoiceDate)
                        SplitAvailableStaff.Add(split);
                }

                if (SplitAvailableStaff.Count == 0)
                {
                    foreach (CommissionSplit split in SplitAllStaff)
                        SplitAvailableStaff.Add(split);
                }
            }
        }

        private DateTime GetSplitDate(CommissionSplit split)
        {
            if (UsePermanentDate)
                return split.Staff.DatePermanent;
            else if (UseStartDate)
                return split.Staff.DateJoined;
            else
                return DateTime.MinValue;
        }

        #endregion Private Methods
    }
}
