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
 *  File: HelpTopics.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


namespace POS.Base.Classes
{
    public sealed class HelpTopics
    {
        // initial setup
        public const string InitialStep1 = "initialsetupstep1";
        public const string InitialStep2 = "initialsetupstep2";
        public const string InitialStep3 = "initialsetupstep3";
        public const string InitialStep4 = "initialsetupstep4";
        public const string InitialStep5 = "initialsetupstep5";
        public const string InitialFinal = "initialsetupfinal";

        // default POS exe help topics
        public const string ChangePassword = "changepassword";

        public const string EditPlugin = "editPlugin";
        public const string HintsAndTips = "hintsandtips";
        public const string Login = "login";
        public const string CreateUSer = "createcustomer";
        public const string Notes = "notes";
        public const string ViewNotes = "viewnotes";
        public const string CreateCustomer = "createcustomer";
        public const string Customers = "customers";
        public const string TrackingReference = "orderstrackingreference";


        // website settings
        public const string WebSiteAddWebsite = "websiteaddwebsite";
        public const string WebsiteSettingBanners = "websitesettingbanners";
        public const string WebsiteSettingBanner = "websitesettingbanner";
        public const string WebsiteSettingPageBanners = "websitepagebanners";
        public const string WebsiteSettingPageBanner = "websitepagebanner";


        // recurring Invoices
        public const string RecurringInvoices = "recurringinvoices";
        public const string RecurringInvociesCreateStep1 = "recurringinvoicesstep1";
        public const string RecurringInvociesCreateStep2 = "recurringinvoicesstep2";
        public const string RecurringInvociesCreateFinalStep = "recurringinvoicesfinalstep";

        // purchase orders
        public const string PurchaseOrders = "purchaseorders";

        // suppliers
        public const string Suppliers = "suppliers";
        public const string SuppliersEditStep1 = "supplierseditstep1";
        public const string SuppliersEditStep2 = "supplierseditstep2";
        public const string SupplierProductStep1 = "supplierproducts";

        // diary topics
        public const string Diary = "diary";
        public const string DiaryApptChanges = "diaryappointmentchanges";
        public const string DiaryApptHistory = "diaryappointmenthistory";
        public const string DiaryApptEdit = "diarycreateoreditappointment";
        public const string DiaryApptClone = "diarycloneappointment";
        public const string DiaryCreditCardDetails = "diarycreditcarddetails";
        public const string DiaryApptNew = "diarynewappointments";

        public const string SalonTreatments = "diarysalontreatments";
        public const string SalonTreatmentEdit = "diaryeditsalontreatments";
        public const string SalonTreatmentEditImage = "diaryeditsalontreatmentimage";
        public const string SalonTreatmentEditStaff = "diaryedittreatmentstaffmembers";

        public const string DiarySettings = "diaryadvancedsettings";
        public const string DiarySettingsGeneral = "diaryadvancedsettingsgeneral";
        public const string DiarySettingsColours = "diaryadvancedsettingscolours";
        public const string DiarySettingsImageOverlay = "diaryadvancedsettingsimageoverlays";
        public const string DiarySettingsAutoHide = "diaryadvancedsettingsautohide";
        public const string DiarySettingsTimes = "diaryadvancedsettingstimes";
        public const string DiarySettingsAdvanced = "diaryadvancedsettingsadvanced";

        public const string DiarySelectTreatmentAll = "diarycreateoredittreatmentaddtreatment";
        public const string DiarySelectTreatmentPrevious = "diarycreateoreditappointmentprevioustreatments";

        // discounts
        public const string AdministrationDiscountCoupons = "administrationdiscountcoupons";
        public const string DiscountCouponStep1 = "discountcouponsstep1";
        public const string DiscountCouponStep2 = "discountcouponsstep2";
        public const string DiscountCouponStep3 = "discountcouponsstep3";
        public const string DiscountCouponStep4 = "discountcouponsstep4";
        public const string DiscountCouponStep5 = "discountcouponsstep5";
        public const string DiscountCouponFinal = "discountcouponssummary";

        // currency watch
        public const string CurrencyWatch = "currencywatch";

        //system emails
        public const string AdminSystemEmails = "systememails";


        public const string CategoryTypes = "categorytypes";
        public const string CategoryTypesAppointmentGroups = "categorytypesappointmentgroups";
        public const string CategoryTypesDownloads = "categorytypesdownloadtypes";
        public const string CategoryTypesProducts = "categorytypesproducts";
        public const string CategoryTypesProductCosts = "categorytypesproductcostitems";
        public const string CategoryTypesProductGroups = "categorytypesproductgroups";
        public const string CategoryTypesHelpDeskDepartments = "categorytypeshelpdeskticketdepartments";

        //products
        public const string Products = "products";
        public const string ProductNew = "newproduct";
        public const string ProductPriceCalculator = "pricecalculator";
        public const string ProductNewProductItem = "newproductitem";
        public const string ProductEditProductDetails = "producteditdetails";
        public const string ProductEditProductGroups = "producteditproductgroups";
        public const string ProductEditProductSettings = "producteditsettings";
        public const string ProductEditProductItems = "producteditproductitems";
        public const string ProductTopSelling = "productedittopsellingproducts";
        public const string ProductEditItem = "editproductitem";
        public const string ProductInvalidSKU = "invalidproductsku";

        // product groups
        public const string ProductGroupNew = "administrationproductgroupsnew";
        public const string ProductGroups = "administrationproductgroups";
        public const string ProductGroupEditGeneral = "editproductgroups";
        public const string ProductGroupEditMobile = "editproductgroupmobile";

        // cash Manager
        public const string CashManagerTill = "admincashdrawertill";
        public const string CashManagerTillVerify = "admincashdrawerverifytill";
        public const string CashManagerPettyCash = "admincashdrawerpettycash";
        public const string CashManagerPettyCashVerify = "admincashdrawerpettycashverify";
        public const string CashManagerSafe = "admincashdrawersafe";
        public const string CashManagerSafeVerify = "admincashdrawerverifysafe";


        // image management
        public const string ImageManagement = "imagemanagement";

        // customers
        public const string CustomerSearch = "customers";
        public const string CustomersMerge = "mergecustomers";
        public const string CustomerAffPayCommissionStep1 = "adminaffiliatepaycommissionstep1";
        public const string CustomerAffPayCommissionStep2 = "adminaffiliatepaycommissionstep2";
        public const string CustomerAffPayCommissionStep3 = "adminaffiliatepaycommissionstep3";
        public const string CustomerAffSettings = "adminaffiliatecreatesettings";
        public const string CustomerAffCommissionData = "affiliatecommissiondata";

        public const string CustomerExportStep1 = "exportCustomerStep1";
        public const string CustomerExportStep2 = "exportCustomerStep2";
        public const string CustomerExportStep3 = "exportCustomerStep3";
        public const string CustomerExportStep4 = "exportCustomerStep4";
        public const string CustomerExportStep5 = "exportCustomerStep5";
        public const string CustomerExportStep6 = "exportCustomerStep6";

        public const string CustomerEditUserDetails = "viewcustomerdetails";
        public const string CustomerEditTickets = "viewcustomersupporttickets";
        public const string CustomerEditOrders = "viewcustomerorders";
        public const string CustomerEditNotes = "viewcustomernotes";
        public const string CustomerEditMarketing = "customermarketingpreferences";
        public const string CustomerEditGoldUser = "editCustomergolduser";
        public const string CustomerEditInvoices = "viewcustomerinvoices";
        public const string CustomerEditDeliveryAddress = "customerdeliveryaddress";
        public const string CustomerEditAffiliate = "adminsettingupaffiliates";
        public const string CustomerEditAppointments = "viewcustomerappointments";
        public const string CustomerEditPermissions = "editcustomerpermissions";
        public const string CustomerEditSalonOwner = "editCustomersalonowners";


        // invoices
        public const string InvoiceChangeSalesPerson = "invoiceviewchangesalesperson";
        public const string InvoiceCreateOrder = "orderscreateorder";
        public const string InvoiceFindOrder = "ordersfindorders";
        public const string InvoiceCancel = "invoiceviewcancelinvoice";
        public const string InvoiceManager = "invoicemanager";
        public const string InvoicesReceived = "ordersviewordersreceived";
        public const string InvoiceView = "invoiceview";
        public const string InvoiceIssueRefund = "invoiceviewissuerefund";
        public const string InvoiceOrderView = "orderview";
        public const string InvoiceOrderOpenSaved = "orderscreateorderopensavedorder";
        public const string InvoiceOrdersUnpaid = "ordersviewunpaidorders";


        // orders
        public const string OrdersDispatch = "ordersdispatchorders";
        public const string OrdersDispatchTracking = "orderstrackingreference";

        // staff
        public const string StaffPageDetails = "staffdetails";
        public const string StaffPageClients = "staffclients";
        public const string StaffPageCommission = "staffcommission";
        public const string StaffPageContact = "staffcontactdetails";
        public const string StaffPageDiary = "staffdiarysettings";
        public const string StaffPageEmergencyContact = "staffemeregencycontact";
        public const string StaffPageEmployment = "staffemploymentdetails";
        public const string StaffPageLeave = "staffleaveholiday";
        public const string StaffPageLicence = "staffdrivinglicence";
        public const string StaffPagePermissions = "staffpospermissions";
        public const string StaffPagePersonal = "staffpersonaldetails";
        public const string StaffPageSickness = "staffsicknessdetails";
        public const string StaffPageTreatments = "stafftreatments";
        public const string StaffPageWorkingHours = "staffworkinghours";

        public const string StaffWorkingHoursEdit = "staffWorkinghoursedit";
        public const string StaffApproveLeave = "staffapproveleave";
        public const string StaffAuthoriseLeave = "staffauthoriseleave";
        public const string StaffRequestLeave = "staffrequestleave";
        public const string StaffViewLeave = "staffviewleave";

        public const string StaffCreateStep1 = "createstaffstep1";
        public const string StaffCreateStep2 = "createstaffstep2";
        public const string StaffCreateStep3 = "createstaffstep3";
        public const string StaffCreateStep4 = "createstaffstep4";
        public const string StaffCreateStep5 = "createstaffstep5";

        public const string StaffSickStep1 = "staffsicknesscreatestep1";
        public const string StaffSickStep2 = "staffsicknesscreatestep2";
        public const string StaffSickStep3 = "staffsicknesscreatestep3";
        public const string StaffSickStep4 = "staffsicknesscreatestep4";

        public const string StaffSickSelectAppointment = "staffsicknessselectappointment";
        public const string StaffViewSicknessRecord = "staffviewsicknessrecord";

        public const string StaffSickReturnTowork = "staffsicknessreturntowork";

        public const string StaffExpenses = "staffexpenses";
        public const string StaffCreateExpensesStep1 = "staffexpensescreatestep1";
        public const string StaffCreateExpensesStep2 = "staffexpensescreatestep2";
        public const string StaffCreateExpensesStep3 = "staffexpensescreatestep3";
        public const string StaffExpensesViewReceipt = "expensesviewreceipt";
        public const string StaffExpensesSettings = "staffexpensessettings";

        // stock control
        public const string StockControl = "stockcontrol";
        public const string StockAutoReOrder = "stockcontrolsetautomaticstockreordering";
        public const string StockCreate = "stockcontrolcreatestock";
        public const string StockAudit = "stockcontrolstockaudit";
        public const string StockCreateConfirm = "stockcreatestockconfirm";
        public const string StockHistory = "stockcontrolstockhistory";
        public const string StockIn = "stockcontrolstockin";
        public const string StockOut = "stockcontrolstockout";


        // till
        public const string Till = "till";
        public const string TillCustomVATRate = "tillcustomvatrate";
        public const string TillDiscount = "tillapplydiscounts";
        public const string TillMarkAsPaid = "";
        public const string TillVoucher = "";
        public const string TillAssignBarcodes = "tillassignbarcodes";
        public const string TillPaymentCash = "tillcashpayment";
        public const string TillPaymentCheque = "tillchequepayments";
        public const string TillPaymentCard = "tillcardpayments";
        public const string TillPaymentSplit = "tillsplitpayments";

        // assign vouchers
        public const string VoucherAssign = "vouchermanagement";

        // countries
        public const string Countries = "countries";
        public const string CountriesAddress = "countriesaddressoptions";

        // website administration
        public const string WebCustomerComments = "customercomments";

        public const string WebDistributors = "websitedistributors";

        public const string WebMissingLinks = "websitemissinglinks";
        public const string WebMissingLinkEdit = "websitemissinglinksedit";

        public const string WebProductGroups = "administrationproductgroups";
        public const string WebProductGroupEdit = "editproductgroups";
        public const string WebProductGroupEditMobile = "editproductgroupmobile";

        public const string WebSalons = "websitesalons";
        public const string WebSalonEdit = "websitesalonseditsalons";
        public const string WebSalonEditGeneral = "websitesalonseditsalonsgeneral";
        public const string WebSalonEditSettings = "websitesalonseditsalonssettings";
        public const string WebSalonEditType = "websitesalonseditsalonstype";
        public const string WebSalonEditVIP = "websitesaloneditvip";
        public const string WebSalonEditOpeningTimes = "websitesalonseditsalonsopeningtimes";
        public const string WebSalonToSalonOwner = "websitesalontosalonowners";
        public const string WebSalonUpdate = "websitesalonupdates";
        public const string WebSalonSelect = "websalonsselectsalon";
        public const string WebSalonOwner = "websitesalonowners";

        public const string WebTipsAndTricks = "websitesalonowners";
        public const string WebTipsAndTricksEdit = "websitetipsandtricksedit";

        public const string WebTreatments = "websitetreatments";
        public const string WebTreatmentEdit = "websiteedittreatments";
        public const string WebTreatmentGroups = "websitetreatmentstreatmentgroups";
        public const string OnlineTreatmetGroupEditGeneral = "onlinetreatmentgroupsedit";

        public const string WebCelebrities = "websitecelebrities";

        public const string WebVideos = "websitevideoadministration";


        // training schedule
        public const string TrainingSchedule = "trainingschedule";
        public const string TrainingScheduleSelectSalon = "trainingscheduleeditcourseaddattendees";
        public const string TrainingScheduleEditAppointment = "trainingscheduleedittrainingcourse";
        public const string TrainingScheduleCreateStep1 = "trainingschedulecreatestep1";


        // marketing
        public const string MarketingCampaigns = "marketingcampaigns";
        public const string MarketingStep1 = "marketingcampaignname";
        public const string MarketingStep2 = "marketingselecttemplate";
        public const string MarketingStep3 = "";
        public const string MarketingStep4 = "";
        public const string MarketingStep5 = "";
        public const string MarketingStep6 = "";
        public const string MarketingStep7 = "";
        public const string MarketingStep8 = "";
        public const string MarketingStep9 = "";
        public const string MarketingStep10 = "";
        public const string MarketingStep11 = "";
        public const string MarketingStep12 = "";
        public const string MarketingStep13 = "";
        public const string MarketingStep14 = "marketingpreview";
        public const string MarketingStep15 = "marketingcampaign";
        public const string MarketingStep16 = "marketingrepeatcampaign";


        // website salon treatments
        public const string Treatments = "websitetreatments";
        public const string TreatmentEdit = "websiteedittreatments";
        public const string TreatmentGroups = "websitetreatmentstreatmentgroups";

        public const string Tickets = "helpdesk";
        public const string TicketReply = "helpdeskviewticket";


        public const string Debug = "DebugInformation";
    }
}
