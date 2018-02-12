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
 *  File: WebsiteOptions.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  06/02/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

namespace Library.Interfaces
{
    public interface IWebsiteOptions
    {
        void AddHeader(string header);

        void AddDescription(string description);

        void AddOption(string name, int value, string description, string reference, int defaultValue, 
            int minValue, int maxValue, bool isGlobal = false);

        void AddOption(string name, double value, string description, string reference, bool isGlobal = false);

        void AddOption(string name, decimal value, string description, string reference, bool isGlobal = false);

        void AddOption(string name, bool value, string description, string reference, bool isGlobal = false);
        
        void AddOption(string name, string value, string description, string reference, int width = 300,
            bool isPassword = false, bool isCulture = false, int numberOfLines = 1, bool isGlobal = false);

        void AddOption(string name, DateTime value, string description, string reference, bool isGlobal);
    }
}
