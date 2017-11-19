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
 *  File: User.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

#if !ANDROID
using System.Data;
#endif

using System.Globalization;

using Library.BOL.Countries;
using Library.BOL.DeliveryAddress;
using Library.BOL.Invoices;
using Library.BOL.Basket;
using Library.BOL.Licencing;
using Library.BOL.Staff;
using Library.BOL.Trade;

namespace Library.BOL.Users
{
    [Serializable]
    public sealed class User : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private string _Email;
        private string _FirstName;
        private string _LastName;
        private string _Password;
        private DateTime _LastVisit;
        private string _BusinessName;
        private string _AddressLine1;
        private string _AddressLine2;
        private string _AddressLine3;
        private string _City;
        private string _County;
        private string _PostCode;
        private MemberLevel _MemberLevel;
        private Country _Country;
        private int _countryID;
        private DeliveryAddresses _DeliveryAddresses;
        private string _Telephone;
        private bool _OffersEmail;
        private bool _OffersPost;
        private bool _OffersTelephone;
        private DateTime _BirthDate;
        private string _Style;
        private ShoppingBasket _basket;
        private Enums.UserRecordType _RecordType;
        private int _AutoDiscount;
        private AppointmentHistory _history;
        private SecurityEnums.SecurityPermissionsPOS _permissionsPOS = 0;
        private SecurityEnums.SecurityPermissionsAccounts _permissionsAccounts = 0;
        private SecurityEnums.SecurityPermissionsCalendar _permissionsCalendar = 0;
        private SecurityEnums.SecurityPermissionsWebsite _permissionsWebsite = 0;
        private SecurityEnums.SecurityPermissionsReports _permissionsReports = 0;
        private SecurityEnums.SecurityPermissionsStockControl _permissionsStock = 0;
        private SecurityEnums.SecurityPermissionsStaff _permissionsStaff = 0;

        private CreditCard _cardDetails;
        private string _barcode;

        private User _manager;
        private bool _managerRetrieved = false;
        private StaffMember _staffRecord;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public User(Int64 ID, string Email, string FirstName, string LastName, string Password, DateTime LastVisit,
            string BusinessName, string AddressLine1, string AddressLine2, string AddressLine3, string City,
            string County, string PostCode, MemberLevel MemberLevel,
            int Country, string Telephone, bool canGenerateBarcode, bool OffersEmail, bool OffersPost, bool OffersTelephone,
            DateTime BirthDate, string Style, Enums.UserRecordType RecordType, int AutoDiscount, Country country)
        {
            _ID = ID;
            _Email = Email;
            _FirstName = FirstName;
            _LastName = LastName;
            _Password = Password;
            _LastVisit = LastVisit;
            _BusinessName = BusinessName;
            _AddressLine1 = AddressLine1;
            _AddressLine2 = AddressLine2;
            _AddressLine3 = AddressLine3;
            _City = City;
            _County = County;
            _PostCode = PostCode;
            _MemberLevel = MemberLevel;
            _Country = country;
            _Telephone = Telephone;
            _OffersEmail = OffersEmail;
            _OffersPost = OffersPost;
            _OffersTelephone = OffersTelephone;
            _BirthDate = BirthDate;
            _Style = Style;
            _RecordType = RecordType;
            _AutoDiscount = AutoDiscount;
            _cardDetails = null;
            CanGenerateBarcode = canGenerateBarcode;
        }

        public User(Int64 ID, string Email, string FirstName, string LastName, string Password, DateTime LastVisit,
            string BusinessName, string AddressLine1, string AddressLine2, string AddressLine3, string City,
            string County, string PostCode, MemberLevel MemberLevel,
            int Country, string Telephone, bool canGenerateBarcode, bool OffersEmail, bool OffersPost, bool OffersTelephone,
            DateTime BirthDate, string Style, Enums.UserRecordType RecordType, int AutoDiscount)
        {
            _ID = ID;
            _Email = Email;
            _FirstName = FirstName;
            _LastName = LastName;
            _Password = Password;
            _LastVisit = LastVisit;
            _BusinessName = BusinessName;
            _AddressLine1 = AddressLine1;
            _AddressLine2 = AddressLine2;
            _AddressLine3 = AddressLine3;
            _City = City;
            _County = County;
            _PostCode = PostCode;
            _MemberLevel = MemberLevel;
            _Country = null;
            _countryID = Country;
            _Telephone = Telephone;
            _OffersEmail = OffersEmail;
            _OffersPost = OffersPost;
            _OffersTelephone = OffersTelephone;
            _BirthDate = BirthDate;
            _Style = Style;
            _RecordType = RecordType;
            _AutoDiscount = AutoDiscount;
            _cardDetails = null;
            CanGenerateBarcode = canGenerateBarcode;
        }

        public User(Int64 id, string userName)
        {
            ID = id;
            FirstName = userName;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// Gets or sets all permissions for a user;
        /// </summary>
        public SecurityEnums.SecurityPermissionsPOS Permissions
        {
            get
            {
                if (_permissionsPOS == 0)
                    _permissionsPOS = DAL.FirebirdDB.PermissionsGet(this);

                return (_permissionsPOS);
            }

            set
            {
                _permissionsPOS = value;
                DAL.FirebirdDB.PermissionsSet(this, _permissionsPOS);
            }
        }

        /// <summary>
        /// Gets or sets all Calendar permissions for a user;
        /// </summary>
        public SecurityEnums.SecurityPermissionsCalendar PermissionsCalendar
        {
            get
            {
                if (_permissionsCalendar == 0)
                    _permissionsCalendar = DAL.FirebirdDB.PermissionsGetCalendar(this);

                return (_permissionsCalendar);
            }

            set
            {
                _permissionsCalendar = value;
                DAL.FirebirdDB.PermissionsSetCalendar(this, _permissionsCalendar);
            }
        }

        /// <summary>
        /// Gets or sets all website permissions for a user;
        /// </summary>
        public SecurityEnums.SecurityPermissionsWebsite PermissionsWebsite
        {
            get
            {
                if (_permissionsWebsite == 0)
                    _permissionsWebsite = DAL.FirebirdDB.PermissionsGetWebsite(this);

                return (_permissionsWebsite);
            }

            set
            {
                _permissionsWebsite = value;
                DAL.FirebirdDB.PermissionsSetWebsite(this, _permissionsWebsite);
            }
        }

        /// <summary>
        /// Gets or sets report permissions for a user
        /// </summary>
        public SecurityEnums.SecurityPermissionsReports PermissionsReports
        {
            get
            {
                if (_permissionsReports == 0)
                    _permissionsReports = DAL.FirebirdDB.PermissionsGetReports(this);

                return (_permissionsReports);
            }

            set
            {
                _permissionsReports = value;
                DAL.FirebirdDB.PermissionsSetReports(this, _permissionsReports);
            }
        }

        /// <summary>
        /// Gets / Sets permissions for user to deal with staff records
        /// </summary>
        public SecurityEnums.SecurityPermissionsStaff PermissionsStaff
        {
            get
            {
                if (_permissionsStaff == 0)
                    _permissionsStaff = DAL.FirebirdDB.PermissionsGetStaff(this);

                return (_permissionsStaff);
            }

            set
            {
                _permissionsStaff = value;
                DAL.FirebirdDB.PermissionsSetStaff(this, _permissionsStaff);
            }
        }

        /// <summary>
        /// Gets or sets all Stock Control permissions for a user;
        /// </summary>
        public SecurityEnums.SecurityPermissionsStockControl PermissionsStock
        {
            get
            {
                if (_permissionsStock == 0)
                    _permissionsStock = DAL.FirebirdDB.PermissionsGetStock(this);

                return (_permissionsStock);
            }

            set
            {
                _permissionsStock = value;
                DAL.FirebirdDB.PermissionsSetStock(this, _permissionsStock);
            }
        }

        /// <summary>
        /// Gets or sets all Accounts permissions for a user;
        /// </summary>
        public SecurityEnums.SecurityPermissionsAccounts PermissionsAccounts
        {
            get
            {
                if (_permissionsAccounts == 0)
                    _permissionsAccounts = DAL.FirebirdDB.PermissionsGetAccounts(this);

                return (_permissionsAccounts);
            }

            set
            {
                _permissionsAccounts = value;
                DAL.FirebirdDB.PermissionsSetAccounts(this, _permissionsAccounts);
            }
        }

        /// <summary>
        /// Unique user id
        /// </summary>
        public Int64 ID
        {
            get
            {
                return (_ID);
            }

            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// Users email address
        /// </summary>
        public string Email
        {
            get
            {
                return (_Email);
            }

            set
            {
                _Email = value;
            }
        }

        public string FirstName
        {
            get
            {
                return (_FirstName);
            }

            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return (_LastName);
            }

            set
            {
                _LastName = value;
            }
        }

        public string UserName
        {
            get
            {
                return (_FirstName + " " + _LastName);
            }
        }

        public string Password
        {
            get
            {
                return (_Password);
            }

            set
            {
                string NewPassword = value;

                //validation???
                if (NewPassword == _Password)
                    throw new Exception("New password must be different to old password");

                if (NewPassword.Length < 6)
                    throw new Exception("New password must be at least 6 characters long");


                DAL.FirebirdDB.UserChangePassword(_ID, _Password, NewPassword);
                _Password = NewPassword;
            }
        }

        public DateTime LastVisit
        {
            get
            {
                return (_LastVisit);
            }

            set
            {
                _LastVisit = value;
                DAL.FirebirdDB.UserSetLastVisit(this);
            }
        }

        public string BusinessName
        {
            get
            {
                return (_BusinessName);
            }

            set
            {
                _BusinessName = value == null ? String.Empty : value;
            }
        }

        public string AddressLine1
        {
            get
            {
                return (_AddressLine1);
            }

            set
            {
                _AddressLine1 = value == null ? String.Empty : value;
            }
        }

        public string AddressLine2
        {
            get
            {
                return (_AddressLine2);
            }

            set
            {
                _AddressLine2 = value == null ? String.Empty : value;
            }
        }

        public string AddressLine3
        {
            get
            {
                return (_AddressLine3);
            }

            set
            {
                _AddressLine3 = value == null ? String.Empty : value;
            }
        }

        public string City
        {
            get
            {
                return (_City);
            }

            set
            {
                _City = value = value == null ? String.Empty : value;
            }

        }

        public string County
        {
            get
            {
                return (_County);
            }

            set
            {
                _County = value = value == null ? String.Empty : value;
            }

        }

        public string PostCode
        {
            get
            {
                return (_PostCode);
            }

            set
            {
                _PostCode = value = value == null ? String.Empty : value;
            }

        }

        public MemberLevel MemberLevel
        {
            get
            {
                return (_MemberLevel);
            }

            set
            {
                _MemberLevel = value;
            }
        }

        public Country Country
        {
            get
            {
                if (_Country == null)
                    _Country = DAL.FirebirdDB.CountryGet(_countryID);

                return (_Country);
            }

            set
            {
                _Country = value;
            }
        }

        public string Telephone
        {
            get
            {
                return (_Telephone);
            }

            set
            {
                _Telephone = value;
            }
        }

        public Salons.Salons Salons
        {
            get
            {
                return (DAL.FirebirdDB.SalonsGet(this));
            }
        }

        public bool OffersEmail
        {
            get
            {
                return (_OffersEmail);
            }

            set
            {
                _OffersEmail = value;
            }
        }

        public bool OffersPost
        {
            get
            {
                return (_OffersPost);
            }

            set
            {
                _OffersPost = value;
            }
        }

        public bool OffersTelephone
        {
            get
            {
                return (_OffersTelephone);
            }

            set
            {
                _OffersTelephone = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return (_BirthDate);
            }

            set
            {
                _BirthDate = value;
            }
        }

        public DeliveryAddresses DeliveryAddresses
        {
            get
            {
                if (_DeliveryAddresses == null)
                    _DeliveryAddresses = DAL.FirebirdDB.MembersAddressGet(this);

                return (_DeliveryAddresses);
            }
        }

        public Appointments.Appointments Appointments
        {
            get
            {
                return (DAL.FirebirdDB.AppointmentsGet(this, 1, 1000));
            }
        }

        public Orders.Orders Orders
        {
            get
            {
                return (DAL.FirebirdDB.OrdersGet(this));
            }
        }

        public Invoices.Invoices Invoices
        {
            get
            {
                return (DAL.FirebirdDB.InvoicesGet(this));
            }
        }

        /// <summary>
        /// Indicates a VIP customer
        /// </summary>
        public bool VIPCustomer
        {
            get
            {
                return (_Style == "VIP");
            }

            set
            {
                if (value)
                    _Style = "VIP";
                else
                    _Style = "";
            }
        }
        public string Style
        {
            get
            {
                return (_Style);
            }
        }

        public ShoppingBasket Basket
        {
            get
            {
                return (_basket);
            }

            set
            {
                _basket = value;
            }
        }

#if !ANDROID
        public DataSet MenuItems
        {
            get
            {
                return (DAL.FirebirdDB.UserGetUserMenuItems());
            }
        }
#endif

        public Enums.UserRecordType RecordType
        {
            get
            {
                return (_RecordType);
            }
        }

        public string RoleName
        {
            get
            {
                string Result = String.Format("M{0}${1}", _ID, _Email);
                Result = Result.Replace('@', '_');
                Result = Result.Replace('.', '_');
                Result = Result.Replace('-', '_');
                Result = Result.Replace("'", "_");
                Result = Result.Replace("/", "");
                Result = Result.Replace('`', '_');
                Result = Result.Substring(0, Result.Length > 31 ? 30 : Result.Length);

                return (Result);
            }
        }

        /// <summary>
        /// Automatic discount for gold users, salon oweners and above
        /// </summary>
        public int AutoDiscount
        {
            get
            {
                int Result = 0;

                if (_MemberLevel >= MemberLevel.GoldUser)
                    Result = _AutoDiscount;

                return (Result);
            }

            set
            {
                if (_MemberLevel >= MemberLevel.GoldUser)
                    _AutoDiscount = value;
            }
        }


        public string Notes
        {
            get
            {
                return (DAL.FirebirdDB.MemberNotesGet(this));
            }

            set
            {
                DAL.FirebirdDB.MemerNotesSet(this, value);
            }
        }

        public AppointmentHistory History
        {
            get
            {
                if (_history == null)
                    _history = DAL.FirebirdDB.AppointmentHistory(this);

                return (_history);
            }
        }

        /// <summary>
        /// Retrieves users Credit/Debit Card details
        /// </summary>
        public CreditCard CardDetails
        {
            set
            {
                _cardDetails = value;
            }

            get
            {
                if (_cardDetails == null)
                    _cardDetails = DAL.FirebirdDB.UserCreditCardDetailsGet(this);

                return (_cardDetails);
            }
        }

        public string Barcode
        {
            get
            {
                if (String.IsNullOrEmpty(_barcode))
                    _barcode = DAL.FirebirdDB.UserGetBarcode(this);

                return (_barcode);
            }
        }

        /// <summary>
        /// indicates wether the user can have a login barcode generated or not
        /// </summary>
        public bool CanGenerateBarcode { get; set; }


        public Licences Licences
        {
            get
            {
                return (DAL.FirebirdDB.LicenceGet(this));
            }
        }

        /// <summary>
        /// Persons manager, if they have one
        /// </summary>
        public User Manager
        {
            get
            {
                if (!_managerRetrieved)
                {
                    _manager = DAL.FirebirdDB.StaffMemberManagerGet(this);
                    _managerRetrieved = true;
                }

                return (_manager);
            }

            set
            {
                _manager = value;
                _managerRetrieved = true;

                if (_manager == null)
                    DAL.FirebirdDB.StaffMemberManagerRemove(this);
                else
                    DAL.FirebirdDB.StaffMemberManagerSet(this, _manager);
            }
        }

        /// <summary>
        /// Gets the users staff record if they have one
        /// </summary>
        public StaffMember StaffRecord
        {
            get
            {
                if (_staffRecord == null)
                {
                    _staffRecord = Library.BOL.Staff.StaffMembers.Get(this);

                    if (_staffRecord == null)
                    {
                        _staffRecord = new Library.BOL.Staff.StaffMember(this);
                        _staffRecord.Save();
                    }
                }

                return (_staffRecord);
            }
        }

        #endregion Properties

        #region Public Methods

        #region Permissions

        /// <summary>
        /// Determines if a user has a specific permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((Permissions & permission) == permission));
            }
            catch
            {
                return (HasPermissionPOS(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific report permission
        /// </summary>
        /// <param name="permission">Permission being sought</param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionReport(SecurityEnums.SecurityPermissionsReports permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsReports & permission) == permission));
            }
            catch
            {
                return (HasPermissionReport(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsCalendar & permission) == permission));
            }
            catch
            {
                return (HasPermissionCalendar(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsAccounts & permission) == permission));
            }
            catch
            {
                return (HasPermissionAccounts(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific stock permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has the permission, otherwise false</returns>
        public bool HasPermissionStock(SecurityEnums.SecurityPermissionsStockControl permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsStock & permission) == permission));
            }
            catch
            {
                return (HasPermissionStock(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsWebsite & permission) == permission));
            }
            catch
            {
                return (HasPermissionWebsite(permission, iteration + 1));
            }
        }

        /// <summary>
        /// Determines if a user has a specific staff related permission
        /// </summary>
        /// <param name="permission"></param>
        /// <returns>true if user has permission, otherwise false</returns>
        public bool HasPermissionStaff(SecurityEnums.SecurityPermissionsStaff permission, int iteration = 0)
        {
            if (iteration > 10)
                return (false);

            try
            {
                return (((PermissionsStaff & permission) == permission));
            }
            catch
            {
                return (HasPermissionStaff(permission, iteration + 1));
            }
        }

        #endregion Permissions

        /// <summary>
        /// Save's the current user 
        /// </summary>
        public override void Save()
        {
            DAL.FirebirdDB.UserAmmendAccount(this);
            CacheClear();
        }

        /// <summary>
        /// Returns the address formatted for display
        /// </summary>
        /// <param name="IsHTML">Determines wether it's for html output or not</param>
        /// <returns>string - address correctly formatted</returns>
        public string Address(bool IsHTML)
        {
            string Seperator;

            if (IsHTML)
                Seperator = "<br>";
            else
                Seperator = "\n";

            string Result = "";

            if (UserName != "")
                Result += Shared.Utilities.ProperCase(UserName) + Seperator;

            if (AddressLine1 != "")
                Result += Shared.Utilities.ProperCase(AddressLine1) + Seperator;

            if (AddressLine2 != "")
                Result += Shared.Utilities.ProperCase(AddressLine2) + Seperator;

            if (AddressLine3 != "")
                Result += Shared.Utilities.ProperCase(AddressLine1) + Seperator;

            if (City != "")
                Result += Shared.Utilities.ProperCase(City) + Seperator;

            if (County != "")
                Result += Shared.Utilities.ProperCase(County) + Seperator;

            if (Country.Name != "")
                Result += Shared.Utilities.ProperCase(Country.Name) + Seperator;

            if (PostCode != "")
                Result += PostCode.ToUpper() + Seperator;

            return (Result);

        }

        /// <summary>
        /// Determines how many invoices have been created for user since datetime
        /// </summary>
        /// <param name="datetime">date from check being made</param>
        /// <returns>int, number of invoices since datetime</returns>
        public int InvoiceCountSinceDate(DateTime datetime)
        {
            int Result = 0;

            foreach (Invoice invoice in Invoices)
            {
                if (invoice.PurchaseDateTime >= datetime)
                    Result++;
            }

            return (Result);
        }

        /// <summary>
        /// Determines wether a users birth date is valid
        /// </summary>
        /// <returns>true if valid, otherwise false</returns>
        public bool ValidBirthDate()
        {
            bool Result = (_BirthDate.Year > 1900 | BirthDate.Year == 1800);

            return (Result);
        }

        /// <summary>
        /// Converts user address/name to proper case and removes duplicate entries
        /// </summary>
        public void FixAddress()
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            TextInfo textInfo = cultureInfo.TextInfo;

            _FirstName = textInfo.ToTitleCase(_FirstName.ToLower());
            _LastName = textInfo.ToTitleCase(_LastName.ToLower());
            _AddressLine1 = textInfo.ToTitleCase(_AddressLine1.ToLower());
            _AddressLine2 = textInfo.ToTitleCase(_AddressLine2.ToLower());
            _AddressLine3 = textInfo.ToTitleCase(_AddressLine3.ToLower());
            _County = textInfo.ToTitleCase(_County.ToLower());
            _City = textInfo.ToTitleCase(_City.ToLower());
            _PostCode = textInfo.ToUpper(_PostCode.ToLower());

            if (_AddressLine3.ToLower() == _City.ToLower())
                _AddressLine3 = "";

            if (_County.ToLower() == _City.ToLower())
                _County = "";

            if (_AddressLine3.ToLower() == _AddressLine1.ToLower())
                _AddressLine3 = "";
        }

        /// <summary>
        /// Determines wether the address is valid or not
        /// </summary>
        /// <returns></returns>
        public bool ValidAddress()
        {
            bool Result = false;

            Result = !String.IsNullOrEmpty(_AddressLine1) && !String.IsNullOrEmpty(_City) && !String.IsNullOrEmpty(_PostCode);

            return (Result);
        }

        /// <summary>
        /// Create's a unique voucher for this user 
        /// </summary>
        /// <param name="value">Voucher value</param>
        /// <param name="expires">Date/Time expires</param>
        /// <returns>string - voucher code</returns>
        public string CreateUniqueVoucher(double value, DateTime expires)
        {
            return (String.Empty);
        }

        /// <summary>
        /// Determine if user name contains string values
        /// </summary>
        /// <param name="values">array of strings</param>
        /// <returns>true if username contains any part of the strings, otherwise false</returns>
        public bool NameContains(string firstName, string lastName)
        {
            bool Result = false;

            firstName = firstName.ToLower().Trim();
            lastName = lastName.ToLower().Trim();

            //Result = ((!String.IsNullOrEmpty(firstName) && UserName.ToLower().Contains(firstName.Trim()) && 
            //    (!String.IsNullOrEmpty(lastName) && UserName.ToLower().Contains(lastName))));

            if (firstName == lastName)
                Result = (_FirstName.ToLower().Contains(firstName.Trim()) ||
                (_LastName.ToLower().Contains(lastName)));
            else
                Result = (_FirstName.ToLower().Contains(firstName.Trim()) &&
                    (_LastName.ToLower().Contains(lastName)));

            return (Result);
        }

        public bool SendPasswordEmail()
        {
            bool Result = false;

            if (Shared.Utilities.IsValidEmail(Email))
            {
                string MailMessage = String.Format("Hi {0}<br />" +
                    "<br /><br />Your User Name and Password are:<br /><br />--------------------------------" +
                    "<br />Username: {1}<br />Password: {2}<br />--------------------------------<br /><br />" +
                    "To login to the members area visit {3}/Members/Login.aspx" +
                    "<br /><br />Thanks", FirstName,
                    Email, Password, Library.DAL.DALHelper.WebsiteAddress);

                DAL.FirebirdDB.AdminEmailMassAdd(UserName, Email, "No reply", "noreply@sieradelta.com",
                    "Login Details", MailMessage, DateTime.Now);
                Result = true;
            }

            return (Result);
        }

        /// <summary>
        /// Retrieves the clients managed by the user (staff member only)
        /// </summary>
        /// <returns></returns>
        public Clients GetTradeClients()
        {
            return (DAL.FirebirdDB.TradeClientManagerClients(this));
        }

        #endregion Public Methods

        #region Static Methods

        public static User SystemUser()
        {
            User Result = null;

            Result = DAL.FirebirdDB.UserGetSystemUser();

            if (Result == null)
            {
                Result = DAL.FirebirdDB.UserCreateAccount("System", "User", "000000000000", "System_User", "asllsddkfj",
                    "asllsddkfj", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty,
                    0, false, false, false, Enums.UserRecordType.Default, DateTime.Now, "Default System User");
                Result.MemberLevel = MemberLevel.System;
                Result.Save();
            }

            return (Result);
        }

        /// <summary>
        /// Returns a collection of users who's birthday falls within the current month
        /// </summary>
        /// <returns>Users collection</returns>
        public static Users GetBirthdayList(string currenLocation, int month, int radius)
        {
            return (DAL.FirebirdDB.UserGetBirthdays(currenLocation, month, radius));
        }

        public static User UserFindByBarcode(string barcode)
        {
            return (DAL.FirebirdDB.UserGetByBarcode(barcode));
        }

        public static User UserGet(Int64 UserID)
        {
            return (DAL.FirebirdDB.UserGet(UserID));
        }

        public static User UserGet(string Email)
        {
            return (DAL.FirebirdDB.UserGet(Email.Trim()));
        }

        public static User UserGet(string Email, string Password)
        {
            if (String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
                return (null);

            return (DAL.FirebirdDB.UserGet(Email.Trim(), Password.Trim()));
        }

        public static Users UserSearch(string FirstName, string LastName, string Email)
        {
            return (DAL.FirebirdDB.UserSearch(FirstName.Trim(), LastName.Trim(), Email.Trim()));
        }

        public static Users UserSearch(string FirstName, string LastName, string Email, string telephone, int MaxRecords)
        {
            return (DAL.FirebirdDB.UserSearch(FirstName.Trim(), LastName.Trim(), Email.Trim(), telephone.Trim(), MaxRecords));
        }

        public static User UserCreateAccount(string FirstName, string Surname, string Telephone, string EMail, string Password,
            string ConfirmPassword, string CompanyName, string Address1, string Address2, string Address3,
            string City, string County, string PostCode, int Country, bool OffersTelephone, bool OffersEmail, bool OffersPostal,
            Enums.UserRecordType RecordType, DateTime BirthDate, string Notes)
        {
            User Result = DAL.FirebirdDB.UserCreateAccount(FirstName, Surname, Telephone, EMail, Password, ConfirmPassword,
                CompanyName, Address1, Address2, Address3, City, County, PostCode, Country, OffersTelephone, OffersEmail, OffersPostal, RecordType,
                BirthDate, Notes);

            //Add delivery address
            Result.DeliveryAddresses.Create(Result);

            Hooks.Hooks.HookNotification(HookEvent.UserAccountCreated,
                String.Format("User Name: {0} {1}; Email: {2}", FirstName, Surname, EMail));

            return (Result);
        }

        public static bool UserLogUserOn(User user)
        {
            return (DAL.FirebirdDB.UserLogUserOn(user));
        }

        /// <summary>
        /// Returns all members of staff
        /// </summary>
        /// <param name="forceRefresh">Does not use cache if set to true</param>
        /// <returns>Users collection</returns>
        public static Users StaffMembers(bool forceRefresh)
        {
            const string STAFF_CACHE = "Staff Member Cache";

            Shared.Classes.CacheItem staff = DAL.DALHelper.InternalCache.Get(STAFF_CACHE);

            if (forceRefresh || staff == null)
            {
                staff = new Shared.Classes.CacheItem(STAFF_CACHE, DAL.FirebirdDB.UserGet());
                DAL.DALHelper.InternalCache.Add(STAFF_CACHE, staff, true);
            }

            return ((Users)staff.Value);
        }

        /// <summary>
        /// Returns all salon owners and distributors
        /// </summary>
        /// <returns>Users Collection</returns>
        public static Users SalonOwners()
        {
            return (DAL.FirebirdDB.UserGetSalonOwners());
        }

        #endregion Static Methods

        #region Internal Methods

        internal void ClearCard()
        {
            _cardDetails = null;
        }

        internal void InvoicesSet(Invoices.Invoices Value)
        {
            throw new NotImplementedException();
        }

        internal void CountrySet(Country Value)
        {
            _Country = Value;
        }

        #endregion Internal Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("User: {0}; Username: {1}", ID, UserName));
        }

        #endregion Overridden Methods

    }
}