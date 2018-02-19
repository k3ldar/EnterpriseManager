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
 *  File: XMLStatic.cs
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

using Library.BOL.Basket;
using Library.BOL.StockControl;
using Library.BOL.Users;
using Library.BOL.SEO;

using Shared.Classes;

namespace Library.DAL
{
#if INHERITED_DAL
    internal class XMLStatic : DatabaseBaseClass
    {
    #region Private Members

        private string _xmlConfigFile;

    #endregion Private Members

        internal override bool TestConnection()
        {
            return (System.IO.File.Exists(_xmlConfigFile));
        }

    #region Currencies

        /// <summary>
        /// Get's an individual currency code
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        internal override Currency CurrenciesGetCurrency(string currencyCode)
        {
            Currency Result = null;

            return (Result);
        }

        internal override Currency CurrenciesGetCulture(System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all currencies
        /// </summary>
        /// <returns></returns>
        internal override Currencies CurrenciesGetAll()
        {
            Currencies Result = new Currencies();


            return (Result);
        }

    #endregion Currencies

    #region Internal Overridden Methods

        internal override BOL.Products.ProductCosts DiscountedProducts()
        {
            throw new NotImplementedException();
        }

        internal override void ThrowInternalError(string one, object two, int three, double four, object five)
        {
            throw new NotImplementedException();
        }

        internal override bool LicenceValid(long licenceID, string domain, int licenceType)
        {
            throw new NotImplementedException();
        }

        internal override int LicenceCount(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Licencing.Licences LicenceGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void LicenceSave(BOL.Licencing.Licence licence)
        {
            throw new NotImplementedException();
        }

        internal override void LicenceCreateTrial(Shared.LicenceType licenceType, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.CashDrawer.CashDenominations CashDenominationsGet(BOL.Countries.Country country)
        {
            throw new NotImplementedException();
        }

        internal override Dictionary<string, string> MailListSubscribers()
        {
            throw new NotImplementedException();
        }

        internal override void MailListSubscribe(string name, string email)
        {
            throw new NotImplementedException();
        }

        internal override bool MailListUnsubscribe(string email, string reason)
        {
            throw new NotImplementedException();
        }

        internal override void ValidationCheckAdd(BOL.Users.User user, ValidationReasons checkType, string reason)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Accounts.PaymentStatuses PaymentStatusesGet()
        {
            throw new NotImplementedException();
        }

        internal override void CreateCustomPages()
        {
            //throw new NotImplementedException();
        }

        internal override BOL.CustomWebPages.CustomPages CustomPagesGet(int websiteID)
        {
            throw new NotImplementedException();
        }

        internal override void CustomPageUpdate(BOL.CustomWebPages.CustomPage page)
        {
            throw new NotImplementedException();
        }

        internal override BOL.CustomWebPages.CustomPage CustomPageGet(string title, BOL.Countries.Country country, CustomPagesType pageType, int webSiteID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.CustomWebPages.CustomPage CustomPageGet(BOL.Countries.Country country, BOL.Products.Product product, CustomPagesType pageType)
        {
            throw new NotImplementedException();
        }

        internal override void SystemEmailSave(BOL.Mail.SystemEmail email)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Mail.SystemEmails SystemEmailGet()
        {
            throw new NotImplementedException();
        }

        internal override void ProductNotificationAdd(BOL.Products.ProductCost item, string email)
        {
            throw new NotImplementedException();
        }

        internal override void ProductNotificationRemove(BOL.Products.ProductCost item, string email)
        {
            throw new NotImplementedException();
        }

        internal override bool ProductNotificationExists(BOL.Products.ProductCost item, string email)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Distributors.WebsiteDistributors WebsiteDistributorsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.POSInstall.POSInstall POSInstallerAdd(string email, string password, string computerName, string serverName, string installType)
        {
            throw new NotImplementedException();
        }

        internal override BOL.POSInstall.POSInstall POSInstallerServers(string email, string password)
        {
            throw new NotImplementedException();
        }

        internal override bool POSInstallValid(string storeID)
        {
            throw new NotImplementedException();
        }

        internal override void RegisterUserForCompetition(string firstName, string lastName, string email, string password, DateTime dateOfBirth, bool receiveUpdates, BOL.Countries.Country country, BOL.Campaigns.Campaign campaign)
        {
            throw new NotImplementedException();
        }

        internal override BOL.TagLines.TagLines TagLinesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.TagLines.TagLine TagLineCreate(string text)
        {
            throw new NotImplementedException();
        }

        internal override void TagLineDelete(BOL.TagLines.TagLine tagLine)
        {
            throw new NotImplementedException();
        }

        internal override void TagLineSave(BOL.TagLines.TagLine tagLine)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Search.Search SearchSubmit(MemberLevel memberLevel, string terms, bool useAND)
        {
            throw new NotImplementedException();
        }

        internal override void TrainingCourseSave(BOL.Training.Course course)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.Attendees TrainingCourseAttendeesGet(BOL.Training.Course course)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.TrainingCourse TrainingCourseGet(int id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.TrainingCourses TrainingCourseGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.Courses TrainingCoursesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.Course TrainingCoursesGet(long id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Training.Course TrainingCoursesCreate(BOL.Appointments.Appointment appointment, BOL.Training.TrainingCourse course, BOL.Therapists.Therapist trainer)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Locations.Locations StoreLocationsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Locations.StoreLocation StoreLocationGet(int id)
        {
            throw new NotImplementedException();
        }

        internal override void SplitPaymentAdd(BOL.Orders.Order order, decimal cash, decimal cheque, decimal card, decimal vouchers)
        {
            throw new NotImplementedException();
        }

        internal override void WebHackingConnection(string ipAddress, string data, ulong request, DateTime created, DateTime lastEntry, int results, string location, string userAgent)
        {
            throw new NotImplementedException();
        }

        internal override void CashDrawerSubmit(BOL.Users.User user, string checkType, CashDrawerType type, string notes, int Pound500, int Pound100, int Pound50, int Pound20, int Pound10, int Pound5, int Pound2, int Pound1, int Pence50, int Pence20, int Pence10, int Pence5, int Pence2, int Pence1)
        {
            throw new NotImplementedException();
        }

        internal override bool CashDrawerDailyStartComplete(CashDrawerType type)
        {
            throw new NotImplementedException();
        }

        internal override bool CashDrawer10MinuteCheck()
        {
            throw new NotImplementedException();
        }

        internal override string CashDrawerVerify(int storeID, BOL.Countries.Country country, Currency currency, DateTime date, CashDrawerType type)
        {
            throw new NotImplementedException();
        }

        internal override BOL.HashTags.HashTags HashTagsGet(string PageName)
        {
            return (null);
        }

        internal override BOL.HashTags.HashTags HashTagsGet()
        {
            throw new NotImplementedException();
        }

        internal override void HashTagAdd(BOL.HashTags.HashTag tag, string pageName)
        {
            throw new NotImplementedException();
        }

        internal override void HashTagRemove(BOL.HashTags.HashTag tag, string pageName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.HashTags.HashTag HashTagCreate(string tagName)
        {
            throw new NotImplementedException();
        }

        internal override decimal RedeemVoucher(string voucherCode, BOL.Users.User user, bool validateOnly)
        {
            throw new NotImplementedException();
        }

        internal override void SellVoucher(string voucherCode, decimal value, BOL.Users.User user, bool validateOnly)
        {
            throw new NotImplementedException();
        }

        internal override void CreateVoucher(string VoucherCode, decimal value)
        {
            throw new NotImplementedException();
        }

        internal override void SellVouchers(BOL.Vouchers.Vouchers vouchers)
        {
            throw new NotImplementedException();
        }

        internal override void VouchersMarkAllAsSold(BOL.Users.User currentUser)
        {
            throw new NotImplementedException();
        }

        internal override void VoucherMarkAsUnsold(BOL.Users.User currentUser, string voucherCode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Vouchers.Voucher VoucherGet(string voucherCode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentGroups AppointmentGroupsGet()
        {
            throw new NotImplementedException();
        }

        internal override long RefundCreate(BOL.Users.User client, BOL.Users.User employee, BOL.Invoices.Invoice invoice, decimal refundAmount, string reason)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Refunds.Refunds RefundsGet(DateTime From, DateTime To)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsPOS PermissionsGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSet(BOL.Users.User user, SecurityEnums.SecurityPermissionsPOS permissions)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsReports PermissionsGetReports(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetReports(BOL.Users.User user, SecurityEnums.SecurityPermissionsReports permissions)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsCalendar PermissionsGetCalendar(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetCalendar(BOL.Users.User user, SecurityEnums.SecurityPermissionsCalendar permissions)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsAccounts PermissionsGetAccounts(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetAccounts(BOL.Users.User user, SecurityEnums.SecurityPermissionsAccounts permissions)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsWebsite PermissionsGetWebsite(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetWebsite(BOL.Users.User user, SecurityEnums.SecurityPermissionsWebsite permissions)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetStock(BOL.Users.User user, SecurityEnums.SecurityPermissionsStockControl permissions)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsStockControl PermissionsGetStock(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override bool CampaignsCanSetReplication()
        {
            throw new NotImplementedException();
        }

        internal override void CampaignSendTestEmail(BOL.Users.User user, string SenderName, string SenderEmail, string Message, string Subject, string CampaignName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Campaigns.Campaigns CampaignsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Campaigns.Campaigns CampaignsGetWizard()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Campaigns.Campaigns CampaignGet(BOL.Countries.Country currentCountry)
        {
            return (null);
        }

        internal override BOL.Campaigns.Campaign CampaignGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Campaigns.Campaign CampaignGet(string CampaignName)
        {
            throw new NotImplementedException();
        }

        internal override void CampaignSave(BOL.Campaigns.Campaign campaign)
        {
            throw new NotImplementedException();
        }

        internal override void CampaignDelete(BOL.Campaigns.Campaign campaign)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Campaigns.Campaign CampaignCreate(string campaignName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.KBGroups FAQGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.KBGroups FAQGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.KBGroups FAQGet(BOL.Users.User user, BOL.Helpdesk.KBGroup parent)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.KBGroup FAQGet(BOL.Users.User user, int parent)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.KBGroup FAQGetParent(BOL.Helpdesk.KBGroup child)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.FAQItems FAQItemsGet(BOL.Helpdesk.KBGroup parent)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.FAQItem FAQItemGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.FAQItem FAQItemCreate()
        {
            throw new NotImplementedException();
        }

        internal override void FAQItemSave(BOL.Helpdesk.FAQItem item)
        {
            throw new NotImplementedException();
        }

        internal override void FAQItemDelete(BOL.Helpdesk.FAQItem item)
        {
            throw new NotImplementedException();
        }

        internal override int FAQItemGetCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.FAQItems FAQItemsGet(int Page, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override void FAQItemSetViewCount(BOL.Helpdesk.FAQItem item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.Updates DatabaseUpdatesGet(string TableName, string Key)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.Updates DatabaseDeletesGet(string TableName, string ColumnName, string Key)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.Updates DatabaseWebLogGet(string Session)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.Updates DatabaseWebLogGetIP(string IPAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Downloads.Download DownloadCreate(string FileName, string Description)
        {
            throw new NotImplementedException();
        }

        internal override void DownloadDelete(BOL.Downloads.Download download)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Downloads.Downloads DownloadsGet(int PageSize, int PageNumber, int DownloadType)
        {
            throw new NotImplementedException();
        }

        internal override int DownloadCount(int DownloadType, bool isActive)
        {
            throw new NotImplementedException();
        }

        internal override void DownloadAdd(BOL.Downloads.Download download)
        {
            throw new NotImplementedException();
        }

        internal override BOL.RSS.RSSFeed RSSFeedsGet(Enums.RSSFeedType feedType)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.Clients TradeClientsGet(Enums.ClientState ClientState)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.Client TradeClientGet(long ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.Client TradeClientCreate(string Name, string CompanyName, string Telephone, string Email, string Address, string Postcode, string Notes)
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientNotesAdd(BOL.Trade.Client client, BOL.Users.User user, string Notes, Enums.ClientAction action)
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientNotesAdd(BOL.Trade.Client client, BOL.Users.User user, string notes, BOL.Trade.ClientAction action)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientNotes TradeClientNotesGet(BOL.Trade.Client client)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientNotes TradeClientNotesGet(BOL.Trade.ClientAction action)
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientsAutoLinkAccounts()
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientChangeState(BOL.Trade.Client client, Enums.ClientState state)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientActions TradeClientActionsGet(BOL.Trade.Client client, Enums.ClientAction action)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientActions TradeClientActionsGet(BOL.Trade.Client client)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientAction TradeClientActionGet(BOL.Trade.Client client, Enums.ClientAction action, bool Open)
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientActionsComplete(BOL.Trade.ClientAction clientAction, BOL.Users.User user, string Notes)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.ClientAction TradeClientActionCreate(BOL.Trade.Client client, Enums.ClientAction ActionType)
        {
            throw new NotImplementedException();
        }

        internal override BOL.USAStates.USStates GetUSStates()
        {
            throw new NotImplementedException();
        }

        internal override BOL.USAStates.USState GetUSState(long ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.USAStates.USState GetUSState(string Name)
        {
            throw new NotImplementedException();
        }

        internal override string GetTempStats()
        {
            throw new NotImplementedException();
        }

        internal override string GetCampaignStats(string Campaign)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsInvoiceTotalByMonth(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsInvoiceCountByDay(BOL.Statistics.Statistics statistics, int TotalDays, DateTime StartDate)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsVisitorsByCountry(BOL.Statistics.Statistics statistics, int Count)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsVisitorsByCountryToday(BOL.Statistics.Statistics statistics, int Count)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDate(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateOnline(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateSalon(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateOffice(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateCount(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateTop5Countries(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateTop10Countries(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateTop5Salons(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthtoDateBySalons(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDateBySalonOwners(BOL.Statistics.Statistics statistics, DateTime StartMonth)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsDailyTotals(BOL.Statistics.Statistics statistics, DateTime month, string countryCode)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthlyTotals(BOL.Statistics.Statistics statistics, int year, string countryCode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Takings StatisticsSalesSalonSummary(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Takings StatisticsSalesSalonTreatments(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Takings StatisticsSalesSalonProducts(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsUpdateRedirectHitCount(string url)
        {
            throw new NotImplementedException();
        }

        internal override int StatisticsRedirectGetHitCount(string url)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsTimeLineEventsGet(BOL.Statistics.Statistics statistics)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics StatisticsAppointmentSummary(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public override int VideoCount()
        {
            throw new NotImplementedException();
        }

        public override BOL.Video.Videos VideoGet()
        {
            throw new NotImplementedException();
        }

        public override BOL.Video.Video VideoGet(int ID)
        {
            throw new NotImplementedException();
        }

        public override void VideoUpdate(BOL.Video.Video video)
        {
            throw new NotImplementedException();
        }

        public override void VideoDelete(BOL.Video.Video video)
        {
            throw new NotImplementedException();
        }

        public override int VideoCreate(string description, string reference)
        {
            throw new NotImplementedException();
        }

        public override string ExportIBLMData(long Start)
        {
            throw new NotImplementedException();
        }

        public override int IBLMMaxOperationID()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Celebrities.Celebrities CelebritiesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Celebrities.Celebrity CelebritiesGet(int ID)
        {
            throw new NotImplementedException();
        }

        public override void CelebrityUpdate(BOL.Celebrities.Celebrity celebrity)
        {
            throw new NotImplementedException();
        }

        public override void CelebrityDelete(BOL.Celebrities.Celebrity celebrity)
        {
            throw new NotImplementedException();
        }

        public override int CelebrityCreate(string name, string description, string image)
        {
            throw new NotImplementedException();
        }

        internal override BOL.News.NewsItems NewsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.News.NewsItems NewsGet(int PageSize, int PageNumber)
        {
            throw new NotImplementedException();
        }

        internal override BOL.News.NewsItem NewsGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override int NewsCount()
        {
            throw new NotImplementedException();
        }

        internal override void BackupDatabase(string Path)
        {
            throw new NotImplementedException();
        }

        internal override void EmailQueueStatistics(out long QueueSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Mail.Emails EmailsGet(bool IncludeSentEmail, short MaxSendAttempts)
        {
            throw new NotImplementedException();
        }

        internal override void EmailMarkSent(BOL.Mail.Email email, string sendResult)
        {
            throw new NotImplementedException();
        }

        internal override void EmailRecordSentAttempt(BOL.Mail.Email email, string sendResult)
        {
            throw new NotImplementedException();
        }

        internal override void EmailDeleteSent()
        {
            throw new NotImplementedException();
        }

        internal override long EmailAdd(string ToName, string ToEMail, string FromName,
            string FromEMail, string Subject, string Message)
        {
            return (-1);
        }

        internal override long EmailAdd(MemberLevel memberLevel, bool SendToAboveMemberLevels, string Subject, string Message)
        {
            throw new NotImplementedException();
        }

        internal override long EmailAdd(BOL.Countries.Country Country, string Subject, string Message)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Countries.Countries CountriesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Countries.Country CountryGet(int CountryID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Countries.Country CountryGet(string CountryCode)
        {
            return (null);
        }

        internal override BOL.Countries.Country CountryGet(System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }

        internal override void CountrySet(BOL.Countries.Country country)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Therapists TherapistsGet()
        {
            throw new NotImplementedException();
        }

        internal override int TherapistsAppointments(BOL.Therapists.Therapist therapist, DateTime From, DateTime To, Enums.AppointmentStatus Status)
        {
            throw new NotImplementedException();
        }

        internal override decimal TherapistSales(BOL.Therapists.Therapist therapist, DateTime From, DateTime To, ProductCostItemType Type)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Takings TherapistSales(BOL.Therapists.Therapist therapist, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.TherapistTakings TherapistTakings(BOL.Therapists.Therapist therapist, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Takings TherapistTakingsProducts(BOL.Therapists.Therapist therapist, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        internal override decimal TherapistSales(BOL.Therapists.Therapist therapist, DateTime from, DateTime to, BOL.Accounts.PaymentStatus paymentStatus, bool Totals = true)
        {
            throw new NotImplementedException();
        }

        internal override decimal TherapistRefunds(BOL.Therapists.Therapist therapist, DateTime From, DateTime To)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Therapists TherapistsGet(long TherapistID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Therapist TherapistGet(long TherapistID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Therapists TherapistsGet(bool PublicOnly)
        {
            throw new NotImplementedException();
        }

        internal override void TherapistSave(BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override void TherapistDelete(BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.Therapist TherapistCreate(BOL.Users.User StaffMember)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.WorkingDays TherapistsWorkingDaysGet(BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override void TherapistsWorkingDaysSave(BOL.Therapists.WorkingDay Day)
        {
            throw new NotImplementedException();
        }

        internal override void TherapistsWorkingDaysDelete(BOL.Therapists.WorkingDay Day)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Therapists.WorkingDay TherapistWorkingDaysCreate(BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentUpdate(BOL.Appointments.Appointment appointment, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override long AppointmentCreate(BOL.Appointments.Appointment appointment, BOL.Users.User currentUser)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime Date, long EmployeeID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(BOL.Users.User user, int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime Date)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime StartDate, DateTime EndDate, BOL.Therapists.Therapist Therapist)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointment AppointmentGet(long AppointmentID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(BOL.Appointments.Appointment MasterAppointment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime MinimumDate, BOLEvents.Progress progress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGetNew(long MaxID, DateTime LastChecked)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime AppointmentDate, BOL.Therapists.Therapist therapist, bool ShowCancelledAppointment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime AppointmentDate, bool ShowCancelledAppointment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGet(DateTime AppointmentDateStart, DateTime AppointmentDateFinish, bool ShowCancelledAppointment)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentDeleteChildren(BOL.Appointments.Appointment appointment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.Appointments AppointmentsGetRequested()
        {
            throw new NotImplementedException();
        }

        internal override int AppointmentsGetCount(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.AppointmentHistory AppointmentHistory(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentChanges AppointmentChanges(BOL.Appointments.Appointment appointment)
        {
            throw new NotImplementedException();
        }

        internal override string AppointmentLastChangedBy(BOL.Appointments.Appointment appointment)
        {
            throw new NotImplementedException();
        }

        internal override string AppointmentStatusGet(int AppointmentStatus)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentStatuses AppointmentStatusGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentStatus AppointmentStatusGet(string name)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTreatments AppointmentTreatmentsGet(BOL.Therapists.Therapist therapist, bool activeTreatmentsOnly)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTreatments AppointmentTreatmentsGet(BOL.Users.User user, bool lastTreated = false)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTreatments AppointmentTreatmentsGet()
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentTreatmentsSave(BOL.Appointments.AppointmentTreatments treatments)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentTreatmentCreate(BOL.Appointments.AppointmentTreatment treatment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.SpecialDates SpecialDatesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTreatment AppointmentTreatmentGet(int TreatmentID)
        {
            throw new NotImplementedException();
        }

        internal override bool AppointmentTreatmentContains(BOL.Appointments.AppointmentTreatment apptTreatment, BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentTreatmentSave(BOL.Appointments.AppointmentTreatment apptTreatment)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentTreatmentAdd(BOL.Appointments.AppointmentTreatment apptTreatment, BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override void AppointmentTreatmentRemove(BOL.Appointments.AppointmentTreatment apptTreatment, BOL.Therapists.Therapist therapist)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTypes AppointmentTypesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatments TreatmentSpaDays(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatments TreatmentsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatments TreatmentsGet(int PageNumber, int PageSize, BOL.Treatments.TreatmentGroup group)
        {
            throw new NotImplementedException();
        }

        internal override int TreatmentsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatment TreatmentGet(int ID, bool SpaDay)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.TreatmentGroups TreatmentGroupsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.TreatmentGroup TreatmentGroupGet(int TreatmentGroupID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons SalonsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salon SalonGet(int SalonID)
        {
            throw new NotImplementedException();
        }

        internal override int SalonsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons SalonsFindNearest(string Postcode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons SalonsGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.SalonDiscount SalonDiscountGet(string CouponCode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.SalonDiscount SalonDiscountGet(BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override int TipsTricksCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.TipsTricks.TipsTricks TipsTricksGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.TipsTricks.TipsTrick TipsTrickGet(int TipID)
        {
            throw new NotImplementedException();
        }

        internal override int DistributorsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Distributors.Distributors DistributorsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override string GetPopupData(int PopupID, out string Title)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroupType ProductGroupTypeGet(int id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroupType ProductGroupTypeGet(string name)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroupTypes ProductGroupTypesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductGroupTypesGetProducts(BOL.Products.ProductGroupType groupType)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCostType ProductCostTypeGet(int id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCostType ProductCostTypeGet(string name)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCostTypes ProductCostTypesGet()
        {
            throw new NotImplementedException();
        }

        internal override bool ProductIsValidSKU(string SKU)
        {
            throw new NotImplementedException();
        }

        internal override int ProductsCount(BOL.Products.ProductType primaryProductType)
        {
            throw new NotImplementedException();
        }

        internal override int ProductsCountOffers()
        {
            throw new NotImplementedException();
        }

        internal override int ProductsCountByProduct(int ProductGroup)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Product ProductGetFeatured()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the product associated with a product cost item
        /// </summary>
        /// <param name="productCost">Product Cost Item</param>
        /// <returns></returns>
        internal override BOL.Products.Product ProductGet(BOL.Products.ProductCost productCost)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGetCarousel()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Product ProductGet(long ProductID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGet(BOL.Products.ProductType primaryProductType,
            int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGet(BOL.Celebrities.Celebrity celebrity)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductGetBlackLabel(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGet(BOL.Products.ProductType primaryProductType,
            int PageNumber, int PageSize, bool IncludeCosts)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGet(BOL.Products.ProductType primaryProductType,
            int PageNumber, int PageSize, BOL.Products.ProductGroup ProductGroup)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGetBySKU(string SKU)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products ProductsGetOffers(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroups ProductGroupsGet(MemberLevel MemberLevel)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroups ProductGroupsGet(BOL.Products.ProductGroupType groupType,
            MemberLevel MemberLevel)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroup ProductGroupGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGet(BOL.Products.Product product)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGetFree(BOL.Products.ProductCost product)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGetFreeOffers()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGet(BOL.Products.Product product, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGet(BOL.Products.Product product, BOL.Users.User user, BOL.Countries.Country country)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCosts ProductCostsGet(BOL.Products.Product product, MemberLevel memberLevel)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGetByBarcode(string barcode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGetSKU(string sku)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGet(int ID, MemberLevel memberLevel)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGet(int ID, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost ProductCostGetGiftWrap()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductTypes ProductTypesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductType ProductTypeGet(string name)
        {
            throw new NotImplementedException();
        }

        internal override int BasketGetTotalItems(long BasketID)
        {
            throw new NotImplementedException();
        }

        internal override long BasketGetNextID(int increment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupon BasketValidateCouponCode(string CouponCode)
        {
            throw new NotImplementedException();
        }

        internal override void BasketAddToBasket(long BasketID, long ItemID, int Quantity, ProductCostItemType ItemType, BOL.Users.User user, int priceColumn)
        {
            throw new NotImplementedException();
        }

        internal override void BasketDeleteFromBasket(long BasketID, long ItemID, ProductCostItemType ItemType)
        {
            throw new NotImplementedException();
        }

        internal override void BasketEmpty(long BasketID)
        {
            throw new NotImplementedException();
        }

        internal override void BasketUpdateBasket(long BasketID, BOL.Basket.BasketItem basketItem, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Orders.Order BasketSendEmailForPayment(BOL.Basket.ShoppingBasket basket, BOL.Accounts.PaymentStatus PayMethod, string UserSession, string RemoteHost, Enums.InvoiceVoucherType VoucherType, Currency currency, int version)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Basket.BasketItems BasketItemsGet(BOL.Basket.ShoppingBasket basket)
        {
            throw new NotImplementedException();
        }

        internal override void BasketItemSave(BOL.Basket.ShoppingBasket basket, BOL.Basket.BasketItem item)
        {
            throw new NotImplementedException();
        }

        internal override bool BasketSavedDelete(SavedBasket basket)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Basket.SavedBaskets BasketSavedGet()
        {
            throw new NotImplementedException();
        }

        internal override double GetShippingCosts(string CountryCode)
        {
            throw new NotImplementedException();
        }

        internal override double GetShippingCosts(int UserID, int AddressID)
        {
            throw new NotImplementedException();
        }

        internal override double GetShippingCostsDefault(string CountryCode)
        {
            throw new NotImplementedException();
        }

        internal override void UserCreditCardDetailsUpdate(BOL.Users.CreditCard card, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void UserCreditCardDetailsDelete(BOL.Users.CreditCard card, BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.CreditCard UserCreditCardDetailsGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void SpecialOffersGet(int UserID, out bool Email, out bool Phone, out bool Postal)
        {
            throw new NotImplementedException();
        }

        internal override void SpecialOffersSet(int UserID, bool Email, bool Phone, bool Postal)
        {
            throw new NotImplementedException();
        }

        internal override void UserMergeRecords(BOL.Users.User currentUser, BOL.Users.User primaryRecord, BOL.Users.User secondaryRecord)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserGetSystemUser()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserGet(long UserID)
        {
            return (null);
        }

        internal override BOL.Users.Users UserGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users UserGetSalonOwners()
        {
            throw new NotImplementedException();
        }

        internal override string UserGetBarcode(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserGetByBarcode(string Barcode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserGet(string Email)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserGet(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users UsersGet(BOLEvents.Progress progress)
        {
            throw new NotImplementedException();
        }

        internal override System.Data.DataSet UserGetUserMenuItems()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users UserGetBirthdays(string currenLocation, int month, int radius)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users UserSearch(string FirstName, string LastName, string Email)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users UserSearch(string FirstName, string LastName, string Email, string Telephone, int MaxRecords)
        {
            throw new NotImplementedException();
        }

        internal override void UserChangePassword(long UserID, string CurrentPassword, string NewPassword)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User UserCreateAccount(string FirstName, string Surname, string Telephone, string EMail, string Password, string ConfirmPassword, string CompanyName, string Address1, string Address2, string Address3, string City, string County, string PostCode, int Country, bool OffersTelephone, bool OffersEmail, bool OffersPostal, Enums.UserRecordType RecordType, DateTime BirthDate, string Notes)
        {
            throw new NotImplementedException();
        }

        internal override bool UserGetDetails(long UserID, out string FirstName, out string Surname, out string EMail, out string Password, out string CompanyName, out string Address1, out string Address2, out string Address3, out string City, out string County, out string PostCode, out int Country)
        {
            throw new NotImplementedException();
        }

        internal override void UserAddressUpdate(long UserID, string Street1, string Street2, string City, string County, string PostCode, int Country)
        {
            throw new NotImplementedException();
        }

        internal override void UserAddressUpdate(long UserID, string CompanyName, string Street1, string Street2, string Street3, string City, string County, string PostCode, int Country)
        {
            throw new NotImplementedException();
        }

        internal override bool UserAddressGet(long UserID, out string CompanyName, out string Street1, out string Street2, out string Street3, out string City, out string County, out string PostCode, out int Country)
        {
            throw new NotImplementedException();
        }

        internal override bool UserGetDetails(long UserID, out string EMail, out string UserName)
        {
            throw new NotImplementedException();
        }

        internal override bool UserAmmendAccount(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override bool UserLogUserOn(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void UserSetLastVisit(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceCancel(BOL.Invoices.Invoice invoice, Stock stockReturnItems, User currentUser)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoice InvoiceGet(BOL.Orders.Order order)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoice InvoiceGet(long InvoiceID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices InvoicesGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override int InvoiceGetCount(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceMarkAsPaid(BOL.Orders.Order order, BOL.Accounts.PaymentStatus PaymentStatus, int InvoiceVersion, string ResultText, string initialReferrer)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceResendByEmail(BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceUpdateProcessStatus(ProcessStatus ProcessStatus, BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceUpdateProcessStatus(ProcessStatus ProcessStatus, BOL.Invoices.Invoice invoice, string TrackingReference)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceUpdatePaymentStatus(BOL.Accounts.PaymentStatus PaymentStatus, BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.InvoiceItems InvoiceItemsGet(BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceSetDate(BOL.Invoices.Invoice invoice, DateTime newDateTime)
        {
            throw new NotImplementedException();
        }

        internal override void OrderCancel(BOL.Orders.Order order)
        {
            throw new NotImplementedException();
        }

        internal override void OrdersProcessUnpaid()
        {
            //throw new NotImplementedException();
        }

        internal override BOL.Orders.Order OrderGet(long OrderID)
        {
            throw new NotImplementedException();
        }

        internal override int OrdersGetCount(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Orders.Orders OrdersGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Orders.Orders OrdersUnpaid(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        internal override void OrderMarkAsPaid(BOL.Orders.Order order, string initialReferrer)
        {
            throw new NotImplementedException();
        }

        internal override void OrderResendByEmail(int InvoiceID)
        {
            throw new NotImplementedException();
        }

        internal override void OrderUpdateProcessStatus(ProcessStatus ProcessStatus, BOL.Orders.Order order)
        {
            throw new NotImplementedException();
        }

        internal override void OrderUpdatePaymentStatus(BOL.Accounts.PaymentStatus PaymentStatus, BOL.Orders.Order order)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Orders.OrderItems OrderItemsGet(BOL.Orders.Order order)
        {
            throw new NotImplementedException();
        }

        internal override void OrderSave(BOL.Basket.ShoppingBasket basket, string description, bool autoOrder)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DeliveryAddress.DeliveryAddress MembersAddressCreate(long MemberID, string Name, string AddressLine1, string AddressLine2, string AddressLine3, string City, string County, string PostCode, int Country)
        {
            throw new NotImplementedException();
        }

        internal override void MembersAddressDelete(BOL.DeliveryAddress.DeliveryAddress deliveryAddress)
        {
            throw new NotImplementedException();
        }

        internal override void MembersAddressUpdate(BOL.DeliveryAddress.DeliveryAddress deliveryAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DeliveryAddress.DeliveryAddresses MembersAddressGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DeliveryAddress.DeliveryAddress MembersAddressGet(long DeliveryAddressID)
        {
            throw new NotImplementedException();
        }


    #region Member Notes

        /// <summary>
        /// Set's notes for a user
        /// </summary>
        /// <param name="member"></param>
        /// <param name="notes"></param>
        internal override void MemerNotesSet(User member, string notes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets notes for a user
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        internal override string MemberNotesGet(User member)
        {
            throw new NotImplementedException();
        }

    #endregion Member Notes


        internal override long HelpdeskCustomerCommentsAdd(BOL.Users.User user, string Username, string Comments)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.CustomerComments HelpdeskCustomerCommentsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.CustomerComments HelpdeskCustomerCommentsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.CustomerComment HelpdeskCustomerCommentGet(int id)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskCustomerCommentUpdate(BOL.Helpdesk.CustomerComment comment)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskCustomerCommentDelete(BOL.Helpdesk.CustomerComment comment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTickets HelpdeskSupportTicketsGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicket HelpdeskSupportTicketGet(string TicketKey, string EMail)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicket HelpdeskSupportTicketGet(int TicketID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTickets HelpdeskSupportTicketsGet(BOL.Users.User user, string TicketKey)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskSupportTicketSubmitResponse(BOL.Helpdesk.SupportTicket supportTicket, string ResponseContent, string ReplierName, bool IsAdmin)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskSupportTicketStatusUpdate(BOL.Helpdesk.SupportTicket Ticket, BOL.Helpdesk.TicketStatus Status)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskSupportTicketDepartmentUpdate(BOL.Helpdesk.SupportTicket Ticket, BOL.Helpdesk.TicketDepartment department)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicket HelpdeskSupportTicketCreate(string TicketKey, string Subject, string Content, string UserName, int Department, int Status, int Priority, string Email)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicketMessages HelpdeskSupportTicketMessagesGet(BOL.Helpdesk.SupportTicket Ticket)
        {
            throw new NotImplementedException();
        }

        internal override void HelpdeskSupportTicketsMaintenance()
        {
            //throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.TicketPriorities HelpdeskTicketPrioritiesGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.TicketDepartments HelpdeskTicketDepartmentsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.TicketStatuses HelpdeskTicketStatusesGet()
        {
            throw new NotImplementedException();
        }

        internal override Dictionary<string, string> SettingsLoad(int websiteID)
        {
            return (new Dictionary<string, string>());
        }

        internal override bool SettingsExist(string name)
        {
            while (name.Contains("."))
                name = name.Substring(name.IndexOf(".") + 1);

            return (Library.XML.GetXMLValue(_xmlConfigFile, "Settings", name.ToUpper(), "notfound") != "notfound");
        }

        internal override string SettingsGet(string name)
        {
            while (name.Contains("."))
                name = name.Substring(name.IndexOf(".") + 1);

            return (Library.XML.GetXMLValue(_xmlConfigFile, "Settings", name.ToUpper(), String.Empty));
        }

        internal override BOL.Salons.Salons SalonsFind(string SalonName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salon SalonFind(string SalonName)
        {
            throw new NotImplementedException();
        }

        internal override void SettingsSet(string name, string Value)
        {
            while (name.Contains("."))
                name = name.Substring(name.IndexOf(".") + 1);

            Library.XML.SetXMLValue(_xmlConfigFile, "Settings", name, Value);
        }

        internal override void LogWebVisits(WebVisitLogItems items)
        {
            throw new NotImplementedException();
        }

        internal override void LogWebVisit(string Platform, string BrowserVersion, string IsCrawler, string RemoteHost, string Method, string Path, string Query, string Referer, string UserSession, string Country)
        {
            //throw new NotImplementedException();
        }

        internal override void RegisterWebsite(int websiteID, string url)
        {
            //throw new NotImplementedException();
        }

        internal override BOL.Orders.Orders AdminOrdersGet(int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses processStatuses)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicket AdminHelpdeskSupportTicketGet(string TicketKey)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTicket AdminHelpdeskSupportTicketGet(int ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.SupportTickets AdminHelpdeskSupportTicketsGet(bool OnHold, bool Closed, bool Open)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.CustomerComment AdminHelpdeskCustomerCommentGet(int CommentID)
        {
            throw new NotImplementedException();
        }

        internal override void AdminHelpdeskCustomerCommentUpdate(BOL.Helpdesk.CustomerComment Comment)
        {
            throw new NotImplementedException();
        }

        internal override void AdminHelpdeskCustomercommentDelete(BOL.Helpdesk.CustomerComment comment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Helpdesk.CustomerComments AdminHelpdeskCustomerCommentsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override int AdminHelpdeskCustomerCommentsCount()
        {
            throw new NotImplementedException();
        }

        internal override int AdminProductsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products AdminProductsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products AdminProductsGet(BOL.Products.ProductGroup Group, string ProductName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Products AdminProductsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.Product AdminProductInsert(string ProductName,
            BOL.Products.ProductType productType, BOL.Products.ProductGroup group)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductUpdate(BOL.Products.Product product)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductDelete(BOL.Products.Product product)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductSoftDelete(BOL.Products.Product product)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductCostSoftDelete(BOL.Products.ProductCost productCost)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost AdminProductCostCreate(BOL.Products.Product product, string productItemName,
            BOL.Products.ProductCostType costType)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductCost AdminProductCostGet(int ProductCostID)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductCostDelete(BOL.Products.ProductCost ProductCostSize)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductCostUpdate(BOL.Products.ProductCost ProductCostSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroups AdminProductGroupsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroups AdminProductGroupsGet(BOL.Products.Product product)
        {
            throw new NotImplementedException();
        }

        internal override int AdminProductGroupsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroup AdminProductGroupCreate(string Description, int productGroupType)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductGroupDelete(BOL.Products.ProductGroup productGroup)
        {
            throw new NotImplementedException();
        }

        internal override void AdminProductGroupUpdate(BOL.Products.ProductGroup productGroup)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Products.ProductGroup AdminProductGroupGet(int GroupID)
        {
            throw new NotImplementedException();
        }

        internal override int AdminInvoicesGetCount(int UserID, int InvoiceID, bool TodayOnly, ProcessStatuses processStatuses)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics AdminInvoicesGetStats(int UserID, int InvoiceID, bool TodayOnly,
            ProcessStatuses processStatuses)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices AdminInvoicesGet(int PageNumber, int PageSize, int UserID, int InvoiceID,
            bool TodayOnly, ProcessStatuses processStatuses)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices AdminInvoicesGet(ProcessStatuses processStatuses, BOL.Accounts.PaymentStatus PaymentStatus)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices AdminInvoicesGet(ProcessStatuses processStatuses, bool SortAscending, bool showCancelled)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices AdminInvoicesGetAll(ProcessStatuses processStatuses)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Invoices.Invoices AdminInvoicesGet(DateTime dateFrom, DateTime dateTo,
            ProcessStatuses processStatuses, int PaymentType, BOL.Coupons.Coupon coupon, bool showCancelled)
        {
            throw new NotImplementedException();
        }

        internal override int AdminTipsTricksCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.TipsTricks.TipsTricks AdminTipsTricksGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.TipsTricks.TipsTrick AdminTipsTricksGet(int TipTrickID)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTipsTricksUpdate(BOL.TipsTricks.TipsTrick Tip)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTipsTricksDelete(BOL.TipsTricks.TipsTrick Tip)
        {
            throw new NotImplementedException();
        }

        internal override BOL.TipsTricks.TipsTrick AdminTipsTrickCreate(BOL.TipsTricks.TipsTrick Tip)
        {
            throw new NotImplementedException();
        }

        internal override long AdminEmailMassAdd(string ToName, string ToEMail, string FromName, string FromEMail, string Subject, string Message, DateTime SendDateTime)
        {
            throw new NotImplementedException();
        }

        internal override int AdminUsersGetCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users AdminUsersGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users AdminUsersGet(MemberLevel MemberLevel)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users AdminUsersGetMassEmail(bool AdminOnly)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users AdminUsersGetMassEmailProductItem(bool AdminOnly, int ProductID)
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsMailCount(Enums.MailCount Option)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics AdminStatsUserCount(Enums.UsersOnline Option)
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsComments()
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsBannedIP()
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsAppointments(Enums.AppointmentStats Option)
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsTickets(Enums.TicketStatus Option)
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsSalonUpdates()
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsInvoices(Enums.InvoiceStatistics Option)
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsUserCount()
        {
            throw new NotImplementedException();
        }

        internal override int AdminStatsLicenceCount()
        {
            throw new NotImplementedException();
        }

        internal override string AdminStatsDownloads()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatment AdminTreatmentGet(int TreatmentID)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTreatmentUpdate(BOL.Treatments.Treatment treatment)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTreatmentDelete(BOL.Treatments.Treatment treatment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.Treatment AdminTreatmentCreate(BOL.Treatments.Treatment treatment)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salon AdminSalonGet(int SalonID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons AdminSalonsGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons AdminSalonsGetUnassigned()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons AdminSalonsGet(string SalonName)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons AdminSalonsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonDelete(BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonUpdate(BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salon AdminSalonCreate(string SalonName, Enums.SalonType SalonType)
        {
            throw new NotImplementedException();
        }

        internal override int AdminSalonCount()
        {
            throw new NotImplementedException();
        }

        internal override void AdminDistributorOwnerCreate(BOL.Users.User user, BOL.Distributors.Distributor distributor)
        {
            throw new NotImplementedException();
        }

        internal override void AdminDistributorOwnerDelete(BOL.Users.User user, BOL.Distributors.Distributor distributor)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonOwnerCreate(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonOwnerDelete(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonOwnerUpdateDelete(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonOwnerUpdateMerge(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override void AdminSalonOwnerUpdateInsert(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salon AdminSalonOwnerUpdateGet(BOL.Users.User user, BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.Users AdminSalonOwnersGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Users.User AdminSalonOwnerGet(BOL.Salons.Salon salon)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Salons.Salons AdminSalonUpdatesGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override int AdminSalonOwnersCount()
        {
            throw new NotImplementedException();
        }

        internal override int AdminSalonOwnersUpdateCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.MissingLinks.MissingLink AdminMissingLinkAdd(string DeprecatedLink, string ReplacementLink)
        {
            throw new NotImplementedException();
        }

        internal override void AdminMissingLinkUpdate(BOL.MissingLinks.MissingLink missingLink)
        {
            throw new NotImplementedException();
        }

        internal override void AdminMissingLinkDelete(BOL.MissingLinks.MissingLink missingLink)
        {
            throw new NotImplementedException();
        }

        internal override BOL.MissingLinks.MissingLink AdminMissingLinkGet(string DeprecatedLink)
        {
            throw new NotImplementedException();
        }

        internal override int AdminMissingLinkCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.MissingLinks.MissingLinks AdminMissingLinksGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Distributors.Distributor AdminDistributorGet(int DistributorID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Distributors.Distributors AdminDistributorsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override void AdminDistributorsDelete(BOL.Distributors.Distributor distributor)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Distributors.Distributor AdminDistributorsCreate(string Name)
        {
            throw new NotImplementedException();
        }

        internal override void AdminDistributorsUpdate(BOL.Distributors.Distributor distributor)
        {
            throw new NotImplementedException();
        }

        internal override int AdminCouponCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupon AdminCouponGet(int CouponID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupon AdminCouponGet(string CouponCode)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupons AdminCouponsGet(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupons AdminCouponsGet()
        {
            throw new NotImplementedException();
        }

        internal override void AdminCouponDelete(BOL.Coupons.Coupon coupon)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupon AdminCouponCreate(string Name)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Coupons.Coupon AdminCouponCreate(string name, int value, BOL.Users.User user, DateTime expires, DateTime startDate)
        {
            throw new NotImplementedException();
        }

        internal override void AdminCouponUpdate(BOL.Coupons.Coupon coupon)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads all products that are required by a coupon
        /// </summary>
        /// <param name="coupon">Coupon to load products for</param>
        internal override BOL.Products.ProductCosts AdminCouponGetRequiredProducts(BOL.Coupons.Coupon coupon)
        {
            throw new NotImplementedException();
        }


        internal override int AdminTreatmentGroupsCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.TreatmentGroup AdminTreatmentGroupCreate(string Description)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTreatmentGroupDelete(BOL.Treatments.TreatmentGroup productGroup)
        {
            throw new NotImplementedException();
        }

        internal override void AdminTreatmentGroupUpdate(BOL.Treatments.TreatmentGroup productGroup)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.TreatmentGroup AdminTreatmentGroupGet(int GroupID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Treatments.TreatmentGroups AdminTreatmentGroupsGet(BOL.Treatments.Treatment treatment)
        {
            throw new NotImplementedException();
        }

        internal override string AdminDatabaseVersion()
        {
            throw new NotImplementedException();
        }

        internal override string AdminDatabaseServer(bool attemptConnect)
        {
            throw new NotImplementedException();
        }

        internal override bool IPAddressToCountryRecreateExternalFile(string GeoTempTable)
        {
            throw new NotImplementedException();
        }

        internal override int IPAddressToCountryProcessFile(string GeoPath, string GeoFile, string GeoTempTable, out int Updated, out int Unchanged, out int Added, out int Unknown, out long newVersion)
        {
            throw new NotImplementedException();
        }

        internal override string IPAddressToCountry(string IPAddress)
        {
            return ("ZZ");
        }

        internal override string IPAddressToCountryA(string IPAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.USAStates.USState IPAddressToState(string IPAddress)
        {
            throw new NotImplementedException();
        }

        internal override bool IPAddressIsBanned(string IPAddress, out int BanType)
        {
            BanType = 0;
            return (false);
        }

        internal override void IPCodeReset()
        {
            throw new NotImplementedException();
        }

        internal override string IPAddressToCountryCreateUpdateSQL(long version)
        {
            throw new NotImplementedException();
        }

        internal override bool AutoBanIPAddress(string path, string IPAddress, bool ForceBan = false)
        {
            throw new NotImplementedException();
        }

        internal override void AutoBanIPAddress(string ipAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.MissingLinks.MissingLink MissingLinkGet(string DeprecatedLink)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.StockHistory StockHistoryGet(BOL.StockControl.StockItem stockItem, BOL.Locations.StoreLocation location, bool includeInternetSales, bool includeStockAudit)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.StockHistory StockHistoryGet(BOL.StockControl.StockItem stockItem)
        {
            throw new NotImplementedException();
        }

        internal override void StockCreate(StockItem stockCreated, User currentUser, int quantity)
        {

        }

        internal override BOL.StockControl.CreateStock StockCreateItemsGet(BOL.Products.ProductCost costItem)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.CreateStockItem StockCreateItemsAdd(BOL.Products.ProductCost primary, BOL.Products.ProductCost subItem, double quantity)
        {
            throw new NotImplementedException();
        }

        internal override void StockCreateItemsDelete(BOL.Products.ProductCost primary, BOL.Products.ProductCost subItem)
        {
            throw new NotImplementedException();
        }

        internal override void StockCreateItemsUpdate(BOL.Products.ProductCost primary, BOL.Products.ProductCost subItem, double quantity)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.Stock StockItemsGet(BOL.Users.User user)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.Stock StockItemsGet(BOL.Users.User user, int StoreID, int TillID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.Stock StockItemsGetFiltered(BOL.Users.User user, int storeID, int productType)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemAddStockInQuantity(BOL.StockControl.StockItem Item, int Quantity)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemAddStockOutQuantity(BOL.StockControl.StockItem Item, int Quantity)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemAddStockInAudit(BOL.StockControl.Stock StockItems, BOL.Users.User CurrentUser)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemAddStockOutAudit(BOL.StockControl.Stock StockItems, BOL.Users.User CurrentUser, string Reason)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemSaveChanges(BOL.StockControl.StockItem Item)
        {
            throw new NotImplementedException();
        }

        internal override void StockItemShowGlobally(BOL.StockControl.StockItem item, bool hidden)
        {
            throw new NotImplementedException();
        }

        internal override void StockAudit(BOL.StockControl.Stock StockAuditItems, BOL.StockControl.Stock StockItems, BOL.Users.User CurrentUser, bool Partial)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.Stock StockItemGet(BOL.Products.ProductCost productCost)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.StockOut StockOutGet(int storeID, int productType, DateTime date)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.StockIn StockInGet(int storeID, int productType, DateTime date)
        {
            throw new NotImplementedException();
        }

        internal override BOL.StockControl.StockItem StockGetItemStock(int storeID, BOL.Products.ProductCost product)
        {
            throw new NotImplementedException();
        }

        internal override void ExecuteRoutineMaintenance(RoutineMaintenanceType maintenanceType)
        {
            //throw new NotImplementedException();
        }

        internal override string GetLocalDatabase()
        {
            throw new NotImplementedException();
        }

        internal override void ResetDatabasePool(bool clearAllConnections)
        {
            // do nothing
        }

        internal override void Prepare()
        {
            _xmlConfigFile = _connectionString[(int)DatabaseType.Standard];
        }

    #endregion Internal Overridden Methods

        internal override BOL.Appointments.WaitingList WaitingListSelect(Int64 ID)
        {
            throw new NotImplementedException();
        }

        internal override bool WaitingListUpdate(BOL.Appointments.WaitingList item)
        {
            throw new NotImplementedException();
        }

        internal override bool WaitingListDelete(BOL.Appointments.WaitingList item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.WaitingLists WaitingListSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.WaitingLists WaitingListPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override int WaitingListCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.WaitingList WaitingListInsertUpdate(BOL.Appointments.WaitingList item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Appointments.AppointmentTreatments AppointmentTreatmentsGet(BOL.Appointments.WaitingList waitingList)
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPCity IPCitySelect(string ipAddress)
        {
            throw new NotImplementedException();
        }

        internal override List<BOL.IPAddresses.IPCity> IPCitySelect(decimal latitude, decimal longitude, string country)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics WebDefenderCurrentlyBanned()
        {
            throw new NotImplementedException();
        }

        internal override void WebDefenderStats(ref Int64 currentlyBanned, ref Int64 previouslyBanned)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics GetVisitorLocations(decimal age)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics GetUnpaidStatistics()
        {
            throw new NotImplementedException();
        }

        internal override int AppointmentFutureCount(User staff, DateTime fromDate)
        {
            throw new NotImplementedException();
        }

        internal override void UpdateCurrentLocation(int storeID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics StatisticsSEOStatistics()
        {
            throw new NotImplementedException();
        }

        internal override void SeoSessionInsertUpdate(UserSession session)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Hourly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal override SeoReports SeoReportsHourly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Daily SEO Reports
        /// </summary>
        /// <returns></returns>
        internal override SeoReports SeoReportsDaily()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Weekly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal override SeoReports SeoReportsWeekly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Monthly Seo Reports
        /// </summary>
        /// <returns></returns>
        internal override SeoReports SeoReportsMonthly()
        {
            throw new NotImplementedException();
        }


        internal override bool ModuleClassUpdate(BOL.ModuleDocumentation.ModuleClass item)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleClassDelete(BOL.ModuleDocumentation.ModuleClass item)
        {
            throw new NotImplementedException();
        }
        internal override bool ModuleClassMemberDelete(BOL.ModuleDocumentation.ModuleMember item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleMembers ModuleClassMemberSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleMembers ModuleClassMemberPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override int ModuleClassMemberCount()
        {
            throw new NotImplementedException();
        }

        internal override void ModuleClassMemberInsertUpdate(BOL.ModuleDocumentation.ModuleMember item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleName ModuleNameSelect(long Id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleName ModuleNameInsert(string name, string description)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleNameUpdate(BOL.ModuleDocumentation.ModuleName item)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleNameDelete(BOL.ModuleDocumentation.ModuleName item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleNames ModuleNameSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleNames ModuleNamePage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override int ModuleNameCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleName ModuleNameInsertUpdate(BOL.ModuleDocumentation.ModuleName item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClass ModuleClassSelect(long Id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClass ModuleClassInsert(long moduleId, bool isPrimary, string moduleNamespace, string name, string description, string exampleUsage)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClasses ModuleClassSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClasses ModuleClassPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override int ModuleClassCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClass ModuleClassInsertUpdate(BOL.ModuleDocumentation.ModuleClass item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleMember ModuleClassMemberSelect(long Id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameter ModuleClassMemberParameterSelect(long Id)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleClassMemberParameterDelete(BOL.ModuleDocumentation.ModuleParameter item)
        {
            throw new NotImplementedException();
        }

        internal override int ModuleClassMemberParameterCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleMember ModuleClassMemberInsert(long classId, ModuleProperties memberProperties, string name, string description, string exceptions, string exampleUsage, string returnValue, string returnValueDesc)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleClassMemberUpdate(BOL.ModuleDocumentation.ModuleMember item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameter ModuleClassMemberParameterInsert(long classMemberId, string name, ModuleProperties properties, int parameterType, string description, string paramType, string exampluUsage, string defaultValue, int sortOrder)
        {
            throw new NotImplementedException();
        }

        internal override bool ModuleClassMemberParameterUpdate(BOL.ModuleDocumentation.ModuleParameter item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameters ModuleClassMemberParameterSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameters ModuleClassMemberParameterPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleClasses ModuleClassSelect(BOL.ModuleDocumentation.ModuleName module)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleMembers ModuleClassMemberSelect(BOL.ModuleDocumentation.ModuleClass moduleClass)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameters ModuleClassMemberParameterSelect(BOL.ModuleDocumentation.ModuleMember member)
        {
            throw new NotImplementedException();
        }

        internal override BOL.ModuleDocumentation.ModuleParameter ModuleClassMemberParameterInsertUpdate(BOL.ModuleDocumentation.ModuleParameter item)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceItemUpdateSalesPerson(BOL.Invoices.InvoiceItem invoiceItem, User user)
        {
            throw new NotImplementedException();
        }

        internal override void InvoiceUpdateNotes(BOL.Invoices.Invoice invoice, string notes)
        {
            throw new NotImplementedException();
        }

        internal override BOL.FileBackup.BackupFile BackupFileGetLatest(string computerName, string path, string name, string extension)
        {
            throw new NotImplementedException();
        }

        internal override void BackupFileSave(BOL.FileBackup.BackupFile file, string contents)
        {
            throw new NotImplementedException();
        }

        internal override string BackupFileGetContents(BOL.FileBackup.BackupFile file)
        {
            throw new NotImplementedException();
        }

        internal override BOL.FileBackup.Files BackupFileGetVersions(BOL.FileBackup.BackupFile file)
        {
            throw new NotImplementedException();
        }

        internal override User StaffMemberManagerGet(User staffMember)
        {
            throw new NotImplementedException();
        }

        internal override void StaffMemberManagerSet(User staffMember, User manager)
        {
            throw new NotImplementedException();
        }

        internal override void StaffMemberManagerRemove(User staffMember)
        {
            throw new NotImplementedException();
        }

        internal override Users StaffMemberManagerSubStaff(BOL.Staff.StaffMember manager)
        {
            throw new NotImplementedException();
        }

        internal override SecurityEnums.SecurityPermissionsStaff PermissionsGetStaff(User user)
        {
            throw new NotImplementedException();
        }

        internal override void PermissionsSetStaff(User user, SecurityEnums.SecurityPermissionsStaff permissions)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffMember StaffMemberSelect(User staffMember)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffMemberUpdate(BOL.Staff.StaffMember item)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffMemberDelete(BOL.Staff.StaffMember item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffMembers StaffMemberSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override int StaffMemberCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffMember StaffMemberInsertUpdate(BOL.Staff.StaffMember item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffSickRecord StaffSickRecordSelect(long ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffSickRecord StaffSickRecordInsert(long userID, DateTime dateStarted, DateTime dateFinished, DateTime dateNotified, string returnInterviewCompleted, long returnInterviewer, string notes, string reasonCited, string certificate, string preBooked, long properties)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffSickRecordUpdate(BOL.Staff.StaffSickRecord item)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffSickRecordDelete(BOL.Staff.StaffSickRecord item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffSickRecords StaffSickRecordSelectAll()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffSickRecords StaffSickRecordPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal override int StaffSickRecordCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffSickRecord StaffSickRecordInsertUpdate(BOL.Staff.StaffSickRecord item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeaveRequest StaffLeaveRequestSelect(long ID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeaveRequest StaffLeaveRequestInsert(long userID, DateTime dateRequested,
            DateTime dateFrom, DateTime dateTo, double totalTime, long authorisedBy, long grantedBy, string notes)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffLeaveRequestUpdate(BOL.Staff.StaffLeaveRequest item)
        {
            throw new NotImplementedException();
        }

        internal override bool StaffLeaveRequestDelete(BOL.Staff.StaffLeaveRequest item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeave StaffLeaveRequestSelectAll(User staffMember)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeave StaffLeaveRequestSelectAllApproval()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeave StaffLeaveRequestSelectAllAuthorisation()
        {
            throw new NotImplementedException();
        }

        internal override int StaffLeaveRequestCount()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffLeaveRequest StaffLeaveRequestInsertUpdate(BOL.Staff.StaffLeaveRequest item)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Export.ExportableItems ImportExportGetConfig()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Export.ExportableItems ImportExportGetConfig(string tableName)
        {
            throw new NotImplementedException();
        }

        internal override User TradeClientManagerGet(BOL.Trade.Client client)
        {
            throw new NotImplementedException();
        }

        internal override void TradeClientManagerSet(BOL.Trade.Client client, User manager)
        {
            throw new NotImplementedException();
        }

        internal override Users TradeClientManagersGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Trade.Clients TradeClientManagerClients(User manager)
        {
            throw new NotImplementedException();
        }

        internal override bool WebDefenderAddressAdd(BOL.IPAddresses.IPAddress address)
        {
            throw new NotImplementedException();
        }

        internal override bool WebDefenderAddressRemove(BOL.IPAddresses.IPAddress address)
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddresses WebDefenderAddressGet()
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddresses WebDefenderAddressGetInactive()
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddresses WebDefenderAddressGet(Shared.AddressType type, bool active, bool inactive)
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddress WebDefenderAddressGet(long id)
        {
            throw new NotImplementedException();
        }

        internal override int WebDefenderAddressNumberOfBans(string ipAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddresses WebDefenderAddressHistory(string ipAddress)
        {
            throw new NotImplementedException();
        }

        internal override BOL.IPAddresses.IPAddresses WebDefenderAddressesBanned(DateTimeOffset fromDate, Int64 maximumID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.CommissionPools StaffCommissionPoolsGet()
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionPoolsDelete(BOL.Staff.CommissionPool pool)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionPoolCreate(BOL.Staff.CommissionPool pool)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionPoolSave(BOL.Staff.CommissionPool pool)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffCommission StaffCommissionPoolGet(BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffCommission StaffCommissionPoolGet(BOL.Staff.CommissionPool pool, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionRebuildPoolData(DateTime dateFrom, DateTime dateTo, bool replace)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionUpdate(BOL.Staff.StaffCommissionItem item, User authorising, Library.CommissionPaymentType paymentType)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionSave(User authorisingUser, BOL.Staff.PayCommissionSettings commissionSettings, CommissionPaymentType paymentType)
        {
            throw new NotImplementedException();
        }

        internal override void StaffCommissionRebuildClientData(DateTime dateFrom, DateTime dateTo, bool replace)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffCommission StaffCommissionClientGet(BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.StaffCommission StaffCommissionClientGet(BOL.Staff.StaffMember staff, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Staff.PaidCommission StaffCommissionPaymentsGet(User staffMember)
        {
            throw new NotImplementedException();
        }

        internal override int AutoUpdateExecute(BOL.DatabaseUpdates.AutoUpdateRule rule, bool testOnly)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.AutoUpdate AutoUpdateGet(long id)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.AutoUpdates AutoUpdateGet()
        {
            throw new NotImplementedException();
        }

        internal override void AutoUpdateCreate(BOL.DatabaseUpdates.AutoUpdate autoUpdate)
        {
            throw new NotImplementedException();
        }

        internal override void AutoUpdateDelete(BOL.DatabaseUpdates.AutoUpdate autoUpdate)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.AutoUpdateRules AutoUpdateRulesGet()
        {
            throw new NotImplementedException();
        }

        internal override void AutoUpdateRulesSave(BOL.DatabaseUpdates.AutoUpdateRule rule)
        {
            throw new NotImplementedException();
        }

        internal override BOL.DatabaseUpdates.AutoUpdateItems AutoUpdateItemsGet(BOL.DatabaseUpdates.AutoUpdateRule rule)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics AdminProductsStatsSKUInvalidCodes()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics AdminProductsStatsSKUDuplicateCodes()
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics AdminProductsStatsFeaturedProducts()
        {
            throw new NotImplementedException();
        }

        internal override void AffiliatedSiteCreate(BOL.Affiliate.AffiliatedItem affiliate)
        {
            throw new NotImplementedException();
        }

        internal override void AffiliatedSiteUpdate(BOL.Affiliate.AffiliatedItem affiliate)
        {
            throw new NotImplementedException();
        }

        internal override void AffiliatedSiteDelete(BOL.Affiliate.AffiliatedItem affiliate)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Affiliate.AffiliatedItems AffiliatedSitesGet(User user)
        {
            throw new NotImplementedException();
        }

        internal override bool AffiliateIDIsUnique(BOL.Affiliate.AffiliatedItem affiliate, string affiliateID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Affiliate.AffiliatedItem AffiliatedSiteGet(string urlReferrer)
        {
            throw new NotImplementedException();
        }

        internal override void AffiliatedSiteWebClick(BOL.Affiliate.AffiliatedItem affiliate, string ipAddress)
        {
            throw new NotImplementedException();
        }

        internal override void AffiliateCommissionUpdate(BOL.Affiliate.AffiliateCommissionItem item, User authorising, CommissionPaymentType paymentType)
        {
            throw new NotImplementedException();
        }

        internal override Users AffiliatedGetUsers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the user for an affiliate ID
        /// </summary>
        /// <param name="affiliateID"></param>
        /// <returns></returns>
        internal override User AffiliatedUserGet(string affiliateID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Affiliate.AffiliateCommission AffiliatedCommissionGet(BOL.Invoices.Invoice invoice)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Affiliate.AffiliateCommission AffiliatedCommissionGet(BOL.Users.User user, DateTime from, DateTime to, bool isPaid, bool isNotPaid)
        {
            throw new NotImplementedException();
        }

        internal override void AffiliatedCommissionSave(User authorisingUser, BOL.Affiliate.PayAffiliateCommissionSettings commissionSettings, CommissionPaymentType paymentType)
        {
            throw new NotImplementedException();
        }

        internal override void StatisticsMonthToDate(BOL.Statistics.Statistics statistics, DateTime StartMonth, string counryCode, int type)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Affiliate.AffiliateProducts AffiliatedProductsGet(string countryCode, string affiliateID, int imageSize, string website)
        {
            throw new NotImplementedException();
        }

        internal override void InitialiseConnection()
        {
            throw new NotImplementedException();
        }

        internal override void FinaliseConnection()
        {
            throw new NotImplementedException();
        }

        internal override bool SettingsExistMeta(string name)
        {
            throw new NotImplementedException();
        }

        internal override string SettingsGetMeta(string Name)
        {
            throw new NotImplementedException();
        }

        internal override void SettingsSetMeta(string Name, string Value)
        {
            throw new NotImplementedException();
        }

        internal override UserSession SeoSessionRetrieve(string sessionID)
        {
            throw new NotImplementedException();
        }

        internal override BOL.Statistics.SimpleStatistics StatisticsGetTopProducts(int number, int days, bool autoUpdate)
        {
            throw new NotImplementedException();
        }

        internal override void SeoSessionSavePage(UserSession session, PageViewData page)
        {
            throw new NotImplementedException();
        }

        internal override SeoReports SeoReportsMonthlyVisitsByCountry(int year, int month)
        {
            throw new NotImplementedException();
        }

        internal override SeoReports SeoReportsMonthlyVisitsByCity(int year, int month)
        {
            throw new NotImplementedException();
        }

        internal override SeoReports SeoReportsMonthlySalesByCountry(int year, int month)
        {
            throw new NotImplementedException();
        }

        internal override SeoReports SeoReportsMonthlySalesByCity(int year, int month)
        {
            throw new NotImplementedException();
        }

        internal override SeoReports SeoReportsCampaign(BOL.Campaigns.Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }

#endif
}
