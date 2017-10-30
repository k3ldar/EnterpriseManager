using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website.Library
{
    public class StringConstants
    {
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

    }
}
