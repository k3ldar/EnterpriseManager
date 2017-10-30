using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Orders;
using Library.BOL.Invoices;

namespace Library.BOL.Salons
{
    [Serializable]
    public sealed class SalonDiscount
    {
        #region Private / Protected Members

        private int _id;
        private Salon _salon;
        private int _salonDiscount;
        private int _customerDiscount;
        private string _couponCode;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public SalonDiscount(int ID, Salon Salon, int SalonDiscount, int CustomerDiscount, string CouponCode)
        {
            _id = ID;
            _salon = Salon;
            _salonDiscount = SalonDiscount;
            _customerDiscount = CustomerDiscount;
            _couponCode = CouponCode;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID
        {
            get
            {
                return (_id);
            }
        }

        public Salon Salon
        {
            get
            {
                return (_salon);
            }
        }

        public int Discount
        {
            get
            {
                return (_salonDiscount);
            }

            set
            {
                _salonDiscount = value;
            }
        }

        public int CustomerDiscount
        {
            get
            {
                return (_customerDiscount);
            }

            set
            {
                _customerDiscount = value;
            }
        }

        public string CouponCode
        {
            get
            {
                return (_couponCode);
            }

            set
            {
                _couponCode = value;
            }
        }

        #endregion Properties

        #region Public Methods

        public void Save(SalonDiscount Discount)
        {
        }

        #endregion Public Methods

        #region Static Methods

        public static SalonDiscount Create(Salon Salon, int SalonDiscount, int CustomerDiscount)
        {
            SalonDiscount Result = null;


            return (Result);
        }

        public static SalonDiscount Get(string CouponCode)
        {
            return (DAL.FirebirdDB.SalonDiscountGet(CouponCode));
        }

        #endregion Static Methods
    }
}
