using System;

using Library.BOL.IPAddresses;

using Shared;
using Shared.Classes;
using Website.Library.Classes;

namespace SieraDelta.Website.Members.Services.WebDefender
{
    public partial class Connect : BaseWebForm
    {
        #region Private Static Members

        private static CacheManager _keyCache = new CacheManager("WebDefender Key Cache", new TimeSpan(0, 20, 0), true);

        #endregion Private Static Members

        protected override void OnInit(EventArgs e)
        {
            IgnoreWebLog = true;

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            string API = GetFormValue(PARAM_API, "Error");
            decimal Version;
            string Method;

            NVPCodec result = new NVPCodec();
            try
            {
                CacheItem userKey = _keyCache.Get(API);

                if (userKey == null)
                {
                    userKey = GetUserPassword(API);
                    _keyCache.Add(API, userKey);
                }

                string userPassword = (string)userKey.Value;

                // userpassword, gained from api key, is used to decrypt values sent
                if (Utilities.Decrypt(GetFormValue(PARAM_VALID, PARAM_VALID_NO), userPassword) != PARAM_VALID_YES)
                    throw new Exception(ERROR_INVALID_API_CODE);

                Version = GetFormValue(PARAM_VERSION, 0.1m);

                // if invalid version could default to ver 1???
                if (Version < VERSION_MINIMUM || Version > VERSION_MAXIMUM)
                    throw new Exception(ERROR_INVALID_VERSION);

                Method = Utilities.Decrypt(GetFormValue("Method", String.Empty), userPassword);

                switch (Method)
                {
                    case METHOD_VALIDATE_CONNECTION:
                        ValidateConnection(result, Version);
                        break;

                    case METHOD_ADDRESS_GET_ACTIVE:
                        //GetActiveAddresses(result, Version);
                        break;

                    //case METHOD_ADDRESS_GET_VARIABLE:
                    //    GetAddressesVariable(result, Version);
                    //    break;

                    case METHOD_ADDRESS_ADD:
                        //AddressAdd(result, Version, userPassword);
                        break;

                    case METHOD_ADDRESS_GET_BANNED:
                        //GetAddressesBanned(result, Version, userPassword);
                        break;

                    //case METHOD_ADDRESS_GET_INACTIVE:
                    //    GetInactiveAddress(result, Version);
                    //    break;

                    case METHOD_ADDRESS_HISTORY:
                        //GetAddressHistory(result, Version, userPassword);
                        break;

                    case METHOD_ADDRESS_GET_ID:
                        //GetAddressByID(result, Version, userPassword);
                        break;

                    default:
                        throw new Exception(ERROR_INVALID_METHOD);
                }
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                result.Add(PARAM_RESULT, RESULT_FAIL);
                result.Add(PARAM_ERROR, err.Message);
            }
            finally
            {
                Response.Write(result.Encode());
                Response.End();
            }
        }

        #region Private Methods

        //private void AddressAdd(NVPCodec result, decimal version, string password)
        //{
        //    IPAddress addr = CreateAddress(Shared.Utilities.Decrypt(GetFormValue("Address", "asdf"), password));

        //    if (IPAddresses.ServiceAddressAdd(addr))
        //    {
        //        result.Add("IPAddress", addr.IpAddress);
        //        result.Add("NEW_ID", addr.ID.ToString());
        //        result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //    }
        //    else
        //        result.Add(PARAM_RESULT, RESULT_FAIL);
        //}

        //private void GetAddressHistory(NVPCodec result, decimal version, string password)
        //{
        //    string ipAddress = Shared.Utilities.Decrypt(GetFormValue("IPAddress", "none"), password);
        //    IPAddresses items = IPAddresses.ServiceAddressGet(ipAddress);
        //    AddressListToNVPCodec(items, result);
        //    result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //}

        //private void GetInactiveAddress(NVPCodec result, decimal version)
        //{
        //    IPAddresses items = IPAddresses.ServiceInactive();
        //    AddressListToNVPCodec(items, result);
        //    result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //}

        //private void GetAddressByID(NVPCodec result, decimal version, string password)
        //{
        //    Int64 id = Convert.ToInt64(GetFormValue(PARAM_ID, -1));
        //    IPAddresses addresses = new IPAddresses();
        //    try
        //    {
        //        IPAddress searchIP = IPAddresses.ServiceAddressGet(id);

        //        if (searchIP == null)
        //        {
        //            result.Add(PARAM_ERROR, ERROR_RECORD_NOT_FOUND);
        //            result.Add(PARAM_RESULT, RESULT_FAIL);
        //        }
        //        else
        //        {
        //            addresses.Add(searchIP);
        //            AddressListToNVPCodec(addresses, result);
        //            result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //        }
        //    }
        //    finally
        //    {
        //        addresses.Clear();
        //        addresses = null;
        //    }
        //}

        //private void GetAddressesBanned(NVPCodec result, decimal version, string password)
        //{
        //    DateTime fromDate = DateTime.FromFileTimeUtc(Convert.ToInt64(GetFormValue(PARAM_FROM_DATE, "invalid")));
        //    Int64 maximumID = Convert.ToInt64(GetFormValue(PARAM_MAXIMUM_ID, Int64.MaxValue.ToString()));
        //    IPAddresses items = IPAddresses.ServiceAddressGetBanned(fromDate, maximumID);
        //    AddressListToNVPCodec(items, result);
        //    result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //}

        //private void GetAddressesVariable(NVPCodec result, decimal version)
        //{
        //    AddressType type = (AddressType)Enum.Parse(typeof(AddressType), GetFormValue("Type", "Unknown"));
        //    bool isActive = GetFormValue("Active", true);
        //    bool inactive = GetFormValue("Inactive", false);

        //    wd.AddressList items = wd.AddressList.AddressGet(type, isActive, inactive);
        //    AddressListToNVPCodec(items, result);
        //    result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //}

        //private void GetActiveAddresses(NVPCodec result, decimal version)
        //{
        //    IPAddresses active = new IPAddresses();// IPAddresses.AddressGet(;
        //    AddressListToNVPCodec(active, result);
        //    result.Add(PARAM_RESULT, RESULT_SUCCESS);
        //}

        //private void AddressListToNVPCodec(IPAddresses list, NVPCodec codec)
        //{
        //    int iCount = 0;

        //    foreach (IPAddress addr in list)
        //    {
        //        codec.Add(iCount.ToString(),
        //            String.Format(PARAM_ADDRESS,
        //            addr.ID.ToString(),
        //            addr.AddressType.ToString(),
        //            addr.BlackListed ? SYMBOL_TRUE : SYMBOL_FALSE,
        //            addr.CanExpire ? SYMBOL_TRUE : SYMBOL_FALSE,
        //            addr.Description,
        //            addr.IpAddress,
        //            addr.IsActive ? SYMBOL_TRUE : SYMBOL_FALSE,
        //            addr.SearchEngine ? SYMBOL_TRUE : SYMBOL_FALSE,
        //            addr.AddDate.ToFileTimeUtc(),
        //            addr.Expire.ToFileTimeUtc()));

        //        iCount++;
        //    }

        //    codec.Add(PARAM_TOTAL, iCount.ToString());
        //}


        //private IPAddress CreateAddress(string rawData)
        //{
        //    string[] addrParts = rawData.Split('#');

        //    IPAddress Result = new IPAddress(Convert.ToInt64(addrParts[0]),
        //        addrParts[5], addrParts[3] == "T", addrParts[2] == "T",
        //        addrParts[4], addrParts[7] == "T", DateTime.FromFileTimeUtc(Convert.ToInt64(addrParts[8])),
        //        (AddressType)Enum.Parse(typeof(AddressType), addrParts[1]),
        //        addrParts[6] == "T", "", DateTime.FromFileTimeUtc(Convert.ToInt64(addrParts[9])));

        //    return (Result);
        //}


        private void ValidateConnection(NVPCodec result, decimal version)
        {
            result.Add(PARAM_RESULT, RESULT_SUCCESS);
            result.Add(PARAM_VERSION, VERSION_MAXIMUM.ToString());
        }

        private CacheItem GetUserPassword(string apiCode)
        {
            // if fail create a webdefender check

            if (apiCode == "sdcjfgsjALE9dkfFKa0kdfnliejngej")
                return (new CacheItem(apiCode, "lkjasddfioeOIIHfj"));
            else
                throw new Exception(ERROR_INVALID_API_CODE);
        }

        #endregion Private Methods

        #region Constants


        internal const string RESULT_SUCCESS = "OK";
        internal const string RESULT_FAIL = "Fail";


        internal const string SYMBOL_TRUE = "T";
        internal const string SYMBOL_FALSE = "F";


        internal const decimal VERSION_MINIMUM = 1.0m;
        internal const decimal VERSION_MAXIMUM = 1.0m;

        internal const string ERROR_INVALID_API_CODE = "Invalid API Code";
        internal const string ERROR_INVALID_METHOD = "Invalid Method";
        internal const string ERROR_INVALID_VERSION = "Invalid Version";
        internal const string ERROR_RECORD_NOT_FOUND = "Record Not Found";

        internal const string PARAM_API = "API";
        internal const string PARAM_VALID = "Valid";
        internal const string PARAM_VALID_NO = "No";
        internal const string PARAM_VALID_YES = "yes+0";
        internal const string PARAM_VERSION = "Version";
        internal const string PARAM_METHOD = "Method";
        internal const string PARAM_RESULT = "Result";
        internal const string PARAM_ERROR = "Error";
        internal const string PARAM_TOTAL = "Total";
        internal const string PARAM_FROM_DATE = "FromDate"; 
        internal const string PARAM_ADDRESS = "{0}#{1}#{2}#{3}#{4}#{5}#{6}#{7}#{8}#{9}";
        internal const string PARAM_ID = "ID";
        internal const string PARAM_MAXIMUM_ID = "MAXIMUM_ID";



        internal const string METHOD_VALIDATE_CONNECTION = "ValidateConnect";
        internal const string METHOD_BAN_NUMBER = "AddressNumberBans";
        internal const string METHOD_ADDRESS_HISTORY = "AddressHistory";
        internal const string METHOD_ADDRESS_GET_ID = "AddressGetID";
        internal const string METHOD_ADDRESS_GET_VARIABLE = "AddressGetVariable";
        internal const string METHOD_ADDRESS_GET_INACTIVE = "AddressGetInactive";
        internal const string METHOD_ADDRESS_GET_ACTIVE = "AddressGetActive";
        internal const string METHOD_ADDRESS_REMOVE = "AddressRemove";
        internal const string METHOD_ADDRESS_ADD = "AddressAdd";
        internal const string METHOD_ADDRESS_GET_BANNED = "AddressesBanned";

        #endregion Constants
    }
}