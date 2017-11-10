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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Enums.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;


namespace Library
{
    /// <summary>
    /// Specific system emails
    /// </summary>
    public enum SystemEmailType
    {
        ThankyouForYourOrder = 1,

        WelcomeEmail  = 2,

        Announcement = 3,

        OrderComplete  = 4,

        OrderDispatched= 5,

        TradeAccountCreated = 6,

        OrderCompleteGeneric = 7,

        OrderCompleteCard = 8,

        OrderCompleteCheque = 11,

        OrderCompleteTelephone = 12,

        StockAvailable = 13,

        RecurringInvoiceCreated = 9,
    }


    [Flags]
    public enum RecurringInvoiceOptions
    {
        None = 0,

        SendEmail = 1,
    }

    public enum RecurringType
    {
        Day = 0,

        Week = 1,

        Month = 2,

        Year = 3
    }

    /// <summary>
    /// Item type
    /// 
    /// Caution when altering these values, need to look at sp WSP_UPDATE_MISSING_STOCK
    /// this sp is used to create all the missing stock
    /// and sp WSP_SHOPPINGBASKET which is used to return certain item types
    /// </summary>
    public enum ProductCostItemType
    {
        /// <summary>
        /// Physical product
        /// </summary>
        Product = 0,

        /// <summary>
        /// Licence
        /// </summary>
        Licence = 1,

        /// <summary>
        /// Hourly/Daily work rate
        /// </summary>
        Rate = 2,

        /// <summary>
        /// Item is of type voucher
        /// </summary>
        Voucher = 3,

        /// <summary>
        /// item is a treatment
        /// </summary>
        Treatment = 4,

        /// <summary>
        /// Item is giftwrapping
        /// </summary>
        GiftWrap = 5,

        /// <summary>
        /// Item is a free product
        /// </summary>
        FreeProduct = 6,
    }

    public enum CampaignSortType
    {
        TopVisits,
        TopSpend,
        StartDateDescending,
        StartDateAscending
    }

    /// <summary>
    /// Contact Details Type
    /// </summary>
    public enum ContactDetailsType
    {
        OfficeTelephone = 0,

        HomeTelephone = 1,

        Mobile = 2,

        Email = 3,

        Fax = 4
    }

    /// <summary>
    /// Supplier Statuses
    /// </summary>
    public enum SupplierStatus
    {
        Active = 0,

        OnHold = 1,
    }

    /// <summary>
    /// Types of assets
    /// </summary>
    public enum AssetType
    {
        Asset = 1,

        License = 2,

        Accessory = 4,

        Consumable = 8,

        Component = 16
    }

    /// <summary>
    /// Employee Status Type
    /// </summary>
    public enum EmployeeLeaveStatus
    {
        Approved,
        Authorised,
        Cancelled,
        Denied,
        Requested
    }

    /// <summary>
    /// Employee Expense Status
    /// </summary>
    public enum EmployeeExpenseStatus
    {
        Submitted = 1,

        Approved = 2,

        Paid = 4,

        Declined = 8
    }

    /// <summary>
    /// Employee Expense Type
    /// </summary>
    public enum EmployeeExpenseType
    {
        MealBreakfast = 1,

        MealLunch = 2,

        MealDinner = 4,

        Mileage = 8,

        TransportPublic = 16,

        TransportTaxi = 32,

        TransportTrain = 64,

        TransportPlane = 128,

        TransportOther = 256,

        Parking = 512,

        Lodgings = 1024,

        Tolls = 2048,

        Other = 4096
    }

    /// <summary>
    /// Employee sick options
    /// </summary>
    public enum SickOptions
    {
        None = 1,

        Cancelled = 2
    }

    /// <summary>
    /// Hook events
    /// </summary>
    public enum HookEvent
    {
        UserAccountCreated = 1,

        OrderCreated = 2,

        OrderProcessing = 3,

        OrderDispatched = 4,

        OrderCancelled = 5,

        InvoiceCreated = 6,

        AppointmentCreated = 7,

        AppointmentStatusChanged = 8,

        HelpDeskTicketCreated = 9,

        HelpDeskTicketReplied = 10,

        TradeClientCreated = 11,

        TradeClientManagerChanged = 12,

        TradeClientNoteAdd = 13,

        TradeClientNoteAddAction = 14
    }

    /// <summary>
    /// Enum for specifying which database to connect to
    /// </summary>
    public enum DatabaseType
    {
        Standard = 0,

        FailOver = 1,

        Reports = 2,

        SeoData = 3,

        GeoIPUpdates = 4,

        Maintenance = 5
    }

    public enum MapReportType
    {
        Currency,

        City,

        Country
    }

    public enum BasketDiscountType
    {
        None,

        Value,

        Percentage,

        Coupon
    }

    [Flags]
    public enum InvoiceOptions
    {
        Unused = 1,

        SageDiscountType = 2
    }

    public enum CommissionPaymentType
    {
        /// <summary>
        /// Payment is from commission pool
        /// </summary>
        Pool = 0,

        /// <summary>
        /// Generated from account management
        /// </summary>
        Account = 1,

        /// <summary>
        /// Adhoc periodic one off etc
        /// </summary>
        Bonus = 2,

        /// <summary>
        /// Affiliate commission
        /// </summary>
        Affiliate = 3
    }

    [Flags]
    public enum ImportExportOptions
    {
        Import = 1,

        Export = 2,

        Required = 3
    }

    /// <summary>
    /// Options for Leave
    /// </summary>
    [Flags]
    public enum LeaveOptions
    {
        /// <summary>
        /// No options
        /// </summary>
        None = 0,

        /// <summary>
        /// Leave request has been cancelled
        /// </summary>
        Cancelled = 1,

        /// <summary>
        /// Leave Denied
        /// </summary>
        Denied = 2,
    }

    /// <summary>
    /// Product Report Types
    /// </summary>
    public enum ProductReportType
    {
        /// <summary>
        /// Top 10 selling products
        /// </summary>
        Top10SellingProducts,

        /// <summary>
        /// Top 20 selling products
        /// </summary>
        Top20SellingProducts,

        /// <summary>
        /// Top selling products all
        /// </summary>
        TopSellingProducts
    }

    /// <summary>
    /// Marital Status
    /// </summary>
    public enum MaritalStatus
    {
        Single = 0,
        Married = 1,
        Separated = 2,
        Divorced = 3,
        Widowed = 4
    }

    /// <summary>
    /// Gender Types
    /// </summary>
    public enum GenderType
    {
        Male = 0,
        Female = 1,
        TransGender = 2,
        Neutral = 3,
        Other = 4
    }

    /// <summary>
    /// Employment Types
    /// </summary>
    public enum EmploymentType
    {
        Contract = 0,
        Casual = 1,
        FixedTerm = 2,
        Trainee = 3,
        Apprentice = 4,
        Commission = 5,
        Contractor = 6,
        ZeroHours = 7,
        Voluntary = 8,
        Internship = 9
    }

    /// <summary>
    /// Pay period for staff
    /// </summary>
    public enum PayPeriod
    {
        Weekly = 0,
        Monthly = 1,
        FourWeekly = 2,
        Fortnightly = 3
    }

    /// <summary>
    /// Module Properties and attributes
    /// </summary>
    [Flags]
    public enum ModuleProperties
    {
        None = 0,

        IsClass = 1,

        IsEnum = 2,

        IsDelegate = 4,

        IsMethod = 8,

        IsProperty = 16,

        IsEvent = 32,

        IsConstructor = 64,

        #region Visibility

        IsPublic = 128,

        IsProtected = 256,

        IsStatic = 512,

        IsAbstract = 1024,

        IsVirtual = 2048,

        #endregion Visibility

        #region Parameter Values

        IsOptional = 4096,

        IsByRef = 8192,

        IsOut = 16386

        #endregion Parameter Values
    }

    /// <summary>
    /// Parameter Types
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Normal parameter
        /// </summary>
        None = 0,

        /// <summary>
        /// Parameter is passed by reference
        /// </summary>
        IsByRef = 1,

        /// <summary>
        /// Parameter is out parameter
        /// </summary>
        IsOut = 2,
    }

    /// <summary>
    /// SEO Timespan
    /// </summary>
    public enum SEOTimeSpan
    {
        /// <summary>
        /// Hourly Report
        /// </summary>
        Hourly,

        /// <summary>
        /// Daily Report
        /// </summary>
        Daily,

        /// <summary>
        /// Weekly Report
        /// </summary>
        Weekly,

        /// <summary>
        /// Monthly Report
        /// </summary>
        Monthly
    }

    [Flags]
    public enum AddressOptions
    {
        /// <summary>
        /// Determines wether to show the business name or not
        /// </summary>
        BusinessNameShow = 1,

        /// <summary>
        /// Determines wether Business Name is mandatory
        /// </summary>
        BusinessNameMandatory = 2,

        /// <summary>
        /// Determines wether AddressLine 1 is shown or not
        /// </summary>
        AddressLine1Show = 4,

        /// <summary>
        /// Determines wether AddressLine1 is mandatory or not
        /// </summary>
        AddressLine1Mandatory = 8,

        /// <summary>
        /// Determines wether AddressLine 2 is shown or not
        /// </summary>
        AddressLine2Show = 16,

        /// <summary>
        /// Determines wether AddressLine2 is mandatory or not
        /// </summary>
        AddressLine2Mandatory = 32,

        /// <summary>
        /// Determines wether AddressLine 3 is shown or not
        /// </summary>
        AddressLine3Show = 64,

        /// <summary>
        /// Determines wether AddressLine1 is mandatory or not
        /// </summary>
        AddressLine3Mandatory = 128,

        /// <summary>
        /// Determines wether to show city data or not
        /// </summary>
        CityShow = 256,

        /// <summary>
        /// Determines wether City is mandatory or not
        /// </summary>
        CityMandatory = 512,

        /// <summary>
        /// Determines wether to show county or not
        /// </summary>
        CountyShow = 1024,

        /// <summary>
        /// Determines wether County is mandatory or not
        /// </summary>
        CountyMandatory = 2048,

        /// <summary>
        /// Determines wether to show the postcode or not
        /// </summary>
        PostCodeShow = 4096,

        /// <summary>
        /// Determines wether post code is mandatory or not
        /// </summary>
        PostCodeMandatory = 8192,

        /// <summary>
        /// Determines wether telephone number is shown
        /// </summary>
        TelephoneShow = 16384,

        /// <summary>
        /// Determines wether telephone is a mandatory field
        /// </summary>
        TelephoneMandatory = 32768
    }

    public enum InvoiceStatistics { ToProcess, Today, OnHold, PartiallyDispatched, VerifyPayment, Received }

    public enum RoutineMaintenanceType
    {
        /// <summary>
        /// General routine maintenance
        /// </summary>
        General,

        /// <summary>
        /// Campaign maintenance
        /// </summary>
        Campaign
    }

    public enum CustomPagesType
    {
        WebPage = 0,

        ProductDescription = 1,

        ProductHowToUse = 2,

        ProductIngredients = 3,

        ProductFeatures = 4,

        ProductGroupDescription = 5
    }

    /// <summary>
    /// Cash drawer types
    /// </summary>
    public enum CashDrawerType
    {
        Till = 0,

        PettyCash = 1,

        Safe = 2
    }

    public enum ValidationReasons
    {
        BypassCreditCard = 0,

        IgnoreIncompleteAppointments = 1,

        IgnoreDateOfBirth = 2,

        IgnoreSpellCheckProduct = 3,

        IgnoreSpellCheckTreatment = 4,

        IgnoreTakePayment = 5,

        IgnoreNewAppointments = 6,

        IgnoreCustomerComments = 7,

        IgnoreSalonUpdates = 8,

        IgnoreOpenTickets = 9,

        CashDrawerSpotCheck = 10,

        UnsubscribeEmail = 11,

        IgnoreSpellCheckTicketReply = 12
    }


    /// <summary>
    /// Change state for user included items
    /// </summary>
    public enum ChangeState { NoChange, Add, Remove }

    /// <summary>
    /// Status for each item that is on an order / invoice
    /// </summary>
    public enum ProcessItemStatus
    {
        /// <summary>
        /// Item has not been dispatched
        /// </summary>
        NotDispatched = 0,

        /// <summary>
        /// Item has been dispatched
        /// </summary>
        Dispatched = 1,

        /// <summary>
        /// Item is about to be dispatched
        /// </summary>
        Dispatching = 6,

        /// <summary>
        /// Order item is on hold as can not be dispatched at the moment (out of stock etc)
        /// </summary>
        OnHold = 2,

        /// <summary>
        /// Item has been cancelled
        /// </summary>
        Cancelled = 3,

        /// <summary>
        /// Item has been refunded from the invoice
        /// </summary>
        Refund = 4,

        /// <summary>
        /// Item has been returned
        /// </summary>
        Returned = 5,

        /// <summary>
        /// Invoice is completed
        /// </summary>
        Complete = 7,
    }

    [Flags]
    public enum ProcessStatuses
    {
        /// <summary>
        /// No flag set
        /// </summary>
        None = 0,

        /// <summary>
        /// Order has been received
        /// </summary>
        OrderReceived = 1,

        /// <summary>
        /// Order is being processed ready for dispatch
        /// </summary>
        Processing = 2,

        /// <summary>
        /// Order has been dispatched to customer
        /// </summary>
        Dispatched = 4,

        /// <summary>
        /// Refund given to customer
        /// </summary>
        IssueRefund = 8,

        /// <summary>
        /// Order received but not paid, Payment pending
        /// </summary>
        PaymentPending = 16,

        /// <summary>
        /// Order has been placed on hold
        /// </summary>
        OnHold = 32,

        /// <summary>
        /// The payment is being verified
        /// </summary>
        VerifyingPayment = 64,

        /// <summary>
        /// The order has been partially dispatched, but some items not sent to customers
        /// </summary>
        PartialDispatch = 128,

        /// <summary>
        /// Order has been cancelled
        /// </summary>
        Cancelled = 256,

        /// <summary>
        /// Order is complete, but no dispatchable items
        /// </summary>
        Complete = 512
    }

    /// <summary>
    /// Possible status for all orders / invoices
    /// </summary>
    public enum ProcessStatus
    {
        /// <summary>
        /// Order has been received
        /// </summary>
        OrderReceived = 0,

        /// <summary>
        /// Order is being processed ready for dispatch
        /// </summary>
        Processing = 1,

        /// <summary>
        /// Order has been dispatched to customer
        /// </summary>
        Dispatched = 2,

        /// <summary>
        /// Refund given to customer
        /// </summary>
        IssueRefund = 3,

        /// <summary>
        /// Order received but not paid, Payment pending
        /// </summary>
        PaymentPending = 4,

        /// <summary>
        /// Order has been placed on hold
        /// </summary>
        OnHold = 5,

        /// <summary>
        /// The payment is being verified
        /// </summary>
        VerifyingPayment = 6,

        /// <summary>
        /// The order has been partially dispatched, but some items not sent to customers
        /// </summary>
        PartialDispatch = 7,

        /// <summary>
        /// Order is complete, same as dispatched but no items to dispatch
        /// </summary>
        Completed = 8,

        /// <summary>
        /// Order has been cancelled
        /// </summary>
        Cancelled = 10
    }

    public enum MemberLevel
    {
        StandardUser = 0,
        FormerStaffMember = 1,
        GoldUser = 2,
        Reseller = 3,
        User4 = 4,
        Distributor = 5,
        SalesAdvisor = 6,
        StaffMember = 7,
        AdminReadOnly = 8,
        AdminUpdateDelete = 9,
        Admin = 10,
        System = 11
    }

    public class Enums
    {
        public enum SearchResultType { Products = 0, KnowledgeBase = 1, Salons = 2, Treatments = 3, Celebrities = 4, HashTags = 5, Feedback = 6 }

        public enum ValidationTypes { CreditCard, IsNumeric, AlphaNumeric, Name, CardValidFrom, CardValidTo, FileName }

        public enum AppointmentStatus { Requested = 1, Confirmed = 2, Arrived = 8, CancelledByUser = 4, CancelledByStaff = 5, NoShow = 6, Completed = 7, Deleted = 99 }
        public enum Month { Jan = 1, Feb = 2, Mar = 3, Apr = 4, May = 5, Jun = 6, Jul = 7, Aug = 8, Sep = 9, Oct = 10, Nov = 11, Dec = 12 }
        public enum RSSFeedType { ClientNotes = 1, TelephoneCalls = 2, Visits = 3, NewSignups = 4 }
        public enum SalonType { Salon = 0, StockistOnly = 1, Distributor = 2 }
        public enum ClientState { NewClient = 0, ActiveClient = 10, ArchivedClient = 20, NewDistributor = 30, CurrentDistributors = 40, ArchivedDistributors = 50, CurrentAtHome = 60, ArchivedAtHome = 70 }

        public enum ClientAction
        {
            None = 0,
            Telephone = 1,
            Visit = 2,
            DetailsSent = 3,
            TakeOn = 4,
            TrainingLIA = 5,
            TrainingBSF = 6,
            TrainingDream = 7,
            CreateAccount = 101,
            CreateSalon = 102,
            LinkAccountToSalon = 103
        }

        public enum Mode { Select = 0, Edit = 1 }

        public enum AppointmentStats { NewAppointments, TodaysAppointments, WeeksAppointments }

        public enum UserRecordType { Default = 0, KitombaImport = 1, PosToImport = 2, PosImported = 3, SBMGenerated = 4 }


        /// <summary>
        /// Repeat type for Appointments
        /// </summary>
        public enum AppointmentRepeatType { NoRepeat = 0, Week = 1, Month = 2, Year = 3 }

        public enum TicketStatus { Open, Closed, OnHold }

        /// <summary>
        /// Invoice voucher type
        /// </summary>
        public enum InvoiceVoucherType
        {
            /// <summary>
            /// Discount is a percentage
            /// </summary>
            Percent = 0,

            /// <summary>
            /// Discount is for money i.e. £10
            /// </summary>
            Value = 1,

            /// <summary>
            /// Used as promotion only, no actual discounts available
            /// </summary>
            Footprint = 2,


            /// <summary>
            /// Special Offer
            /// </summary>
            SpecialOffer = 3,

            /// <summary>
            /// Used to give a product away freely
            /// </summary>
            FreeProduct = 4

            // if you add new ones, check shoppingbasket.cs line 1011
        }

        public enum MailCount { ToProcess, Queued, Failed }
    }
}