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
 *  File: Vouchers.cs
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

using Library.BOL.Users;
using Library.BOLEvents;

namespace Library.BOL.Vouchers
{
    [Serializable]
    public sealed class Vouchers : BaseCollection
    {
        private const int LABEL_CREATE_ATTEMPTS = 10000;

        #region Static Methods

        #region Admin Methods

        public static Voucher Get(string voucherCode)
        {
            return (DAL.FirebirdDB.VoucherGet(voucherCode));
        }

        public static void MarkAllAsSold(User currentUser)
        {
            DAL.FirebirdDB.VouchersMarkAllAsSold(currentUser);
        }


        public static void MarkVoucherAsUnSold(User currentUser, string voucherCode)
        {
            DAL.FirebirdDB.VoucherMarkAsUnsold(currentUser, voucherCode);
        }

        #endregion Admin Methods

        /// <summary>
        /// Redeems a voucher that has previously been sold
        /// </summary>
        /// <param name="voucherCode">Voucher Code</param>
        /// <param name="value">Value of voucher</param>
        public static decimal RedeemVoucher(string voucherCode, User user, bool validateOnly)
        {
            if (String.IsNullOrEmpty(voucherCode))
                throw new Exception("Voucher Code is not valid");

            //voucherCode = ValidateVoucherCode(voucherCode);
            return (DAL.FirebirdDB.RedeemVoucher(voucherCode, user, validateOnly));
        }


        /// <summary>
        /// Sell a voucher
        /// </summary>
        /// <param name="voucherCode">Voucher Code</param>
        /// <param name="value">Value of voucher</param>
        /// <param name="validateOnly">if true validates the code but does not save</param>
        public static void SellVoucher(string voucherCode, decimal value, User user, bool validateOnly)
        {
            if (String.IsNullOrEmpty(voucherCode))
                throw new Exception("Voucher Code is not valid");

            if (value < 0.01m)
                throw new Exception("Voucher has invalid value");

            //voucherCode = ValidateVoucherCode(voucherCode);
            DAL.FirebirdDB.SellVoucher(voucherCode, value, user, validateOnly);
        }

        public static void CreateVoucher(string voucherCode, decimal value)
        {
            Library.DAL.FirebirdDB.CreateVoucher(voucherCode, value);
        }

        /// <summary>
        /// Create a voucher code and add to the database ready to sell
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="value">Value of voucher</param>
        /// <returns>Unique voucher code</returns>
        public static string CreateVoucher(Progress progress, decimal value, 
            string prefix = "HV", string format = "NNN-MLN-LL-DLL-NLN", int randomAddition = 20)
        {
            if (value < 0.01m)
                throw new Exception("Voucher has invalid value");
            
            string Result = String.Empty;

            int attempts = 0;
            ProgressEventArgs args = new ProgressEventArgs(LABEL_CREATE_ATTEMPTS, 0);

            while (true)
            {
                // only 'LABEL_CREATE_ATTEMPTS' attempts
                if (attempts > LABEL_CREATE_ATTEMPTS)
                    throw new Exception("Failed to generate unique voucher code.");

                if (progress != null)
                {
                    progress.RaiseOnProgress(args);
                }

                args.Percent = attempts;

                try
                {
                    Result = Library.Utils.LibUtils.GenerateRandomVoucherCode(prefix, format, randomAddition);
                    DAL.FirebirdDB.CreateVoucher(Result, value);
                    break;
                }
                catch (Exception err)
                {
                    if (err.Message.Contains("Voucher already exists"))
                    {
                        attempts++;
                    }
                    else
                        throw;                    
                }
            }

            return (Result);
        }

        private static string CreateVoucher()
        {
            // Generate random voucher in form of LL-NNNN-LLLL-NNLL-N-L-N
            return (Library.Utils.LibUtils.GenerateRandomVoucherCode());
        }

        public static void SellVouchers(Vouchers vouchers)
        {
            foreach (Voucher v in vouchers)
                v.Code = ValidateVoucherCode(v.Code);

            DAL.FirebirdDB.SellVouchers(vouchers);
        }

        /// <summary>
        /// Ensures a voucher meets specified criteria
        /// </summary>
        /// <param name="VoucherCode">Code to be validated</param>
        /// <returns></returns>
        private static string ValidateVoucherCode(string VoucherCode)
        {
            string Result = "";
            int i = 0;

            //NNN-MLN-LL-DLL-NLN 

            foreach (char c in VoucherCode.Replace("-",""))
            {
                switch (i)
                {
                    case 5:
                    case 9:
                    case 11:
                    case 15:
                        if (c != '-')
                        {
                            Result += "-";
                            Result += c;
                        }
                        else
                            Result += c;

                        break;
                    default:
                        Result += c;
                        break;
                }

                i++;
            }

            return (Result);
            //HVLQ-4212-VYWM-22OX-2
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Voucher object</returns>
        public Voucher this[int Index]
        {
            get
            {
                return ((Voucher)this.InnerList[Index]);
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
        public int Add(Voucher value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Voucher value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Voucher value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Voucher value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Voucher value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Vouchers.Voucher";
        private const string OBJECT_TYPE_ERROR = "Must be of type Voucher";


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
