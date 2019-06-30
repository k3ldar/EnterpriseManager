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
 *  File: CreditCard.cs
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

using Shared;

namespace SharedBase.BOL.Users
{
    /// <summary>
    /// CreditCard Object used to house Debit/Credit card details
    /// </summary>
    [Serializable]
    public sealed class CreditCard : BaseObject
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public CreditCard(Int64 id, User member, string cardNumber, string last4Digits, string validFrom,
            string validTo, string cardName, string last3, AcceptedCreditCardTypes cardType)
        {
            ID = id;
            Member = member;
            CardNumber = cardNumber;
            Last4Digits = last4Digits;
            ValidFrom = validFrom;
            ValidTo = validTo;
            CardName = cardName;
            Last3Digits = last3;
            CardType = cardType;
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Adds a credit card to file
        /// </summary>
        /// <param name="card">CreditCard object</param>
        /// <param name="user">User who is adding card</param>
        public static void Add(CreditCard card, User user)
        {
            DAL.FirebirdDB.UserCreditCardDetailsUpdate(card, user);
            user.ClearCard();
        }

        #endregion Static Methods

        #region Overridden Methods

        /// <summary>
        /// Converts CreditCard to a readable string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("CreditCard - ID: {0}; Last4: {1}; User: {2}", ID, Last4Digits, Member.ToString());
        }

        /// <summary>
        /// Deletes credit card details entirely
        /// </summary>
        public override void Delete()
        {
            DAL.FirebirdDB.UserCreditCardDetailsDelete(this, this.Member);
        }

        #endregion Overridden Methods

        #region Public Methods

        public string CardNumberDecoded(User user)
        {
            string Result = String.Empty;

            if (ID == -1)
                Result = CardNumber;
            else
                Result = SharedBase.Utils.StringCipher.Decrypt(CardNumber, "CCD9idkmrhyd@_13A");

#warning every time card is decrypted, log the decryption date time, user and who's card

            return Result;
        }

        public bool CardStillValied()
        {
            string[] from = ValidFrom.Split('/');
            string[] to = ValidTo.Split('/');

            int yearFrom = Convert.ToInt32(from[1]);
            int monthFrom = Convert.ToInt32(from[0]);

            int yearTo = Convert.ToInt32(to[1]);
            int monthTo = Convert.ToInt32(to[0]);

            DateTime fromDate = new DateTime(yearFrom + 2000, monthFrom, 18);
            DateTime toDate = new DateTime(yearTo + 2000, monthTo, 18);

            return toDate >= fromDate && toDate > DateTime.Now;
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// ID of the credit card
        /// </summary>
        public Int64 ID
        {
            internal set;
            get;
        }

        /// <summary>
        /// Member who owns the card
        /// </summary>
        public User Member
        {
            get;
            set;
        }

        /// <summary>
        /// The card number
        /// </summary>
        public string CardNumber
        {
            set;
            get;
        }

        /// <summary>
        /// last 4 digits of the card
        /// </summary>
        public string Last4Digits
        {
            get;
            set;
        }

        /// <summary>
        /// Date Valid From mm/yy
        /// </summary>
        public string ValidFrom
        {
            get;
            set;
        }

        /// <summary>
        /// Date Valid To mm/yy
        /// </summary>
        public string ValidTo
        {
            get;
            set;
        }

        /// <summary>
        /// Name on card
        /// </summary>
        public string CardName
        {
            get;
            set;
        }

        /// <summary>
        /// Last 3 digits of security number
        /// </summary>
        public string Last3Digits
        {
            get;
            set;
        }

        /// <summary>
        /// Type of credit/debit card
        /// </summary>
        public AcceptedCreditCardTypes CardType
        {
            get;
            set;
        }

        #endregion Properties
    }
}
