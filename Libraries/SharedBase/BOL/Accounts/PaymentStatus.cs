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
 *  File: PaymentStatus.cs
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

namespace SharedBase.BOL.Accounts
{
    [Serializable]
    public sealed class PaymentStatus
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="initialProcessStatus"></param>
        /// <param name="isPaid">Indicates wether the status is paid or not</param>
        /// <param name="providerNamespace">Namespace procider to handle the payment status</param>
        public PaymentStatus(int id, string description, int initialProcessStatus, bool isPaid,
            string providerNamespace, bool isTill, bool isOffice, bool isOnline, bool createInvoice,
            MemberLevel memberLevel)
        {
            ID = id;
            Description = description;
            InitialProcessStatus = initialProcessStatus;
            IsPaid = isPaid;
            ProviderNamespace = providerNamespace;
            IsOffice = isOffice;
            IsOnline = isOnline;
            IsTill = isTill;
            CreateInvoice = createInvoice;
            MemberLevel = memberLevel;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of status
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Description of status
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initial process status
        /// </summary>
        public int InitialProcessStatus { get; private set; }

        /// <summary>
        /// Indicates wether the status is paid or not
        /// </summary>
        public bool IsPaid { get; private set; }

        /// <summary>
        /// Namespace which contains code to manipulate the Payment Status
        /// </summary>
        public string ProviderNamespace { get; private set; }

        /// <summary>
        /// Indicates wether the payment can be used for a till
        /// </summary>
        public bool IsTill { get; private set; }

        /// <summary>
        /// Indicates wether payment type can be used in the office
        /// </summary>
        public bool IsOffice { get; private set; }

        /// <summary>
        /// Indicates wether the payment type can be used online
        /// </summary>
        public bool IsOnline { get; private set; }

        /// <summary>
        /// If true an invoice order is created when creating an invoice (order)
        /// </summary>
        public bool CreateInvoice { get; private set; }

        /// <summary>
        /// Minimum member level to which this payment type relies on
        /// </summary>
        public MemberLevel MemberLevel { get; private set; }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (Description);
        }

        #endregion Overridden Methods
    }
}
