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
 *  File: SecurityEnums.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace SharedBase
{
    public sealed class SecurityEnums
    {
        [Flags]
        public enum SecurityPermissionsStaff
        {
            /// <summary>
            /// User can grant leave to people under them
            /// </summary>
            ApproveLeave = 1,

            /// <summary>
            /// User can authorise leave to people under them
            /// </summary>
            AuthoriseLeave = 2,

            /// <summary>
            /// User can grant all leave, regardless of heirarchy
            /// </summary>
            ApproveAllLeave = 4,

            /// <summary>
            /// User can authorise all leave, regardless of heirarchy
            /// </summary>
            AuthoriseAllLeave = 8,

            /// <summary>
            /// Add Leave Requests for any staff Member
            /// </summary>
            AddLeaveForAllStaff = 16,

            /// <summary>
            /// Allow staff to book annual leave, even if it's over the quota for the staff member
            /// </summary>
            AllowToBookOverQuota = 32,

            /// <summary>
            /// View Staff Sickness Records
            /// </summary>
            ViewSicknessRecords = 64,

            /// <summary>
            /// View personal Details
            /// </summary>
            ViewPersonalDetails = 128,

            /// <summary>
            /// View Employment Details
            /// </summary>
            ViewEmploymentDetails = 256,

            /// <summary>
            /// View Holiday Details
            /// </summary>
            ViewHolidayDetails = 512,

            /// <summary>
            /// View Emergency Contact Details
            /// </summary>
            ViewEmergencyContactDetails = 1024,

            /// <summary>
            /// View Driving Licence Details
            /// </summary>
            ViewDrivingLicenceDetails = 2048,

            /// <summary>
            /// View Staff Contact Detail
            /// </summary>
            ViewContactDetails = 4096,

            /// <summary>
            /// Create New Staff Members
            /// </summary>
            CreateNewStaffMember = 8192,

            /// <summary>
            /// Remove Members of Staff
            /// </summary>
            RemoveStaffMembers = 16384,

            /// <summary>
            /// Users with this permission can only manage their own staff
            /// </summary>
            ManageOwnStaffOnly = 32768,

            /// <summary>
            /// User can cancel any other users leave
            /// </summary>
            CancelAllLeave = 65536,

            /// <summary>
            /// View Commission Details
            /// </summary>
            ViewCommissionDetails = 131072,

            /// <summary>
            /// User has rights to view/manage commission pools
            /// </summary>
            ManageCommissionPools = 262144,

            /// <summary>
            /// User has rights to make bonus payments
            /// </summary>
            BonusPayments = 524288,

            /// <summary>
            /// View Clients Tab
            /// </summary>
            ViewClients = 1048576,

            /// <summary>
            /// User can manage client commission
            /// </summary>
            ManageClientCommission = 2097152,

            /// <summary>
            /// Use can book staff off sick
            /// </summary>
            BookStaffOffSick = 4194304,

            /// <summary>
            /// Staff member can approve expenses
            /// </summary>
            ApproveExpenses = 8388608,

            /// <summary>
            /// User can edit expenses
            /// </summary>
            EditExpenses = 16777216
        }

        [Flags]
        public enum SecurityPermissionsCalendar
        {
            EditTreatments = 1,
            AdvancedSettings = 2,
            NewAppointments = 4,
            EditEmployee = 8,
            ChangeWorkingHours = 16,
            AddAllDayEvent = 32,
            ViewAppointmentHistory = 64,
            CreateConfirmed = 128,
            TakePayment = 256,
            ViewReports = 512,
            ResizeTreatments = 1024,
            ManageBookings = 2048,
            ShowDebugInformation = 4096,
            ChangeGroups = 8192,
            ViewAllLocations = 16384,
            ManageStaffTimeOff = 32768,
            CancelAppointments = 65536,
            LockAppointments = 131072,
            UnlockAnyAppointment = 262144,
            BypassCreditCard = 524288,

            /// <summary>
            /// User has access to the administration toolbar
            /// </summary>
            AdministrationToolbar = 1048576,


            NewSalonTreatments = 2097152,

            /// <summary>
            /// display cancelled by staff menu item
            /// </summary>
            CancelledByStaffMenu = 4194304,

            /// <summary>
            /// Allows users to view history
            /// </summary>
            ViewHistory = 8388608
        }

        [Flags]
        public enum SecurityPermissionsPOS : UInt64
        {
            //General
            AllowCreateNew = 1,
            AllowSave = 2,
            AllowDelete = 4,

            //Access
            AlterUserMemberLevel = 8,
            AlterUser = 16,
            SearchUsers = 32,
            ViewDiary = 64,
            ViewStockControl = 128,
            ViewOrderManager = 256,
            ViewTill = 512,
            ViewSupportTickets = 1024,


            //Coupons
            AdministerCoupons = 4096,

            /// <summary>
            /// Export Customers
            /// </summary>
            ExportCustomers = 8192,

            /// <summary>
            /// User is allowed to manage auto updates
            /// </summary>
            ManageAutoUpdates = 16384,

            /// <summary>
            /// User can manage affiliate settings
            /// </summary>
            ManageAffiliates = 32768,

            /// <summary>
            /// Assign security permissions
            /// </summary>
            AdministerAssignPermissions = 65536,

            /// <summary>
            /// Administer Salon treatments
            /// </summary>
            AdministerSalonTreatments = 131072,

            /// <summary>
            /// Administer Products
            /// </summary>
            AdministerProducts = 262144,

            /// <summary>
            /// Assign barcodes to products
            /// </summary>
            AssignBarcodes = 524288,

            /// <summary>
            /// User can manage training schedule
            /// </summary>
            ManageTrainingSchedule = 1048576,

            /// <summary>
            /// Administer Discount Coupons
            /// </summary>
            AdministerDiscountCoupons = 2097152,


            /// <summary>
            /// User can reset user password for normal users only
            /// </summary>
            ResetPassword = 4194304,

            /// <summary>
            /// View Invoice Manager
            /// </summary>
            ViewInvoiceManager = 8388608,

            /// <summary>
            /// Administer Staff Members
            /// </summary>
            AdministerStaffMembers = 16777216,

            /// <summary>
            /// Dispatch Orders
            /// </summary>
            DispatchOrders = 33554432,

            /// <summary>
            /// Merge Customer Records
            /// </summary>
            MergeCustomerRecords = 67108864,

            /// <summary>
            /// user can manage category types
            /// </summary>
            ManageCategoryTypes = 134217728,

            /// <summary>
            /// User has permission to edit system emails
            /// </summary>
            AdministerSystemEmails = 268435456,

            /// <summary>
            /// User can manage vouchers
            /// </summary>
            AdministerVoucherManagement = 536870912,

            /// <summary>
            /// User can manage images
            /// </summary>
            ManageImages = 1073741824,

            /// <summary>
            /// User can manage marketing
            /// </summary>
            ManageMarketing = 2147483648
        }

        [Flags]
        public enum SecurityPermissionsWebsite
        {
            /// <summary>
            /// User can Create New Salons
            /// </summary>
            CreateNewSalons = 1,

            /// <summary>
            /// User can create new products
            /// </summary>
            CreateNewProducts = 2,

            /// <summary>
            /// User can view online reports
            /// </summary>
            ViewOnlineReports = 4,

            /// <summary>
            /// User can manage hash tags on a page
            /// </summary>
            ManageHashTags = 8,

            /// <summary>
            /// User is allowed to save campaigns
            /// </summary>
            SaveCampaigns = 16,

            /// <summary>
            /// Manage FAQ's
            /// </summary>
            ManageFAQs = 32,

            /// <summary>
            /// Manage Meta Data
            /// </summary>
            MetaData = 64,

            /// <summary>
            /// Manage Tag Lines
            /// </summary>
            TagLines = 128,

            /// <summary>
            /// Manage Customer Comments
            /// </summary>
            ManageCustomerComments = 256,

            /// <summary>
            /// User can send mass email from website
            /// </summary>
            SendMassEmail = 512,

            /// <summary>
            /// User can send mass email to all salon owners
            /// </summary>
            SendMassEmailSalonOwners = 1024,

            /// <summary>
            /// User can send mass email to all users
            /// </summary>
            SendMassEmailAllUsers = 2048,

            /// <summary>
            /// User has permission to alter Website Options
            /// </summary>
            AlterWebsiteOptions = 4096,

            /// <summary>
            /// Allows a user to alter custom web pages
            /// </summary>
            ManageCustomPages = 8192,

            /// <summary>
            /// User has permission to alter Static Home Page Banners
            /// </summary>
            StaticHomePageBanners = 16384,

            /// <summary>
            /// User has permission to manage celebrities
            /// </summary>
            ManageCelebrities = 32768,

            /// <summary>
            /// User has permission to manage video's
            /// </summary>
            ManageVideos = 65536,


            AdministerTreatmentGroups = 131072,


            AdministerTipsTricks = 262144,

            //Admin Members
            AdministerSalonsView = 524288,

            AdministerSalonUpdates = 1048576,

            /// <summary>
            /// Administer Distributors
            /// </summary>
            AdministerDistributors = 2097152,

            /// <summary>
            /// Administer Treatments
            /// </summary>
            AdministerTreatments = 4194304,


            /// <summary>
            /// Administer Missing Links
            /// </summary>
            AdministerMissingLinks = 8388608,

            /// <summary>
            /// Administer Salon Owners
            /// </summary>
            AdministerSalonOwners = 16777216,

            /// <summary>
            /// User has permission to edit countries
            /// </summary>
            AdministerCountries = 33554432,

            /// <summary>
            /// User has permission to change the client type
            /// </summary>
            UpdateClientType = 67108864,

            /// <summary>
            /// User has permission to change the account manager
            /// </summary>
            UpdateAccountManager = 134217728,

            /// <summary>
            /// User has permission to administer websites and website settings
            /// </summary>
            AdministerWebsites = 268435456
        }

        [Flags]
        public enum SecurityPermissionsAccounts
        {
            /// <summary>
            /// User can view order manager
            /// </summary>
            ViewOrderManager = 1,

            /// <summary>
            /// User can view orders received
            /// </summary>
            ViewOrdersReceived = 2,

            /// <summary>
            /// User can issue a refund
            /// </summary>
            IssueRefund = 4,

            /// <summary>
            /// User can create an order
            /// </summary>
            CreateOrder = 8,

            /// <summary>
            /// User can export accounts data to SAGE
            /// </summary>
            ExportToSage = 16,

            /// <summary>
            /// User can cancel invoices
            /// </summary>
            CancelInvoices = 32,

            /// <summary>
            /// User can enter Cash Drawer Data
            /// </summary>
            CashDrawer = 64,

            /// <summary>
            /// User can change invoice date
            /// </summary>
            ChangeInvoiceDate = 128,

            /// <summary>
            /// User can view unpaid orders
            /// </summary>
            ViewUnpaidOrders = 256,

            /// <summary>
            /// User can change the sales person for the invoice
            /// </summary>
            ChangeSalesPerson = 512,


            ViewSuppliers = 1024,


            AddUpdateSuppliers = 2048
        }

        [Flags]
        public enum SecurityPermissionsReports
        {
            /// <summary>
            /// User can view Birthday List
            /// </summary>
            BirthdayList = 1,

            /// <summary>
            /// Reports specific to salons
            /// </summary>
            SalonReports = 2,

            /// <summary>
            /// User can create vouchers
            /// </summary>
            CreateVouchers = 4,

            /// <summary>
            /// Stock Control Reports
            /// </summary>
            StockReports = 8,

            /// <summary>
            /// Product Reports
            /// </summary>
            ProductReports = 16
        }

        [Flags]
        public enum SecurityPermissionsStockControl
        {
            /// <summary>
            /// User has permission to move stock in and out
            /// </summary>
            MoveStockInAndOut = 1,

            /// <summary>
            /// User can hide stock from all users within a site
            /// </summary>
            HideStockItemsGlobally = 2,

            /// <summary>
            /// User can create stock items
            /// </summary>
            CreateStock = 4,

            /// <summary>
            /// User can change in/out status of stock
            /// </summary>
            UpdateStockInOutStatus = 8,

            /// <summary>
            /// User is allowed to autmatically re-order stock
            /// </summary>
            AutoReOrderStock = 16
        }
    }
}
