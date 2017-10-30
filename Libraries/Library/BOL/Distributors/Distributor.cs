using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

using Library.BOL.Users;

namespace Library.BOL.Distributors
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
            return (String.Format("Distributor: {0}; Name: {1}", ID, Name));
        }

        #endregion Overridden Methods

    }
}