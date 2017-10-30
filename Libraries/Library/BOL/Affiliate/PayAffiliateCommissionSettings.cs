using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Library.BOL.Basket;
using Library.BOL.Users;

namespace Library.BOL.Affiliate
{
    [Serializable]
    public sealed class PayAffiliateCommissionSettings
    {
        #region Constructors

        public PayAffiliateCommissionSettings(Currency localCurrency)
        {
            LocalCurrency = localCurrency;
        }

        #endregion Constructors

        #region Properties

        public User User { get; set; }

        public AffiliateCommission CommissionItems { get; set; }

        private Currency LocalCurrency { get; set; }

        #endregion Properties

        #region Public Methods

        public void Save(Users.User authorisingUser, CommissionPaymentType paymentType)
        {
            DAL.FirebirdDB.AffiliatedCommissionSave(authorisingUser, this, paymentType);
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
