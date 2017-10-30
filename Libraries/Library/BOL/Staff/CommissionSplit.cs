using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Basket;

namespace Library.BOL.Staff
{
    [Serializable]
    public sealed class CommissionSplit
    {
        public CommissionSplit(StaffMember staff, Currency localCurrency)
        {
            Staff = staff;
            LocalCurrency = localCurrency;
        }

        #region Properties

        internal StaffMember Staff { get; set; }

        internal decimal PreviousAllocation { get; set; }

        private Currency LocalCurrency { get; set; }

        public string StaffName
        {
            get
            {
                Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(Staff.UserID);
                return (user.UserName);
            }
        }

        public string Allocation
        {
            get
            {
                return (Library.Utils.SharedUtils.FormatMoney(CurrentAllocation, LocalCurrency));
            }
        }

        public string Previous
        {
            get
            {
                return (Library.Utils.SharedUtils.FormatMoney(PreviousAllocation, LocalCurrency));
            }
        }
        
        public decimal CurrentAllocation { get; set; }

        #endregion Properties

        #region Private Methods

        public void NormaliseValues()
        {
            CurrentAllocation = Math.Round(CurrentAllocation, 2);
        }

        #endregion Private Methods
    }
}
