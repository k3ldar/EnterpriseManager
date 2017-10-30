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
