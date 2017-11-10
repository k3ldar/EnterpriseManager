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
 *  File: SalonUser.cs
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
using Library.DAL;
using Library.BOL.Salons;
using Library.BOL.Users;
using Library.BOL.Distributors;

namespace Library
{
    public sealed class SalonUser
    {
        public Salon SalonGet(int SalonID)
        {
            return (DAL.FirebirdDB.AdminSalonGet(SalonID));
        }

        #region Salon Owners

        public void AddSalonToUser(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerCreate(user, salon);
        }

        public void RemoveSalonFromUser(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerDelete(user, salon);
        }

        public void AddDistributorToUser(User user, Distributor distributor)
        {
            FirebirdDB.AdminDistributorOwnerCreate(user, distributor);
        }

        public void RemoveDistributorFromUser(User user, Distributor distributor)
        {
            FirebirdDB.AdminDistributorOwnerDelete(user, distributor);
        }

        public void SalonOwnerCreate(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerCreate(user, salon);
        }


        public void SalonOwnerDelete(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerDelete(user, salon);
        }

        public void SalonOwnerUpdateDelete(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateDelete(user, salon);
        }


        public void SalonOwnerUpdateMerge(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateMerge(user, salon);
        }


        public void SalonOwnerUpdateInsert(User user, Salon salon)
        {
            FirebirdDB.AdminSalonOwnerUpdateInsert(user, salon);
        }


        public Salon SalonOwnerUpdateGet(User user, Salon salon)
        {
            return (FirebirdDB.AdminSalonOwnerUpdateGet(user, salon));
        }


        #endregion Salon Owners
    }
}
