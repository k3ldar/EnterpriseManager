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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: TranslatedEnums.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Text;

using Languages;
using SharedBase;

namespace Reports
{
    public static class TranslatedEnums
    {
        public static string TranslateProductReportType(ProductReportType reportType)
        {
            switch (reportType)
            {
                case ProductReportType.Top10SellingProducts:
                    return (LanguageStrings.Top10SellingProducts);
                case ProductReportType.Top20SellingProducts:
                    return (LanguageStrings.Top20SellingProducts);
                case ProductReportType.TopSellingProducts:
                    return (LanguageStrings.TopSellingProducts);
                default:
                    throw new Exception ("Invalid ProductReportType in Translation");
            }
        }
    }
}
