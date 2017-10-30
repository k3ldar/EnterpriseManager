using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.Vouchers
{
    [Serializable]
    public sealed class Voucher : BaseObject
    {
        public Voucher(string code, decimal amount, User user, DateTime expires)
        {
            Code = code;
            Amount = amount;
            User = user;
            Expires = expires;
        }

        public Voucher(Int64 id, string code, decimal amount, bool hasBeenSold, DateTime expires)
        {
            Code = code;
            Amount = amount;
            Sold = hasBeenSold;
            Expires = expires;
        }

        #region Properties

        public string Code
        {
            set;
            get;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public User User
        {
            get;
            set;
        }

        public bool Sold
        {
            get;
            set;
        }

        public DateTime Expires { get; private set; }

        #endregion Properties

        //#region Public Methods

        //public bool Valid()
        //{
        //    return (_IsActive && DateTime.Now < _Expires && DateTime.Now > StartDateTime && VoucherUsage < MaxUsage);
        //}

        //#endregion Public Methods
    }
}
