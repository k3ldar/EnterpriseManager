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
 *  File: Database.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using System.Globalization;
using SharedBase.BOL.Users;

using Shared;
using Shared.Classes;

namespace SharedBase.DAL
{
#if INHERITED_DAL
    internal abstract class DatabaseBaseClass
    {
    #region Private Members

        /// <summary>
        /// Database connection string
        /// </summary>
        protected string[] _connectionString;
        internal string _roleName = String.Empty;
        protected User _User;

        /// <summary>
        /// If true, then the connection string will as provided will be used, 
        /// otherwise the connection string provided will be substituted for a
        /// standard build connection string
        /// </summary>
        protected bool StandardConnection = false;

    #endregion Private Members

#if DEBUG
    #region Debug Methods

        internal abstract void ThrowInternalError(string one, object two, int three, double four, object five);

    #endregion Debug Methods
#endif

    #region Constructors / Destructors

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ConnectionString">Connection string to be used</param>
        [Obsolete("temporary obsolete to see where it's used")]
        public DatabaseBaseClass(string connectionString, string failOverConnection, 
            string reportConnection, string seoConnection)
        {
            _connectionString[(int)DatabaseType.Standard] = connectionString;
            _connectionString[(int)DatabaseType.FailOver] = failOverConnection;
            _connectionString[(int)DatabaseType.Reports] = reportConnection;
            _connectionString[(int)DatabaseType.SeoData] = seoConnection;
        }


        /// <summary>
        /// constructor
        /// </summary>
        public DatabaseBaseClass()
        {
        }


    #endregion Constructors / Destructors

    #region Internal Methods

    #region Shared Connections

        /// <summary>
        /// Initialises a connection
        /// </summary>
        internal abstract void InitialiseConnection();

        /// <summary>
        /// Finalises a connection
        /// </summary>
        internal abstract void FinaliseConnection();

    #endregion Shared Connections

    #region Affiliated Sites

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="affiliateID"></param>
        /// <param name="imageSize"></param>
        /// <param name="website"></param>
        /// <returns></returns>
        internal abstract AffiliateProducts AffiliatedProductsGet(string countryCode, string affiliateID, int imageSize, string website);

        /// <summary>
        /// Saves a commission item to a member of staff's allocation
        /// </summary>
        /// <param name="authorisingUser"></param>
        /// <param name="splitCommission"></param>
        internal abstract void AffiliatedCommissionSave(User authorisingUser, PayAffiliateCommissionSettings commissionSettings, CommissionPaymentType paymentType);

        /// <summary>
        /// Retrieves commission for an invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal abstract AffiliateCommission AffiliatedCommissionGet(Invoice invoice);

        /// <summary>
        /// Retrieves commission for a date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        internal abstract AffiliateCommission AffiliatedCommissionGet(User user, DateTime from, DateTime to, bool isPaid, bool isNotPaid);

        /// <summary>
        /// Get Users who can earn commission on affiliation
        /// </summary>
        /// <returns></returns>
        internal abstract Users AffiliatedGetUsers();

        /// <summary>
        /// Returns the user for an affiliate ID
        /// </summary>
        /// <param name="affiliateID"></param>
        /// <returns></returns>
        internal abstract User AffiliatedUserGet(string affiliateID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        internal abstract void AffiliateCommissionUpdate(AffiliateCommissionItem item, User authorising, Library.CommissionPaymentType paymentType);

        /// <summary>
        /// Determines wether the affiliate id is unique or not
        /// </summary>
        /// <param name="affiliateID"></param>
        /// <returns></returns>
        internal abstract bool AffiliateIDIsUnique(AffiliatedItem affiliate, string affiliateID);

        /// <summary>
        /// Retrieves a list of affiliated sites for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal abstract AffiliatedItems AffiliatedSitesGet(User user);

        /// <summary>
        /// Gets the affiliated item for the website
        /// </summary>
        /// <param name="urlReferrer"></param>
        /// <returns></returns>
        internal abstract AffiliatedItem AffiliatedSiteGet(string urlReferrer);

        /// <summary>
        /// Creates an affiliated site
        /// </summary>
        /// <param name="affiliate"></param>
        internal abstract void AffiliatedSiteCreate(AffiliatedItem affiliate);

        /// <summary>
        /// Updates an affiliated site details
        /// </summary>
        /// <param name="affiliate"></param>
        internal abstract void AffiliatedSiteUpdate(AffiliatedItem affiliate);

        /// <summary>
        /// Deletes an affilaite site, delete is soft delete by turning active to false
        /// </summary>
        /// <param name="affiliate"></param>
        internal abstract void AffiliatedSiteDelete(AffiliatedItem affiliate);

        /// <summary>
        /// Adds a web click for an affiliate site
        /// </summary>
        /// <param name="affiliate"></param>
        /// <param name="?"></param>
        internal abstract void AffiliatedSiteWebClick(AffiliatedItem affiliate, string ipAddress);

    #endregion Affiliated Sites

    #region Auto Update

        /// <summary>
        /// Executes all user defined updates based on rules
        /// </summary>
        internal abstract int AutoUpdateExecute(AutoUpdateRule rule, bool testOnly);

        /// <summary>
        /// Returns an individual user defined auto update item
        /// </summary>
        /// <param name="id"></param>
        internal abstract AutoUpdate AutoUpdateGet(Int64 id);

        /// <summary>
        /// Retrieves all auto update items
        /// </summary>
        /// <returns></returns>
        internal abstract AutoUpdates AutoUpdateGet();

        /// <summary>
        /// Saves an auto update item
        /// </summary>
        /// <param name="autoUpdate"></param>
        internal abstract void AutoUpdateCreate(AutoUpdate autoUpdate);

        /// <summary>
        /// Deletes an auto update item
        /// </summary>
        /// <param name="autoUpdate"></param>
        internal abstract void AutoUpdateDelete(AutoUpdate autoUpdate);

    #endregion Auto Update

    #region Auto Update Rules

        /// <summary>
        /// Returns all the items for a rule
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        internal abstract AutoUpdateItems AutoUpdateItemsGet(AutoUpdateRule rule);

        /// <summary>
        /// Retrieves all auto update rules
        /// </summary>
        /// <returns></returns>
        internal abstract AutoUpdateRules AutoUpdateRulesGet();

        /// <summary>
        /// Updates a saved rule
        /// </summary>
        /// <param name="rule"></param>
        internal abstract void AutoUpdateRulesSave(AutoUpdateRule rule);

    #endregion Auto Update Rules

    #region Export / Import

        /// <summary>
        /// Returns import / export items for a specific table
        /// </summary>
        /// <returns></returns>
        internal abstract ExportableItems ImportExportGetConfig();

        /// <summary>
        /// Returns import / export items for a specific table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        internal abstract ExportableItems ImportExportGetConfig(string tableName);

    #endregion Export / Import

    #region Staff Commission

        /// <summary>
        /// Retrieves all paid commission for a member of staff
        /// </summary>
        /// <param name="staffMember"></param>
        /// <returns></returns>
        internal abstract PaidCommission StaffCommissionPaymentsGet(User staffMember);

        /// <summary>
        /// Retrieves commission for an invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal abstract StaffCommission StaffCommissionClientGet(Invoice invoice);

        /// <summary>
        /// Retrieves commission for a date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        internal abstract StaffCommission StaffCommissionClientGet(StaffMember staff, DateTime from, DateTime to, bool isPaid, bool isNotPaid);

        /// <summary>
        /// Rebuilds all statistics for a given date range on pool data
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="replace"></param>
        internal abstract void StaffCommissionRebuildClientData(DateTime dateFrom, DateTime dateTo, bool replace);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        internal abstract void StaffCommissionUpdate(StaffCommissionItem item, User authorising, Library.CommissionPaymentType paymentType);

        /// <summary>
        /// Retrieves commission for an invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        internal abstract StaffCommission StaffCommissionPoolGet(Invoice invoice);

        /// <summary>
        /// Retrieves commission for a date range
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="isPaid"></param>
        /// <param name="isNotPaid"></param>
        /// <returns></returns>
        internal abstract StaffCommission StaffCommissionPoolGet(CommissionPool pool, DateTime from, DateTime to, bool isPaid, bool isNotPaid);

        /// <summary>
        /// Rebuilds all statistics for a given date range on pool data
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="replace"></param>
        internal abstract void StaffCommissionRebuildPoolData(DateTime dateFrom, DateTime dateTo, bool replace);

        /// <summary>
        /// Saves a commission item to a member of staff's allocation
        /// </summary>
        /// <param name="authorisingUser"></param>
        /// <param name="splitCommission"></param>
        internal abstract void StaffCommissionSave(User authorisingUser, PayCommissionSettings commissionSettings, CommissionPaymentType paymentType);

    #endregion Staff Commission

    #region Staff Commission Pools

        /// <summary>
        /// Returns a collection of commission pools
        /// </summary>
        /// <returns>CommissionPools</returns>
        internal abstract CommissionPools StaffCommissionPoolsGet();

        /// <summary>
        /// Deletes a commission pool
        /// </summary>
        /// <param name="pool">pool to be deleted</param>
        internal abstract void StaffCommissionPoolsDelete(CommissionPool pool);

        /// <summary>
        /// Creates a new commission pool
        /// </summary>
        /// <param name="pool">pool to be created</param>
        internal abstract void StaffCommissionPoolCreate(CommissionPool pool);

        /// <summary>
        /// Saves an existing commission pool
        /// </summary>
        /// <param name="pool"></param>
        internal abstract void StaffCommissionPoolSave(CommissionPool pool);

    #endregion Staff Commission Pools

    #region Staff Members

        /// <summary>
        /// Gets the staff members manager
        /// </summary>
        /// <param name="user">User who's manager is requested</param>
        /// <returns>User object of manager, if there is one, otherwise null</returns>
        internal abstract User StaffMemberManagerGet(User staffMember);

        /// <summary>
        /// Sets the manager for a member of staff
        /// </summary>
        /// <param name="staffMember"></param>
        /// <param name="manager"></param>
        internal abstract void StaffMemberManagerSet(User staffMember, User manager);

        /// <summary>
        /// Removes the staff members manager
        /// </summary>
        /// <param name="staffMember">Member of staff</param>
        internal abstract void StaffMemberManagerRemove(User staffMember);

        /// <summary>
        /// Returns a collection of users that report to the manager
        /// </summary>
        /// <param name="manager"></param>
        /// <returns>Users collection</returns>
        internal abstract Users StaffMemberManagerSubStaff(StaffMember manager);

    #endregion Staff Members

    #region Internal StaffLeaveRequest methods

        /// <summary>
        /// Select individual record from  table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeaveRequest StaffLeaveRequestSelect(Int64 ID);

        /// <summary>
        /// Inserts an individual record into table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeaveRequest StaffLeaveRequestInsert(Int64 userID, DateTime dateRequested,
            DateTime dateFrom, DateTime dateTo, double totalTime, Int64 authorisedBy, Int64 grantedBy, string notes);

        /// <summary>
        /// Updates/Saves individual record in table STAFF_LEAVE
        /// </summary>
        internal abstract bool StaffLeaveRequestUpdate(StaffLeaveRequest item);

        /// <summary>
        /// Delete individual record from  table STAFF_LEAVE
        /// </summary>
        internal abstract bool StaffLeaveRequestDelete(StaffLeaveRequest item);

        /// <summary>
        /// Selects all records from table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeave StaffLeaveRequestSelectAll(User staffMember);

        /// <summary>
        /// Selects all records from table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeave StaffLeaveRequestSelectAllApproval();

        /// <summary>
        /// Selects all records from table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeave StaffLeaveRequestSelectAllAuthorisation();

        /// <summary>
        /// Returns the number of records from  table STAFF_LEAVE
        /// </summary>
        internal abstract int StaffLeaveRequestCount();

        /// <summary>
        /// Inserts or Updates a record within table STAFF_LEAVE
        /// </summary>
        internal abstract StaffLeaveRequest StaffLeaveRequestInsertUpdate(StaffLeaveRequest item);

    #endregion Internal StaffLeaveRequest methods

    #region Internal StaffMember methods

        /// <summary>
        /// Select individual record from  table STAFF_MEMBERS
        /// </summary>
        internal abstract StaffMember StaffMemberSelect(User staffMember);

        /// <summary>
        /// Updates/Saves individual record in table STAFF_MEMBERS
        /// </summary>
        internal abstract bool StaffMemberUpdate(StaffMember item);

        /// <summary>
        /// Delete individual record from  table STAFF_MEMBERS
        /// </summary>
        internal abstract bool StaffMemberDelete(StaffMember item);

        /// <summary>
        /// Selects all records from table STAFF_MEMBERS
        /// </summary>
        internal abstract StaffMembers StaffMemberSelectAll();

        /// <summary>
        /// Returns the number of records from  table STAFF_MEMBERS
        /// </summary>
        internal abstract int StaffMemberCount();

        /// <summary>
        /// Inserts or Updates a record within table STAFF_MEMBERS
        /// </summary>
        internal abstract StaffMember StaffMemberInsertUpdate(StaffMember item);

    #endregion Internal StaffMember methods

    #region Internal StaffSickRecord methods

        /// <summary>
        /// Select individual record from  table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract StaffSickRecord StaffSickRecordSelect(Int64 ID);

        /// <summary>
        /// Inserts an individual record into table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract StaffSickRecord StaffSickRecordInsert(Int64 userID, DateTime dateStarted, 
            DateTime dateFinished, DateTime dateNotified, string returnInterviewCompleted, 
            Int64 returnInterviewer, string notes, string reasonCited, string certificate, 
            string preBooked, Int64 properties);

        /// <summary>
        /// Updates/Saves individual record in table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract bool StaffSickRecordUpdate(StaffSickRecord item);

        /// <summary>
        /// Delete individual record from  table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract bool StaffSickRecordDelete(StaffSickRecord item);

        /// <summary>
        /// Selects all records from table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract StaffSickRecords StaffSickRecordSelectAll();

        /// <summary>
        /// Selects a page of records from table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract StaffSickRecords StaffSickRecordPage(int page, int pageSize);

        /// <summary>
        /// Returns the number of records from  table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract int StaffSickRecordCount();

        /// <summary>
        /// Inserts or Updates a record within table STAFF_SICK_RECORDS
        /// </summary>
        internal abstract StaffSickRecord StaffSickRecordInsertUpdate(StaffSickRecord item);

    #endregion Internal StaffSickRecord methods

    #region File Backups

        /// <summary>
        /// Get's the latest version of a backup file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        internal abstract BackupFile BackupFileGetLatest(string computerName, string path, string name, string extension);

        /// <summary>
        /// Saves a copy of a backup file
        /// </summary>
        /// <param name="file">file object to save</param>
        internal abstract void BackupFileSave(BackupFile file, string contents);

        /// <summary>
        /// Retrieves the contents of the backed up file
        /// </summary>
        /// <param name="file">BackupFile object</param>
        /// <returns>Base64 Encoded Contents of the file</returns>
        internal abstract string BackupFileGetContents(BackupFile file);

        /// <summary>
        /// Retrieves all previous versions of a file
        /// </summary>
        /// <param name="file">BackupFile object</param>
        /// <returns>Files collection of all previous versions</returns>
        internal abstract Files BackupFileGetVersions(BackupFile file);

    #endregion File Backups

    #region Module Documentation

    #region Internal ModuleClass methods

        /// <summary>
        /// Select individual record from  table MOD_CLASS
        /// </summary>
        internal abstract ModuleClass ModuleClassSelect(Int64 Id);

        /// <summary>
        /// select alll classes for a module
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        internal abstract ModuleClasses ModuleClassSelect(ModuleName module);

        /// <summary>
        /// Inserts an individual record into table MOD_CLASS
        /// </summary>
        internal abstract ModuleClass ModuleClassInsert(Int64 moduleId, bool isPrimary,
            string moduleNamespace, string name, string description, string exampleUsage);

            /// <summary>
        /// Updates/Saves individual record in table MOD_CLASS
        /// </summary>
        internal abstract bool ModuleClassUpdate(ModuleClass item);

        /// <summary>
        /// Delete individual record from  table MOD_CLASS
        /// </summary>
        internal abstract bool ModuleClassDelete(ModuleClass item);

        /// <summary>
        /// Selects all records from table MOD_CLASS
        /// </summary>
        internal abstract ModuleClasses ModuleClassSelectAll();

        /// <summary>
        /// Selects a page of records from table MOD_CLASS
        /// </summary>
        internal abstract ModuleClasses ModuleClassPage(int page, int pageSize);

        /// <summary>
        /// Returns the number of records from  table MOD_CLASS
        /// </summary>
        internal abstract int ModuleClassCount();

        /// <summary>
        /// Inserts or Updates a record within table MOD_CLASS
        /// </summary>
        internal abstract ModuleClass ModuleClassInsertUpdate(ModuleClass item);

    #endregion Internal Class methods

    #region Internal ClassMember methods

        /// <summary>
        /// Select individual record from  table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract ModuleMember ModuleClassMemberSelect(Int64 Id);

        /// <summary>
        /// Select individual record from  table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract ModuleMembers ModuleClassMemberSelect(ModuleClass moduleClass);

        /// <summary>
        /// Inserts an individual record into table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract ModuleMember ModuleClassMemberInsert(Int64 classId, 
            ModuleProperties memberProperties, string name, string description, 
            string exceptions, string exampleUsage, string returnValue,
            string returnValueDesc);

        /// <summary>
        /// Updates/Saves individual record in table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract bool ModuleClassMemberUpdate(ModuleMember item);

        /// <summary>
        /// Delete individual record from  table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract bool ModuleClassMemberDelete(ModuleMember item);

        /// <summary>
        /// Selects all records from table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract ModuleMembers ModuleClassMemberSelectAll();

        /// <summary>
        /// Selects a page of records from table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract ModuleMembers ModuleClassMemberPage(int page, int pageSize);

        /// <summary>
        /// Returns the number of records from  table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract int ModuleClassMemberCount();

        /// <summary>
        /// Inserts or Updates a record within table MOD_CLASS_MEMBER
        /// </summary>
        internal abstract void ModuleClassMemberInsertUpdate(ModuleMember item);

    #endregion Internal ModuleClassMember methods

    #region Internal ModuleClassMemberParameter methods

        /// <summary>
        /// Select individual record from  table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract ModuleParameter ModuleClassMemberParameterSelect(Int64 Id);

        internal abstract ModuleParameters ModuleClassMemberParameterSelect(ModuleMember member);

        /// <summary>
        /// Inserts an individual record into table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract ModuleParameter ModuleClassMemberParameterInsert(Int64 classMemberId, string name, ModuleProperties properties, int parameterType, string description, string paramType, string exampluUsage, string defaultValue, int sortOrder);

        /// <summary>
        /// Updates/Saves individual record in table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract bool ModuleClassMemberParameterUpdate(ModuleParameter item);

        /// <summary>
        /// Delete individual record from  table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract bool ModuleClassMemberParameterDelete(ModuleParameter item);

        /// <summary>
        /// Selects all records from table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract ModuleParameters ModuleClassMemberParameterSelectAll();

        /// <summary>
        /// Selects a page of records from table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract ModuleParameters ModuleClassMemberParameterPage(int page, int pageSize);

        /// <summary>
        /// Returns the number of records from  table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract int ModuleClassMemberParameterCount();

        /// <summary>
        /// Inserts or Updates a record within table MOD_CLASS_MEMBER_PARAMETERS
        /// </summary>
        internal abstract ModuleParameter ModuleClassMemberParameterInsertUpdate(ModuleParameter item);

    #endregion Internal ModuleClassMemberParameter methods

    #region Internal ModuleModule methods

        /// <summary>
        /// Select individual record from  table MOD_MODULE
        /// </summary>
        internal abstract ModuleName ModuleNameSelect(Int64 Id);

        /// <summary>
        /// Inserts an individual record into table MOD_MODULE
        /// </summary>
        internal abstract ModuleName ModuleNameInsert(string name, string description);

        /// <summary>
        /// Updates/Saves individual record in table MOD_MODULE
        /// </summary>
        internal abstract bool ModuleNameUpdate(ModuleName item);

        /// <summary>
        /// Delete individual record from  table MOD_MODULE
        /// </summary>
        internal abstract bool ModuleNameDelete(ModuleName item);

        /// <summary>
        /// Selects all records from table MOD_MODULE
        /// </summary>
        internal abstract ModuleNames ModuleNameSelectAll();

        /// <summary>
        /// Selects a page of records from table MOD_MODULE
        /// </summary>
        internal abstract ModuleNames ModuleNamePage(int page, int pageSize);

        /// <summary>
        /// Returns the number of records from  table MOD_MODULE
        /// </summary>
        internal abstract int ModuleNameCount();

        /// <summary>
        /// Inserts or Updates a record within table MOD_MODULE
        /// </summary>
        internal abstract ModuleName ModuleNameInsertUpdate(ModuleName item);

    #endregion Internal Module methods



    #endregion Module Documentation

    #region Internal Seo methods

        /// <summary>
        /// Saves a page session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="page"></param>
        internal abstract void SeoSessionSavePage(UserSession session, PageViewData page);

        /// <summary>
        /// Retrieves a user session from the database
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns></returns>
        internal abstract UserSession SeoSessionRetrieve(string sessionID);

        /// <summary>
        /// Inserts an individual record into table SEO_DATA
        /// </summary>
        internal abstract void SeoSessionInsertUpdate(UserSession session);

        /// <summary>
        /// Hourly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsHourly();

        /// <summary>
        /// Daily SEO Reports
        /// </summary>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsDaily();

        /// <summary>
        /// Weekly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsWeekly();

        /// <summary>
        /// Monthly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsMonthly();

        /// <summary>
        /// Visits monthly by country
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsMonthlyVisitsByCountry(int year, int month);

        /// <summary>
        /// Visits month by city
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsMonthlyVisitsByCity(int year, int month);

        /// <summary>
        /// Sales monthly by country
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsMonthlySalesByCountry(int year, int month);

        /// <summary>
        /// Sales monthly by city
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsMonthlySalesByCity(int year, int month);

        /// <summary>
        /// Campaign Stats
        /// </summary>
        /// <param name="campaign"></param>
        /// <returns></returns>
        internal abstract SeoReports SeoReportsCampaign(Campaign campaign);

    #endregion Internal Seo methods

    #region Internal Ipcity methods

        /// <summary>
        /// Select individual record from  table WD$IPCITY
        /// </summary>
        internal abstract IPCity IPCitySelect(string ipAddress);

        /// <summary>
        /// Get the nearest 20 cities to the coordinates
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="country"></param>
        /// <returns>List<IPCity></returns>
        internal abstract List<IPCity> IPCitySelect(decimal latitude, decimal longitude, string country);

    #endregion Internal Ipcity methods

    #region WebDefender

        /// <summary>
        /// Gets details of banned ip addresses 
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics WebDefenderCurrentlyBanned();

        /// <summary>
        /// Get's statistics for WebDefender
        /// </summary>
        /// <param name="currentlyBanned"></param>
        /// <param name="previouslyBanned"></param>
        internal abstract void WebDefenderStats(ref Int64 currentlyBanned, ref Int64 previouslyBanned);
                /// <summary>
        /// Adds an address to the banned list
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        internal abstract bool WebDefenderAddressAdd(BOL.IPAddresses.IPAddress address);

        /// <summary>
        /// Removes an address from the banned list
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        internal abstract bool WebDefenderAddressRemove(BOL.IPAddresses.IPAddress address);

        /// <summary>
        /// Returns all active addresses
        /// 
        /// these are both banned and fixed ip addresses
        /// </summary>
        /// <returns></returns>
        internal abstract IPAddresses WebDefenderAddressGet();

        /// <summary>
        /// Retrieves a list of inactive Addresses
        /// 
        /// These are addresses that have been banned previously but no longer active
        /// </summary>
        /// <returns></returns>
        internal abstract IPAddresses WebDefenderAddressGetInactive();

        /// <summary>
        /// Retrieves a list of addresses for an address type
        /// </summary>
        /// <param name="type">Address type to search</param>
        /// <returns>AddressList collection</returns>
        internal abstract IPAddresses WebDefenderAddressGet(AddressType type, bool active, bool inactive);

        /// <summary>
        /// Retrieves an Address based on it's ID
        /// </summary>
        /// <param name="id">ID of Address to retrieve</param>
        /// <returns>Address object</returns>
        internal abstract BOL.IPAddresses.IPAddress WebDefenderAddressGet(Int64 id);

        /// <summary>
        /// Returns the number of bans for an IP address
        /// </summary>
        /// <param name="ipAddress">IP Address to be checked</param>
        /// <returns>number of previous ban's</returns>
        internal abstract int WebDefenderAddressNumberOfBans(string ipAddress);

        /// <summary>
        /// Returns a list of details about an IP Address
        /// </summary>
        /// <param name="ipAddress">IP Address to be checked</param>
        /// <returns>AddressList collection</returns>
        internal abstract IPAddresses WebDefenderAddressHistory(string ipAddress);

        /// <summary>
        /// Returns a collection of ip addresses which are currently banned
        /// </summary>
        /// <returns></returns>
        internal abstract IPAddresses WebDefenderAddressesBanned(DateTimeOffset fromDate, Int64 maximumID);

    #endregion WebDefender

    #region WaitingList Methods

        /// <summary>
        /// Select individual record from  table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract WaitingList WaitingListSelect(Int64 ID);


        /// <summary>
        /// Updates/Saves individual record in table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract bool WaitingListUpdate(WaitingList item);

        /// <summary>
        /// Delete individual record from  table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract bool WaitingListDelete(WaitingList item);

        /// <summary>
        /// Selects all records from table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract WaitingLists WaitingListSelectAll();

        /// <summary>
        /// Selects a page of records from table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract WaitingLists WaitingListPage(int page, int pageSize);


        /// <summary>
        /// Returns the number of records from  table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract int WaitingListCount();


        /// <summary>
        /// Inserts or Updates a record within table WS_APPOINTMENT_WAIT_LIST_LONG
        /// </summary>
        internal abstract WaitingList WaitingListInsertUpdate(WaitingList item);

    #endregion WaitingList Methods

    #region Currencies

        /// <summary>
        /// Get's an individual currency code
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        internal abstract Currency CurrenciesGetCurrency(string currencyCode);

        /// <summary>
        /// Retrieves a currency based on the culture
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        internal abstract Currency CurrenciesGetCulture(CultureInfo culture);

        /// <summary>
        /// Retrieves all currencies
        /// </summary>
        /// <returns></returns>
        internal abstract Currencies CurrenciesGetAll();

    #endregion Currencies

    #region Licences

        /// <summary>
        /// Validates a licence
        /// </summary>
        /// <param name="licenceID">ID of licence</param>
        /// <param name="domain">Domain/IP Address linked to</param>
        /// <param name="licenceType">Type of Licence</param>
        /// <returns>True if valid, otherwise false</returns>
        internal abstract bool LicenceValid(Int64 licenceID, string domain, int licenceType);

        /// <summary>
        /// Returns the number of licences for a user
        /// </summary>
        /// <param name="user">User who's licences are sought</param>
        /// <returns>int, total number of licences</returns>
        internal abstract int LicenceCount(User user);

        /// <summary>
        /// Retrieves all licences for a user
        /// </summary>
        /// <param name="user">User who's licences are sought</param>
        /// <returns>Licences collection</returns>
        internal abstract Licences LicenceGet(User user);

        /// <summary>
        /// Saves changes to a licence
        /// </summary>
        /// <param name="licence">Licence to save</param>
        internal abstract void LicenceSave(Licence licence);

        /// <summary>
        /// Create a Licence
        /// </summary>
        /// <param name="licence">Licence to create</param>
        /// <param name="user">User who owns the licence</param>
        internal abstract void LicenceCreateTrial(LicenceType licenceType, User user);

    #endregion Licences

    #region Cash Denominations

        /// <summary>
        /// Retrieves all currency denominations for a country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        internal abstract CashDenominations CashDenominationsGet(Country country);

    #endregion Cash Denominations

    #region Mail Lists

        /// <summary>
        /// Returns a collection of subscribers
        /// </summary>
        /// <returns></returns>
        internal abstract Dictionary<string, string> MailListSubscribers();

        /// <summary>
        /// Method for user to subscribe to mail list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        internal abstract void MailListSubscribe(string name, string email);

        /// <summary>
        /// Method for user to unsubscribe from email list
        /// </summary>
        /// <param name="email"></param>
        /// <param name="reason"></param>
        internal abstract bool MailListUnsubscribe(string email, string reason);

    #endregion Mail Lists

    #region Validation Checks

        internal abstract void ValidationCheckAdd(User user, ValidationReasons checkType, string reason);

    #endregion Validation Checks

    #region Payment Statuses

        /// <summary>
        /// Returns a collection of payment statuses
        /// </summary>
        /// <returns>PaymentStatuses collection</returns>
        internal abstract PaymentStatuses PaymentStatusesGet();

    #endregion Payment Statuses

    #region Custom Web Pages

        internal abstract void CreateCustomPages();

        /// <summary>
        /// Retrieves a collection of custom pages
        /// </summary>
        /// <returns></returns>
        internal abstract CustomPages CustomPagesGet(int websiteID);

        /// <summary>
        /// Updates a custom web page
        /// </summary>
        /// <param name="page"></param>
        internal abstract void CustomPageUpdate(CustomPage page);

        /// <summary>
        /// Retrieves a custom page
        /// </summary>
        /// <param name="title">Title of page</param>
        /// <param name="countryCode">Country of page to return</param>
        /// <returns></returns>
        internal abstract CustomPage CustomPageGet(string title, Country country, CustomPagesType pageType, int webSiteID);

        /// <summary>
        /// Retrieves custom translated data for a product
        /// </summary>
        /// <param name="country"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        internal abstract CustomPage CustomPageGet(Country country, Product product, CustomPagesType pageType);

    #endregion Custom Web Pages

    #region System Emails

        /// <summary>
        /// Saves a system Email
        /// </summary>
        /// <param name="email"></param>
        internal abstract void SystemEmailSave(SystemEmail email);

        /// <summary>
        /// Returns a collection of System Emails
        /// </summary>
        /// <returns>System Emails collection</returns>
        internal abstract SystemEmails SystemEmailGet();

    #endregion System Eails

    #region Notifications

        /// <summary>
        /// Adds a new notification
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        internal abstract void ProductNotificationAdd(ProductCost item, string email);

        /// <summary>
        /// Removes a notification for a user
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        internal abstract void ProductNotificationRemove(ProductCost item, string email);

        /// <summary>
        /// Determines whether a notification exists
        /// </summary>
        /// <param name="item">Product Cost Item which is out of stock</param>
        /// <param name="email">Email of user who wants notifications</param>
        /// <returns>true if the notification exists, otherwise false</returns>
        internal abstract bool ProductNotificationExists(ProductCost item, string email);

    #endregion Notifications

    #region Website Distributors

        /// <summary>
        /// Returnes a collection of countries for distributors
        /// </summary>
        /// <returns>Countries collection</returns>
        internal abstract WebsiteDistributors WebsiteDistributorsGet();

    #endregion Website Distributors

    #region POS Installer

        /// <summary>
        /// Install a client or server instance of the POS
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="computerName"></param>
        /// <param name="serverName"></param>
        /// <returns></returns>
        internal abstract POSInstall POSInstallerAdd(string email, string password, string computerName, string serverName, string installType);

        /// <summary>
        /// Returns a list of servers for the user
        /// </summary>
        /// <param name="email">users email</param>
        /// <param name="password">users password</param>
        /// <returns>delimeted list of servers</returns>
        internal abstract POSInstall POSInstallerServers(string email, string password);


        /// <summary>
        /// Determines wether the install is valid or not
        /// </summary>
        /// <param name="storeID">Store to be validated</param>
        /// <returns>true if valid, otherwise false</returns>
        internal abstract bool POSInstallValid(string storeID);

    #endregion POS Installer

    #region Competition Registration

        /// <summary>
        /// Registers a user for a competition
        /// </summary>
        /// <param name="firstName">Users first name</param>
        /// <param name="lastName">Users last name</param>
        /// <param name="email">Users email address</param>
        /// <param name="dateOfBirth">Users Date of Birth (optional)</param>
        /// <param name="receiveUpdates">Indicates wether the user will receive email updates</param>
        /// <param name="country">Users Country</param>
        /// <param name="campaign">Campaign user is registering for</param>
        internal abstract void RegisterUserForCompetition(string firstName, string lastName, string email, string password,
            DateTime dateOfBirth, bool receiveUpdates, Country country, Campaign campaign);

    #endregion Competition Registration

    #region TagLines

        /// <summary>
        /// Retrieves a collection of TagLines
        /// </summary>
        /// <returns>TagLines collection</returns>
        internal abstract TagLines TagLinesGet();

        /// <summary>
        /// Creates a new tag line
        /// </summary>
        /// <param name="text">Tag line text</param>
        /// <returns>TagLine object</returns>
        internal abstract TagLine TagLineCreate(string text);

        /// <summary>
        /// Delete's a TagLine
        /// </summary>
        /// <param name="tagLine">TagLine to be deleted</param>
        internal abstract void TagLineDelete(TagLine tagLine);

        /// <summary>
        /// Save's a TagLine object
        /// </summary>
        /// <param name="tagLine"></param>
        internal abstract void TagLineSave(TagLine tagLine);

    #endregion TagLines

    #region Searching

        /// <summary>
        /// Searches the database
        /// </summary>
        /// <param name="memberLevel">Member level of user completing the search</param>
        /// <param name="terms">Search Terms
        /// 
        /// Individual words seerated by a space</param>
        /// <param name="useAND">if true values are AND together ortherwise OR together</param>
        /// <returns>Search collection</returns>
        internal abstract Search SearchSubmit(MemberLevel memberLevel, string terms, bool useAND);

    #endregion Searching

    #region Training Courses

        /// <summary>
        /// Saves changes to a training course
        /// </summary>
        /// <param name="course">Course to be saved</param>
        internal abstract void TrainingCourseSave(Course course);

        /// <summary>
        /// Retrieves the salons attending a course
        /// </summary>
        /// <param name="course">course</param>
        /// <returns>Attendees collection</returns>
        internal abstract Attendees TrainingCourseAttendeesGet(Course course);

        /// <summary>
        /// Returns an individual training course
        /// </summary>
        /// <param name="id">ID of training course</param>
        /// <returns>TrainingCourse object</returns>
        internal abstract TrainingCourse TrainingCourseGet(int id);

        /// <summary>
        /// Returns a collection of Training Courses
        /// </summary>
        /// <returns>TrainingCourses collection</returns>
        internal abstract TrainingCourses TrainingCourseGet();

        /// <summary>
        /// Retrieves a collection of training courses
        /// </summary>
        /// <returns>Courses collection</returns>
        internal abstract Courses TrainingCoursesGet();

        /// <summary>
        /// Retrieves an actual training Course
        /// </summary>
        /// <param name="id">ID of training course to retrieve</param>
        /// <returns>Course</returns>
        internal abstract Course TrainingCoursesGet(Int64 id);

        /// <summary>
        /// Create a training Course for an appointment
        /// </summary>
        /// <param name="appointment">Appointment Course being created for</param>
        /// <param name="course">Training Course the appointment is for</param>
        /// <returns>Course object</returns>
        internal abstract Course TrainingCoursesCreate(Appointment appointment, TrainingCourse course, Therapist trainer);

    #endregion Training Courses

    #region Store Locations

        internal abstract void UpdateCurrentLocation(int storeID);

        /// <summary>
        /// Returns a collection of Store Locations
        /// </summary>
        /// <returns>Locations object</returns>
        internal abstract Locations StoreLocationsGet();

        /// <summary>
        /// Retrieves an individual store location based on the ID
        /// </summary>
        /// <param name="id">ID of store location to retrieve</param>
        /// <returns>StoreLocation object</returns>
        internal abstract StoreLocation StoreLocationGet(int id);

    #endregion Store Locations

    #region Split Payments

        /// <summary>
        /// Adds a split payment entry into the database
        /// </summary>
        /// <param name="order">order to which payment applies</param>
        /// <param name="cash">total cash</param>
        /// <param name="cheque">total cheque</param>
        /// <param name="card">total card</param>
        /// <param name="vouchers">total voucher</param>
        internal abstract void SplitPaymentAdd(Order order, decimal cash, decimal cheque, decimal card, decimal vouchers);

    #endregion Split Payments

    #region Web Hacking Attempts

        internal abstract void WebHackingConnection(string ipAddress, string data, ulong request, DateTime created, DateTime lastEntry, int results, string location, string userAgent);

    #endregion Web Hacking Attempts

    #region Cash Drawer

        /// <summary>
        /// Submit a cash draw check
        /// </summary>
        /// <param name="user"></param>
        /// <param name="CheckType"></param>
        /// <param name="Pound500"></param>
        /// <param name="Pound100"></param>
        /// <param name="Pound50"></param>
        /// <param name="Pound20"></param>
        /// <param name="Pound10"></param>
        /// <param name="Pound5"></param>
        /// <param name="Pound2"></param>
        /// <param name="Pound1"></param>
        /// <param name="Pence50"></param>
        /// <param name="Pence20"></param>
        /// <param name="Pence10"></param>
        /// <param name="Pence5"></param>
        /// <param name="Pence2"></param>
        /// <param name="Pence1"></param>
        internal abstract void CashDrawerSubmit(User user, string checkType, CashDrawerType type, string notes, 
            int Pound500, int Pound100, int Pound50, int Pound20, int Pound10, int Pound5, int Pound2, 
            int Pound1, int Pence50, int Pence20, int Pence10, int Pence5, int Pence2, int Pence1);

        /// <summary>
        /// Indicates wether the start of day cash drawer check has been completed or not
        /// </summary>
        /// <returns></returns>
        internal abstract bool CashDrawerDailyStartComplete(CashDrawerType type);

        /// <summary>
        /// Determines if a check was made in the last 10 minutes or not
        /// </summary>
        /// <returns></returns>
        internal abstract bool CashDrawer10MinuteCheck();

        /// <summary>
        /// Returns stats for today's cash drawer
        /// </summary>
        /// <returns></returns>
        internal abstract string CashDrawerVerify(int storeID, Country country,
            Currency currency, DateTime date, CashDrawerType type);

    #endregion Cash Drawer

    #region Hash Tags

        /// <summary>
        /// Returns all tags associated with a page
        /// </summary>
        /// <param name="PageName">Name of Page</param>
        /// <returns>hash Tags Collection</returns>
        internal abstract HashTags HashTagsGet(string PageName);

        /// <summary>
        /// Returns all Hash Tags
        /// </summary>
        /// <returns>Hash Tags Collection</returns>
        internal abstract HashTags HashTagsGet();

        /// <summary>
        /// Adds a hashtag to a page
        /// </summary>
        /// <param name="tag">Tag to add</param>
        /// <param name="pageName">PageName</param>
        internal abstract void HashTagAdd(HashTag tag, string pageName);

        /// <summary>
        /// removes a hashtag from a page
        /// </summary>
        /// <param name="tag">Tag to remove</param>
        /// <param name="pageName">PageName</param>
        internal abstract void HashTagRemove(HashTag tag, string pageName);

        /// <summary>
        /// Creates a new #Tag
        /// </summary>
        /// <param name="tagName">Name of tag to create</param>
        /// <returns>HashTag Object</returns>
        internal abstract HashTag HashTagCreate(string tagName);

    #endregion Hash Tags

    #region Vouchers

        /// <summary>
        /// Redeems a voucher that has previously been sold
        /// </summary>
        /// <param name="voucherCode">Voucher Code</param>
        /// <param name="value">Value of voucher</param>
        /// <param name="user">User redeeming the voucher</param>
        internal abstract decimal RedeemVoucher(string voucherCode, User user, bool validateOnly);

        /// <summary>
        /// Sell a voucher
        /// </summary>
        /// <param name="voucherCode">Voucher Code</param>
        /// <param name="value">Value of voucher</param>
        /// <param name="user">User voucher sold to</param>
        /// <param name="validateOnly">if true the data will not be saved only validated.</param>
        internal abstract void SellVoucher(string voucherCode, decimal value, User user, bool validateOnly);

        /// <summary>
        /// Creates a new voucher code
        /// </summary>
        /// <param name="VoucherCode">New Voucher Code</param>
        /// <param name="value">Voucher Value</param>
        internal abstract void CreateVoucher(string VoucherCode, decimal value);

        /// <summary>
        /// Adds multiple vouchers
        /// </summary>
        /// <param name="vouchers">Vouchers to be added</param>
        internal abstract void SellVouchers(Vouchers vouchers);

        /// <summary>
        /// Marks all non sold vouchers as sold
        /// 
        /// Used as admin function to *sort* our vouchers
        /// </summary>
        /// <param name="currentUser"></param>
        internal abstract void VouchersMarkAllAsSold(User currentUser);

        /// <summary>
        /// Set's the current voucher as unsold
        /// </summary>
        /// <param name="currentUser">current user</param>
        /// <param name="voucherCode">voucher code</param>
        internal abstract void VoucherMarkAsUnsold(User currentUser, string voucherCode);

        /// <summary>
        /// Retrieves a voucher
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        internal abstract Voucher VoucherGet(string voucherCode);

    #endregion Vouchers

    #region AppointmentGroups

        /// <summary>
        /// Returns a collection of appointment groups
        /// </summary>
        /// <returns>AppointmentGroups collection</returns>
        internal abstract AppointmentGroups AppointmentGroupsGet();

    #endregion AppointmentGroups

    #region Refunds

        /// <summary>
        /// Create a Refund
        /// </summary>
        /// <param name="client"></param>
        /// <param name="employee"></param>
        /// <param name="invoice"></param>
        /// <param name="refundAmount"></param>
        /// <param name="reason"></param>
        /// <returns>Int64, new id of refund</returns>
        internal abstract Int64 RefundCreate(User client, User employee, Invoice invoice, 
            decimal refundAmount, string reason);
        
        /// <summary>
        /// Retrieves all refunds for a specific date period
        /// </summary>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <returns>Refunds Collection</returns>
        internal abstract Refunds RefundsGet(DateTime From, DateTime To);

    #endregion Refunds

    #region Permissions

        internal abstract SecurityEnums.SecurityPermissionsPOS PermissionsGet(User user);

        internal abstract void PermissionsSet(User user, SecurityEnums.SecurityPermissionsPOS permissions);

        internal abstract SecurityEnums.SecurityPermissionsReports PermissionsGetReports(User user);

        internal abstract void PermissionsSetReports (User user, SecurityEnums.SecurityPermissionsReports permissions);

        internal abstract SecurityEnums.SecurityPermissionsStaff PermissionsGetStaff(User user);

        internal abstract void PermissionsSetStaff(User user, SecurityEnums.SecurityPermissionsStaff permissions);

        internal abstract SecurityEnums.SecurityPermissionsCalendar PermissionsGetCalendar(User user);

        internal abstract void PermissionsSetCalendar(User user, SecurityEnums.SecurityPermissionsCalendar permissions);

        internal abstract SecurityEnums.SecurityPermissionsAccounts PermissionsGetAccounts(User user);

        internal abstract void PermissionsSetAccounts(User user, SecurityEnums.SecurityPermissionsAccounts permissions);

        internal abstract SecurityEnums.SecurityPermissionsWebsite PermissionsGetWebsite(User user);

        internal abstract void PermissionsSetWebsite(User user, SecurityEnums.SecurityPermissionsWebsite permissions);

        internal abstract void PermissionsSetStock(User user, SecurityEnums.SecurityPermissionsStockControl permissions);

        internal abstract SecurityEnums.SecurityPermissionsStockControl PermissionsGetStock(User user);

    #endregion Permissions

    #region Campaigns

        internal abstract bool CampaignsCanSetReplication();

        /// <summary>
        /// Sends a test email for a campaign
        /// </summary>
        /// <param name="SenderName"></param>
        /// <param name="SenderEmail"></param>
        /// <param name="Message"></param>
        /// <param name="Subject"></param>
        /// <param name="CampaignName"></param>
        internal abstract void CampaignSendTestEmail(User user, string SenderName, string SenderEmail,
            string Message, string Subject, string CampaignName);

        /// <summary>
        /// Retrieves all campaigns
        /// </summary>
        /// <returns>Campaigns collection</returns>
        internal abstract Campaigns CampaignsGet();

        /// <summary>
        /// Retrieves all campaigns
        /// </summary>
        /// <returns>Campaigns collection</returns>
        internal abstract Campaigns CampaignsGetWizard();
        /// <summary>
        /// Retrieves the active campaigns
        /// </summary>
        /// <returns>Campaign object, if no campaign running returns null</returns>
        internal abstract Campaigns CampaignGet(Country currentCountry);

        /// <summary>
        /// Retrieves a campaign based on its ID
        /// </summary>
        /// <param name="ID">ID of campaign</param>
        /// <returns>Campaign object</returns>
        internal abstract Campaign CampaignGet(int ID);

        /// <summary>
        /// Retrieves a campaign based on its Name
        /// </summary>
        /// <param name="CampaignName">Campaing Name</param>
        /// <returns>Campaign object if found, otherwise null</returns>
        internal abstract Campaign CampaignGet(string CampaignName);

        /// <summary>
        /// Save a campaign
        /// </summary>
        /// <param name="campaign">Campaign to be saved</param>
        internal abstract void CampaignSave(Campaign campaign);

        /// <summary>
        /// Deletes a campaign
        /// </summary>
        /// <param name="campaign">Campaign to be deleted</param>
        internal abstract void CampaignDelete(Campaign campaign);

        /// <summary>
        /// Create a new campaign
        /// </summary>
        /// <returns>Campaign object</returns>
        internal abstract Campaign CampaignCreate(string campaignName);

    #endregion Campaigns

    #region Frequently Asked Questions

        internal abstract KBGroups FAQGet();

        internal abstract KBGroups FAQGet(User user);

        internal abstract KBGroups FAQGet(User user, KBGroup parent);

        internal abstract KBGroup FAQGet(User user, int parent);

        internal abstract KBGroup FAQGetParent(KBGroup child);

        internal abstract FAQItems FAQItemsGet(KBGroup parent);

        internal abstract FAQItem FAQItemGet(int ID);

        internal abstract FAQItem FAQItemCreate();

        internal abstract void FAQItemSave(FAQItem item);

        internal abstract void FAQItemDelete(FAQItem item);

        internal abstract int FAQItemGetCount();

        internal abstract FAQItems FAQItemsGet(int Page, int PageSize);

        internal abstract void FAQItemSetViewCount(FAQItem item);

    #endregion Frequently Asked Questions

    #region Database Updates

        internal abstract Updates DatabaseUpdatesGet(string TableName, string Key);
        internal abstract Updates DatabaseDeletesGet(string TableName, string ColumnName, string Key);
        internal abstract Updates DatabaseWebLogGet(string Session);
        internal abstract Updates DatabaseWebLogGetIP(string IPAddress);

    #endregion Database Updates

    #region Downloads


        internal abstract Download DownloadCreate(string FileName, string Description);
        internal abstract void DownloadDelete(Download download);
        internal abstract Downloads DownloadsGet(int PageSize, int PageNumber, int DownloadType);
        internal abstract int DownloadCount(int DownloadType, bool isActive);
        internal abstract void DownloadAdd(Download download);

    #endregion Downloads

    #region RSS Feeds

        internal abstract RSSFeed RSSFeedsGet(Enums.RSSFeedType feedType);

    #endregion RSS Feeds

    #region Trade Clients

        /// <summary>
        /// Returns all clients managed by a staff member
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        internal abstract Clients TradeClientManagerClients(User manager);

        /// <summary>
        /// Retrieves the account manager for the client
        /// </summary>
        /// <param name="client">Client who's manager is sought</param>
        internal abstract User TradeClientManagerGet(Client client);

        /// <summary>
        /// Set's the Manager for the client
        /// </summary>
        /// <param name="client">Client who's manager will be set</param>
        /// <param name="manager">Staff Member who will manage the account</param>
        internal abstract void TradeClientManagerSet(Client client, User manager);

        /// <summary>
        /// Retrieves a list of all Client Managers
        /// </summary>
        /// <returns></returns>
        internal abstract Users TradeClientManagersGet();

        internal abstract Clients TradeClientsGet(Enums.ClientState ClientState);
        internal abstract Client TradeClientGet(Int64 ID);
        internal abstract Client TradeClientCreate(string Name, string CompanyName, string Telephone, string Email, string Address, string Postcode, string Notes);

        internal abstract void TradeClientNotesAdd(Client client, User user, string Notes, Enums.ClientAction action);
        internal abstract void TradeClientNotesAdd(Client client, User user, string notes, ClientAction action);
        internal abstract ClientNotes TradeClientNotesGet(Client client);
        internal abstract ClientNotes TradeClientNotesGet(ClientAction action);
        internal abstract void TradeClientsAutoLinkAccounts();
        internal abstract void TradeClientChangeState(Client client, Enums.ClientState state);

        /// <summary>
        /// Returns all archived actions
        /// </summary>
        /// <param name="client"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        internal abstract ClientActions TradeClientActionsGet(Client client, Enums.ClientAction action);

        /// <summary>
        /// Returns all client actions
        /// </summary>
        /// <param name="client">Client who's actions are being sought</param>
        /// <returns>ClientActions Collection</returns>
        internal abstract ClientActions TradeClientActionsGet(Client client);

        /// <summary>
        /// Returns Open or Closed Action for Client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        internal abstract ClientAction TradeClientActionGet(Client client, Enums.ClientAction action, bool Open);

        /// <summary>
        /// Completes a trade action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="user"></param>
        /// <param name="Notes"></param>
        internal abstract void TradeClientActionsComplete(ClientAction clientAction, User user, string Notes);

        internal abstract ClientAction TradeClientActionCreate(Client client, Enums.ClientAction ActionType);

    #endregion Trade Clients

    #region US States

        internal abstract USStates GetUSStates();
        internal abstract USState GetUSState(Int64 ID);
        internal abstract USState GetUSState(string Name);

    #endregion US States

    #region Stats Code

        /// <summary>
        /// Get's Product SEO Statistics
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics StatisticsSEOStatistics();

        /// <summary>
        /// Gets lat/long ip address of visitors
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        internal abstract SimpleStatistics GetVisitorLocations(decimal age);

        /// <summary>
        /// Gets statistics on unpaid orders
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics GetUnpaidStatistics();

        internal abstract string GetTempStats();

        internal abstract string GetCampaignStats(string Campaign);

        internal abstract void StatisticsInvoiceTotalByMonth(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsInvoiceCountByDay(Statistics statistics, int TotalDays, DateTime StartDate);

        internal abstract void StatisticsVisitorsByCountry(Statistics statistics, int Count);

        internal abstract void StatisticsVisitorsByCountryToday(Statistics statistics, int Count);

        internal abstract void StatisticsMonthToDate(Statistics statistics, DateTime StartMonth, string counryCode, int dataType);

        internal abstract void StatisticsMonthToDate(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateOnline(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateSalon(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateOffice(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateCount(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateTop5Countries(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateTop10Countries(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateTop5Salons(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthtoDateBySalons(Statistics statistics, DateTime StartMonth);

        internal abstract void StatisticsMonthToDateBySalonOwners(Statistics statistics, DateTime StartMonth);

        /// <summary>
        /// Returns Sales Summary By Day
        /// </summary>
        /// <param name="statistics">Statistics object
        /// Used for callback
        /// </param>
        /// <param name="from">Date From</param>
        /// <param name="to">Date To</param>
        /// <param name="countryCode">Country Code or blank for all countries</param>
        internal abstract void StatisticsDailyTotals(Statistics statistics, DateTime month, string countryCode);

        internal abstract void StatisticsMonthlyTotals(Statistics statistics, int year, string countryCode);

        internal abstract Takings StatisticsSalesSalonSummary(DateTime from, DateTime to);

        internal abstract Takings StatisticsSalesSalonTreatments(DateTime from, DateTime to);

        internal abstract Takings StatisticsSalesSalonProducts(DateTime from, DateTime to);

        internal abstract void StatisticsUpdateRedirectHitCount(string url);

        internal abstract int StatisticsRedirectGetHitCount(string url);

        internal abstract void StatisticsTimeLineEventsGet(Statistics statistics);

        internal abstract SimpleStatistics StatisticsAppointmentSummary(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Returns a collection of top selling products
        /// </summary>
        /// <param name="number">number of items (i.e. 10 for top 10)</param>
        /// <param name="days">number of days to go back</param>
        /// <param name="autoUpdate">if true the top (number) of products are set as top</param>
        /// <returns></returns>
        internal abstract SimpleStatistics StatisticsGetTopProducts(int number, int days, bool autoUpdate);

    #endregion Stats Code

    #region Videos

        public abstract int VideoCount();

        public abstract Videos VideoGet();

        public abstract Video VideoGet(int ID);

        public abstract void VideoUpdate(Video video);

        public abstract void VideoDelete(Video video);

        public abstract int VideoCreate(string description, string reference);

    #endregion Videos

    #region Export IBLM Data

        public abstract string ExportIBLMData(Int64 Start);

        public abstract int IBLMMaxOperationID();

    #endregion Export IBLM Data

    #region Celebrities

        internal abstract Celebrities CelebritiesGet();

        internal abstract Celebrity CelebritiesGet(int ID);

        public abstract void CelebrityUpdate(Celebrity celebrity);

        public abstract void CelebrityDelete(Celebrity celebrity);

        public abstract int CelebrityCreate(string name, string description, string image);

    #endregion Celebrities

    #region News

        /// <summary>
        /// Returns all News Items
        /// </summary>
        /// <returns></returns>
        internal abstract NewsItems NewsGet();

        /// <summary>
        /// Returns a page of news items
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        internal abstract NewsItems NewsGet(int PageSize, int PageNumber);

        /// <summary>
        /// Returns an individual NewsItem
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        internal abstract NewsItem NewsGet(int ID);

        /// <summary>
        /// Returns total news items
        /// </summary>
        /// <returns></returns>
        internal abstract int NewsCount();

    #endregion News

    #region Backup

        internal abstract void BackupDatabase(string Path);

    #endregion Backup

    #region Email

        internal abstract void EmailQueueStatistics(out Int64 QueueSize);

        internal abstract Emails EmailsGet(bool IncludeSentEmail,
            Int16 MaxSendAttempts);

        internal abstract void EmailMarkSent(Email email, string sendResult);

        internal abstract void EmailRecordSentAttempt(Email email, string sendResult);

        internal abstract void EmailDeleteSent();

        internal abstract Int64 EmailAdd(string ToName, string ToEMail, string FromName,
            string FromEMail, string Subject, string Message);

        /// <summary>
        /// Email mail shot
        /// </summary>
        /// <param name="memberLevel">Will send to this member level and above</param>
        /// <param name="Subject">Subject of Message</param>
        /// <param name="Message">Message</param>
        /// <returns>Number of emails scheduled to send</returns>
        internal abstract Int64 EmailAdd(MemberLevel memberLevel, bool SendToAboveMemberLevels, string Subject, string Message);

        /// <summary>
        /// Email shot to specific country, only to normal members
        /// </summary>
        /// <param name="Country"></param>
        /// <param name="ubject"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        internal abstract Int64 EmailAdd(Country Country, string Subject, string Message);

    #endregion Email

    #region Countries

        internal abstract Countries CountriesGet();
        internal abstract Country CountryGet(int CountryID);
        internal abstract Country CountryGet(string CountryCode);

        internal abstract Country CountryGet(CultureInfo cultureInfo);

        internal abstract void CountrySet(Country country);

    #endregion Countries

    #region Therapists

        /// <summary>
        /// Returns a list of Therapists
        /// </summary>
        /// <returns>Therapists collection</returns>
        internal abstract Therapists TherapistsGet();

        /// <summary>
        /// returns total appointments for date range and status
        /// </summary>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <param name="Status">Appointment Status</param>
        /// <returns>number of appointments</returns>
        internal abstract int TherapistsAppointments(Therapist therapist, DateTime From, DateTime To, 
            Enums.AppointmentStatus Status);

        /// <summary>
        /// Returns total sales for date range and type
        /// </summary>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <param name="Type">Sales type</param>
        /// <returns>Total sales for period</returns>
        internal abstract decimal TherapistSales(Therapist therapist, DateTime From, DateTime To, ProductCostItemType Type);

        /// <summary>
        /// Returns a collection of all sales for a therapist for a date range
        /// </summary>
        /// <param name="therapist"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        /// <returns></returns>
        internal abstract Takings TherapistSales(Therapist therapist, DateTime from, DateTime to);

        /// <summary>
        /// Returns the total discounts for specified period
        /// </summary>
        /// <param name="therapist">Therapist who's takings are sought</param>
        /// <param name="from">Start date to analyse</param>
        /// <param name="to">End date to analyse</param>
        /// <returns>TherapistTakings object</returns>
        internal abstract TherapistTakings TherapistTakings(Therapist therapist, DateTime from, DateTime to);

        /// <summary>
        /// Returns the total product sales by therapist for a date period
        /// </summary>
        /// <param name="therapist">Therapist who's takings are sought</param>
        /// <param name="from">Start date to analyse</param>
        /// <param name="to">End date to analyse</param>
        /// <returns>TherapistTakings object</returns>
        internal abstract Takings TherapistTakingsProducts(Therapist therapist, DateTime from, DateTime to);

        /// <summary>
        /// Returns Sales by Sales Type for a therapist
        /// </summary>
        /// <param name="therapist"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="SalesType"></param>
        /// <returns></returns>
        internal abstract decimal TherapistSales(Therapist therapist, DateTime from, DateTime to, PaymentStatus paymentStatus, bool Totals = true);

        /// <summary>
        /// Returns total refunds for date range
        /// </summary>
        /// <param name="therapist">Employee</param>
        /// <param name="From">Date From</param>
        /// <param name="To">Date To</param>
        /// <returns>Total refunds for period specified</returns>
        internal abstract decimal TherapistRefunds(Therapist therapist, DateTime From, DateTime To);

        /// <summary>
        /// Returns an individual Therapist
        /// </summary>
        /// <param name="TherapistID">ID of the Therapist to return</param>
        /// <returns>Therapists collection containing the Therapist</returns>
        internal abstract Therapists TherapistsGet(Int64 TherapistID);

        internal abstract Therapist TherapistGet(Int64 TherapistID);

        internal abstract Therapists TherapistsGet(bool PublicOnly);

        internal abstract void TherapistSave(Therapist therapist);

        internal abstract void TherapistDelete(Therapist therapist);

        internal abstract Therapist TherapistCreate(User StaffMember);

        internal abstract WorkingDays TherapistsWorkingDaysGet(Therapist therapist);

        internal abstract void TherapistsWorkingDaysSave(WorkingDay Day);

        internal abstract void TherapistsWorkingDaysDelete(WorkingDay Day);

        internal abstract WorkingDay TherapistWorkingDaysCreate(Therapist therapist);

    #endregion Therapists

    #region Appointments

        /// <summary>
        /// Count of future appointments for the member of staff
        /// </summary>
        /// <param name="staff">Staff Member</param>
        /// <param name="fromDate">Date to search from</param>
        /// <returns>int - number of future salon appointments</returns>
        internal abstract int AppointmentFutureCount(User staff, DateTime fromDate);

        internal abstract void AppointmentUpdate(Appointment appointment, User user);
        internal abstract Int64 AppointmentCreate(Appointment appointment, User currentUser);
        internal abstract Appointments AppointmentsGet(DateTime Date, Int64 EmployeeID);
        internal abstract Appointments AppointmentsGet(User user, int PageNumber, int PageSize);
        internal abstract Appointments AppointmentsGet(DateTime Date);
        internal abstract Appointments AppointmentsGet(DateTime StartDate, DateTime EndDate, Therapist Therapist);
        internal abstract Appointment AppointmentGet(Int64 AppointmentID);
        internal abstract Appointments AppointmentsGet(Appointment MasterAppointment);
        internal abstract Appointments AppointmentsGet(DateTime MinimumDate, Progress progress);
        internal abstract Appointments AppointmentsGetNew(Int64 MaxID, DateTime LastChecked);
        internal abstract Appointments AppointmentsGet(int PageNumber, int PageSize);

        internal abstract Appointments AppointmentsGet(DateTime AppointmentDate, Therapist therapist, bool ShowCancelledAppointment);
        internal abstract Appointments AppointmentsGet(DateTime AppointmentDate, bool ShowCancelledAppointment);

        internal abstract Appointments AppointmentsGet(DateTime AppointmentDateStart, DateTime AppointmentDateFinish,
            bool ShowCancelledAppointment);


        internal abstract void AppointmentDeleteChildren(Appointment appointment);

        internal abstract Appointments AppointmentsGetRequested();

        /// <summary>
        /// returns the number of appointments for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal abstract int AppointmentsGetCount(User user);

        /// <summary>
        /// Retrieves the users Appointment History
        /// </summary>
        /// <param name="user">User who's history is being sought</param>
        /// <returns>AppointmentHistory collection</returns>
        internal abstract AppointmentHistory AppointmentHistory(User user);

        /// <summary>
        /// Retrieves all changes for an appointment
        /// </summary>
        /// <param name="appointment">Appointment who's changes are sought</param>
        /// <returns>AppointmentChanges collection</returns>
        internal abstract AppointmentChanges AppointmentChanges(Appointment appointment);

        /// <summary>
        /// Retrieves the name of the last user to create/alter the appointment
        /// </summary>
        /// <param name="appointment">Appointment</param>
        /// <returns>string, name of the person or "unknown"</returns>
        internal abstract string AppointmentLastChangedBy(Appointment appointment);

    #region Appointment Status

        internal abstract string AppointmentStatusGet(int AppointmentStatus);

        internal abstract AppointmentStatuses AppointmentStatusGet();

        internal abstract AppointmentStatus AppointmentStatusGet(string name);

    #endregion Appointment Status

    #region Appointment Treatments

        /// <summary>
        /// Gets all treatments for a waiting list
        /// </summary>
        /// <param name="waitingList"></param>
        /// <returns></returns>
        internal abstract AppointmentTreatments AppointmentTreatmentsGet(WaitingList waitingList);

        internal abstract AppointmentTreatments AppointmentTreatmentsGet(Therapist therapist, bool activeTreatmentsOnly);

        /// <summary>
        /// Retrieves all appointments that a user has previously had
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>AppointmentTreatments collection</returns>
        internal abstract AppointmentTreatments AppointmentTreatmentsGet(User user, bool lastTreated = false);

        internal abstract AppointmentTreatments AppointmentTreatmentsGet();

        internal abstract void AppointmentTreatmentsSave(AppointmentTreatments treatments);

        internal abstract void AppointmentTreatmentCreate(AppointmentTreatment treatment);

    #endregion Appointment Treatments

    #region Special Dates

        internal abstract SpecialDates SpecialDatesGet();

    #endregion Special Dates

    #endregion Appointments

    #region Appointment Treatments

        internal abstract AppointmentTreatment AppointmentTreatmentGet(int TreatmentID);

        internal abstract bool AppointmentTreatmentContains(AppointmentTreatment apptTreatment, Therapist therapist);

        internal abstract void AppointmentTreatmentSave(AppointmentTreatment apptTreatment);

        internal abstract void AppointmentTreatmentAdd(AppointmentTreatment apptTreatment, Therapist therapist);

        internal abstract void AppointmentTreatmentRemove(AppointmentTreatment apptTreatment, Therapist therapist);

    #endregion Appointment Treatments

    #region Appointment Types

        /// <summary>
        /// Returns a collection of appointment types
        /// </summary>
        /// <returns>AppointmentTypes collection</returns>
        internal abstract AppointmentTypes AppointmentTypesGet();

    #endregion

    #region Treatments

        internal abstract Treatments TreatmentSpaDays(int PageNumber, int PageSize);

        /// <summary>
        /// Returns a list of treatments available within the salon
        /// </summary>
        /// <param name="PageNumber">Current page number</param>
        /// <param name="PageSize">Size of page</param>
        /// <returns>Treatments collection</returns>
        internal abstract Treatments TreatmentsGet(int PageNumber, int PageSize);

        internal abstract Treatments TreatmentsGet(int PageNumber, int PageSize, TreatmentGroup group);

        /// <summary>
        /// Returns the total number of treatments available within the salon
        /// </summary>
        /// <returns>int - Number of treatments</returns>
        internal abstract int TreatmentsCount();

        internal abstract Treatment TreatmentGet(int ID, bool SpaDay);

        internal abstract TreatmentGroups TreatmentGroupsGet();

        internal abstract TreatmentGroup TreatmentGroupGet(int TreatmentGroupID);

    #endregion Treatments

    #region Salons

        /// <summary>
        /// Returns a page of salons that are available to the public
        /// </summary>
        /// <param name="PageNumber">Current Page number</param>
        /// <param name="PageSize">Size of the Page of Salons</param>
        /// <returns>Salons collection</returns>
        internal abstract Salons SalonsGet(int PageNumber, int PageSize);

        /// <summary>
        /// Finds a salon based on the salon ID
        /// </summary>
        /// <param name="SalonID"></param>
        /// <returns>Valid Salon object if found, otherwise null</returns>
        internal abstract Salon SalonGet(int SalonID);

        /// <summary>
        /// Returns the number of salons
        /// </summary>
        /// <returns>int Number of publicly available salons</returns>
        internal abstract int SalonsCount();

        /// <summary>
        /// Finds nearest 10 salons to the given postcode
        /// </summary>
        /// <param name="Postcode">First part of post code, i.e. TF10</param>
        /// <returns></returns>
        internal abstract Salons SalonsFindNearest(string Postcode);

        /// <summary>
        /// Returns all salons linked to the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal abstract Salons SalonsGet(User user);

        /// <summary>
        /// Validates coupon code against Salon Discount
        /// </summary>
        /// <param name="CouponCode">Coupon Code to search for</param>
        /// <returns>SalonDiscount object if found, otherwise null</returns>
        internal abstract SalonDiscount SalonDiscountGet(string CouponCode);

        /// <summary>
        /// Retrieves a Salon's VIP Salon discount settings
        /// </summary>
        /// <param name="salon">Salon who's details are to be returned</param>
        /// <returns>SalonDiscount object if found, otherwise null</returns>
        internal abstract SalonDiscount SalonDiscountGet(Salon salon);

    #endregion Salons

    #region Tips and Tricks

        /// <summary>
        /// Returns the total number of Tips & Tricks
        /// </summary>
        /// <returns>int - Count of Tips & Tricks</returns>
        internal abstract int TipsTricksCount();

        /// <summary>
        /// Returns a collection of Tips & Tricks that are publicly viewable
        /// </summary>
        /// <param name="PageNumber">Current Page Number</param>
        /// <param name="PageSize">Size of page  - number of records to retrieve for the page</param>
        /// <returns>TipsTricks collection</returns>
        internal abstract TipsTricks TipsTricksGet(int PageNumber, int PageSize);

        /// <summary>
        /// Returns an individual tip
        /// </summary>
        /// <param name="TipID">ID of tip to retrieve</param>
        /// <returns>TipsTrick object if found, otherwise null</returns>
        internal abstract TipsTrick TipsTrickGet(int TipID);

    #endregion Tips and Tricks

    #region Distributors

        internal abstract int DistributorsCount();

        internal abstract Distributors DistributorsGet(int PageNumber, int PageSize);

    #endregion Distributors

    #region Popup

        internal abstract string GetPopupData(int PopupID, out string Title);

    #endregion Popup

    #region Products

    #region Product Group Types

        internal abstract ProductGroupType ProductGroupTypeGet(int id);

        internal abstract ProductGroupType ProductGroupTypeGet(string name);

        internal abstract ProductGroupTypes ProductGroupTypesGet();

        internal abstract Products ProductGroupTypesGetProducts(ProductGroupType groupType);

    #endregion Product Group Types

    #region Product Cost Types

        internal abstract ProductCostType ProductCostTypeGet(int id);

        internal abstract ProductCostType ProductCostTypeGet(string name);

        internal abstract ProductCostTypes ProductCostTypesGet();

    #endregion Product Cost Types

        /// <summary>
        /// Returns a collection of discounted products
        /// </summary>
        /// <returns>Collection of ProductCosts items which have been discounted</returns>
        internal abstract ProductCosts DiscountedProducts();

        /// <summary>
        /// Determines wether a SKU code is valid
        /// </summary>
        /// <param name="SKU">SKU code to validate</param>
        /// <returns>bool - true if valid SKU otherwise false</returns>
        internal abstract bool ProductIsValidSKU(string SKU);

        /// <summary>
        /// Returns the number of products publicly visible
        /// </summary>
        /// <returns>int - Count of products</returns>
        internal abstract int ProductsCount(ProductType primaryProductType);

        /// <summary>
        /// Returns the number of products that are on offer
        /// </summary>
        /// <returns></returns>
        internal abstract int ProductsCountOffers();

        /// <summary>
        /// Returns the number of products within a product group
        /// </summary>
        /// <param name="ProductGroup">Product Group ID</param>
        /// <returns>int - Count of products for specified product group</returns>
        internal abstract int ProductsCountByProduct(int ProductGroup);

        /// <summary>
        /// Returns the featured product
        /// </summary>
        /// <returns>Product object containing the featured product</returns>
        internal abstract Product ProductGetFeatured();

        /// <summary>
        /// Returns all products for carousel
        /// </summary>
        /// <returns>Products object</returns>
        internal abstract Products ProductsGetCarousel();

        /// <summary>
        /// Returns an individual product
        /// </summary>
        /// <param name="ProductID">ID of the product to return</param>
        /// <returns>Product object</returns>
        internal abstract Product ProductGet(Int64 ProductID);


        /// <summary>
        /// Returns a page of products
        /// </summary>
        /// <param name="PageNumber">Current page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <returns>Products collection</returns>
        internal abstract Products ProductsGet(ProductType primaryProductType, int PageNumber, int PageSize);

        internal abstract Products ProductsGet(Celebrity celebrity);

        /// <summary>
        /// Gets the product associated with a product cost item
        /// </summary>
        /// <param name="productCost">Product Cost Item</param>
        /// <returns></returns>
        internal abstract Product ProductGet(ProductCost productCost);

        /// <summary>
        /// Retrieves black label products available for sale
        /// </summary>
        /// <param name="user">Current User</param>
        /// <returns>Products Collection</returns>
        internal abstract Products ProductGetBlackLabel(User user);


        /// <summary>
        /// Returns a page of products
        /// </summary>
        /// <param name="PageNumber">Current Page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <param name="IncludeCosts">If true then all product costs are loaded as well</param>
        /// <returns></returns>
        internal abstract Products ProductsGet(ProductType primaryProductType, int PageNumber, int PageSize, bool IncludeCosts);

        /// <summary>
        /// Returns a page of products for a product group
        /// </summary>
        /// <param name="PageNumber">Current page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <param name="ProductGroup">Productgroup id</param>
        /// <returns>Products collection</returns>
        internal abstract Products ProductsGet(ProductType primaryProductType, int PageNumber, int PageSize, 
            ProductGroup ProductGroup);

        /// <summary>
        /// Returns all products for a specific SKU
        /// </summary>
        /// <param name="SKU">SKU for products</param>
        /// <returns>Products collection</returns>
        internal abstract Products ProductsGetBySKU(string SKU);

        /// <summary>
        /// Returns a page of products on offer
        /// </summary>
        /// <param name="PageNumber">Current Page</param>
        /// <param name="PageSize">Number of products per page</param>
        /// <returns></returns>
        internal abstract Products ProductsGetOffers(int PageNumber, int PageSize);

        /// <summary>
        /// Returns a collection of Product Groups
        /// </summary>
        /// <param name="MemberLevel">Member level for product group</param>
        /// <returns>ProductGroups collection</returns>
        internal abstract ProductGroups ProductGroupsGet(MemberLevel MemberLevel);

        /// <summary>
        /// Returns a collection of Product Groups
        /// </summary>
        /// <param name="MemberLevel">Member level for product group</param>
        /// <returns>ProductGroups collection</returns>
        internal abstract ProductGroups ProductGroupsGet(ProductGroupType groupType, MemberLevel MemberLevel);

        /// <summary>
        /// Returns a ProductGroup item
        /// </summary>
        /// <param name="ID">ID of ProductGroup</param>
        /// <returns>ProductGroup item if found, otherwise null</returns>
        internal abstract ProductGroup ProductGroupGet(int ID);

        /// <summary>
        /// Returns product cost / size data for each product
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>ProductCosts collection</returns>
        internal abstract ProductCosts ProductCostsGet(Product product);

        internal abstract ProductCosts ProductCostsGetFree(ProductCost product);

        internal abstract ProductCosts ProductCostsGetFreeOffers();

        internal abstract ProductCosts ProductCostsGet(Product product, User user);

        internal abstract ProductCosts ProductCostsGet(Product product, User user, Country country);

        internal abstract ProductCosts ProductCostsGet(Product product, MemberLevel memberLevel);

        /// <summary>
        /// Returns a product cost item based on it's barcode
        /// </summary>
        /// <param name="barcode">barcode of item</param>
        /// <returns>ProductCost item if found, otherwise null</returns>
        internal abstract ProductCost ProductCostGetByBarcode(string barcode);


        internal abstract ProductCost ProductCostGetSKU(string sku);

        internal abstract ProductCost ProductCostGet(int ID);

        internal abstract ProductCost ProductCostGet(int ID, MemberLevel memberLevel);

        internal abstract ProductCost ProductCostGet(int ID, User user);

        /// <summary>
        /// returns the Gift Wrap Product Cost Item
        /// </summary>
        /// <returns></returns>
        internal abstract ProductCost ProductCostGetGiftWrap();

        /// <summary>
        /// Returns a collection of product types
        /// </summary>
        /// <returns>ProductTypes collection</returns>
        internal abstract ProductTypes ProductTypesGet();


        /// <summary>
        /// Returns a product type based on it's name
        /// </summary>
        /// <param name="name">Name of Product Type</param>
        /// <returns></returns>
        internal abstract ProductType ProductTypeGet(string name);


    #endregion Products

    #region Shopping Basket

        internal abstract int BasketGetTotalItems(Int64 BasketID);
        internal abstract Int64 BasketGetNextID(int increment);
        internal abstract Coupon BasketValidateCouponCode(string CouponCode);
        internal abstract void BasketAddToBasket(Int64 BasketID, Int64 ItemID, int Quantity, ProductCostItemType ItemType, User user, int priceColumn);

        internal abstract void BasketDeleteFromBasket(Int64 BasketID, Int64 ItemID, ProductCostItemType ItemType);

        internal abstract void BasketEmpty(Int64 BasketID);

        internal abstract void BasketUpdateBasket(Int64 BasketID, BasketItem basketItem, User user);

        /// <summary>
        /// Converts shopping basket into an order
        /// </summary>
        /// <param name="basket">Basket to convert to Order</param>
        /// <returns>Order</returns>
        internal abstract Order BasketSendEmailForPayment(ShoppingBasket basket, PaymentStatus PayMethod, string UserSession,
            string RemoteHost, Enums.InvoiceVoucherType VoucherType, Currency currency, int version);

        internal abstract BasketItems BasketItemsGet(ShoppingBasket basket);

        /// <summary>
        /// Saves a basket item
        /// </summary>
        /// <param name="basket"></param>
        /// <param name="item"></param>
        internal abstract void BasketItemSave(ShoppingBasket basket, BasketItem item);

        /// <summary>
        /// Returns a collection of saved baskets
        /// </summary>
        /// <returns></returns>
        internal abstract SavedBaskets BasketSavedGet();

        /// <summary>
        /// Deletes a saved basket
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal abstract bool BasketSavedDelete(SavedBasket basket);

    #endregion Shopping Basket

    #region Shipping Costs

        internal abstract Double GetShippingCosts(string CountryCode);
        internal abstract Double GetShippingCosts(int UserID, int AddressID);
        internal abstract Double GetShippingCostsDefault(string CountryCode);

    #endregion Shipping costs

    #region Users

    #region Credit Cards

        /// <summary>
        /// Updates (add if not found) credit card details for a user
        /// </summary>
        /// <param name="card">CreditCard object</param>
        /// <param name="user">User who is updating the credit card</param>
        internal abstract void UserCreditCardDetailsUpdate(CreditCard card, User user);

        /// <summary>
        /// Deletes credit card details for a user
        /// </summary>
        /// <param name="card">CreditCard object</param>
        /// <param name="user">User who is deleting the credit card</param>
        internal abstract void UserCreditCardDetailsDelete(CreditCard card, User user);

        /// <summary>
        /// Retrieves user credit card details
        /// </summary>
        /// <param name="user">User whose details are required</param>
        /// <returns>CreditCard object if found, otherwise null</returns>
        internal abstract CreditCard UserCreditCardDetailsGet(User user);

    #endregion Credit Cards

    #region Special Offers

        internal abstract void SpecialOffersGet(int UserID, out bool Email,
            out bool Phone, out bool Postal);

        internal abstract void SpecialOffersSet(int UserID, bool Email,
            bool Phone, bool Postal);

    #endregion Special Offers

        /// <summary>
        /// Merges two user records together
        /// </summary>
        /// <param name="currentUser">User making the request</param>
        /// <param name="primaryRecord">Primary Record</param>
        /// <param name="secondaryRecord">Secondary Record</param>
        internal abstract void UserMergeRecords(User currentUser, User primaryRecord, User secondaryRecord);

        /// <summary>
        /// retrieves the system user, there can only be 1
        /// </summary>
        /// <returns></returns>
        internal abstract User UserGetSystemUser();

        /// <summary>
        /// Retrieves User object
        /// </summary>
        /// <param name="UserID">ID of user for data to return</param>
        /// <returns>User object</returns>
        internal abstract User UserGet(Int64 UserID);

        /// <summary>
        /// UserGet returns all members of staff
        /// </summary>
        /// <returns>Users Collection</returns>
        internal abstract Users UserGet();

        /// <summary>
        /// Returns all salon owners
        /// </summary>
        /// <returns>Users Collection</returns>
        internal abstract Users UserGetSalonOwners();

        internal abstract string UserGetBarcode(User user);
        internal abstract User UserGetByBarcode(string Barcode);
        internal abstract User UserGet(string Email);
        internal abstract User UserGet(string Email, string Password);

        /// <summary>
        /// Retrieves all users within the system
        /// </summary>
        /// <param name="progress">Progress object which will receive progress on the retrieval</param>
        internal abstract Users UsersGet(Progress progress);

#if !ANDROID
        internal abstract DataSet UserGetUserMenuItems();
#endif

        internal abstract Users UserGetBirthdays(string currenLocation, int month, int radius);

        internal abstract Users UserSearch(string FirstName, string LastName, string Email);
        internal abstract Users UserSearch(string FirstName, string LastName, string Email, string telephone, int MaxRecords);
        internal abstract void UserChangePassword(Int64 UserID, string CurrentPassword, string NewPassword);

        internal abstract User UserCreateAccount(string FirstName, string Surname, string Telephone, string EMail, string Password,
            string ConfirmPassword, string CompanyName, string Address1, string Address2, string Address3,
            string City, string County, string PostCode, int Country, bool OffersTelephone, bool OffersEmail, bool OffersPostal,
            Enums.UserRecordType RecordType, DateTime BirthDate, string Notes);

        internal abstract bool UserGetDetails(Int64 UserID, out string FirstName, out string Surname,
            out string EMail,
            out string Password, out string CompanyName, out string Address1,
            out string Address2, out string Address3, out string City, out string County,
            out string PostCode, out int Country);
        internal abstract void UserAddressUpdate(Int64 UserID, string Street1,
            string Street2, string City, string County, string PostCode, int Country);
        internal abstract void UserAddressUpdate(Int64 UserID, string CompanyName, string Street1,
            string Street2, string Street3, string City, string County, string PostCode,
            int Country);
        internal abstract bool UserAddressGet(Int64 UserID, out string CompanyName, out string Street1,
            out string Street2, out string Street3, out string City, out string County,
            out string PostCode, out int Country);
        internal abstract bool UserGetDetails(Int64 UserID, out string EMail, out string UserName);
        internal abstract bool UserAmmendAccount(User user);
        internal abstract bool UserLogUserOn(User user);

        internal abstract void UserSetLastVisit(User user);


    #endregion Users

    #region Invoices

        internal abstract void InvoiceCancel(Invoice invoice, Stock stockReturnItems, User currentUser);

        internal abstract Invoice InvoiceGet(Order order);

        internal abstract Invoice InvoiceGet(Int64 InvoiceID);

        /// <summary>
        /// Retrieves all invoices for a specific user
        /// </summary>
        /// <returns></returns>
        internal abstract Invoices InvoicesGet(User user);

        /// <summary>
        /// Retrieves the number of invoices for a specified user
        /// </summary>
        /// <param name="user">User object of user to get invoice count for</param>
        /// <returns>int 0 if none found, otherwise the number of invoices a user has.</returns>
        internal abstract int InvoiceGetCount(User user);

        internal abstract void InvoiceMarkAsPaid(Order order, PaymentStatus PaymentStatus,
            int InvoiceVersion, string ResultText, string initialReferrer);

        internal abstract void InvoiceResendByEmail(Invoice invoice);

        /// <summary>
        /// Updates staff notes for an invoice
        /// </summary>
        /// <param name="notes"></param>
        internal abstract void InvoiceUpdateNotes(Invoice invoice, string notes);

        internal abstract void InvoiceItemUpdateSalesPerson(InvoiceItem invoiceItem, User user);

        internal abstract void InvoiceUpdateProcessStatus(ProcessStatus ProcessStatus, Invoice invoice);

        internal abstract void InvoiceUpdateProcessStatus(ProcessStatus ProcessStatus, Invoice invoice, string TrackingReference);

        internal abstract void InvoiceUpdatePaymentStatus(PaymentStatus PaymentStatus, Invoice invoice);

        internal abstract InvoiceItems InvoiceItemsGet(Invoice invoice);

        /// <summary>
        /// Sets the date of the invoice
        /// </summary>
        /// <param name="invoice">Invoice object who's date will change</param>
        /// <param name="newDateTime">New Invoice Date</param>
        internal abstract void InvoiceSetDate(Invoice invoice, DateTime newDateTime);

    #endregion Invoices

    #region Orders

        internal abstract void OrderCancel(Order order);

        /// <summary>
        /// Processes all unpaid invoices, sends an email to the user asking if they want to continue with the order
        /// </summary>
        internal abstract void OrdersProcessUnpaid();

        internal abstract Order OrderGet(Int64 OrderID);

        /// <summary>
        /// Returns the number of orders for a user
        /// </summary>
        /// <param name="user">User to check how many orders they have</param>
        /// <returns>int 0 if none otherwise the number of orders</returns>
        internal abstract int OrdersGetCount(User user);

        /// <summary>
        /// Retrieves all invoices for a specific user
        /// </summary>
        /// <returns></returns>
        internal abstract Orders OrdersGet(User user);

        /// <summary>
        /// Retrieves a list of unpaid/cancelled orders for a date range
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns>Orders collection</returns>
        internal abstract Orders OrdersUnpaid(DateTime startDate, DateTime endDate);

        internal abstract void OrderMarkAsPaid(Order order, string initialReferrer);

        internal abstract void OrderResendByEmail(int InvoiceID);

        internal abstract void OrderUpdateProcessStatus(ProcessStatus ProcessStatus, Order order);

        internal abstract void OrderUpdatePaymentStatus(PaymentStatus PaymentStatus, Order order);

        internal abstract OrderItems OrderItemsGet(Order order);


        /// <summary>
        /// Saves the basket as an order in progress
        /// </summary>
        /// <param name="basket">Current Shopping Basket</param>
        /// <param name="description">Saved Name</param>
        internal abstract void OrderSave(ShoppingBasket basket, string description, bool autoOrder);

    #endregion Orders

    #region Members Address

        internal abstract DeliveryAddress MembersAddressCreate(Int64 MemberID, string Name, string AddressLine1,
            string AddressLine2, string AddressLine3, string City, string County,
            string PostCode, int Country);

        internal abstract void MembersAddressDelete(DeliveryAddress deliveryAddress);

        internal abstract void MembersAddressUpdate(DeliveryAddress deliveryAddress);

        internal abstract DeliveryAddresses MembersAddressGet(User user);

        internal abstract DeliveryAddress MembersAddressGet(Int64 DeliveryAddressID);

    #endregion Members Address

    #region Member Notes

        /// <summary>
        /// Set's notes for a user
        /// </summary>
        /// <param name="member"></param>
        /// <param name="notes"></param>
        internal abstract void MemerNotesSet(User member, string notes);

        /// <summary>
        /// Gets notes for a user
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        internal abstract string MemberNotesGet(User member);

    #endregion Member Notes

    #region Helpdesk

    #region Customer Comments

        /// <summary>
        /// Adds a customer comment
        /// </summary>
        /// <param name="user">User object, if user logged on</param>
        /// <param name="Username">Name of user</param>
        /// <param name="Comments">Comments to be added</param>
        /// <returns></returns>
        internal abstract Int64 HelpdeskCustomerCommentsAdd(User user, string Username, string Comments);

        /// <summary>
        /// Retrieves page of customer comments viewable on the website
        /// </summary>
        /// <param name="PageNumber">Current Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>CustomerComments collection</returns>
        internal abstract CustomerComments HelpdeskCustomerCommentsGet(int PageNumber, int PageSize);

        /// <summary>
        /// Retrieves all customer comments viewable on the website
        /// </summary>
        /// <returns>CustomerComments collection</returns>
        internal abstract CustomerComments HelpdeskCustomerCommentsGet();

        /// <summary>
        /// retrieves an individual comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal abstract CustomerComment HelpdeskCustomerCommentGet(int id);

        /// <summary>
        /// Updates an individual comment
        /// </summary>
        /// <param name="comment"></param>
        internal abstract void HelpdeskCustomerCommentUpdate(CustomerComment comment);

        /// <summary>
        /// Deletes an individual comment
        /// </summary>
        /// <param name="comment"></param>
        internal abstract void HelpdeskCustomerCommentDelete(CustomerComment comment);

    #endregion Customer Comments

    #region Support Tickets

        internal abstract SupportTickets HelpdeskSupportTicketsGet(User user);
        internal abstract SupportTicket HelpdeskSupportTicketGet(string TicketKey, string EMail);
        internal abstract SupportTicket HelpdeskSupportTicketGet(int TicketID);
        internal abstract SupportTickets HelpdeskSupportTicketsGet(User user, string TicketKey);
        internal abstract void HelpdeskSupportTicketSubmitResponse(SupportTicket supportTicket,
            string ResponseContent, string ReplierName, bool IsAdmin);
        internal abstract void HelpdeskSupportTicketStatusUpdate(SupportTicket Ticket, TicketStatus Status);
        internal abstract void HelpdeskSupportTicketDepartmentUpdate(SupportTicket Ticket, TicketDepartment department);
        internal abstract SupportTicket HelpdeskSupportTicketCreate(string TicketKey, string Subject, string Content,
            string UserName, int Department, int Status, int Priority, string Email);
        internal abstract SupportTicketMessages HelpdeskSupportTicketMessagesGet(SupportTicket Ticket);
        internal abstract void HelpdeskSupportTicketsMaintenance();

    #endregion Support Tickets

    #region Support Ticket Collections

        internal abstract TicketPriorities HelpdeskTicketPrioritiesGet();
        internal abstract TicketDepartments HelpdeskTicketDepartmentsGet();
        internal abstract TicketStatuses HelpdeskTicketStatusesGet();

    #endregion Support Ticket Collections

    #endregion Helpdesk

    #region Settings

        internal abstract Dictionary<string, string> SettingsLoad(int websiteID);

        internal abstract bool SettingsExistMeta(string name);

        internal abstract string SettingsGetMeta(string Name);

        internal abstract void SettingsSetMeta(string Name, string Value);

        internal abstract bool SettingsExist(string name);

        internal abstract string SettingsGet(string Name);

        internal abstract Salons SalonsFind(string SalonName);

        internal abstract Salon SalonFind(string SalonName);

        internal abstract void SettingsSet(string Name, string Value);

    #endregion Settings

    #region Web Logging

        internal abstract void LogWebVisits(WebVisitLogItems items);

        internal abstract void LogWebVisit(string Platform, string BrowserVersion, string IsCrawler,
            string RemoteHost, string Method, string Path, string Query,
            string Referer, string UserSession, string Country);

        /// <summary>
        /// Logs the website in the database if it isn't already
        /// </summary>
        /// <param name="websiteID"></param>
        /// <param name="url"></param>
        internal abstract void RegisterWebsite(int websiteID, string url);

    #endregion Web Logging

    #region Data Storage

        /// <summary>
        /// Test's connection to the storage mechanism
        /// </summary>
        /// <returns></returns>
        internal abstract bool TestConnection();

    #endregion Data Storage

    #region Administration Methods

    #region Admin Orders

        internal abstract Orders AdminOrdersGet(int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses processStatuses);

    #endregion Admin Orders

    #region Admin Helpdesk

        internal abstract SupportTicket AdminHelpdeskSupportTicketGet(string TicketKey);

        internal abstract SupportTicket AdminHelpdeskSupportTicketGet(int ID);

        internal abstract SupportTickets AdminHelpdeskSupportTicketsGet(bool OnHold, bool Closed, bool Open);

        internal abstract CustomerComment AdminHelpdeskCustomerCommentGet(int CommentID);

        internal abstract void AdminHelpdeskCustomerCommentUpdate(CustomerComment Comment);

        internal abstract void AdminHelpdeskCustomercommentDelete(CustomerComment comment);

        internal abstract CustomerComments AdminHelpdeskCustomerCommentsGet(int PageNumber, int PageSize);

        internal abstract int AdminHelpdeskCustomerCommentsCount();

    #endregion Admin Helpdesk

    #region Admin Products

        /// <summary>
        /// Returns all featured products
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics AdminProductsStatsFeaturedProducts();

        /// <summary>
        /// Returns Invalid SKU statistics
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics AdminProductsStatsSKUInvalidCodes();

        /// <summary>
        /// Returns Invalid SKU statistics
        /// </summary>
        /// <returns></returns>
        internal abstract SimpleStatistics AdminProductsStatsSKUDuplicateCodes();

        internal abstract int AdminProductsCount();

        /// <summary>
        /// Returns Page of Products
        /// </summary>
        /// <param name="PageNumber">Page Number</param>
        /// <param name="PageSize">Size of Page</param>
        /// <returns>Products collection</returns>
        internal abstract Products AdminProductsGet(int PageNumber, int PageSize);

        /// <summary>
        /// Returns all Products for a specific Product Group
        /// </summary>
        /// <param name="Group">ProductGroup</param>
        /// <param name="ProductName">Name of product, allows partial search</param>
        /// <returns>Products collection</returns>
        internal abstract Products AdminProductsGet(ProductGroup Group, string ProductName);

        /// <summary>
        /// Returns all Products sorted by SKU
        /// </summary>
        /// <returns>Products collection</returns>
        internal abstract Products AdminProductsGet();

        /// <summary>
        /// Inserts a product into the product list
        /// </summary>
        /// <param name="ProductName"></param>
        /// <returns>Product</returns>
        internal abstract Product AdminProductInsert(string ProductName, ProductType productType, ProductGroup group);

        internal abstract void AdminProductUpdate(Product product);

        internal abstract void AdminProductDelete(Product product);

                /// <summary>
        /// Removes a product from all lists by changing to is_deleted true (soft delete)
        /// </summary>
        /// <param name="product">Product to be soft deleted</param>
        internal abstract void AdminProductSoftDelete(Product product);


    #region Admin Product Costs

        /// <summary>
        /// Removes a product from all lists by changing to is_deleted true (soft delete)
        /// </summary>
        /// <param name="product">Product to be soft deleted</param>
        internal abstract void AdminProductCostSoftDelete(ProductCost productCost);

        internal abstract ProductCost AdminProductCostCreate(Product product, string productItemName,
            ProductCostType costType);
        internal abstract ProductCost AdminProductCostGet(int ProductCostID);
        internal abstract void AdminProductCostDelete(ProductCost ProductCostSize);
        internal abstract void AdminProductCostUpdate(ProductCost ProductCostSize);

    #endregion Admin Product Costs

    #region Admin Product Groups

        /// <summary>
        /// Returns a page of Product Groups
        /// </summary>
        /// <param name="PageNumber">int - Current Page Number</param>
        /// <param name="PageSize">int - Current Page Size</param>
        /// <returns>ProductGroups collection</returns>
        internal abstract ProductGroups AdminProductGroupsGet(int PageNumber, int PageSize);

        /// <summary>
        /// Returns all Product Groups for a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal abstract ProductGroups AdminProductGroupsGet(Product product);
        /// <summary>
        /// Determines the count of product groups
        /// </summary>
        /// <returns>int - Count of Product Groups</returns>
        internal abstract int AdminProductGroupsCount();

        internal abstract ProductGroup AdminProductGroupCreate(string Description, int productGroupType);

        internal abstract void AdminProductGroupDelete(ProductGroup productGroup);

        internal abstract void AdminProductGroupUpdate(ProductGroup productGroup);

        internal abstract ProductGroup AdminProductGroupGet(int GroupID);

    #endregion Admin Product Groups

    #endregion Admin Products

    #region Admin Invoices

        internal abstract int AdminInvoicesGetCount(int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses processStatuses);

        internal abstract SimpleStatistics AdminInvoicesGetStats(int UserID, int InvoiceID, bool TodayOnly,
            ProcessStatuses processStatuses);

        internal abstract Invoices AdminInvoicesGet(int PageNumber, int PageSize, int UserID, int InvoiceID, bool TodayOnly, 
            ProcessStatuses processStatuses);

        internal abstract Invoices AdminInvoicesGet(ProcessStatuses processStatuses, PaymentStatus PaymentStatus);

        internal abstract Invoices AdminInvoicesGet(ProcessStatuses processStatuses, bool SortAscending, bool showCancelled);

        internal abstract Invoices AdminInvoicesGetAll(ProcessStatuses processStatuses);

        internal abstract Invoices AdminInvoicesGet(DateTime dateFrom, DateTime dateTo, ProcessStatuses processStatuses,
            int PaymentType, Coupon coupon, bool showCancelled);

    #endregion Admin Invoices

    #region Admin Tips and Tricks

        internal abstract int AdminTipsTricksCount();

        internal abstract TipsTricks AdminTipsTricksGet(int PageNumber, int PageSize);

        internal abstract TipsTrick AdminTipsTricksGet(int TipTrickID);

        internal abstract void AdminTipsTricksUpdate(TipsTrick Tip);

        internal abstract void AdminTipsTricksDelete(TipsTrick Tip);

        internal abstract TipsTrick AdminTipsTrickCreate(TipsTrick Tip);

    #endregion Admin Tips and Tricks

    #region Admin Email

        internal abstract Int64 AdminEmailMassAdd(string ToName, string ToEMail, string FromName,
            string FromEMail, string Subject, string Message, DateTime SendDateTime);

    #endregion Admin Email

    #region Admin Users

        /// <summary>
        /// Returns the number of registered users.
        /// </summary>
        /// <returns></returns>
        internal abstract int AdminUsersGetCount();

        internal abstract Users AdminUsersGet(int PageNumber, int PageSize);

        /// <summary>
        /// Returns all users for a specific member level
        /// </summary>
        /// <param name="MemberLevel"></param>
        /// <returns></returns>
        internal abstract Users AdminUsersGet(MemberLevel MemberLevel);

        internal abstract Users AdminUsersGetMassEmail(bool AdminOnly);

        internal abstract Users AdminUsersGetMassEmailProductItem(bool AdminOnly, int ProductID);

    #endregion Admin Users

    #region Admin Stats

        internal abstract int AdminStatsMailCount(Enums.MailCount Option);
        internal abstract SimpleStatistics AdminStatsUserCount(Enums.UsersOnline Option);
        internal abstract int AdminStatsComments();
        internal abstract int AdminStatsBannedIP();
        internal abstract int AdminStatsAppointments(Enums.AppointmentStats Option);
        internal abstract int AdminStatsTickets(Enums.TicketStatus Option);
        internal abstract int AdminStatsSalonUpdates();
        internal abstract int AdminStatsInvoices(Enums.InvoiceStatistics Option);
        internal abstract int AdminStatsUserCount();
        internal abstract int AdminStatsLicenceCount();
        internal abstract string AdminStatsDownloads();

    #endregion Admin Stats

    #region Admin Treatments

        internal abstract Treatment AdminTreatmentGet(int TreatmentID);

        internal abstract void AdminTreatmentUpdate(Treatment treatment);

        internal abstract void AdminTreatmentDelete(Treatment treatment);

        internal abstract Treatment AdminTreatmentCreate(Treatment treatment);

    #endregion Admin Treatments

    #region Admin Salons

        /// <summary>
        /// Returns an individual Salon
        /// </summary>
        /// <param name="SalonID">ID of salon to return</param>
        /// <returns>Salon object</returns>
        internal abstract Salon AdminSalonGet(int SalonID);

        /// <summary>
        /// Returns all salons
        /// </summary>
        /// <returns></returns>
        internal abstract Salons AdminSalonsGet();

        /// <summary>
        /// Returns all salons which are not assigned to a Salon Owner
        /// </summary>
        /// <returns></returns>
        internal abstract Salons AdminSalonsGetUnassigned();

        internal abstract Salons AdminSalonsGet(string SalonName);

        /// <summary>
        /// Returns a page of salons
        /// </summary>
        /// <param name="PageNumber"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        internal abstract Salons AdminSalonsGet(int PageNumber, int PageSize);

        /// <summary>
        /// Deletes a Salon
        /// </summary>
        /// <param name="salon"></param>
        internal abstract void AdminSalonDelete(Salon salon);

        /// <summary>
        /// Updates a salon
        /// </summary>
        /// <param name="salon">Salon to be updated</param>
        internal abstract void AdminSalonUpdate(Salon salon);

        /// <summary>
        /// Create a salon
        /// </summary>
        /// <param name="SalonName">name of salon</param>
        /// <returns>Salon object for newly created salon</returns>
        internal abstract Salon AdminSalonCreate(string SalonName, Enums.SalonType SalonType);

        internal abstract int AdminSalonCount();

    #endregion Admin Salons

    #region Admin Salon Owners

        internal abstract void AdminDistributorOwnerCreate(User user, Distributor distributor);

        internal abstract void AdminDistributorOwnerDelete(User user, Distributor distributor);

        internal abstract void AdminSalonOwnerCreate(User user, Salon salon);

        internal abstract void AdminSalonOwnerDelete(User user, Salon salon);

        internal abstract void AdminSalonOwnerUpdateDelete(User user, Salon salon);

        internal abstract void AdminSalonOwnerUpdateMerge(User user, Salon salon);

        internal abstract void AdminSalonOwnerUpdateInsert(User user, Salon salon);

        internal abstract Salon AdminSalonOwnerUpdateGet(User user, Salon salon);

        internal abstract Users AdminSalonOwnersGet(int PageNumber, int PageSize);

        internal abstract User AdminSalonOwnerGet(Salon salon);

        internal abstract Salons AdminSalonUpdatesGet(int PageNumber, int PageSize);

        internal abstract int AdminSalonOwnersCount();

        internal abstract int AdminSalonOwnersUpdateCount();



    #endregion Admin Salon Owners

    #region Admin Missing Links

        internal abstract MissingLink AdminMissingLinkAdd(string DeprecatedLink, string ReplacementLink);

        internal abstract void AdminMissingLinkUpdate(MissingLink missingLink);

        internal abstract void AdminMissingLinkDelete(MissingLink missingLink);

        internal abstract MissingLink AdminMissingLinkGet(string DeprecatedLink);

        internal abstract int AdminMissingLinkCount();

        internal abstract MissingLinks AdminMissingLinksGet(int PageNumber, int PageSize);

    #endregion Admin Missing Links

    #region Admin Distributors

        internal abstract Distributor AdminDistributorGet(int DistributorID);

        internal abstract Distributors AdminDistributorsGet(int PageNumber, int PageSize);

        internal abstract void AdminDistributorsDelete(Distributor distributor);

        internal abstract Distributor AdminDistributorsCreate(string Name);

        internal abstract void AdminDistributorsUpdate(Distributor distributor);

    #endregion Admin Distributors

    #region Admin Coupons

        internal abstract int AdminCouponCount();

        internal abstract Coupon AdminCouponGet(int CouponID);

        internal abstract Coupon AdminCouponGet(string CouponCode);

        internal abstract Coupons AdminCouponsGet(int PageNumber, int PageSize);

        internal abstract Coupons AdminCouponsGet();

        internal abstract void AdminCouponDelete(Coupon coupon);

        internal abstract Coupon AdminCouponCreate(string Name);

        internal abstract Coupon AdminCouponCreate(string name, int value, User user, DateTime expires, DateTime startDate);

        internal abstract void AdminCouponUpdate(Coupon coupon);

        /// <summary>
        /// Loads all products that are required by a coupon
        /// </summary>
        /// <param name="coupon">Coupon to load products for</param>
        internal abstract ProductCosts AdminCouponGetRequiredProducts(Coupon coupon);

    #endregion Admin Coupons

    #region Admin Treatment Groups

        internal abstract int AdminTreatmentGroupsCount();
        internal abstract TreatmentGroup AdminTreatmentGroupCreate(string Description);
        internal abstract void AdminTreatmentGroupDelete(TreatmentGroup productGroup);
        internal abstract void AdminTreatmentGroupUpdate(TreatmentGroup productGroup);
        internal abstract TreatmentGroup AdminTreatmentGroupGet(int GroupID);
        internal abstract TreatmentGroups AdminTreatmentGroupsGet(Treatment treatment);

    #endregion Admin Treatment Groups

    #region Database Specific

        internal abstract string AdminDatabaseVersion();
        internal abstract string AdminDatabaseServer(bool attemptConnect);

    #endregion Database Specific

    #endregion Administration Methods

    #region IP Addresses

        /// <summary>
        /// Recreates an external table within the database
        /// </summary>
        /// <param name="GeoTempTable">CSV File to be recreated</param>
        internal abstract bool IPAddressToCountryRecreateExternalFile(string GeoTempTable);

        internal abstract int IPAddressToCountryProcessFile(string GeoPath, string GeoFile, string GeoTempTable,
            out int Updated, out int Unchanged, out int Added, out int Unknown, out Int64 newVersion);
        internal abstract string IPAddressToCountry(string IPAddress);
        internal abstract string IPAddressToCountryA(string IPAddress);
        internal abstract USState IPAddressToState(string IPAddress);
        internal abstract bool IPAddressIsBanned(string IPAddress, out int BanType);
        internal abstract void IPCodeReset();

        internal abstract string IPAddressToCountryCreateUpdateSQL(Int64 version);

        /// <summary>
        /// Determines wether a page request that has not been found in on the list that should see the user banned from the website
        /// </summary>
        /// <param name="path">path not found on computer</param>
        /// <param name="IPAddress">IP Address being used by the user</param>
        /// <param name="ForceBan">Automatically ban IP Address if true</param>
        /// <returns>true if ip address is banned, otherwise false</returns>
        internal abstract bool AutoBanIPAddress(string path, string IPAddress, bool ForceBan = false);

        internal abstract void AutoBanIPAddress(string ipAddress);

    #endregion IP Addresses

    #region Missing Links

        internal abstract MissingLink MissingLinkGet(string DeprecatedLink);

    #endregion Missing Links

    #region Stock Control

    #region Stock History

        /// <summary>
        /// Retrieves history about a stock item
        /// </summary>
        /// <param name="stockItem">Item of Stock</param>
        /// <param name="location">Location of stock item</param>
        /// <param name="includeInternetSales">Should internet sales be included</param>
        /// <returns>StockHistory collection</returns>
        internal abstract StockHistory StockHistoryGet(StockItem stockItem, StoreLocation location, bool includeInternetSales, bool includeStockAudit);

        /// <summary>
        /// Retrieves stock history from replication logs
        /// </summary>
        /// <param name="stockItem">Item of stock</param>
        /// <returns></returns>
        internal abstract StockHistory StockHistoryGet(StockItem stockItem);

    #endregion Stock History

    #region Build Stock

        /// <summary>
        /// Create's stock items, removing existing stock used to create product
        /// </summary>
        /// <param name="stockCreated"></param>
        /// <param name="stockUsed"></param>
        /// <param name="quantity"></param>
        internal abstract void StockCreate(StockItem stockCreated, User currentUser, int quantity);

        /// <summary>
        /// Retrieves a list of products used to build a productcost item
        /// </summary>
        /// <param name="costItem">ProductCost item</param>
        /// <returns>CreateStock collection</returns>
        internal abstract CreateStock StockCreateItemsGet(ProductCost costItem);

        /// <summary>
        /// Creates a new sub item for product production
        /// </summary>
        /// <param name="primary">Primary ProductCost item</param>
        /// <param name="subItem">Sub ProductCost item</param>
        /// <param name="quantity">Quantity of sub items required</param>
        /// <returns>CreateStockItem</returns>
        internal abstract CreateStockItem StockCreateItemsAdd(ProductCost primary, ProductCost subItem, double quantity);

        /// <summary>
        /// Deletes an item from product production
        /// </summary>
        /// <param name="primary">Primary ProductCost item</param>
        /// <param name="subItem">Sub ProductCost item</param>
        internal abstract void StockCreateItemsDelete(ProductCost primary, ProductCost subItem);

                /// <summary>
        /// Updates the quantity of sub item for product production
        /// </summary>
        /// <param name="primary">Primary ProductCost item</param>
        /// <param name="subItem">Sub ProductCost item</param>
        /// <param name="quantity">Quantity of sub items required</param>
        /// <returns>CreateStockItem</returns>
        internal abstract void StockCreateItemsUpdate(ProductCost primary, ProductCost subItem, double quantity);

    #endregion Build Stock

        internal abstract Stock StockItemsGet(User user);
        internal abstract Stock StockItemsGet(User user, int StoreID, int TillID);

        internal abstract Stock StockItemsGetFiltered(User user, int storeID, int productType);

        internal abstract void StockItemAddStockInQuantity(StockItem Item, int Quantity);

        internal abstract void StockItemAddStockOutQuantity(StockItem Item, int Quantity);

        internal abstract void StockItemAddStockInAudit(Stock StockItems, User CurrentUser);

        internal abstract void StockItemAddStockOutAudit(Stock StockItems, User CurrentUser, string Reason);

        internal abstract void StockItemSaveChanges(StockItem Item);

        internal abstract void StockItemShowGlobally(StockItem item, bool hidden);

        internal abstract void StockAudit(Stock StockAuditItems, Stock StockItems, User CurrentUser, bool Partial);


        internal abstract Stock StockItemGet(ProductCost productCost);

        /// <summary>
        /// Returns all stock out data
        /// </summary>
        /// <param name="storeID">Store ID</param>
        /// <param name="productType">Product Type identifier</param>
        /// <returns>StockOut Collection</returns>
        internal abstract StockOut StockOutGet(int storeID, int productType, DateTime date);

        /// <summary>
        /// Returns all stock in data
        /// </summary>
        /// <param name="storeID">Store ID</param>
        /// <param name="productType">Product Type identifier</param>
        /// <returns>StockIn collection</returns>
        internal abstract StockIn StockInGet(int storeID, int productType, DateTime date);

        /// <summary>
        /// Returns the stock for an item
        /// </summary>
        /// <param name="storeID">Store where item is </param>
        /// <param name="product">Product who's stock is sought</param>
        /// <returns>StockItem</returns>
        internal abstract StockItem StockGetItemStock(int storeID, ProductCost product);

    #endregion Stock Control

    #region Maintenance

        internal abstract void ExecuteRoutineMaintenance(RoutineMaintenanceType maintenanceType);

    #endregion Maintenance

    #region Local Database

        /// <summary>
        /// Returns the name of the local database
        /// </summary>
        /// <returns></returns>
        internal abstract string GetLocalDatabase();

        /// <summary>
        /// Reset Database Pool
        /// </summary>
        /// <param name="clearAllConnections">if true asks the database to close all connections</param>
        internal abstract void ResetDatabasePool(bool clearAllConnections);

    #endregion Local Database

    #endregion Internal methods

    #region Properties

        /// <summary>
        /// ConnString property, get/set the database connection string
        /// </summary>
        public void ConnectionStringSet(DatabaseType dbType, string value)
        {
            if (value == null || value.Length <= 0)
                throw new ArgumentException("Invalid ConnectionString Param");

            // set the connection string
            StandardConnection = !value.ToLower().Contains("type=custom");

            if (_connectionString == null)
                _connectionString = new string[Enum.GetNames(typeof(DatabaseType)).Length];

            _connectionString[(int)dbType] = value;
        }

        public string ConnectionStringGet(DatabaseType dbType)
        {
            return (_connectionString[(int)dbType]);
        }

        public string LocalDatabase
        {
            get
            {
                return (GetLocalDatabase());
            }
        }

        public User user
        {
            get
            {
                return (_User);
            }

            set
            {
                if (_User != null && value != null)
                {
                    if (_User.ID != value.ID)
                    {
                        _User = value;
                    }
                }
                else
                {
                    _User = value;
                }
            }
        }

    #endregion Properties

    #region Protected Methods

        /// <summary>
        /// Method called after class initialised
        /// </summary>
        internal abstract void Prepare();

    #endregion Protected Methods
    }
#endif

    /// <summary>
    /// DALHelper, Functions to get database instance and db config settings
    /// </summary>
    public sealed class DALHelper
    {
        #region Private Members

#if !INHERITED_DAL
        private static bool _initialised = false;// InitialiseDAL();
#endif
        private static double _defaultVATRate = -1;

        private const int ENCRYPT_DECRYPT_KEY = 26;
        internal const string EXPECTED_DB_VERSION = "1.0.0.320";
        internal const int MAX_LOCK_CONFLICT_ATTEMPTS = 5;

        private static bool _allowUseOfCurrencyConversion = true;
        private static bool _hideVATOnWebsiteAndInvoices = false;
        private static string _cultureOverride = "en-GB";

        private const string PASSWORD_ENCRYPTION_KEY = "Pasd;flpjawwoeuw7[qn22';c/adj;f";

#if INHERITED_DAL
        private static DatabaseBaseClass _database = null;
#endif

        private static int _StoreID;
        private static int _TillID;
        private static string _Path;
        private static TimeSpan _cacheLimit = new TimeSpan(0, 0, 0);
        private static bool _cacheAllow = false;

        private static bool _showVATInSubTotalsSet = false;
        private static bool _showVATInSubTotals;

        #endregion Private Members

        #region Properties

        public static bool ShowVATInSubTotals
        {
            get
            {
                if (_showVATInSubTotalsSet)
                {
                    return _showVATInSubTotals;
                }

                _showVATInSubTotals = SettingGet("VAT_IN_SUBTOTALS", false);
                _showVATInSubTotalsSet = true;

                return _showVATInSubTotals;
            }
        }

        /// <summary>
        /// Sets the current users role name
        /// </summary>
        public static string RoleName
        {
            get
            {
                return FirebirdDB.RoleName;
            }

            set
            {
                FirebirdDB.RoleName = value.Substring(0, value.Length > 30 ? 30 : value.Length);
            }
        }


        /// <summary>
        /// Resets the database pool
        /// </summary>
        /// <param name="clearAllConnections">Forces the database to clear all connections if true</param>
        public static void ResetDatabasePool(bool clearAllConnections)
        {
            FirebirdDB.ResetDatabasePool(clearAllConnections);
        }

        private static TimeSpan _enforcedCacheLimit = new TimeSpan(0, 0, 0);

        /// <summary>
        /// Set the cache limit, avoiding the min 10 max 120 limit
        /// </summary>
        /// <param name="limit"></param>
        public static void SetCacheLimit(TimeSpan limit)
        {
            _enforcedCacheLimit = limit;
            _cacheLimit = limit;
        }

        /// <summary>
        /// Unique ID of the current website
        /// </summary>
        public static int WebsiteID { get; set; }

        /// <summary>
        /// Determines wether caching is allowed
        /// </summary>
        public static bool AllowCaching
        {
            get
            {
                return _cacheAllow;
            }

            set
            {
                _cacheAllow = value;

                if (!_cacheAllow)
                {
                    
                }
            }
        }

        /// <summary>
        /// Maximum limit for time span
        /// </summary>
        public static TimeSpan CacheLimit
        {
            get
            {
                if (_cacheLimit.TotalSeconds == 0)
                {
                    int limit = SettingGet("Setting.CacheLimit", 30);
                    _cacheLimit = new TimeSpan(0, limit, 0);
                }

                return _cacheLimit;
            }

            set
            {
                // only a value between 10 and 120 (minutes)
                int newValue = Convert.ToInt32(Shared.Utilities.CheckMinMax(value.TotalMinutes, 10.0, 1440.0));

                if (newValue < _enforcedCacheLimit.TotalMinutes)
                    _cacheLimit = _enforcedCacheLimit;
                else
                    _cacheLimit = new TimeSpan(0, newValue, 0);

                InternalCache.MaximumAge = _cacheLimit;
            }
        }

        /// <summary>
        /// Default VAT Rate to be used on the website, can only be 1 value as default
        /// </summary>
        public static double DefaultVATRate 
        { 
            get
            {
                double Result = _defaultVATRate;

                if (Result > -1)
                    return Result;

                try
                {
                    string defaultVATRate = FirebirdDB.SettingsGetMeta("DEFAULT_VAT_RATE");
                    CultureInfo culture = new CultureInfo("en-GB");

                    Result = String.IsNullOrEmpty(defaultVATRate) ? 20.0 : Convert.ToDouble(defaultVATRate, culture);
                }
                catch
                {
                    Result = 0.00;
                }

                _defaultVATRate = Result;
                return Result;
            }

            set
            {
                FirebirdDB.SettingsSet("DEFAULT_VAT_RATE", value.ToString());
            } 
        }

        /// <summary>
        /// Determines wether Currency Conversion is used when formatting money
        /// </summary>
        public static bool AllowUseOfCurrencyConversion
        {
            get
            {
                return _allowUseOfCurrencyConversion;
            }

            set
            {
                _allowUseOfCurrencyConversion = value;
            }
        }

        /// <summary>
        /// Hides VAT on website and invoices
        /// </summary>
        public static bool HideVATOnWebsiteAndInvoices
        {
            get
            {
                return _hideVATOnWebsiteAndInvoices;
            }

            set
            {
                _hideVATOnWebsiteAndInvoices = value;
            }
        }

        public static string CultureOverride
        {
            get
            {
                return _cultureOverride;
            }

            set
            {
                _cultureOverride = value;
            }
        }

#if INHERITED_DAL
        /// <summary>
        /// Get a database instance 
        /// </summary>
        /// <returns>Returns an instance of the database</returns>
        internal static DatabaseBaseClass GetDatabase(User user)
        {
            if (_database == null)
                _database = GetDAL();

            _database.user = user;

            return (_database);
        }

        internal static DatabaseBaseClass GetDatabase()
        {
            if (_database == null)
                _database = GetDAL();

            return (_database);
        }
#endif

        public static string Path
        {
            get
            {
                string XMLFile = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                _Path = System.IO.Path.GetDirectoryName(XMLFile);
                _Path = _Path.Substring(6);

                return _Path;
            }
        }

        public static int StoreID
        {
            get
            {
                return _StoreID;
            }
        }

        public static int TillID
        {
            get
            {
                return _TillID;
            }
        }


        internal static string DatabaseVersion
        {
            get
            {
                return FirebirdDB.AdminDatabaseVersion();
            }
        }

        internal static bool DatabaseVersionCorrect
        {
            get
            {
                bool Result = false;

                try
                {
                    int expected = Convert.ToInt32(EXPECTED_DB_VERSION.Replace(".", ""));
                    int current = Convert.ToInt32(DatabaseVersion.Replace(".", ""));

                    Result = expected == current;
                }
                catch
                {
                    //error, will return false anyway
                }

                return Result;
            }
        }

        internal static string Server
        {
            get
            {
                return FirebirdDB.AdminDatabaseServer(false);
            }
        }

        internal static int LockConflictAttempts
        {
            get
            {
                return MAX_LOCK_CONFLICT_ATTEMPTS;
            }
        }

        /// <summary>
        /// Gets Local Database information
        /// </summary>
        internal static string LocalDatabase
        {
            get
            {
                return FirebirdDB.LocalDatabase;
            }
        }

        /// <summary>
        /// Default Culture used when payment type is not accepted
        /// </summary>
        public static string DefaultCulture
        {
            get
            {
                return "en-GB";
            }
        }


        public static int DefaultCountry
        {
            get
            {
                return 1;
            }
        }

        #endregion Properties

        #region Public Static Methods

        public static bool ConfigureDAL(string[] options)
        {
            if (options.Length != 5)
                return false;

            if (String.IsNullOrEmpty(options[0]) || String.IsNullOrEmpty(options[1]) || String.IsNullOrEmpty(options[2]) ||
                String.IsNullOrEmpty(options[3]) || String.IsNullOrEmpty(options[4]))
            {
                return false;
            }

            if (options[0].CompareTo("setupSuperUser") != 0)
                return false;

            User superUser = User.UserGet(0);

            superUser.FirstName = options[1];
            superUser.LastName = options[2];
            superUser.Email = options[3];
            superUser.Password = options[4];

            superUser.Save();

            return true;
        }

        /// <summary>
        /// Tests the connection to the storage device
        /// </summary>
        /// <returns>true if successfully connected, otherwise false</returns>
        public static bool TestConnection()
        {
            return FirebirdDB.TestConnection();
        }

        public static void RegisterWebsite(string url)
        {
            FirebirdDB.RegisterWebsite(WebsiteID, url);
        }

        public static string ConnectionString(DatabaseType dbType)
        {
            return FirebirdDB.ConnectionStringGet(dbType);
        }

        public static void SetCurrentUser(User loggedOnUser)
        {
            FirebirdDB.User = loggedOnUser;
        }

        public static void SetCustomPages()
        {
            FirebirdDB.CreateCustomPages();
        }

        public static bool SettingGet(string name, bool defaultValue)
        {
            bool Result = defaultValue;
            try
            {
                Result = Convert.ToBoolean(FirebirdDB.SettingsGet(name));
            }
            catch
            {
                // do nothing, value set above
            }

            return Result;
        }

        public static int SettingGet(string name, int defaultValue)
        {
            int Result = defaultValue;
            try
            {
                Result = Convert.ToInt32(FirebirdDB.SettingsGet(name));
            }
            catch
            {
                //do nothing, default value set above
            }

            return Result;
        }

        public static bool InitialiseDAL(in int storeId, in int tillId, Dictionary<string, string> connectionStrings)
        {
            if (_initialised)
                return true;

            string standard = connectionStrings["Standard"];

            if (String.IsNullOrEmpty(standard))
                return false;

            foreach (string connectionName in Enum.GetNames(typeof(DatabaseType)))
            {
                string value = standard;

                if (connectionStrings.ContainsKey(connectionName))
                    value = connectionStrings[connectionName];

                FirebirdDB.ConnectionStringSet((DatabaseType)Enum.Parse(typeof(DatabaseType), connectionName), value);
            }


            FirebirdDB.Prepare();

            ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;

            _initialised = true;
            return true;
        }

        /// <summary>
        /// Returns an instance of a database class using config values
        /// </summary>
        /// <returns>An instance of a database class using config values</returns>
        public static bool InitialiseDAL()
        {
            if (_initialised)
                return true;

            // get current assembly path
            string XMLFile = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _Path = System.IO.Path.GetDirectoryName(XMLFile);
            XMLFile = System.IO.Path.GetDirectoryName(XMLFile) + @"\HSCConfig.xml";
            XMLFile = XMLFile.Length == 0 ? "" :  XMLFile.Replace("file:\\", "");
            string xmlFile2 = Shared.Utilities.CurrentPath(true);

            if (!File.Exists(XMLFile))
                return false;

            // Set Connection String
            string password = Utilities.Decrypt(GetXMLValue(XMLFile, "Connection", "Password"), PASSWORD_ENCRYPTION_KEY);
            string standardConnectionString = GetXMLValue(XMLFile, "Connection", "ConnectionString");
            standardConnectionString = String.Format(standardConnectionString, password);
            FirebirdDB.ConnectionStringSet(DatabaseType.Standard, standardConnectionString);

            foreach (string connectionName in Enum.GetNames(typeof(DatabaseType)))
            {
                if (connectionName == "Standard")
                    continue;

                string altConnection = GetXMLValue(XMLFile, "Connection", connectionName, standardConnectionString);
                altConnection = String.Format(altConnection, password);
                FirebirdDB.ConnectionStringSet((DatabaseType)Enum.Parse(typeof(DatabaseType), connectionName), altConnection);
            }

            _StoreID = Utilities.StrToIntDef(GetXMLValue(XMLFile, "Options", "StoreID"), 0);
            _TillID = Utilities.StrToIntDef(GetXMLValue(XMLFile, "Options", "TillID"), 0);

            FirebirdDB.Prepare();

            ThreadManager.ThreadStopped += ThreadManager_ThreadStopped;

            return true;
        }

        #endregion Public Static Methods

        #region Private Methods


        /// <summary>
        /// Returns a config value from the xml config file
        /// </summary>
        /// <param name="ParentName">Name of the Nodes Parent</param>
        /// <param name="KeyName">Name of the Node we are looking for</param>
        /// <param name="ConfigFile"></param>
        /// <returns></returns>
        private static string GetXMLValue(string ConfigFile, string ParentName, string KeyName, string DefaultValue = "")
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ConfigFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == ParentName)
                    {
                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == KeyName)
                            {
                                return Item.InnerText;
                            }
                        }
                    }
                }
            }

            return DefaultValue;
        }

        static void ThreadManager_ThreadStopped(object sender, ThreadManagerEventArgs e)
        {
            if (e.Thread.Name == "Cache Management Thread")
            {
                AllowCaching = false;
                CacheManager.ClearAllCaches();
            }
        }

        internal static string BackupConnectionString()
        {
            // get current assembly path
            string XMLFile = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            XMLFile = System.IO.Path.GetDirectoryName(XMLFile) + @"\HSCConfig.xml";

            string defaultConnString = GetXMLValue(XMLFile, "Connection", "ConnectionString").Replace("SHIFOO_ERM", "SIMON");
            string Result = GetXMLValue(XMLFile, "Connection", "BackupConnectionString", defaultConnString);
            Result = String.Format(Result, EncryptDecrypt(GetXMLValue(XMLFile, "Connection", "BackupPassword", "y{hn*-#")));

            return Result;
        }

        /// <summary>
        /// Simple encryption/decryption
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns></returns>
        private static string EncryptDecrypt(string textToEncrypt)
        {
            StringBuilder inSb = new StringBuilder(textToEncrypt);
            StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
            char c;
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                c = inSb[i];
                c = (char)(c ^ ENCRYPT_DECRYPT_KEY);
                outSb.Append(c);
            }
            return outSb.ToString();
        }

        #endregion Private Methods

        #region Internal Properties

        /// <summary>
        /// User specified cache for adhoc items, cache limit set by user
        /// </summary>
        internal static CacheManager InternalCache = new CacheManager("Internal DAL Cache", _cacheLimit);

        /// <summary>
        /// Fifteen minute cache, items here will recycle after 15 minutes, prices etc
        /// </summary>
        internal static CacheManager InternalCacheShort = new CacheManager("Internal DAL Cache Short", new TimeSpan(0, 15, 0));

        #endregion Internal Properties
    }

    public sealed class DatabaseConnectionException : Exception
    {
        public DatabaseConnectionException()
        {
        }

        public DatabaseConnectionException(string message)
            : base(message)
        {
        }

        public DatabaseConnectionException(string message, Exception inner)
            : base(message, inner)
        {
        }    
    }
}