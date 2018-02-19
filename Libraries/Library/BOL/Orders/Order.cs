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
 *  File: Order.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Library.Utils;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.Users;
using Library.BOL.Accounts;

namespace Library.BOL.Orders
{
    [Serializable]
    public sealed class Order
    {
        #region Private / Protected Members

        private Int64 _ID;
        private User _User;
        private int _UserID;
        private DateTime _PurchaseDateTime;
        private decimal _TotalCost;
        private decimal _subTotal;
        private PaymentStatus _Status;
        private decimal _ShippingCosts;
        private int _Discount;
        private ProcessStatus _ProcessStatus;
        private DeliveryAddress.DeliveryAddress _DeliveryAddress;
        private int _DeliveryAddressID;
        private double _ConversionRate;
        private double _VATRate;
        private string _Culture;
        private decimal _DiscountAmmount;
        private decimal _VATAmmount;
        private OrderItems _OrderItems;
        private string _CouponName;
        private int _StoreID;
        private int _TillID;
        private double _CostMultiplier;
        private Enums.InvoiceVoucherType _voucherType;
        private Country _orderCountry = null;
        private Currency _currency = null;
        private int _version;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Order(Int64 ID, int UserID, DateTime PurchaseDateTime, decimal TotalCost, PaymentStatus Status,
            decimal ShippingCosts, int Discount, ProcessStatus ProcessStatus,
            int DeliveryAddressID, double ConversionRate, double VATRate, string Culture, decimal DiscountAmmount,
            decimal VATAmmount, string Coupon, int StoreID, int TillID, double CostMultiplier, 
            Enums.InvoiceVoucherType VoucherType, int originalCountry, bool vatRemoved, bool removeVATFromPostage,
            Int64 localOrderNumber, int version, decimal subTotal, InvoiceOptions options)
        {
            _ID = ID;
            _UserID = UserID;
            _PurchaseDateTime = PurchaseDateTime;
            _TotalCost = TotalCost;
            _Status = Status;
            _ShippingCosts = ShippingCosts;
            _Discount = Discount;
            _ProcessStatus = ProcessStatus;
            _DeliveryAddressID = DeliveryAddressID;
            _ConversionRate = ConversionRate;
            _VATRate = VATRate;
            _Culture = Culture;
            _DiscountAmmount = DiscountAmmount;
            _VATAmmount = VATAmmount;
            _CouponName = Coupon;
            _StoreID = StoreID;
            _TillID = TillID;
            _CostMultiplier = CostMultiplier;
            _voucherType = VoucherType;
            OriginalCountry = originalCountry;
            VATRemoved = vatRemoved;
            RemoveVATFromPostage = removeVATFromPostage;
            LocalOrderNumber = localOrderNumber;
            _version = version;
            _subTotal = subTotal;
            Options = options;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// The currency against which the invoice was created
        /// </summary>
        public Currency Currency
        {
            get
            {
                if (_currency == null)
                {
                    _currency = Currencies.Get(new System.Globalization.CultureInfo(_Culture));
                    _currency.ConversionRate = (decimal)ConversionRate;
                    _currency.Multiplier = (decimal)CostMultiplier;
                }

                return (_currency);
            }
        }

        public double CostMultiplier
        {
            get
            {
                return (_CostMultiplier);
            }
        }

        public string CouponName
        {
            get
            {
                return (_CouponName);
            }

            set
            {
                _CouponName = value;
            }
        }

        public OrderItems OrderItems
        {
            get
            {
                if (_OrderItems == null)
                    _OrderItems = DAL.FirebirdDB.OrderItemsGet(this);

                return (_OrderItems);
            }
        }

        public int Version
        {
            get
            {
                switch (_version)
                {
                    case Consts.INVOICE_VERSION_VAT_ADD:
                    case Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                        return (_version);
                    default:
                        return (_VATAmmount == -1 ? 0 : 1);
                }
            }
        }

        /// <summary>
        /// Unique Invoice ID
        /// </summary>
        public Int64 ID
        {
            get
            {
                return (_ID);
            }
        }

        /// <summary>
        /// The ID used to display the ID if a local one has been used
        /// </summary>
        public Int64 DisplayID
        {
            get
            {
                if (LocalOrderNumber > 0)
                    return (LocalOrderNumber);
                else
                    return (_ID);
            }
        }

        public User User
        {
            get
            {
                if (_User == null)
                    _User = DAL.FirebirdDB.UserGet(_UserID);

                return (_User);
            }
        }

        public DateTime PurchaseDateTime
        {
            get
            {
                return (_PurchaseDateTime);
            }
        }

        public decimal TotalCost
        {
            get
            {
                return (_TotalCost);
            }
        }

        public PaymentStatus Status
        {
            get
            {
                return (_Status);
            }

            set
            {
                _Status = value;
                DAL.FirebirdDB.OrderUpdatePaymentStatus(_Status, this);
            }
        }

        public decimal ShippingCosts
        {
            get
            {
                return (_ShippingCosts);
            }
        }

        public int Discount
        {
            get
            {
                return (_Discount);
            }
        }

        public ProcessStatus ProcessStatus
        {
            get
            {
                return (_ProcessStatus);
            }

            //set
            //{
            //    _ProcessStatus = value;
            //    DAL.FirebirdDB.OrderUpdateProcessStatus(value, this);
            //}
        }

        public DeliveryAddress.DeliveryAddress DeliveryAddress
        {
            get
            {
                if (_DeliveryAddress == null)
                    _DeliveryAddress = DAL.FirebirdDB.MembersAddressGet(_DeliveryAddressID);

                return (_DeliveryAddress);
            }
        }

        public double ConversionRate
        {
            get
            {
                return (_ConversionRate);
            }
        }

        public double VATRate
        {
            get
            {
                return (_VATRate);
            }
        }

        public string Culture
        {
            get
            {
                return (_Culture);
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                return (_DiscountAmmount);
            }
        }

        public decimal VATAmount
        {
            get
            {
                decimal Result = _VATAmmount;

                switch (this.Version)
                { 
                    case Consts.INVOICE_VERSION_VAT_ADD:
                    case Consts.INVOICE_VERSION_VAT_ADD_OPTIONS:
                        break;
                    default:
                        if (RemoveVATFromPostage)
                        {
                            Result += SharedUtils.VATCalculatePaid(Result, _VATRate);
                        }

                        break;
                }

                return (Result);
            }
        }

        public int StoreID
        {
            get
            {
                return (_StoreID);
            }
        }

        public int TillID
        {
            get
            {
                return (_TillID);
            }
        }

        /// <summary>
        /// Type of voucher used
        /// </summary>
        public Enums.InvoiceVoucherType VoucherType
        {
            get
            {
                return (_voucherType);
            }
        }

        /// <summary>
        /// True if vat was removed from the sale price
        /// </summary>
        public bool VATRemoved { get; private set; }

        /// <summary>
        /// Country code for country where original user came from
        /// </summary>
        public int OriginalCountry { get; private set; }


        public string TotalCostStr
        {
            get
            {
                return (SharedUtils.FormatMoney(TotalCost, Currency, false, true));
            }
        }

        public string ShippingCostsStr
        {
            get
            {
                return (SharedUtils.FormatMoney(ShippingCosts, Currency, false, true));
            }
        }

        public string SubTotalAmountStr
        {
            get
            {
                return (SharedUtils.FormatMoney(_subTotal, Currency));
            }
        }

        public string DiscountAmountStr
        {
            get
            {
                return (SharedUtils.FormatMoney(DiscountAmount, Currency, false, true));
            }
        }

        public string VatAmountStr
        {
            get
            {
                return (SharedUtils.FormatMoney(VATAmount, Currency, false, true));
            }
        }

        public Country Country
        {
            get
            {
                if (_orderCountry == null)
                    _orderCountry = Countries.Countries.Get(OriginalCountry);

                return (_orderCountry);
            }
        }

        /// <summary>
        /// determines wether vat is removed from postage
        /// </summary>
        public bool RemoveVATFromPostage { get; private set; }

        /// <summary>
        /// Local Order Number for the store
        /// </summary>
        public Int64 LocalOrderNumber { get; private set; }

        /// <summary>
        /// Invoice Options
        /// </summary>
        public InvoiceOptions Options { get; private set; }

        #endregion Properties

        #region Public Methods

        public void Paid(User user, PaymentStatus PaymentType, string ResultText, string initialReferrer)
        {
            try
            {
                DAL.FirebirdDB.InvoiceMarkAsPaid(this, PaymentType, Consts.INVOICE_VERSION_VAT_ADD, ResultText, initialReferrer);

                Status = PaymentType;

                Hooks.Hooks.HookNotification(HookEvent.InvoiceCreated,
                    String.Format("Order ID: {0}; Result: {1}",
                        ID, ResultText));

            }
            catch (Exception err)
            {
                //send email
                DAL.FirebirdDB.EmailAdd("Web Master", "web.master@sieradelta.com", "no reply", "web.master@sieradelta.com", "Error when paying",
                    String.Format("{0}<br />Order {1}<p>{2}</p>", err.Message, this.ID, err.StackTrace == null ? "Unknown Stack Trace" : err.StackTrace.ToString()));

                //try again one more time
                DAL.FirebirdDB.InvoiceMarkAsPaid(this, PaymentType, Consts.INVOICE_VERSION_VAT_ADD, ResultText, initialReferrer);
            }
        }

        public void Cancel()
        {
            DAL.FirebirdDB.OrderCancel(this);
        }

        #endregion Public Methods

        #region Internal Methods

        internal void SetOrderItems(OrderItems Value)
        {
            _OrderItems = Value;
        }

        internal void SetDeliveryAddress(DeliveryAddress.DeliveryAddress Value)
        {
            _DeliveryAddress = Value;
        }

        internal void SetUser(User Value)
        {
            _User = Value;
        }

        #endregion Internal Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Order: {0}; User ID: {1}", ID, _UserID));
        }

        #endregion Overridden Methods

    }
}