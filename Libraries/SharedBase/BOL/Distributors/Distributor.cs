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
 *  File: Distributor.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using SharedBase.BOL.Users;

namespace SharedBase.BOL.Distributors
{
    [Serializable]
    public sealed class Distributor : Salons.Salon
    {

        public Distributor(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, string PostCode, string openingTimes)
            :base (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, PostCode, openingTimes)
        {
        }

        public Distributor(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, bool SalonStockist, int Location, int SortOrder,
            string PostCode, bool VIPSalon, bool ShowOnWeb, Enums.SalonType SalonType, string openingTimes)
            :base (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, SalonStockist, Location, SortOrder,
                PostCode, VIPSalon, ShowOnWeb, SalonType, openingTimes)
        {
        }

        public Distributor(int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, bool SalonStockist, int Location, int SortOrder,
             string PostCode, bool VIPSalon, float Distance, Enums.SalonType SalonType, string openingTimes)
            :base (ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, SalonStockist, Location, 
                SortOrder, PostCode, VIPSalon, Distance, SalonType, openingTimes)
        {

        }

        public Distributor(int UserID, int ID, string Name, string Image, string ContactName, string Address, string Telephone,
            string Fax, string Email, string URL, string PostCode, string openingTimes)
            :base (UserID, ID, Name, Image, ContactName, Address, Telephone, Fax, Email, URL, PostCode, openingTimes)
        {


        }


        #region Overridden Methods

        public override string ToString()
        {
            return String.Format("Distributor: {0}; Name: {1}", ID, Name);
        }

        #endregion Overridden Methods

    }
}