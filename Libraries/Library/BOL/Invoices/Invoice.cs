using System;
using System.Collections.Generic;
using System.Web;

using Library.BOL.Accounts;
using Library.BOL.Basket;
using Library.BOL.Users;
using Library.BOL.DeliveryAddress;
using Library.BOL.Countries;
using Library.BOL.StockControl;

using Library;
using Library.Utils;


namespace Library.BOL.Invoices
{
    [Serializable]
    public sealed class Invoice : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private int _OrderID;
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
        private DateTime _Dateshipped;
        private PaymentStatus _PaymentType;
        private InvoiceItems _InvoiceItems;
        private int _Version;
        private string _RemoteHost;
        private string _UserSession;
        private string _CouponName;
        private int _StoreID;
        private int _TillID;
        private string _TrackingReference;
        private double _CostMultiplier;
        private string _notes;
        private Enums.InvoiceVoucherType _voucherType;
        private Country _invoiceCountry;
        private Currency _currency = null;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public Invoice(Int64 id, int orderID, int userID, DateTime purchaseDateTime, decimal totalCost, PaymentStatus status,
            decimal shippingCosts, int discount, ProcessStatus processStatus,
            int deliveryAddressID, double conversionRate, double vatRate, string culture, decimal discountAmmount,
            decimal vatAmmount, DateTime dateshipped, PaymentStatus paymentType, int version, string remoteHost, string userSession, 
            string coupon, int storeID, int tillID, string trackingReference, double costMultiplier, string notes,
            Enums.InvoiceVoucherType voucherType, int originalCountry, bool vatRemoved, bool removeVATFromPostage,
            Int64 localInvoiceNumber, string staffNotes, decimal subTotal, InvoiceOptions options)
        {
            _ID = id;
            _OrderID = orderID;
            _UserID = userID;
            _PurchaseDateTime = purchaseDateTime;
            _TotalCost = totalCost;
            _Status = status;
            _ShippingCosts = shippingCosts;
            _Discount = discount;
            _ProcessStatus = processStatus;
            _DeliveryAddressID = deliveryAddressID;
            _ConversionRate = conversionRate;
            _VATRate = vatRate;
            _Culture = culture;
            _DiscountAmmount = discountAmmount;
            _VATAmmount = vatAmmount;
            _Dateshipped = dateshipped;
            _PaymentType = paymentType;
            _Version = version;
            _RemoteHost = remoteHost;
            _UserSession = userSession;
            _CouponName = coupon;
            _StoreID = storeID;
            _TillID = tillID;
            _TrackingReference = trackingReference;
            _CostMultiplier = costMultiplier;
            _notes = notes;
            _voucherType = voucherType;
            OriginalCountry = originalCountry;
            VATRemoved = vatRemoved;
            RemoveVATFromPostage = removeVATFromPostage;
            LocalInvoiceNumber = localInvoiceNumber;
            StaffNotes = staffNotes;
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

                    // did it find a currency???
                    if (_currency == null)
                    {

                    }

                    _currency.ConversionRate = (decimal)ConversionRate;
                    _currency.Multiplier = (decimal)CostMultiplier;
                }

                return (_currency);
            }
        }

        /// <summary>
        /// The value that the total was multiplied against
        /// </summary>
        public double CostMultiplier
        {
            get
            {
                return (_CostMultiplier);
            }
        }

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
                if (LocalInvoiceNumber > 0)
                    return (LocalInvoiceNumber);
                else
                    return (_ID);
            }
        }

        public int OrderID
        {
            get
            {
                return (_OrderID);
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


        public User User
        {
            get
            {
                if (_User == null)
                    _User = DAL.FirebirdDB.UserGet(_UserID);

                return (_User);
            }
        }

        public int Version
        {
            get
            {
                return (_Version);
            }
        }

        public DateTime PurchaseDateTime
        {
            get
            {
                return (_PurchaseDateTime);
            }

            set
            {
                _PurchaseDateTime = value;
            }
        }

        public string TrackingURL
        {
            get
            {
                return (String.Format("http://www.royalmail.com/track-trace?trackNumber={0}&page_type=rml-tracking-details", TrackingReference.Replace(" ", "")));
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
                DAL.FirebirdDB.InvoiceUpdatePaymentStatus(_Status, this);
            }
        }

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

        public string SubTotalAmountStr
        {
            get
            {
                return (SharedUtils.FormatMoney(_subTotal, Currency));
            }
        }


        public decimal TotalCost
        {
            get
            {
                decimal Result = 0.00m;

                switch (_Version)
                {
                    case 1:
                        Result = (_TotalCost + _ShippingCosts) - ((_TotalCost / 100) * _Discount);
                        break;
                    default:
                        Result = _TotalCost;
                        break;
                }

                return (Result);
            }
        }

        public decimal SubTotal
        {
            get
            {
                return (_subTotal);
            }
        }

        public decimal ShippingCosts
        {
            get
            {
                decimal Result = _ShippingCosts;

                //if (RemoveVATFromPostage && Result > 0.00)
                //{
                //    Result = Utils.HSCUtils.VATRemove(Result, _VATRate);
                //}

                return (Result);
            }
        }

        public double VATRate
        {
            get
            {
                return (_VATRate);
            }
        }

        public decimal DiscountAmount
        {
            get
            {
                decimal Result = 0.00m;

                switch (_Version)
                {
                    case 1:
                        Result = (_TotalCost / 100) * _Discount;
                        break;
                    default:
                        Result = _DiscountAmmount;
                        break;
                }

                return (Result);
            }
        }

        public decimal VATAmount
        {
            get
            {
                decimal Result = _VATAmmount;

                //if (RemoveVATFromPostage)
                //{
                //    Result += Utils.HSCUtils.VATCalculatePaid(Result, _VATRate);
                //}

                return (Result);
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

        public string Culture
        {
            get
            {
                return (_Culture);
            }
        }

        public DateTime Dateshipped
        {
            get
            {
                return (_Dateshipped);
            }
        }

        public PaymentStatus PaymentType
        {
            get
            {
                return (_PaymentType);
            }
        }

        public InvoiceItems InvoiceItems
        {
            get
            {
                if (_InvoiceItems == null)
                    _InvoiceItems = DAL.FirebirdDB.InvoiceItemsGet(this);

                return (_InvoiceItems);
            }
        }

        public string RemoteHost
        {
            get
            {
                return (_RemoteHost);
            }
        }

        public string UserSession
        {
            get
            {
                return (_UserSession);
            }
        }

        public new int StoreID
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

        public string TrackingReference
        {
            get
            {
                return (_TrackingReference.Replace(" ", ""));
            }

            set
            {
                _TrackingReference = value.Replace(" ", "");
            }
        }

        public string Notes
        {
            get
            {
                return (_notes);
            }

            set
            {
                _notes = value;
            }
        }

        public Enums.InvoiceVoucherType VoucherType
        {
            get
            {
                return (_voucherType);
            }
        }

        /// <summary>
        /// True if the vat was removed
        /// </summary>
        public bool VATRemoved { get; private set; }

        /// <summary>
        /// Country code for country where original user came from
        /// </summary>
        public int OriginalCountry { get; private set; }

        public Country Country
        {
            get
            {
                if (_invoiceCountry == null)
                    _invoiceCountry = Countries.Countries.Get(OriginalCountry);

                return (_invoiceCountry);
            }
        }

        /// <summary>
        /// determines wether vat is removed from postage
        /// </summary>
        public bool RemoveVATFromPostage { get; private set; }

        /// <summary>
        /// Local invoice for current store
        /// </summary>
        public Int64 LocalInvoiceNumber { get; private set; }

        /// <summary>
        /// Staff notes about the invoice
        /// </summary>
        public string StaffNotes { get; private set; }

        /// <summary>
        /// Invoice Options
        /// </summary>
        public InvoiceOptions Options { get; private set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Updates the staff notes for the invoice
        /// </summary>
        /// <param name="notes"></param>
        public void UpdateStaffNotes (string notes)
        {
            StaffNotes = notes;
            
            DAL.FirebirdDB.InvoiceUpdateNotes(this, notes);
        }

        /// <summary>
        /// sets the date of an invoice
        /// </summary>
        /// <param name="newDateTime">New invoice date/time</param>
        public void SetDate(DateTime newDateTime)
        {
            DAL.FirebirdDB.InvoiceSetDate(this, newDateTime);
            this.PurchaseDateTime = newDateTime;
        }

        public void ResendEmail()
        {
            DAL.FirebirdDB.InvoiceResendByEmail(this);
        }

        public void Cancel(Stock stockReturnItems, User currentUser)
        {
            DAL.FirebirdDB.InvoiceCancel(this, stockReturnItems, currentUser);
        }

        public void SetProcessStatus(User user, ProcessStatus ProcessStatus)
        {
            _ProcessStatus = ProcessStatus;
            DAL.FirebirdDB.InvoiceUpdateProcessStatus(ProcessStatus, this);

            switch (ProcessStatus)
            {
                case Library.ProcessStatus.Processing:
                    Hooks.Hooks.HookNotification(HookEvent.OrderProcessing,
                        String.Format("Invoice ID: {0}; ProcessStatus: {1}", ID, ProcessStatus.ToString()));
                    break;
                case Library.ProcessStatus.Cancelled:
                    Hooks.Hooks.HookNotification(HookEvent.OrderCancelled,
                        String.Format("Invoice ID: {0}; ProcessStatus: {1}", ID, ProcessStatus.ToString()));
                    break;
            }
        }

        public void SetDispatched(User user, ProcessStatus ProcessStatus, string TrackingReference)
        {
            _ProcessStatus = ProcessStatus;
            _TrackingReference = TrackingReference;
            DAL.FirebirdDB.InvoiceUpdateProcessStatus(ProcessStatus, this, TrackingReference.Replace(" ", ""));

            Hooks.Hooks.HookNotification(HookEvent.OrderDispatched,
                String.Format("Invoice ID: {0}; ProcessStatus: {1}", ID, ProcessStatus.ToString()));

        }

        public void CancelInvoice(User user)
        {
            if (this.ProcessStatus == ProcessStatus.OrderReceived || this.ProcessStatus == ProcessStatus.Processing)
            {
                if (this.Status.ID == PaymentStatuses.Get("Paynet Paid").ID || this.Status.ID == PaymentStatuses.Get("Paypal Paid").ID || this.Status.ID == PaymentStatuses.Get("Paypal Pending").ID)
                {
                    DAL.FirebirdDB.InvoiceUpdateProcessStatus(ProcessStatus.IssueRefund, this);
                }
                else
                    throw new Exception("Only invoices paid using Paynet and Paypal can be cancelled");
            }
            else
            {
                switch (this.ProcessStatus)
                {
                    case ProcessStatus.Cancelled:
                        throw new Exception("Invoice has already been cancelled");
                    case ProcessStatus.Dispatched:
                        throw new Exception("Can not cancel an invoice which has been dispatched");
                    case ProcessStatus.IssueRefund:
                        throw new Exception("Invoice has already been cancelled and awaiting refund");
                }
            }
        }

        public string Address(bool IsHTML)
        {
            string Seperator;

            if (IsHTML)
                Seperator = "<br>";
            else
                Seperator = "\n";

            if (_DeliveryAddress == null)
                _DeliveryAddress = DAL.FirebirdDB.MembersAddressGet(_DeliveryAddressID);

            if (_DeliveryAddress == null)
                _DeliveryAddress = this.User.DeliveryAddresses.First();

            if (_DeliveryAddress == null)
                _DeliveryAddress = User.DeliveryAddresses.Create(User);

            string Result = "";

            if (User.UserName != "")
                Result += _DeliveryAddress.Name + Seperator;

            if (_DeliveryAddress.AddressLine1 != "")
                Result += _DeliveryAddress.AddressLine1 + Seperator;

            if (_DeliveryAddress.AddressLine2 != "")
                Result += _DeliveryAddress.AddressLine2 + Seperator;

            if (_DeliveryAddress.AddressLine3 != "")
                Result += _DeliveryAddress.AddressLine3 + Seperator;

            if (_DeliveryAddress.City != "")
                Result += _DeliveryAddress.City + Seperator;

            if (_DeliveryAddress.County != "")
                Result += _DeliveryAddress.County + Seperator;

            if (_DeliveryAddress.Country.Name != "")
                Result += _DeliveryAddress.Country.Name + Seperator;

            if (_DeliveryAddress.PostCode != "")
                Result += _DeliveryAddress.PostCode + Seperator;

            return (Result);

        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Invoice: {0}; User ID: {1}", ID, _UserID));
        }

        #endregion Overridden Methods
    }
}