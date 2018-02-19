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
 *  File: StringConstants.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace POS.Base.Classes
{
    public sealed class StringConstants
    {
        public const string PASSWORD_DEFAULT = "masterkey";


        public const string NULL = "null";

        public const string APP_64BIT = "x64";
        public const string APP_32BIT = "x32";

        public const string AFFILIATE_LIVE_DAYS = "AFFILIATE_LIVE_DAYS";
        public const string AFFILIATE_LINK_1 = "<a href=\"{0}?aff={1}\">{0}</a>";
        public const string AFFILIATE_LINK_2 = "<a href=\"{0}\">{0}</a>";

        // max string length is 35 chars
        public const string POS_SETTING_BUSINESS_NAME = "POS_BUS_NAME";
        public const string POS_SETTING_BUSINESS_ADDRESS = "POS_BUS_ADDR";
        public const string POS_SETTING_BUSINESS_TELEPHONE = "POS_BUS_TEL";
        public const string POS_SETTING_BUSINESS_EMAIL = "POS_BUS_EMAIL";
        public const string POS_SETTING_BUSINESS_REG_NO = "POS_BUS_REG_NO";
        public const string POS_SETTING_BUSINESS_VAT_NO = "POS_BUS_VAT_NO";


        public const string POS_SETTING_LEAVEYEAR_STARTS = "POS_LY_STARTS";
        public const string POS_SETTING_LEAVAE_YEAR_ENDS = "POS_LY_ENDS";
        public const string POS_SETTING_MAX_DAYS = "POS_MAX_DAYS";
        public const string POS_SETTING_MAX_HOURS = "POS_MAX_HOURS";
        public const string POS_SETTING_FUTURE_YEARS ="POS_MAX_FUTURE_MONTHS";
        public const string POS_SETTING_MINIMUM_DAYS = "POS_MIN_DAYS";
        public const string POS_SETTING_MINIMUM_HOURS = "POS_MIN_HOURS";
        public const string POS_SETTING_XLEAVE_YEARS = "POS_XLEAVE_YEARS";
        public const string POS_SETTING_CROSSOVER_DAY = "POS_XOVER_DAY";
        public const string POS_SETTING_CROSSOVER_HOURS = "POS_XOVER_HOURS";
        public const string POS_SETTING_VAT_NUMBER = "VAT_NUMBER";
        public const string POS_SETTING_INVOICE_ADDRESS = "POS_INVOICE_ADDRESS";
        public const string POS_SETTING_INVOICE_FOOTER = "POS_INVOICE_FOOTER";
        public const string POS_SETTING_MIN_TRACKING_VALUE = "POS_MIN_TRACKING_VAL";
        public const string POS_SETTING_INV_PREFIX = "POS_INVOICE_PREFIX";

        public const string POS_SETTING_MILEAGE_RATE_1 = "POS_MILEAGE_1";
        public const string POS_SETTING_MILEAGE_RATE_2 = "POS_MILEAGE_2";
        public const string POS_SETTING_MILEAGE_FIRSTX = "POS_MILEAGE_FIRST";

        public const string POS_SETTING_ACCOUNT_YEAR_START = "POS_ACCT_YR_START";
        public const string POS_SETTING_ACCOUNT_YEAR_END = "POS_ACCT_YR_END";


        public const string DEFAULT_BOT_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0) sdbot/POS";
        public const string DEFAULT_BOT_CLOUD_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0b; Windows NT 6.0) sdcloud/";

        public const string BACKUP_NAME = "pos";


        public const string STORE_DISCOUNT = "Store Discount";
        

        // database errors
        public const string ERROR_APPOINTMENT_NOT_FOUND = "Record not found in Table WS_APPOINTMENTS";
        public const string ERROR_PROCESS_IN_USE = "because it is being used by another process";
        public const string ERROR_LOCK_CONFLICT = "lock conflict on no wait transaction";
        public const string ERROR_UPDATE_CONFLICTS = "update conflicts with concurrent update";
        public const string ERROR_VIOLATION_FOREIGN_KEY = "violation of FOREIGN KEY constraint";
        public const string ERROR_USER_FOREIGN_VIOLATION = "violation of FOREIGN KEY constraint \"FK_WS_INVOICE_USER_ID\" on table \"WS_INVOICE\"";
        public const string ERROR_FOREIGN_KEY_NOT_EXIST = "Foreign key reference target does not exist";
        public const string ERROR_FOREIGN_KEY_EXISTS = "Foreign key references are present for the record";
        public const string ERROR_VIOLATION_UNIQUE_KEY = "violation of PRIMARY or UNIQUE KEY constraint";
        public const string ERROR_VIOLATION_APPT_OPTIONS = "PRIMARY or UNIQUE KEY constraint \"PK_APPT_OPTIONS_EX\"";
        public const string ERROR_VIOLATION_COUPON = "violation of PRIMARY or UNIQUE KEY constraint \"IDX_COUPONS_UNIQUE_COUPON";
        public const string ERROR_VIOLATION_PRODUCT_PRODUCT_NAME = "PRIMARY or UNIQUE KEY constraint \"IDX_WS_PRODUCTS_NAME";
        public const string ERROR_DIPLICATE_SKU = "violation of PRIMARY or UNIQUE KEY constraint \"UNQ_WS_PRODUCTS_COST_SIZE_SKU";
        public const string ERROR_VIOLATION_CAMPAIGN = "violation of PRIMARY or UNIQUE KEY constraint \"UNQ_WS_CAMPAIGNS_NAME";
        public const string ERROR_INVALID_TRANSACTION_HANDLE = "invalid transaction handle (expecting explicit transaction start)";
        public const string ERROR_INVALID_TRANSACTION = "invalid transaction handle";
        public const string ERROR_EXPECTING_TRANSACTION_START = "expecting explicit transaction start";
        public const string ERROR_FB_CLIENT = "FirebirdSql.Data.FirebirdClient";
        public const string ERROR_STORE_DUPLICATE = "attempt to store duplicate value";
        public const string ERROR_STORE_DUPLICATE_USER_EMAIL = "attempt to store duplicate value (visible to active transactions) in unique index \"IDX_WS_MEMBERS_EMAIL";
        public const string ERROR_PRODUCT_HAS_STOCK = "Can not delete as stock exists";
        public const string ERROR_ADDRESS_IN_USE = "Address can not be updated as it is in use with an order/invoice";
        public const string ERROR_INVALID_VOUCHER_CODE = "Invalid Voucher Code";
        public const string ERROR_INVALID_VOUCHER_AMOUNT = "Invalid Voucher Amount";
        public const string ERROR_INVALID_VOUCHER_ISSUE_DATE = "validation error for column ISSUE_DATE";
        public const string ERROR_INVALID_VOUCHER_NOT_SOLD = "The voucher with this code has not been sold";
        public const string ERROR_INVALID_VOUCHER_REDEEMED = "Voucher has already been redeemed";
        public const string ERROR_INVALID_VOUCHER_NOT_EXIST = "Voucher does not exist";
        public const string ERROR_INVALID_VOUCHER_SOLD = "The voucher has already been sold";
        public const string ERROR_STOCK_ZERO = "Stock Level Can not be less than zero";
        public const string ERROR_UNABLE_TO_CONNECT_REMOTE_SERVER = "Unable to connect to the remote server";
        public const string ERROR_STOCK_CREATE_NOT_FOUND = "Can not create stock, product not found";
        public const string ERROR_INVALID_SKU = "Invalid SKU Code";
        public const string ERROR_USED_BY_OTHER_PROCESSS = "used by another process";


        public const string ERROR_LOG_ENTRY = "\r\nLog Entry : ";
        public const string ERROR_PRINTER_DELETED = "specified printer has been deleted";
        public const string ERROR_NO_PAGES = "The document has no pages";
        public const string ERROR_INVALID_TYPE = "Invalid Type";
        public const string ERROR_INVALID_PERMISSIONS = "Invalid Permission, Administration Users Only";
        public const string ERROR_INVALID_PERMISSION_UPDATE = "User does not have permission to Update";
        public const string ERROR_THREAD_BEING_ABORTED = "Thread was being aborted.";
        public const string ERROR_DISPOSED_OBJECT = "Cannot access a disposed object.";
        public const string ERROR_INPUT_STREAM = "input stream is not a valid binary format";
        public const string ERROR_FILE = "{1}\\Errors\\{0}.txt";
        public const string ERROR_FILE_NAME = "dd-MM-yyyy hh-mm-ss";
        public const string ERROR_INTERNAL_1 = "Internal Exception in DAL\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}";
        public const string ERROR_INTERNAL_2 = "{5}\r\nInternal Exception in DAL\r\n\r\nMethod: {0}\r\n\r\nMessage: {4}\r\n\r\nSource: {1}\r\n\r\nParameters:\r\n\r\n{2}\r\n\r\nCallstack:\r\n\r\n{3}";
        public const string ERROR_INFO = "{2}\r\nClient Connected: {3}\r\nStore: {4}\r\nTill: {5}\r\nUser: {6}\r\nShifoo Systems\r\nPoint of Sale\r\nVersion: {0}\r\nDatabase Version: {1}\r\n";
        public const string ERROR_INFO_UPTIME = "\r\nUptime: {0}";
        public const string ERROR_INFO_MODULE = "{0} - {1}\r\n";
        public const string ERROR_DEBUG_STOP = "adhd";
        public const string ERROR_LOG_SEPERATOR = "-------------------------------";
        public const string ERROR_CANT_SEND = "Error - Can't Send";
        public const string ERROR_NO_NETWORK = "Unable to complete network request to host";
        public const string ERROR_INPUT_STRING = "Input string was not in a correct format";
        public const string ERROR_INVALID_PRODUCT_ITEM = "Invalid Product Item";
        public const string ERROR_PRODUCT_IN_USE = "Product Item is in use.";
        public const string ERROR_THERAPIST_NOT_FOUND = "Therapist not found";
        public const string ERROR_INVALID_VOUCHER_TYPE = "Invalid InvoiceVoucherType";
        public const string ERROR_READING_DATA = "Error reading data from the connection.";
        public const string ERROR_CARD_INVALID_NUMBER = "The card number does not appear to be valid!";
        public const string ERROR_CARD_INVALID_LAST_3 = "The last 3 digits do not appear to be valid!";
        public const string ERROR_CARD_INVALID_FROM_TO = "The Valid From/To values do not appear to be valid";
        public const string ERROR_CARD_INVALID_FROM = "Valid From can not be greater or equal to Valid To";
        public const string ERROR_CARD_INVALID_REASON = "Please enter a valid reason of at least 15 characters long";
        public const string ERROR_INVALID_INPUT_STREAM = "The input stream is not a valid binary format.";
        public const string ERROR_RESOLVE_REMOTE_NAME = "The remote name could not be resolved";
        public const string ERROR_INVALID_FOLDER_TYPE = "Invalid Folder Type";


        public const string TABLE_MEMBERS = "WS_MEMBERS";
        public const string TABLE_PRODUCTS = "WS_PRODUCTS";
        public const string TABLE_PRODUCT_ITEMS = "WS_PRODUCTS_COST_SIZE";

        public const string LANGUAGE_RESOURCE_FILE = "languages.resources";

        public const string CULTURE_ENGLISH = "en";
        public const string CULTURE_ENGLISH_UK = "en-GB";

        internal const string FOLDER_ERRORS = "Errors";
        internal const string FOLDER_DICTIONARY = "Dictionary";
        internal const string FOLDER_MARKETING = "Marketing";
        internal const string FOLDER_LANGUAGES = "Languages";
        internal const string FOLDER_BACKUPS = "Backups";
        public const string FOLDER_INVOICES = "Invoices";
        public const string FOLDER_IMAGE_PRODUCT = "Product";
        internal const string FOLDER_PLUGIN = "Plugins";
        internal const string FOLDER_TEMP = "Temp";
        internal const string FOLDER_HELP = "Help";

        public const string FOLDER_PATH = "{0}\\{1}\\";
        public const string FOLDER_DICTIONARY_PATH = "{0}\\dictionary\\";
        public const string FOLDER_DICTIONARY_FILE = "{0}Dictionary\\{1}";
        public const string FOLDER_MARKETING_PREVIEW = "Marketing\\Preview\\";
        public const string FOLDER_PRODUCT_IMAGES = "Images\\Products\\{0}\\";
        public const string FOLDER_ADOBE = "{0}\\Adobe\\";
        public const string FOLDER_IMAGES = "Images";
        public const string FOLDER_IMAGE_FILE = "{0}Images\\{1}";
        public const string FOLDER_IMAGES_PRODUCTS = "Images\\Products\\Product\\";

        public const string FILE_EXTENSION_DICTIONARY_AFF = ".aff";
        public const string FILE_EXTENSION_DICTIONARY_DIC = ".dic";
        public const string FILE_EXTENSION_JPG = ".jpg";
        public const string FILE_EXTENSION_JPEG = ".jpeg";
        public const string FILE_EXTENSION_BITMAP = ".bmp";
        public const string FILE_EXTENSION_GIF = ".gif";
        public const string FILE_EXTENSION_ICO = ".ico";
        public const string FILE_EXTENSION_EMAIL_HTM = ".email.htm";
        public const string FILE_EXTENSION_EMAIL = ".email";
        public const string FILE_EXTENSION_NEW = ".new";
        public const string FILE_EXTENSION_DICTIONARY = ".dic";
        public const string FILE_EXTENSION_DICTIONARY_SEARCH = "*.dic";
        public const string FILE_EXTENSION_CAMPAIGN = ".cmpg";
        public const string FILE_EXTENSION_HTML = ".html";
        public const string FILE_EXTENSION_DLL = ".dll";


        public const string FILE_SEARCH_JPEG = "JPEG Files|*.jpg";
        public const string FILE_SEARCH_HTML = "*.html";
        public const string FILE_SEARCH_DLL = "DLL Files|*.dll";

        public const string FILE_POS_MANUAL = "POS Manual.pdf";
        public const string FILE_SAGE_EXPORT = "NewSageUsers.csv";
        public const string FILE_ERROR_LOG = "ErrorLog.txt";
        public const string FILE_NAME_DATE = "ddMMyyhhmmss";
        public const string FILE_INVOICE_PART = "Invoice{0}.pdf";
        public const string FILE_INVOICE_LOCATION = "{0}{1}\\{2}";
        public const string FILE_CONFIG = @"\HSCConfig.xml";
        public const string FILE_CONFIG_2 = "HSCConfig.XML";
        public const string FILE_CONFIG_PLUGIN = "PluginConfig.xml";
        public const string FILE_HINTS = "ControlHints.xml";
        public const string FILE_MARKETING = "Marketing\\Settings.xml";
        public const string FILE_MARKETING_IMAGE_STYLE = "Marketing\\ImageStyle.xml";
        public const string FILE_SETTINGS = "Settings.xml";
        public const string FILE_MARKETING_IMAGE_TEMPLATE = "templates.xml";
        public const string FILE_MARKETING_IMAGE_COLOR = "ImageStyle.xml";
        public const string FILE_SYSTEM_CONFIG = "PosConfiguration.dat";
        public const string FILE_LIBRARY_USER32 = "user32.dll";
        public const string FILE_LABEL_NAME_1 = "{0}\\Labels\\label{1}.bmp";
        public const string FILE_LABEL_NAME_2 = "ddMMyyhhmmss";
        public const string FILE_LABEL_NAME_3 = @"{0}\Images\ShippingLabel.bmp";
        public const string FILE_DID_YOU_KNOW = "DidYouKnow.xml";
        public const string FILE_DICTIONARY_CUSTOM_WORDS = "{0}\\dictionary\\custom.words";
        public const string FILE_IMAGE_NO_SALON = "/images/Salons/no-salon.gif";
        public const string FILE_ADOBE = "AcroRd32.exe";
        public const string FILE_INITIAL_SETUP = "InitialSetup.dat";
        public const string FILE_SERVICE_UPDATE = "Service{0}.zip";
        public const string FILE_USER_SETTINGS_CONFIG = "\\Shifoo\\HSCSettings.xml";
        public const string FILE_UPLOAD_HTML = "{0}{1}.html";
        public const string FILE_SPLASH_IMAGE = "splash.img";
        public const string FILE_PLUGIN_DATA = "Plugins.dat";
        public const string FILE_YAHOO_CURRENCIES = "CurrencyConversions.dat";
        public const string FILE_YAHOO_CURRENCIES_TEMP = "CurrencyConversions.tmp";
        public const string FILE_DELETE = "Delete File, iteration {0}, file: {1}";
        public const string FILE_NAME_CHARACTERS = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.-_";


        public const string WEB_SETTING_HOME_BANNER = "{0}.HOMEBANNER{1}";
        public const string WEB_SETTING_HOME_BANNER_LINK = "{0}.HOMEBANNER{1}LINK";

        public const string WEB_SETTING_PAGE_BANNER = "{0}.PAGEBANNER{1}";
        public const string WEB_SETTING_PAGE_BANNER_LINK = "{0}.PAGEBANNER{1}LINK";

        public const string WEB_SETTING_HOME_FIXED_BANNER_SHOW = "{0}.SETTINGS.HOMEBANNERS";
        public const string WEB_SETTING_HOME_FIXED_BANNER = "{0}.FIXEDBANNER{1}";
        public const string WEB_SETTING_HOME_FIXED_BANNER_LINK = "{0}.FIXEDBANNER{1}LINK";
        public const string WEB_SETTING_HOME_FIXED_BANNER_TITLE = "{0}.FIXEDBANNER{1}TITLE";
        public const string WEB_SETTING_HOME_FIXED_BANNER_DESCRIPTION = "{0}.FIXEDBANNER{1}NAME";



        public const string SERVICE_REPLICATION_ENGINE_1 = "Firebird Replication";


        public const string FONT_ARIAL = "Arial";


        public const string STAFF_COMMISSION_DETAILS = "{0}; {1}; {2}";

        public const string ORDER_LOCATION_HOST = "shop";


        public const string STOCK_ITEM_REMOVED = "{0} x {1} {2}\r\n";
        public const string STOCK_HIDDEN_FORMAT = ";{0};";
        public const string STOCK_UNHIDE_FORMAT = "{0};";
        public const string STOCK_SALE_INTERNET = "Internet";
        public const string STOCK_SEARCH_FILTER = "{0} {1} {2} {3}";

        public const string LABEL_PAGE_SIZE = "62mm x 100mm";

        public const string IMAGE_SEARCH = "*_DEFAULT*";
        public const string IMAGE_SEARCH_HOME_IMAGES = "*_700*";
        public const string IMAGE_SEARCH_PAGE_IMAGES = "*_154*";
        public const string IMAGE_SEARCH_OFFER_IMAGES = "*_650*";
        public const string IMAGE_SEARCH_PRODUCTS = "*_148*";
        public const string IMAGE_SEARCH_TREATMENTS = "*_148*";
        public const string IMAGE_SEARCH_WEB_TREATMENTS = "*_130*";
        public const string IMAGE_SEARCH_CELEBRITIES = "*_172*";
        public const string IMAGE_SEARCH_FIXED_HOME_BANNERS = "*_449*";


        public const string IMAGE_LOGO_INVOICE = "LOGO_239.jpg";


        public const string IMAGE_FTP_ROOT = "{0}/Images/{1}/{2}";

        public const string IMAGE_SEARCH_FILTER = "{0}|*.jpg;*.jpeg;*.png;*.gif|Jpeg|*.jpg;*.jpeg|PNG|*.png|Gif|*.gif";
        public const string IMAGE_DEFAULT = "_DEFAULT";
        public const string IMAGE_SIZE_DEFAULT = "148";
        public const string IMAGE_SIZE_DEFAULT_PRODUCT_IMAGE = "_148.JPG";
        public const string IMAGE_SIZE_BASKET = "66";


        public const string WEB_PAGE_MISSING_LINK = "/Anypage.aspx";
        public const string WEB_PAGE_UPDATE_IMAGES = "staff/admin/WebManualUpdates.aspx";


        public const string HTML = "HTML";


        public const string CURRENCY_CONVERSION = "1 {0} = {1} {2} {3}";
        public const string CURRENCY_CONVERSION_ALT = "{0}\t{1}\t{2}";
        public const string CURRENCY_UP = "↑";
        public const string CURRENCY_DOWN = "↓";
        public const string CURRENCY_SAME = "-";

        
        public const string BASE_WEB_HTTP = "http://";
        public const string BASE_WEB_HTTPS = "https://";
        public const string BASE_WEB_WWW = "www.";
        public const string BASE_WEB_METHOD_POST = "POST";


        public const string STAFF_FIRST_START_TIME = "{0} 06:00";
        public const string STAFF_START_10_AM = "{0} 10:00";
        public const string STAFF_START_10_30_AM = "{0} 10:30";
        public const string STAFF_FIRST_END_TIME = "{0} 12:00";

        public const string THREAD_NAME_UPDATE_IMAGE = "Update Image Thread";
        public const string THREAD_NAME_START_OF_DAY_CASH_DRAWER = "Start of day Cash Drawer check";
        public const string THREAD_NAME_POS_UPDATES = "Check for Updated POS Version";
        public const string THREAD_NAME_MAINTENANCE = "Maintenance Thread";
        public const string THREAD_NAME_IMAGE_MOVE = "Image Move Thread";
        public const string THREAD_NAME_UPDATE_LAUNCHER = "Update Thread Launcher";
        public const string THREAD_NAME_CASH_DRAWER_CHECKS = "Cash Drawer Random Checks";
        public const string THREAD_NAME_LOAD_ALL_USERS = "Load All Users";
        public const string THREAD_NAME_LOAD_ALL_APPOINTMENTS = "Load All Appointments";
        public const string THREAD_NAME_PRODUCT_WATCH = "Product Watch Thread";
        public const string THREAD_NAME_COMMUNICATION_LISTENER = "Communication Service Listner Thread";
        public const string THREAD_NAME_AUTO_LOGOUT = "Auto Logout Thread";
        public const string THREAD_NAME_UPDATE_SERVICE = "Update Service Files Thread";
        public const string THREAD_NAME_INSTALL_VALID = "Pos Install Validation";
        public const string THREAD_NAME_POS_INSTALL_UPDATER = "Pos Installer Updater";
        public const string THREAD_NAME_CURRENCY_CONVERSION = "Currency Conversion Update Thread";
        public const string THREAD_NAME_FILE_BACKUP = "File Backup Thread";
        public const string THREAD_NAME_EXECUTE_AUTO_UPDATES = "Execute Auto Updates Thread";
        public const string THREAD_NOTIFICATIONS_UPDATE = "Notification Update Thread";
        public const string THREAD_NAME_RECURRING_INVOICES = "Generate Recurring Invoices";


        public const string THREAD_FORCED_CLOSE = "Thread forced to Close - Name: {0}; ID: {1}";
        public const string THREAD_FORCED_ABORT = "Thread forced to Abort - Name: {0}; ID: {1}";
        public const string THREAD_START = "Thread started - Name: {0}; ID: {1}";
        public const string THREAD_STOP = "Thread stopped - Name: {0}; ID: {1}";


        public const string YAHOO_CURRENCIES = "USD#United States Dollars $;EUR#Euro €;GBP#United Kingdom Pounds £;JPY#Japan Yen ¥;AFN#Afghanistan Afghanis ؋;ALL#Albania Leke Lek;DZD#Algeria Dinars DA;ARS#Argentina Pesos $;AUD#Australia Dollars $;BSD#Bahamas Dollars $;BHD#Bahrain Dinars BD;BDT#Bangladesh Taka Tk;BBD#Barbados Dollars $;BMD#Bermuda Dollars $;BRL#Brazil Reais R$;BGN#Bulgaria Leva лв;CAD#Canada Dollars $;XOF#CFA Francs BCEAO CFAF;XAF#CFA Francs BEAC CFAF;XPF#CFP Francs ;CLP#Chile Pesos $;CNY#China Yuan Renminbi 元;COP#Colombia Pesos $;CRC#Costa Rica Colones ₡;HRK#Croatia Kuna kn;CYP#Cyprus Pounds £;CZK#Czech Republic Koruny Kč;DKK#Denmark Kroner kr;DOP#Dominican Republic Pesos RD$;XCD#East Caribbean Dollars $;EGP#Egypt Pounds £;EEK#Estonia Krooni kr;FJD#Fiji Dollars $;HKD#Hong Kong Dollars 元;HUF#Hungary Forint Ft;ISK#Iceland Kronur kr;XDR#IMF Special Drawing Rights ;INR#India Rupees ₨;IDR#Indonesia Rupiahs Rp;IRR#Iran Rials ﷼;IQD#Iraq Dinars ID;ILS#Israel New Shekels ₪;JMD#Jamaica Dollars J$;JOD#Jordan Dinars JD;KZT#Kazakhstan Tenge лв;KES#Kenya Shillings K Sh;KWD#Kuwait Dinars KD;LBP#Lebanon Pounds £;MYR#Malaysia Ringgits RM;MTL#Malta Liri Lm;MUR#Mauritius Rupees ₨;MXN#Mexico Pesos $;MAD#Morocco Dirhams DH;NZD#New Zealand Dollars $;NGN#Nigeria Nairas ₦;NOK#Norway Kroner kr;OMR#Oman Rials ﷼;PKR#Pakistan Rupees ₨;XPD#Palladium Ounces ;PEN#Peru Nuevos Soles S/.;PHP#Philippines Pesos Php;PLN#Poland Zlotych zł;QAR#Qatar Riyals ﷼;RON#Romania New Lei lei;RUB#Russia Rubles руб;SAR#Saudi Arabia Riyals ﷼;XAG#Silver Ounces ;SGD#Singapore Dollars $;ZAR#South Africa Rand R;KRW#South Korea Won ₩;LKR#Sri Lanka Rupees ₨;SDG#Sudan Pounds ;SEK#Sweden Kronor kr;CHF#Switzerland Francs CHF;TWD#Taiwan New Dollars NT$;THB#Thailand Baht ฿;TTD#Trinidad and Tobago Dollars TT$;TND#Tunisia Dinars TD;TRY#Turkey Lira YTL;AED#United Arab Emirates Dirhams Dh;VEF#Venezuela Bolivares Fuertes ;VND#Vietnam Dong ₫;ZMK#Zambia Kwacha ZK;";
        public const string YAHOO_CURRENCY_REQUEST = "\"{0}{1}\"";
        public const string YAHOO_CURRENCY_REQUEST_SUBSEQUENT = ",\"{0}{1}\"";

        public const string REPLICATION_IS_REPLICATING = "ISREPLICATING";
        public const string REPLICATION_ID_CHANGED = "IDCHANGED";
        public const string REPLICATION_APPOINTMENTS = "APPOINTMENTS";
        public const string REPLICATION_USERS = "USERS";
        public const string REPLICATION_END = "Replication End";
        public const string REPLICATION_RUN = "Run Replication";
        public const string REPLICATION_REPLICATE = "REPLICATE";


        public const string USER_DEFAULT_NO_EMAIL = "no-email";
        public const string USER_DEFAULT_FIRST_NAME = "POS";
        public const string USER_DEFAULT_LAST_NAME = "User";
        public const string USER_SALON_USER = "salonuser";



        public const string MAIL_CHIMP_CAMPAIGN_TYPE = "regular";
        public const string MAIL_CHIMP_OPTIONS = "options";
        public const string MAIL_CHIMP_SCHEDULE_FORMAT = "yyyy-MM-dd HH:mm:ss";



        public const string REPORT_MENU_NAME = "menuReport{0}";
        public const string REPORT_PROPERTY_VOUCHER_COUNTRY = "VoucherCountry";
        public const string REPORT_PROPERTY_ALL_APPOINTMENTS = "AllAppointments";
        public const string REPORT_METHOD_SHOW_DIALOG = "ShowDialog";

        public const string XML_ROOT_NODE_NAME = "SieraDelta";
        public const string XML_CONFIG_FILE = "HSCConfig.XML";
        public const string XML_LABEL_PRINTER = "LabelPrinter";
        public const string XML_LABEL_NAME = "Name";
        public const string XML_TOP = "Top";
        public const string XML_LEFT = "Left";
        public const string XML_WIDTH = "Width";
        public const string XML_HEIGHT = "Height";
        public const string XML_LOCAL_DELIVERY = "LocalDeliverySettings";
        public const string XML_INTERNATIONAL_DELIVERY = "InternationalDeliverySettings";
        public const string XML_PREFIX = "Prefix";
        public const string XML_SUFFIX = "Suffix";
        public const string XML_AUTO_INCREMENT = "AutoIncrement";
        public const string XML_UNIQUE_NUMBER = "UniqueNumber";
        public const string XML_MARKETING = "Marketing";
        public const string XML_MARKETING_TEMPLATES = "Templates";
        public const string XML_MARKETING_TEMPLATE = "Template{0}";
        public const string XML_MARKETING_FILENAME = "FileName";
        public const string XML_MARKETING_FILE = "File";
        public const string XML_MARKETING_THUMBNAIL = "Thumbnail";
        public const string XML_MARKETING_COLOR = "Color";
        public const string XML_MARKETING_BACK_COLOR = "BackColor";
        public const string XML_SPLITTER_DISTANCE = "SplitterDistancce";
        public const string XML_PLUGINS = "Plugins";
        public const string XML_PLUGIN_HOME_BUTTON = "HomeButton";
        public const string XML_PLUGIN_HOME_BUTTON_VISIBLE = "{0}Visible";
        public const string XML_PLUGIN_HOME_BUTTON_POSITION = "{0}Position";
        public const string XML_PLUGIN_TRAY_ICON = "TrayIcon";
        public const string XML_PLUGIN_TRAY_ICON_VISIBLE = "{0}Visible";
        public const string XML_PLUGIN_TRAY_ICON_POSITION = "{0}Position";


        public const string SETTINGS_AUTO_LOGIN = "AutoLogin";
        public const string SETTINGS_USER_ID = "UserID";
        public const string SETTINGS_USER_EMAIL = "Email";
        public const string SETTINGS_USER_PASSWORD = "Password";
        public const string SETTINGS_ADOBE = "Adobe";
        public const string SETTINGS_APPLICATION = "Application";
        public const string SETTINGS_VERSION = "Version";
        public const string SETTINGS_LANGUAGE_PACK = "LanguagePack";
        public const string SETTINGS_VERSION_INFO = "VersionInfo";
        public const string SETTINGS_SERVICE_FILES = "ServiceFiles";
        public const string SETTINGS_CAMPAIGN_NAME = "CampaignName";
        public const string SETTINGS_CAMPAIGN_TRACKING_CODE = "TrackingCode";
        public const string SETTINGS_CAMPAIGN_EMAIL = "CampaignEmail";
        public const string SETTINGS_INTRO = "Intro";
        public const string SETTINGS_MENU_NAME_1 = "Menu 1 Name";
        public const string SETTINGS_MENU_URL_1 = "Menu 1 URL";
        public const string SETTINGS_MENU_NAME_2 = "Menu 2 Name";
        public const string SETTINGS_MENU_URL_2 = "Menu 2 URL";
        public const string SETTINGS_MENU_NAME_3 = "Menu 3 Name";
        public const string SETTINGS_MENU_URL_3 = "Menu 3 URL";
        public const string SETTINGS_MENU_NAME_4 = "Menu 4 Name";
        public const string SETTINGS_MENU_URL_4 = "Menu 4 URL";
        public const string SETTINGS_MENU_NAME_5 = "Menu 5 Name";
        public const string SETTINGS_MENU_URL_5 = "Menu 5 URL";
        public const string SETTINGS_STEP_6 = "Step6";
        public const string SETTINGS_FACEBOOK = "FaceBook";
        public const string SETTINGS_GPLUS = "GPlus";
        public const string SETTINGS_RSS = "RSS";
        public const string SETTINGS_TWITTER = "Twitter";
        public const string SETTINGS_STEP_5 = "Step5{0}";
        public const string SETTINGS_DESCRIPTION = "Description";
        public const string SETTINGS_TITLE = "Title";
        public const string SETTINGS_IMAGE = "Image";
        public const string SETTINGS_URL = "URL";
        public const string SETTINGS_ADDITIONAL_PRODUCTS = "AdditionalProducts";
        public const string SETTINGS_ADDITIONAL_PRODUCT_TITLE_LENGTH = "AdditionalProductTitleLength";
        public const string SETTINGS_ADDITIONAL_PRODUCT_DESCRIPTION_LEGTH = "AdditionalProductDescriptionLength";
        public const string SETTINGS_ADDITIONAL_PRODUCT_WIDTH = "AdditionalProductWidth";
        public const string SETTINGS_STEP_1 = "Step1";
        public const string SETTINGS_NAME = "Name";
        public const string SETTINGS_TEMPLATE = "Template";
        public const string SETTINGS_TEMPLATES = "Templates";
        public const string SETTINGS_FILENAME = "FileName";
        public const string SETTINGS_MARKETING = "Marketing";
        public const string SETTINGS_STEP_2 = "Step2";
        public const string SETTINGS_ALLOW_SET_TITLE = "AllowSetTitle";
        public const string SETTINGS_ALLOW_STRAP_LINE = "AllowStrapLine";
        public const string SETTINGS_STRAP_LINE = "StrapLine";
        public const string SETTINGS_STRAP_LINE_COUNT = "StrapLineLineCount";
        public const string SETTINGS_TITLE_LENGTH = "TitleLength";
        public const string SETTINGS_STRAP_LINE_LENGTH = "StrapLineLength";
        public const string SETTINGS_COLOR_SET = "AllowSetColour";
        public const string SETTINGS_STEP_3 = "Step3";
        public const string SETTINGS_COLOR_R = "ColorR";
        public const string SETTINGS_COLOR_G = "ColorG";
        public const string SETTINGS_COLOR_B = "ColorB";
        public const string SETTINGS_SUB_TEXT = "SubText";
        public const string SETTINGS_STEP_3A = "Step3A";
        public const string SETTINGS_SUB_TEXT_ALLOW = "AllowSubText";
        public const string SETTINGS_STEP_4 = "Step4";
        public const string SETTINGS_IMAGE_LINK = "ImageLink";
        public const string SETTINGS_IMAGE_LINK_CUSTOM = "CustomImageLink";
        public const string SETTINGS_PRODUCT_TYPE_1 = "SelectedProductType1";
        public const string SETTINGS_PRODUCT_1 = "SelectedProduct1";
        public const string SETTINGS_PRODUCT_COST_1 = "SelectedProductCost1";
        public const string SETTINGS_PRODUCT_TYPE_2 = "SelectedProductType2";
        public const string SETTINGS_PRODUCT_2 = "SelectedProduct2";
        public const string SETTINGS_PRODUCT_COST_2 = "SelectedProductCost2";
        public const string SETTINGS_PRODUCT_TYPE_3 = "SelectedProductType3";
        public const string SETTINGS_PRODUCT_3 = "SelectedProduct3";
        public const string SETTINGS_PRODUCT_COST_3 = "SelectedProductCost3";
        public const string SETTINGS_PRODUCT_TYPE_4 = "SelectedProductType4";
        public const string SETTINGS_PRODUCT_4 = "SelectedProduct4";
        public const string SETTINGS_PRODUCT_COST_4 = "SelectedProductCost4";
        public const string SETTINGS_IMAGE_FILE = "ImageFile";
        public const string SETTINGS_SECONDARY_IMAGE = "SecondaryImage";
        public const string SETTINGS_SECONDARY_LINK = "SecondaryImageLink";
        public const string SETTINGS_MAIN_IMAGE_WIDTH = "MainImageWidth";
        public const string SETTINGS_HOME_IMAGE = "HomeImage";
        public const string SETTINGS_HOME_IMAGE_LINK = "HomeLink";
        public const string SETTINGS_PAGE_IMAGE = "PageImage";
        public const string SETTINGS_PAGE_IMAGE_LINK = "PageLink";
        public const string SETTINGS_CRC = "CRC";



        public const string SETTINGS_CAMPAIGN_TRACKING_CODE_ALLOWED = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-.";
        public const string SETTINGS_CAMPAIGN_BASE_URL = "{base-url}";
        public const string SETTINGS_CAMPAIGN_BASE_URL_SHORT = "{base-url-short}";
        public const string SETTINGS_CAMPAIGN_HEADER = "{header}";
        public const string SETTINGS_CAMPAIGN_STRAPLINE = "{strapline}";
        public const string SETTINGS_CAMPAIGN_CAMPAIGN = "{campaign}";
        public const string SETTINGS_CAMPAIGN_HEADER_COLOR = "{header-color}";
        public const string SETTINGS_CAMPAIGN_COMPANY_NAME = "{company-name}";
        public const string SETTINGS_CAMPAIGN_CAMPAIGN_EMAIL = "{campaign-email}";
        public const string SETTINGS_CAMPAIGN_MENU_URL_1 = "{menu-1-url}";
        public const string SETTINGS_CAMPAIGN_MENU_NAME_1 = "{menu-1-name}";
        public const string SETTINGS_CAMPAIGN_MENU_URL_2 = "{menu-2-url}";
        public const string SETTINGS_CAMPAIGN_MENU_NAME_2 = "{menu-2-name}";
        public const string SETTINGS_CAMPAIGN_MENU_URL_3 = "{menu-3-url}";
        public const string SETTINGS_CAMPAIGN_MENU_NAME_3 = "{menu-3-name}";
        public const string SETTINGS_CAMPAIGN_MENU_URL_4 = "{menu-4-url}";
        public const string SETTINGS_CAMPAIGN_MENU_NAME_4 = "{menu-4-name}";
        public const string SETTINGS_CAMPAIGN_MENU_URL_5 = "{menu-5-url}";
        public const string SETTINGS_CAMPAIGN_MENU_NAME_5 = "{menu-5-name}";
        public const string SETTINGS_CAMPAIGN_MAIN_IMAGE = "{main-image}";
        public const string SETTINGS_CAMPAIGN_MAIN_IMAGE_LINK = "{main-image-link}";
        public const string SETTINGS_CAMPAIGN_SECONDARY_IMAGE = "{secondary-image}";
        public const string SETTINGS_CAMPAIGN_SECONDARY_IMAGE_LINK = "{secondary-image-link}";
        public const string SETTINGS_CAMPAIGN_PRODUCT_NAME = "{prodct-{0}-name}";
        public const string SETTINGS_CAMPAIGN_PRODUCT_IMAGE = "{prodct-{0}-image}";
        public const string SETTINGS_CAMPAIGN_PRODUCT_URL = "{prodct-{0}-url}";
        public const string SETTINGS_CAMPAIGN_PRODUCT_DESCRIPTION = "{prodct-{0}-description}";
        public const string SETTINGS_CAMPAIGN_SUBTEXT_COLOR = "{subtext-color}";
        public const string SETTINGS_CAMPAIGN_SUBTEXT = "{subtext}";
        public const string SETTINGS_CAMPAIGN_SOCIAL_RSS = "{social-rss}";
        public const string SETTINGS_CAMPAIGN_SOCIAL_G_PLUS = "{social-g-plus}";
        public const string SETTINGS_CAMPAIGN_SOCIAL_TWITTER = "{social=twitter}";
        public const string SETTINGS_CAMPAIGN_SOCIAL_FACEBOOK = "{social-facebook}";
        public const string SETTINGS_CAMPAIGN_VIEW_ONLINE = "{view-online}";
        public const string SETTINGS_CAMPAIGN_HTML_BR = "<br />";
        public const string SETTINGS_CAMPAIGN_HTML_RGB = "rgb({0}, {1}, {2})";
        public const string SETTINGS_CAMPAIGN_TEMPLATE_STYLE_DEFAULT = "emails/template1";
        public const string SETTINGS_CAMPAIGN_TEMPLATE_STYLE_SELECTED = "emails/{0}";
        public const string SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR = "color: white;";
        public const string SETTINGS_CAMPAIGN_TEMPLATE_BACK_COLOR = "rgb(167, 169, 172)";
        public const string SETTINGS_CAMPAIGN_TEMPLATE_TEXT_COLOR_SET = "color: {0};";



        public const string SETTINGS_CAMPAIGN_ONLINE_IMAGE_LOCATION = "{0}/Campaigns/{1}/{2}/";
        public const string SETTINGS_CAMPAIGN_ONLINE_PREVIEW = "{0}Preview{1}.html";
        public const string SETTINGS_CAMPAIGN_ONLINE_TRACKING_LINK = "/offers/cm.aspx?cmp=";

        public const string CREDIT_CARD_PASSPHRASE = "CCD9idkmrhyd@_13A";
        public const string CREDIT_CARD_DATE_FORMAT = "MM/yy";


        public const string PAYMENT_TYPE_SPLIT = "In Store Split Payment";
        public const string PAYMENT_TYPE_SALON_NOT_PAID = "In Store Not Paid";

        public const string TILL_BARCODE_PREFIX_HHB = "HHB";
        public const string TILL_BARCODE_PREFIX_HV = "HV";


        public const string EXPORT_CSV_HEADER_ITEM = "{0},";
        public const string EXPORT_CSV_ITEM_COLUMN = "\"{0}\"";

        public const string EXPORT_USER_COLUMN_EMAIL = "EMAIL";
        public const string EXPORT_USER_COLUMN_USERNAME = "USERNAME";
        public const string EXPORT_USER_COLUMN_FIRSTNAME = "FIRSTNAME";
        public const string EXPORT_USER_COLUMN_LASTNAME = "LASTNAME";
        public const string EXPORT_USER_COLUMN_BUSINESSNAME = "BUSINESSNAME";
        public const string EXPORT_USER_COLUMN_ADDRESSLINE1 = "ADDRESSLINE1";
        public const string EXPORT_USER_COLUMN_ADDRESSLINE2 = "ADDRESSLINE2";
        public const string EXPORT_USER_COLUMN_ADDRESSLINE3 = "ADDRESSLINE3";
        public const string EXPORT_USER_COLUMN_CITY = "CITY";
        public const string EXPORT_USER_COLUMN_COUNTY = "COUNTY";
        public const string EXPORT_USER_COLUMN_POSTCODE = "POSTCODE";
        public const string EXPORT_USER_COLUMN_COUNTRY = "COUNTRY";
        public const string EXPORT_USER_COLUMN_TELEPHONE = "TELEPHONE";
        public const string EXPORT_USER_COLUMN_OFFER_EMAIL = "RECEIVE_EMAIL_SPECIAL_OFFERS";
        public const string EXPORT_USER_COLUMN_OFFER_PHONE = "RECEIVE_PHONE_SPECIAL_OFFERS";
        public const string EXPORT_USER_COLUMN_OFFER_POSTAL = "RECEIVE_POSTAL_SPECIAL_OFFERS";
        public const string EXPORT_USER_COLUMN_BIRTH_DATE = "BIRTH_DATE";
        public const string EXPORT_USER_COLUMN_NOTES = "NOTES";

        public const string PREFIX_AND_SUFFIX = "{0}{1}";
        public const string PREFIX_AND_SUFFIX_SPACE = "{0} {1}";
        public const string PREFIX_AND_SUFFIX_HYPHEN = "{0} - {1}";
        public const string PREFIX_AND_SUFFIX_SLASH = "{0}/{1}";
        public const string PREFIX_AND_SUFFIX_HYPHEN_BRACKETS = "{0} - ({1})";
        public const string PREFIX_AND_SPACE = "{0} ";
        public const string PREFIX_NO_SPACE = "{0}";
        public const string PREFIX_SUFFIX_COLON = "{0} : {1}";
        public const string INVOICE_NAME_ID_WITH_PREFIX = "{0} {1}{2}";
        public const string STOCK_ITEM_WITH_SKU = "{0} - {1} {2}";

        public const string TRACKING_REFERENCE = "{0}{1}{2}";

        public const string PRODUCT_COST_SIZE_DEFAULT = "{0} ({1})";
        public const string PRODUCT_COST_SIZE_TYPE = "{0} - {1} ({2})";


        public const string TEXT_LENGTH_DESCRIPTION = "{0}/{1} {2}";

        public const string USER_NAME = "{0}: {1}";
        public const string USER_PASSWORD_CHARACTERS = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ.";
        public const string EXPENSES_ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ ,.";

        public const string MAIL_CHIMP = "MailChimp";


        public const string COST_ZERO = "0.00";


        public const string BUTTON_ASSIGN = "{0} >>";
        public const string BUTTON_UNASSIGN = "<< {0}";


        public const string DATA_SOURCE_COLUMN_ID = "ID";
        public const string DATA_SOURCE_COLUMN_DESCRIPTION = "Description";
        public const string DATA_SOURCE_COLUMN_NAME = "Name";


        public const string VALIDATION_CHECK_CUSTOMER = "Member: {0} - {1}";
        public const string VALIDATION_CHECK_PRODUCT = "Product: {0} - {1}";
        public const string VALIDATION_CHECK_CARD = "User: {0} - {1} - {2}";
        public const string VALIDATION_CHECK_TICKET = "Ticket: {0} - {1}";

        public const string PAYMENT_OFFICE = "office";
        public const string PAYMENT_OFFICE_PAID = "Office Paid";
        public const string PAYMENT_OFFICE_NOT_PAID = "Office Not Paid";
        public const string PAYMENT_IN_STORE_SPLIT = "In Store Split Payment";
        public const string PAYMENT_IN_SALON_CASH = "In Store Paid Cash";


        public const string NO_EMAIL = "noemail";

        public const string CREATE_ORDER_TITLE = " - {0} - ({1})";


        public const string ORDER_PREFIX = "#{0}";


        public const string DISCOUNT = "{0} @ {1}{2}";


        public const string EMERGENCY_CONTACT_DATA = "{0}#{1}";


        public const string STATUS_SPLIT = "Split";

        public const string SYMBOL_AT = "@";
        public const string SYMBOL_PIPE = "|";
        public const string SYMBOL_HASH = "#";
        public const char SYMBOL_HASH_CHAR = '#';
        public const char SYMBOL_SQUIGGLE_CHAR = '~';
        public const string SYMBOL_AMPERSAND = "&";
        public const string SYMBOL_PERCENT = "%";
        public const string SYMBOL_ZERO = "0";
        public const string SYMBOL_ZERO_STOP = "0.";
        public const string SYMBOL_ONE = "1";
        public const string SYMBOL_TWO = "2";
        public const string SYMBOL_THREE = "3";
        public const string SYMBOL_SEVEN = "7";
        public const string SYMBOL_NINE = "9";
        public const string SYMBOL_DOLLAR = "$";
        public const char SYMBOL_DOLLAR_CHAR = '$';
        public const string SYMBOL_CRLF = "\r\n";
        public const string SYMBOL_CRLF_DOUBLE = "\r\n\r\n";
        public const string SYMBOL_CRLF_SAVED = "\\r\\n";
        public const string SYMBOL_MONEY_FORMAT_CURRENCY = "C";
        public const string SYMBOL_DATE_FORMAT_G = "G";
        public const string SYMBOL_DATE_FORMAT_M = "m";
        public const string SYMBOL_DATE_FORMAT_D = "d"; // short date localized
        public const string SYMBOL_DATE_FORMAT_T = "t"; // localized time only
        public const string SYMBOL_DATE_FORMAT_MONTH_YEAR = "y";
        public const string SYMBOL_SPACE = " ";
        public const char SYMBOL_SPACE_CHAR = ' ';
        public const string SYMBOL_EMPTY_STRING = "";
        public const string SYMBOL_HYPHEN = "-";
        public const string SYMBOL_HYPHON_SPACES = " - ";
        public const string SYMBOL_RETURN = "\r";
        public const char SYMBOL_RETURN_CHAR = '\r';
        public const string SYMBOL_LINE_FEED = "\n";
        public const string SYMBOL_EQUALS = "=";
        public const string SYMBOL_UNDERSCORE = "_";
        public const string SYMBOL_COLON = ":";
        public const string SYMBOL_SEMI_COLON = ";";
        public const char SYMBOL_SEMI_COLON_CHAR = ';';
        public const string SYMBOL_FORWARD_SLASH = "/";
        public const string SYMBOL_FULL_STOP = ".";
        public const char SYMBOL_FULL_STOP_CHAR = '.';
        public const char SYMBOL_BACK_SPACE = '\b';
        public const char SYMBOL_LETTER_D = 'd';
        public const string SYMBOL_TICK = "";
        public const string SYMBOL_COMMA = ",";

        public const string DATE_FORMAT_MONTH_FULL = "MMMM";
        


        public const string SPLIT_PAYMENT_VALID_CHARS = "0123456789.\b";


        public const string PAYMENT_BUTTON_0 = "btn0";
        public const string PAYMENT_BUTTON_1 = "btn1";
        public const string PAYMENT_BUTTON_2 = "btn2";
        public const string PAYMENT_BUTTON_3 = "btn3";
        public const string PAYMENT_BUTTON_4 = "btn4";
        public const string PAYMENT_BUTTON_5 = "btn5";
        public const string PAYMENT_BUTTON_6 = "btn6";
        public const string PAYMENT_BUTTON_7 = "btn7";
        public const string PAYMENT_BUTTON_8 = "btn8";
        public const string PAYMENT_BUTTON_9 = "btn9";
        public const string PAYMENT_BUTTON_10 = "btn10";
        public const string PAYMENT_BUTTON_20 = "btn20";
        public const string PAYMENT_BUTTON_40 = "btn40";
        public const string PAYMENT_BUTTON_50 = "btn50";
        public const string PAYMENT_BUTTON_100 = "btn100";

        public const string DATE_TIME_HOUR = "HH:mm";
        public const string DATE_DAY = "ddd";
        public const string DATE_WORK_ANIVERSARY = "dd MMMM";


        public const string YES = "Yes";
        public const string NO = "No";
        public const string TRUE = "True";
        public const string FALSE = "False";

        public const string CHARS_VALID_NUMERIC = "0123456789\b";


        public const string DIARY_HIDDEN_USER_SEPERATOR = "{0}={1}$";



        public const string MAP_LOCATIONS = "#LOCATIONS#";
        public const string MAP_TITLE = "#TITLE#";




        public const string VIDEO_YOUTUBE = "youtube";
        public const string VIDEO_YOUTUBE_SEPERATOR = "v=";

        public const string INVOICE_MANAGER_FORM_PROPERTIES = "FormProperties{0}";
        public const string INVOICE_MANAGER_SETTINGS_DISPATCHED = "Dispatched";
        public const string INVOICE_MANAGER_SETTINGS_ORDER_CANCELLED = "OrderCancelled";
        public const string INVOICE_MANAGER_SETTINGS_ORDER_RECEIVED = "OrderReceived";
        public const string INVOICE_MANAGER_SETTINGS_ORDER_PROCESSISNG = "OrderProcessing";
        public const string INVOICE_MANAGER_SETTINGS_DATE_ANY = "DateAny";
        public const string INVOICE_MANAGER_SETTINGS_DATE_RANGE = "DateRange";
        public const string INVOICE_MANAGER_SETTINGS_DATE_SPECIFIC = "DateSpecific";
        public const string INVOICE_MANAGER_SETTINGS_DATE_TODAY = "DateToday";
        public const string INVOICE_MANAGER_SETTINGS_PAYMENT_TYPE = "PaymentType";
        public const string INVOICE_MANAGER_SETTINGS_DISCOUNT_CODE = "DiscountCode";
        public const string INVOICE_MANAGER_SETTINGS_DATE_FROM = "DateFrom";
        public const string INVOICE_MANAGER_SETTINGS_DATE_TO = "DateTo";



        public const string CASH_DRAWER_START_OF_DAY = "START";
        public const string CASH_DRAWER_SAFE_IN = "SAFEIN";
        public const string CASH_DRAWER_CHECK = "CHECK";
        public const string CASH_DRAWER_CASH_ADD = "CASHA";
        public const string CASH_DRAWER_CASH_REMOVE = "CASHR";
        public const string CASH_DRAWER_PURCHASE = "PURCHA";
        public const string CASH_DRAWER_BANK = "BANK";
        public const string CASH_DRAWER_END_OF_DAY = "FINISH";
        public const string CASH_DRAWER_TILL_ITEMS = "Start of Day\rRoutine Check\rAdd Cash\rMoved To Safe\rBank\rEnd of Day";
        public const string CASH_DRAWER_SAFE_ITEMS = "Start of Day\rRoutine Check\rAdd Cash\rRemove Cash\rBank\rEnd of Day";
        public const string CASH_DRAWER_CASH_ITEMS = "Start of Day\rRoutine Check\rAdd Cash\rRemove Cash\rPurchase\rMoved To Safe\rBank\rEnd of Day";
        public const string CASH_DRAWER_TYPE_START_OF_DAY = "Start of Day";
        public const string CASH_DRAWER_TYPE_ROUTINE_CHECK = "Routine Check";
        public const string CASH_DRAWER_TYPE_MOVED_TO_SAFE = "Moved To Safe";
        public const string CASH_DRAWER_TYPE_ADD_CASH = "Add Cash";
        public const string CASH_DRAWER_TYPE_REMOVE_CASH = "Remove Cash";
        public const string CASH_DRAWER_TYPE_PURCHASE = "Purchase";
        public const string CASH_DRAWER_TYPE_BANK = "Bank";
        public const string CASH_DRAWER_TYPE_END_OF_DAY = "End of Day";


        public const string BASE_FORM = "BaseForm";


        public const string ABOUT_TEXT = "{7}\n\nVersion: {0} {8}\n\nDatabase Version: {1} {6}\n\nStore: {2}\n\nTill: {3}\n\nClient ID: {4}\n\n{5}";


        public const string PARAM_MARKETING = "Marketing";
        public const string PARAM_ADMINISTRATION = "Administration";
        public const string PARAM_IGNORE_CHECKS = "ic";
        public const string PARAM_IGNORE_ROLE = "IgnoreRole";
        public const string PARAM_MULTIPLE_INSTANCE = "MultipleInstance";
        public const string PARAM_ADMIN_CONFIG = "SystemConfig";
        public const string PARAM_CONFIGURE_REPLICATION = "configureReplication";
        public const string PARAM_ADMIN_SET_USER = "SetupInitialUser";
        public const string PARAM_ADMIN_FIRST_NAME = "firstName";
        public const string PARAM_ADMIN_LAST_NAME = "lastName";
        public const string PARAM_ADMIN_EMAIL = "email";
        public const string PARAM_ADMIN_PASSWORD = "password";
        public const string PARAM_SITE_ID = "siteID";


        public const string PRICE_DESCRIPTION_1 = "Price1Description";
        public const string PRICE_DESCRIPTION_2 = "Price2Description";
        public const string PRICE_DESCRIPTION_3 = "Price3Description";
        public const string PRICE_1 = "Price 1";
        public const string PRICE_2 = "Price 2";
        public const string PRICE_3 = "Price 3";


        public const string COMMISSION_POOL_MONTHS = "POS_COM_POOL_MONTHS";
        public const string COMMISSION_POOL_MIN_WAiT = "POS_COM_POOL_MIN_MONTHS";

        public const string COMMISSION_AFFILIATE_MONTHS = "POS_COM_MONTHS";
        public const string COMMISSION_AFFILIATE_MIN_WAiT = "POS_COM_MIN_MONTHS";

        public const string COMMISSION_CLIENT_MONTHS = "POS_COM_MONTHS";
        public const string COMMISSION_CLIENT_MIN_WAiT = "POS_COM_MIN_MONTHS";

        public const string EXPORT_HEADER_SAGE_USERS = "\"Account Reference\",\"Account Name\",\"Street 1\",\"Street 2\",\"Town\",\"County\",\"Postcode\",\"Contact Name\",\"Telephone Number\",\"EMail\",\"Country Code\"";
        public const string EXPORT_LINE_SAGE_USERS = "\"W{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"";

        public const string STOCK_SKU = "SKU";

        public const string STOCK_REORDER_COUNT = "COUNT";
        public const string STOCK_REORDER_PARAMETER_USER_ID = "USER_ID";
        public const string STOCK_REORDER_PARAMETER_USER_EMAIL = "USER_EMAIL";
        public const string STOCK_REORDER_PARAMETER_USER_PASSWORD = "USER_PASSWORD";
        public const string STOCK_REORDER_PARAMETER_USER_REQUESTING = "USER_REQUESTING";

        public const string STOCK_REORDER_PARAMATER_ID = "ID{0}";
        public const string STOCK_REORDER_PARAMATER_SKU = "SKU{0}";
        public const string STOCK_REORDER_PARAMATER_QUANTITY = "QUANTITY{0}";
        public const string STOCK_REORDER_PARAMATER_NAME = "NAME{0}";
        public const string STOCK_REORDER_PARAMATER_SIZE = "SIZE{0}";

        public const string PLUGIN_DATA = "{0}#{1}#{2}#{3}" + SYMBOL_CRLF;

        public const string PLUGIN_STORE = "STORE";
        public const string PLUGIN_TILL = "TILL";
        public const string PLUGIN_UPDATE_ADD_NEW_MODULES = "ALLOW NEW";
        public const string PLUGIN_UPDATE_VERSION = "VERSION";
        public const string PLUGIN_HASH = "HASH";
        public const string PLUGIN_PREFIX = "POS.";
        public const string PLUGIN_ERROR_INVALID_HASH = "Invalid Hash Value";
        public const string PLUGIN_UPDATES_NONE = "No Updates Available";

        public const string PLUGIN_UPDATER_THREAD = "POS Plugin Updater Thread";
        public const string PLUGIN_ALERT_THREAD = "POS Plugin Alert Thread";

        public const string PLUGIN_MODULE_BASE_NAME = "buttonPlugin{0}";
        public const string PLUGIN_MODULE_NAME_DIARY = "Diary";
        public const string PLUGIN_MODULE_NAME_STOCK = "Stock";
        public const string PLUGIN_MODULE_NAME_TILL = "Till";
        public const string PLUGIN_MODULE_NAME_ORDERS = "Orders";
        public const string PLUGIN_MODULE_NAME_ORDER_DISPATCH = "DispatchOrder";
        public const string PLUGIN_MODULE_NAME_CUSTOMERS = "Customers";
        public const string PLUGIN_MODULE_INTERNAL = "Internal Plugin";


        public const string PLUGIN_EVENT_DATABASE_BACKUP = "Database Backup";
        public const string PLUGIN_EVENT_TAKE_PAYMENT = "Take Payment";
        public const string PLUGIN_EVENT_PLUGIN_LOADED = "Plugin Loaded";
        public const string PLUGIN_EVENT_PLUGIN_UNLOADED = "Plugin Unloaded";
        public const string PLUGIN_EVENT_MAIN_FORM_SHOWING = "Main Form Load Complete";
        public const string PLUGIN_EVENT_SETTINGS_CHANGED_USER = "User Settings Changed";
        public const string PLUGIN_EVENT_SETTINGS_CHANGED_ADMIN = "Administration Settings Changed";
        public const string PLUGIN_EVENT_EDIT_PRODUCT_ITEM = "Edit Product Item";
        public const string PLUGIN_EVENT_EDIT_CUSTOMER = "Edit Customer";
        public const string PLUGIN_EVENT_SHOW_TILL_DISCOUNT = "Show Till Discount";
        public const string PLUGIN_EVENT_SHOW_CUSTOM_VAT_RATE = "Show Custom VAT Rate";
        public const string PLUGIN_EVENT_SHOW_MARK_AS_PAID = "Show Mark as Paid";
        public const string PLUGIN_EVENT_EDIT_TRAINING_APPOINTMENT = "Edit Training Appointment";
        public const string PLUGIN_EVENT_EDIT_APPOINTMENT = "Edit Appointment";
        public const string PLUGIN_EVENT_EDIT_SALON_TREATMENTS = "Edit Salon Treatments";
        public const string PLUGIN_EVENT_EDIT_STAFF_WORKING_HOURS = "Edit Staff Working Hours";
        public const string PLUGIN_EVENT_EDIT_STAFF_MEMBER = "Edit Staff Member";
        public const string PLUGIN_EVENT_SWITCH_USER = "Login Switch User";
        public const string PLUGIN_EVENT_VIEW_TICKET = "View Support Ticket";
        public const string PLUGIN_EVENT_CHANGE_STATUSBAR = "Change Status Bars";
        public const string PLUGIN_EVENT_SELECT_SALON = "Select Salon";
        public const string PLUGIN_EVENT_VIEW_INVOICE = "View Invoice";
        public const string PLUGIN_EVENT_VIEW_ORDER = "View Order";
        public const string PLUGIN_EVENT_VIEW_INVOICES_RECEIVED = "View Invoices Received";
        public const string PLUGIN_EVENT_EDIT_SALON = "Edit Salon Details";
        public const string PLUGIN_EVENT_LOAD_ADMIN_SETTINGS = "Load Admin Settings";
        public const string PLUGIN_EVENT_HOST_VERSION = "Host Version";
        public const string PLUGIN_EVENT_NEW_POS_VERSION = "New POS Version";
        public const string PLUGIN_EVENT_RAISE_LOGOUT_WARNING = "Raise Logout Warning";
        public const string PLUGIN_EVENT_TOAST_NOTIFICATION = "Toast Notification";
        public const string PLUGIN_EVENT_UPDATE_STATUS_BAR = "Update Status Bars";
        public const string PLUGIN_EVENT_WEBSITE_MODULE = "Website Module";
        public const string PLUGIN_EVENT_WEBSITE_COUNT = "Website Count";
        public const string PLUGIN_EVENT_WEBSITE_NAME = "Website Name";
        public const string PLUGIN_EVENT_LEAVE_ADD = "Leave Request Add";
        public const string PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE = "Product add or updated";
        public const string PLUGIN_EVENT_TREATMENT_ADD_REMOVE_UPDATE = "Treatment add or updated";
        public const string PLUGIN_EVENT_STOCK_COUNT_CHANGED = "Stock Count Changed";
        public const string PLUGIN_EVENT_INVOICE_CREATED = "New Invoice Created";
        public const string PLUGIN_EVENT_ORDER_DISPATCHED = "Order Dispatched";
        public const string PLUGIN_EVENT_ORDER_PROCESS_STATUS_CHANGED = "Order Status Changed";


        // !!!!  WHEN ADDING NEW EVENTS, MAKE SURE THEY ARE IN DEBUG MODUE TOO !!!!!!

        public const string EVENT_LOG_RECURR_INV_GENERATED = "Order {0} automatically generated for {1}";
        public const string EVENT_LOG_RECURR_INV_SENT = "Email sent for order {0} automatically generated for {1}";
        public const string EVENT_LOG_RECURR_INV_NOT_SENT = "Failed to send email sent for order {0} automatically generated for {1}";

        public const string POS_NEW_VERSION = "New Version";
        public const string POS_NEW_VERSION_FILE = "PosUpdate.exe";
        public const string POS_NEW_VERSION_INSTALLED = "PosUpdate.exe.installed";
    }
}
