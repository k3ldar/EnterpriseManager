using System;
using System.Globalization;

using Library.BOL.Countries;
using Library.BOL.Orders;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace Library.BOL.DeliveryAddress
{
    [Serializable]
    public sealed class DeliveryAddress : BaseObject
    {
        #region Private / Protected Members

        private Int64 _ID;
        private Int64 _MemberID;
        private string _Name;
        private string _AddressLine1;
        private string _AddressLine2;
        private string _AddressLine3;
        private string _City;
        private string _County;
        private string _PostCode;
        private Country _Country;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public DeliveryAddress(Int64 ID, Int64 MemberID, string Name, string AddressLine1, string AddressLine2, 
            string AddressLine3, string City, string County, string PostCode, int Country)
        {
            _ID = ID;
            _MemberID = MemberID;
            _Name = Name;
            _AddressLine1 = AddressLine1;
            _AddressLine2 = AddressLine2;
            _AddressLine3 = AddressLine3;
            _City = City;
            _County = County;
            _PostCode = PostCode;
            _Country = DAL.FirebirdDB.CountryGet(Country);
        }


        #endregion Constructors / Destructors

        #region Properties

        public Int64 MemberID
        {
            get
            {
                return (_MemberID);
            }
        }

        public Int64 ID
        {
            get
            {
                return (_ID);
            }
        }
                   
        public string Name
        {
            get
            {
                return (_Name);
            }

            set
            {
                _Name = value;
            }
        }
        
        public string AddressLine1
        {
            get
            {
                return (_AddressLine1);
            }

            set
            {
                _AddressLine1 = value;
            }
        }
        
        public string AddressLine2
        {
            get
            {
                return (_AddressLine2);
            }

            set
            {
                _AddressLine2 = value;
            }
        }
        
        public string AddressLine3
        {
            get
            {
                return (_AddressLine3);
            }

            set
            {
                _AddressLine3 = value;
            }
        }
        
        public string City
        {
            get
            {
                return (_City);
            }

            set
            {
                _City = value;
            }
        }

        public string County
        {
            get
            {
                return (_County);
            }

            set
            {
                _County = value;
            }
        }
        
        public string PostCode
        {
            get
            {
                 return (_PostCode);
            }

            set
            {
                _PostCode = value;
            }
        }
        
        public Country Country
        {
            get
            {
                return (_Country);
            }

            set
            {
                if (value == null)
                    throw new Exception("Country can not be null");

                _Country = value;
            }
        }

        public string Address(bool IsHTML)
        {
            string Seperator;

            if (IsHTML)
                Seperator = "<br>";
            else
                Seperator = "\n";

            string Result = "";

            if (Name != "")
                Result += Name + Seperator;

            if (AddressLine1 != "")
                Result += AddressLine1 + Seperator;

            if (AddressLine2 != "")
                Result += AddressLine2 + Seperator;

            if (AddressLine3 != "")
                Result += AddressLine1 + Seperator;

            if (City != "")
                Result += City + Seperator;

            if (County != "")
                Result += County + Seperator;

            if (Country.Name != "")
                Result += Country.Name + Seperator;

            if (PostCode != "")
                Result += PostCode + Seperator;

            return (Result);
        }

        public bool InUse
        {
            get
            {
                bool Result = false;

                Orders.Orders userOrders = Orders.Orders.Get(Users.User.UserGet(_MemberID));

                foreach (Order order in userOrders)
                {
                    if (order.ID == _ID)
                    {
                        Result = true;
                        break;
                    }
                }

                return (Result);
            }
        }

        #endregion Properties

        #region Public Methods

        public override void Save()
        {
            if (InUse)
                throw new Exception("Address can not be updated as it is in use with an order/invoice");

            DAL.FirebirdDB.MembersAddressUpdate(this);
        }

        /// <summary>
        /// Converts user address/name to proper case and removes duplicate entries
        /// </summary>
        public void FixAddress(CultureInfo cultureInfo)
        {
            TextInfo textInfo = cultureInfo.TextInfo;

            _Name = textInfo.ToTitleCase(_Name.ToLower());
            _AddressLine1 = textInfo.ToTitleCase(_AddressLine1.ToLower());
            _AddressLine2 = textInfo.ToTitleCase(_AddressLine2.ToLower());
            _AddressLine3 = textInfo.ToTitleCase(_AddressLine3.ToLower());
            _County = textInfo.ToTitleCase(_County.ToLower());
            _City = textInfo.ToTitleCase(_City.ToLower());
            _PostCode = textInfo.ToUpper(_PostCode.ToLower());

            if (_AddressLine3.ToLower() == _City.ToLower())
                _AddressLine3 = "";

            if (_County.ToLower() == _City.ToLower())
                _County = "";

            if (_AddressLine3.ToLower() == _AddressLine1.ToLower())
                _AddressLine3 = "";
        }


        #endregion Public Methods


        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("DeliverAddress: {0}; Member ID: {1}; Name: {2}", ID, _MemberID, _Name));
        }

        #endregion Overridden Methods

    }
}