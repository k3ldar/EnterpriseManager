using System;

namespace Website.Library
{
    public class StringConstants
    {
        // translated Data
        public const string TRANSLATED_DATA_HOME_PAGE = "Home Page";


        // Cache Names
        public const string CACHE_NAME_HOME_PAGE_FIXED_BANNERS = "Page Fixed Banner Cache";
        public const string CACHE_NAME_PAGE_BANNERS_PREFIX = "Page Banners Prefex";
        public const string CACHE_NAME_PAGE_BANNERS_SUFFIX = "Page Banners Suffix";

        // errors database
        public const string ERROR_FIREBIRD_LOCK_CONFLICT_1 = "update conflicts with concurrent update";
        public const string ERROR_FIREBIRD_LOCK_CONFLICT_2 = "lock conflict on no wait transaction";

        // errors 
        public const string ERROR_THREAD_ABORTED = "Thread was being aborted";

        //Session Strings
        public const string SESSION_NAME_USER_BASKET_CURRENCY = "BASKET_CURRENCY";
        public const string SESSION_NAME_SHOPPING_ID = "SHOPPING_BASKET";
        public const string SESSION_NAME_WEBSITE_COUNTRY = "WEBSITE_COUNTRY";
        public const string SESSION_NAME_WEBSITE_PRICE_COLUMN = "WEBSITE_PRICE_COLUMN";
        public const string SESSION_NAME_USER_SESSION = "USER_SESSION";

#if DISPLAY_DEBUG_INFO
        public const string SESSION_NAME_SESSION_INITIATED = "SESSION_INITIATED_FROM";
#endif


        // cookies
        public const string COOKIE_USER_LANGUAGE = "CustomUserLanguage{0}";
        public const string COOKIE_USER_CURRENCY = "CustomUserCurrency{0}";
        public const string COOKIE_AFFILIATE = "Affiliate{0}";
        public const string COOKIE_BYPASS_MAINTENANCE = "ByPassMaint{0}";


        // payment Statuses
        public const string PAYMENT_STATUS_BUY_SAFE_PAID = "SunTech BuySafe - Paid";
        public const string PAYMENT_STATUS_BUY_SAFE_24PAYMENT = "SunTech 24Payment - Paid";
        public const string PAYMENT_STATUS_BUY_SAFE_WEB_ATM = "SunTech WebATM - Paid";



        public const string SYMBOL_SEVEN = "7";


        public const string AFFILIATE_LIVE_DAYS = "AFFILIATE_LIVE_DAYS";


        public const string WEB_SETTING_HOME_FIXED_BANNER_SHOW = "{0}.SETTINGS.HOMEBANNERS";
        public const string WEB_SETTING_HOME_FIXED_BANNER = "{0}.FIXEDBANNER{1}";
        public const string WEB_SETTING_HOME_FIXED_BANNER_LINK = "{0}.FIXEDBANNER{1}LINK";
        public const string WEB_SETTING_HOME_FIXED_BANNER_TITLE = "{0}.FIXEDBANNER{1}TITLE";
        public const string WEB_SETTING_HOME_FIXED_BANNER_DESCRIPTION = "{0}.FIXEDBANNER{1}NAME";

    }
}
