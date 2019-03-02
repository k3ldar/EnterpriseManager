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
 *  File: PayAffiliateCommissionSettings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharedBase.BOL.Basket;
using SharedBase.BOL.Users;

namespace SharedBase.BOL.Affiliate
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
