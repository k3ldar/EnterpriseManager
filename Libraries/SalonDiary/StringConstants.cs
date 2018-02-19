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
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonDiary
{
    internal class StringConstants
    {
        internal const string PHONE_PREFIX_UK = "44";
        internal const string PHONE_PREFIX_UK_MOBILE = "07";


        internal const string NUMBER_ZERO = "0";
        internal const string NUMBER_ZERO_DOUBLE = "00";

        internal const string DIARY_TIME_FORMAT = "HH:mm";
        internal const string DIARY_DATE_DAY = "dddd";
        internal const string DIARY_DATE_FORMAT = "G";
        internal const string DIARY_DATE_BIRTH_DATE = "m";
        internal const string DIARY_DATE_DAY_ONLY = "d";

        internal const string TOTAL = "Total";

        internal const string THERAPIST_LIST = "{0}$";

        internal const string CARRIAGE_RETURN_AND_LINE_FEED = "\r\n";
        internal const string CARRIAGE_RETURN = "\r";
        internal const string LINE_FEED = "\n";

        internal const string PREFIX_AND_SUFFIX_SPACE = "{0} {1}";


        internal const string CHARACTER_LENGTH = "{0}/{1} {2}";

        internal const string APPOINTMENT_ID = "[{0}]";

        internal const string DATE_FORMAT = "d MMM";
        internal const string DATE_FORMAT_TIME = "dddd";
        internal const string DATE_RANGE = "{0} - {1}";

        internal const string ERROR_UPDATE_CONFLICT = "update conflicts with concurrent update";
        internal const string ERROR_FOREIGN_KEY_NOT_EXIST = "Foreign key reference target does not exist";

        internal const string SYMBOL_SPACE = " ";
        internal const string SYMBOL_DOLLAR = "$";


        internal const string THREAD_NAME_SALON_UTILISATION = "Salon Utilisation Thread";
        internal const string THREAD_NAME_CHECK_WAIT_LIST = "Waiting List Scanner Thread";


        internal const string ERROR_READING_DATA_FROM_CONNECTION = "Error reading data from the connection";
        internal const string ERROR_INVALID_TRANSACTION_HANDLE = "invalid transaction handle (expecting explicit transaction start)";
        internal const string ERROR_HANDLE_NOT_CREATED = "BeginInvoke cannot be called on a control until the window handle has been created";
        internal const string ERROR_THREAD_ABORT = "Thread was being aborted";
        internal const string ERROR_CONVERT_INVALID_TYPE = "is not of type";


        internal const string EMPLOYEE_ID = "Employee ID: {0}";


        internal const string SMS_NAME = "{NAME}";
        internal const string SMS_DAY = "{DAY}";
        internal const string SMS_TIME = "{TIME}";
        internal const string SMS_EMPLOYEE = "{THERAPIST}";
        internal const string SMS_FILE = "sms.message";
    }
}
