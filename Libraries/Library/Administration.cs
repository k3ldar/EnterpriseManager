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
 *  File: Administration.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using Library.DAL;
using Library.BOL.Treatments;
using Library.BOL.Distributors;
using Library.BOL.Products;
using Library.BOL.Salons;
using Library.BOL.TipsTricks;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.BOL.Helpdesk;
using Library.BOL.MissingLinks;
using Library.BOL.Coupons;

namespace Library
{
    /// <summary>
    /// Administration contains methods that the website uses to interact with the administration functions
    /// </summary>
    public sealed class WebsiteAdministration
    {
        #region Private / Protected Members

        private User _user;

        #endregion Private / Protected Members

        #region Public Methods

        #region Stats

        public string GetCampaignStats(string Campaign)
        {
            return (FirebirdDB.GetCampaignStats(Campaign));
        }

        #endregion Stats

        #region Product Groups

        /// <summary>
        /// Returns all product groups
        /// </summary>
        /// <param name="primaryProductType">Primary Product Type</param>
        public ProductGroups ProductGroups(bool visibleOnWebsite = true)
        {
            return (FirebirdDB.ProductGroupsGet(_user.MemberLevel, visibleOnWebsite));
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        public Products ProductsGet()
        {
            return (FirebirdDB.AdminProductsGet());
        }

        public Products ProductsGet(ProductGroup Group, string ProductName)
        {
            return (FirebirdDB.AdminProductsGet(Group, ProductName));
        }


        public int ProductCount
        {
            get
            {
                return (FirebirdDB.AdminProductsCount());
            }
        }

        /// <summary>
        /// returns an individual product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public Product ProductGet(int ProductID)
        {
            return (FirebirdDB.ProductGet(ProductID));
        }

        public Products ProductsGet(int PageNumber, int PageSize)
        {
            return(FirebirdDB.AdminProductsGet(PageNumber, PageSize));
        }

        public Product ProductInsert(string productName, ProductType productType, ProductGroup group)
        {
            return (FirebirdDB.AdminProductInsert(productName, productType, group));
        }

        #endregion Product Groups

        #region Product Groups

        /// <summary>
        /// Returns a page of Product Groups ignores ShowOnWebsite status
        /// </summary>
        /// <param name="PageNumber">int - Current Page Number</param>
        /// <param name="PageSize">int - Current Page Size</param>
        /// <returns>ProductGroups collection</returns>
        public ProductGroups ProductGroupsGet(int PageNumber, int PageSize)
        {
            return(FirebirdDB.AdminProductGroupsGet(PageNumber, PageSize));
        }

        /// <summary>
        /// Determines the count of product groups
        /// </summary>
        /// <returns>int - Count of Product Groups</returns>
        public int ProductGroupsCount()
        {
            return (FirebirdDB.AdminProductGroupsCount());
        }

        public ProductGroup ProductGroupCreate(string Description, ProductGroupType productGroupType)
        {
            return (FirebirdDB.AdminProductGroupCreate(Description, productGroupType.ID));
        }

        public void ProductGroupDelete(ProductGroup productGroup)
        {
            FirebirdDB.AdminProductGroupDelete(productGroup);
        }

        public void ProductGroupUpdate(ProductGroup productGroup)
        {
            FirebirdDB.AdminProductGroupUpdate(productGroup);
        }

        public ProductGroup ProductGroupGet(int GroupID)
        {
            return (FirebirdDB.AdminProductGroupGet(GroupID));
        }

        #endregion Product Groups

        #region Product Costs

        public ProductCost ProductCostCreate(Product product, string productItemName, ProductCostType costType)
        {
            return (FirebirdDB.AdminProductCostCreate(product, productItemName, costType));
        }

        //public ProductCost ProductCostGet(int ProductCostID)
        //{
        //    return (FirebirdDB.AdminProductCostGet(ProductCostID));
        //}

        public void ProductCostDelete(ProductCost ProductCostSize)
        {
            FirebirdDB.AdminProductCostDelete(ProductCostSize);
        }

        public void ProductCostUpdate(ProductCost ProductCostSize)
        {
            FirebirdDB.AdminProductCostUpdate(ProductCostSize);
        }

        #endregion Product Costs

        #region Missing Links

        public MissingLink MissingLinkAdd(string DeprecatedLink, string ReplacementLink)
        {
            return (FirebirdDB.AdminMissingLinkAdd(DeprecatedLink, ReplacementLink));
        }

        public void MissingLinkUpdate(MissingLink missingLink)
        {
            FirebirdDB.AdminMissingLinkUpdate(missingLink);
        }

        public void MissingLinkDelete(MissingLink missingLink)
        {
            FirebirdDB.AdminMissingLinkDelete(missingLink);
        }

        public MissingLink MissingLinkGet(string DeprecatedLink)
        {
            return (FirebirdDB.AdminMissingLinkGet(DeprecatedLink));
        }

        public int MissingLinkCount()
        {
            return (FirebirdDB.AdminMissingLinkCount());
        }

        public MissingLinks MissingLinksGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminMissingLinksGet(PageNumber, PageSize));
        }

        #endregion Missing Links

        #region Helpdesk

        public SupportTicket HelpdeskSupportTicketGet(string TicketKey)
        {
            return (FirebirdDB.AdminHelpdeskSupportTicketGet(TicketKey));
        }

        public SupportTickets HelpdeskSupportTicketsGet(bool OnHold, bool Closed, bool Open)
        {
            return (FirebirdDB.AdminHelpdeskSupportTicketsGet(OnHold, Closed, Open));
        }

        public CustomerComment HelpdeskCustomerCommentGet(int CommentID)
        {
            return (FirebirdDB.AdminHelpdeskCustomerCommentGet(CommentID));
        }

        public CustomerComments HelpdeskCustomerCommentsGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminHelpdeskCustomerCommentsGet(PageNumber, PageSize));
        }

        public int HelpdeskCustomerCommentsCount()
        {
            return (FirebirdDB.AdminHelpdeskCustomerCommentsCount());
        }

        #endregion Helpdesk

        #region Products

        public int ProductsCount()
        {
            return (FirebirdDB.AdminProductsCount());
        }

        #endregion Products
 
        #region Admin Orders

        public Orders OrdersGet(int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses processStatuses)
        {
            return (FirebirdDB.AdminOrdersGet(UserID, InvoiceID, TodayOnly, processStatuses));
        }

        #endregion Admin Orders

        #region Tips and Tricks

        public int TipsTricksCount()
        {
            return (FirebirdDB.AdminTipsTricksCount());
        }

        public TipsTricks TipsTricksGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminTipsTricksGet(PageNumber, PageSize));
        }

        public TipsTrick TipsTricksGet(int TipTrickID)
        {
            return (FirebirdDB.AdminTipsTricksGet(TipTrickID));
        }

        public void TipsTricksUpdate(TipsTrick Tip)
        {
            FirebirdDB.AdminTipsTricksUpdate(Tip);
        }

        public void TipsTricksDelete(TipsTrick Tip)
        {
            FirebirdDB.AdminTipsTricksDelete(Tip);
        }

        public TipsTrick TipsTrickCreate(TipsTrick Tip)
        {
            return (FirebirdDB.AdminTipsTrickCreate(Tip));
        }

        #endregion Tips and Tricks

        #region Email

        public static Int64 EmailMassAdd(string ToName, string ToEMail, string FromName,
            string FromEMail, string Subject, string Message, DateTime SendDateTime)
        {
            return (FirebirdDB.AdminEmailMassAdd(ToName, ToEMail, FromName, FromEMail, Subject, Message, SendDateTime));
        }

        #endregion Email

        #region Users

        /// <summary>
        /// Returns the number of registered users.
        /// </summary>
        /// <returns></returns>
        public int UsersGetCount()
        {
            return (FirebirdDB.AdminUsersGetCount());
        }

        public Users UsersGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminUsersGet(PageNumber, PageSize));
        }

        /// <summary>
        /// Returns all users for a specific member level
        /// </summary>
        /// <param name="MemberLevel"></param>
        /// <returns></returns>
        public Users UsersGet(MemberLevel MemberLevel)
        {
            return (FirebirdDB.AdminUsersGet(MemberLevel));
        }

        public Users UsersGetMassEmail(bool AdminOnly)
        {
            return (FirebirdDB.AdminUsersGetMassEmail(AdminOnly));
        }

        public Users UsersGetMassEmail(bool AdminOnly, int ProductItem)
        {
            return (FirebirdDB.AdminUsersGetMassEmailProductItem(AdminOnly, ProductItem));
        }

        #endregion Users

        #region Stats

        public int StatsMailCount(Enums.MailCount Option)
        {
            return (FirebirdDB.AdminStatsMailCount(Option));
        }

        public int StatsComments()
        {
            return (FirebirdDB.AdminStatsComments());
        }

        public int StatsBannedIP()
        {
            return (FirebirdDB.AdminStatsBannedIP());
        }

        public int StatsAppointments(Enums.AppointmentStats Option)
        {
            return (FirebirdDB.AdminStatsAppointments(Option));
        }


        public string StatsDownloads()
        {
            return (FirebirdDB.AdminStatsDownloads());
        }


        public int StatsTickets(Enums.TicketStatus Option)
        {
            return (FirebirdDB.AdminStatsTickets(Option));
        }

        public int StatsSalonUpdates()
        {
            return (FirebirdDB.AdminStatsSalonUpdates());
        }

        public int StatsInvoices(InvoiceStatistics Option)
        {
            return (FirebirdDB.AdminStatsInvoices(Option));
        }


        public int StatsUserCount()
        {
            return (FirebirdDB.AdminStatsUserCount());
        }

        public int StatsLicenceCount()
        {
            return (FirebirdDB.AdminStatsLicenceCount());
        }

        #endregion Stats

        #region Treatments

        public Treatment TreatmentGet(int TreatmentID)
        {
            return (FirebirdDB.AdminTreatmentGet(TreatmentID));
        }


        public Treatment TreatmentCreate(Treatment treatment)
        {
            return (FirebirdDB.AdminTreatmentCreate(treatment));
        }


        #endregion Treatments

        #region  Salons

        /// <summary>
        /// Returns an individual Salon
        /// </summary>
        /// <param name="SalonID">ID of salon to return</param>
        /// <returns>Salon object</returns>
        public Salon SalonGet(int SalonID)
        {
            return (FirebirdDB.AdminSalonGet(SalonID));
        }


        /// <summary>
        /// Returns all salons
        /// </summary>
        /// <returns></returns>
        public Salons SalonsGet()
        {
            return (FirebirdDB.AdminSalonsGet());
        }

        /// <summary>
        /// Retrieves all salons which are not assigned to a salon owner
        /// </summary>
        /// <returns></returns>
        public Salons SalonsUnassigned()
        {
            return (FirebirdDB.AdminSalonsGetUnassigned());
        }

        public Salons SalonsGet(string SalonName)
        {
            return (FirebirdDB.AdminSalonsGet(SalonName));
        }

        /// <summary>
        /// Returns a page of salons
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public Salons SalonsGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminSalonsGet(PageNumber, PageSize));
        }


        /// <summary>
        /// Create a salon
        /// </summary>
        /// <param name="SalonName">name of salon</param>
        /// <returns>Salon object for newly created salon</returns>
        public Salon SalonCreate(string SalonName, Enums.SalonType SalonType)
        {
            return (FirebirdDB.AdminSalonCreate(SalonName, SalonType));
        }

        public int SalonCount()
        {
            return (FirebirdDB.AdminSalonCount());
        }

        #endregion Admin Salons

        #region Salon Owners

        public void SalonOwnerCreate(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerCreate(user, salon);
        }


        public void SalonOwnerDelete(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerDelete(user, salon);
        }

        public void SalonOwnerUpdateDelete(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateDelete(user, salon);
        }


        public void SalonOwnerUpdateMerge(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateMerge(user, salon);
        }


        public void SalonOwnerUpdateInsert(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateInsert(user, salon);
        }


        public Salon SalonOwnerUpdateGet(User user, Salon salon)
        {
            return (FirebirdDB.AdminSalonOwnerUpdateGet(user, salon));
        }

        public Users SalonOwnersGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminSalonOwnersGet(PageNumber, PageSize));
        }

        public int SalonOwnersCount()
        {
            return (FirebirdDB.AdminSalonOwnersCount());
        }

        public int SalonOwnersUpdateCount()
        {
            return (FirebirdDB.AdminSalonOwnersUpdateCount());
        }

        public Salons SalonUpdatesGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminSalonUpdatesGet(PageNumber, PageSize));
        }

        #endregion Salon Owners

        #region Distributors

        public Distributor DistributorGet(int DistributorID)
        {
            return (FirebirdDB.AdminDistributorGet(DistributorID));
        }

        public Distributors DistributorsGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminDistributorsGet(PageNumber, PageSize));
        }

        public void DistributorsDelete(Distributor distributor)
        {
            FirebirdDB.AdminDistributorsDelete(distributor);
        }

        public Distributor DistributorsCreate(string Name)
        {
            return (FirebirdDB.AdminDistributorsCreate(Name));
        }

        public void DistributorsUpdate(Distributor distributor)
        {
            FirebirdDB.AdminDistributorsUpdate(distributor);
        }

        #endregion Distributors

        #region Coupons

        public int CouponCount()
        {
            return (FirebirdDB.AdminCouponCount());
        }

        public Coupon CouponGet(int CouponID)
        {
            return (FirebirdDB.AdminCouponGet(CouponID));
        }

        public Coupons CouponsGet(int PageNumber, int PageSize)
        {
            return (FirebirdDB.AdminCouponsGet(PageNumber, PageSize));
        }

        public void CouponDelete(Coupon coupon)
        {
            FirebirdDB.AdminCouponDelete(coupon);
        }

        public Coupon CouponCreate(string Name)
        {
            return (FirebirdDB.AdminCouponCreate(Name));
        }

        public void CouponUpdate(Coupon coupon)
        {
            FirebirdDB.AdminCouponUpdate(coupon);
        }

        #endregion Coupons

        #endregion Public Methods

        #region Backup

        public static void BackupDatabase(string FileName)
        {
            FirebirdDB.BackupDatabase(FileName);
        }

        #endregion Backup

        #region Properties

        /// <summary>
        /// Returns the name of the local POS database
        /// </summary>
        public static string LocalDatabase
        {
            get
            {
                return (DALHelper.LocalDatabase);
            }
        }

        public static string DatabaseVersion
        {
            get
            {
                return (DALHelper.DatabaseVersion);
            }
        }

        public static bool DatabaseVersionCorrect
        {
            get
            {
                return (DALHelper.DatabaseVersionCorrect);
            }
        }

        public static int StoreID
        {
            get
            {
                return (DALHelper.StoreID);
            }
        }

        public static int TillID
        {
            get
            {
                return (DALHelper.TillID);
            }
        }

        public User user
        {
            get
            {
                return (_user);
            }
        }

        public static string Server
        {
            get
            {
                return (DAL.FirebirdDB.AdminDatabaseServer(false));
            }
        }


        #endregion Properties

        #region Constructors / Destructors

        public WebsiteAdministration(User user)
        {
            if (user.MemberLevel < MemberLevel.Distributor)
                throw new Exception(String.Format("Invalid Permission, Administration Users Only.  UserID: {0}", user.ID));

            _user = user;
        }

        #endregion Constructors / Destructors

        #region Static Methods

        /// <summary>
        /// Determines wether to autoban the IP address depending on the request
        /// </summary>
        /// <param name="path">Path user is searching for</param>
        /// <param name="ipAddress">IP Address of User</param>
        /// <param name="ForceBan">Forces the banning of the web page</param>
        /// <returns>true if ip address is banned</returns>
        public static bool AutoBanIPAddress(string path, string ipAddress, bool ForceBan = false)
        {
            return (FirebirdDB.AutoBanIPAddress(path, ipAddress, ForceBan));
        }

        public static void BanIPAddress(string ipAddress)
        {
            FirebirdDB.AutoBanIPAddress(ipAddress);
        }

        /// <summary>
        /// Executes routine maintenance
        /// </summary>
        /// <param name="campaigns">if true only campaign maintenance is executed, otherwise other routine maintenance is executed</param>
        public static void RoutineMaintenance(RoutineMaintenanceType maintenanceType)
        {
            FirebirdDB.ExecuteRoutineMaintenance(maintenanceType);
        }

        public static void LogHackAttempt(string ipAddress, string data, string location, DateTime created, DateTime lastEntry, ulong request, int results, string userAgent)
        {
            try
            {
                FirebirdDB.WebHackingConnection(ipAddress, data, request, created, lastEntry, results, location, userAgent);
            }
            catch (Exception err)
            {
                //ignore errors
                if (err.Message.Contains("hello"))
                { }
            }
        }

        #endregion Static Methods
    }
}
