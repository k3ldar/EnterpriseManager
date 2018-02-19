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
 *  File: IPCity.cs
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

using Shared.Classes;

namespace Library.BOL.IPAddresses
{
    [Serializable]
	public sealed class IPCity : IComparable<IPCity>
    {
        #region Static Members

        /// <summary>
        /// Internal IP Address Cache, holds IP Addresses for 24 hours at a time
        /// </summary>
        private static CacheManager _IPCache = new CacheManager("GeoIP Data", DAL.DALHelper.CacheLimit, true, false);

        #endregion Static Members

        #region Constructors

        /// <summary>
		/// Standard constructor for Ipcity
		/// </summary>
		/// <param name="wdId">Property Description for Field WD$ID</param>
		/// <param name="wdCountry">Property Description for Field WD$COUNTRY</param>
		/// <param name="wdRegion">Property Description for Field WD$REGION</param>
		/// <param name="wdCity">Property Description for Field WD$CITY</param>
		/// <param name="wdPostcode">Property Description for Field WD$POSTCODE</param>
		/// <param name="wdLatitude">Property Description for Field WD$LATITUDE</param>
		/// <param name="wdLongitude">Property Description for Field WD$LONGITUDE</param>
		/// <param name="wdMetroCode">Property Description for Field WD$METRO_CODE</param>
		/// <param name="wdAreaCode">Property Description for Field WD$AREA_CODE</param>
		/// <param name="wdVersion">Property Description for Field WD$VERSION</param>
        public IPCity(Int64 id, string country,
            string region, string city, string postcode,
            decimal latitude, decimal longitude, string metroCode,
            string areaCode, Int64 version)
		{
			ID = id;
			Country = country;
			Region = region;
			City = city;
			Postcode = postcode;
			Latitude = latitude;
			Longitude = longitude;
			MetroCode = metroCode;
			AreaCode = areaCode;
			Version = version;

		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="postcode"></param>
        public IPCity(Int64 id, string country, string city, string postcode)
        {
            ID = id;
            Country = country;
            City = city;
            Postcode = postcode;
        }

        public IPCity(Int64 id, string country,
            string region, string city, string postcode,
            decimal latitude, decimal longitude, string metroCode,
            string areaCode, Int64 version, Int64 numeric, Int64 startBlock, Int64 endBlock)
        {
            ID = id;
            Country = country;
            Region = region;
            City = city;
            Postcode = postcode;
            Latitude = latitude;
            Longitude = longitude;
            MetroCode = metroCode;
            AreaCode = areaCode;
            Version = version;
            Numeric = numeric;
            StartBlock = startBlock;
            EndBlock = endBlock;
        }

		#endregion Constructors

        #region Static Methods

        public static List<IPCity> Get(decimal latitude, decimal longitude, string country)
        {
            return (DAL.FirebirdDB.IPCitySelect(latitude, longitude, country));
        }

        public static List<IPCity> GetAll()
        {
            return (DAL.FirebirdDB.IPCitySelectAll());
        }

        public static IPCity Get(string userIP, string ipAddress)
        {
            CacheItem item = _IPCache.Get(ipAddress);

            if (item != null)
                return ((IPCity)item.Value);

            IPCity ipCache = DAL.FirebirdDB.IPCitySelect(ipAddress);
            _IPCache.Add(ipAddress, new CacheItem(ipAddress, ipCache));

            return (ipCache);
        }

        /// <summary>
        /// Returns a list of current items in the cache
        /// </summary>
        /// <returns></returns>
        public static List<IPCity> Get()
        {
            List<IPCity> Result = new List<IPCity>();

            List<CacheItem> Items = _IPCache.Items;

            foreach (CacheItem item in Items)
            {
                Result.Add((IPCity)item.Value);
            }

            return (Result);
        }

        #endregion Static Methods

        #region Public Methods

        /// <summary>
		/// Saves the current record
		/// </summary>
		public void Save()
		{
            throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes the current record
		/// </summary>
		public bool Delete()
		{
            throw new NotImplementedException();
		}


		/// <summary>
		/// Reloads the current record
		/// </summary>
		public void Reload()
		{
			throw new NotImplementedException();
		}

		#endregion Public Methods

		#region Overridden Methods

		/// <summary>
		/// Returns the String for the class
		/// </summary>
		public override string ToString()
		{
			return (String.Format("WD$IPCITY Record {0}", ID));
		}

		#endregion Overridden Methods

		#region Properties

		/// <summary>
		/// Property Description for Field WD$ID
		/// </summary>
		public Int64 ID { get; internal set; }

		/// <summary>
		/// Property Description for Field WD$COUNTRY
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Property Description for Field WD$REGION
		/// </summary>
		public string Region { get; set; }

		/// <summary>
		/// Property Description for Field WD$CITY
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Property Description for Field WD$POSTCODE
		/// </summary>
		public string Postcode { get; set; }

		/// <summary>
		/// Property Description for Field WD$LATITUDE
		/// </summary>
        public decimal Latitude { get; set; }

		/// <summary>
		/// Property Description for Field WD$LONGITUDE
		/// </summary>
        public decimal Longitude { get; set; }

		/// <summary>
		/// Property Description for Field WD$METRO_CODE
		/// </summary>
		public string MetroCode { get; set; }

		/// <summary>
		/// Property Description for Field WD$AREA_CODE
		/// </summary>
		public string AreaCode { get; set; }

		/// <summary>
		/// Property Description for Field WD$VERSION
		/// </summary>
		public Int64 Version { get; set; }

        /// <summary>
        /// Numeric value of IP Address
        /// </summary>
        public Int64 Numeric { get; private set; }
        
        /// <summary>
        /// Start block / range of the ip address
        /// </summary>
        public Int64 StartBlock { get; private set; }

        /// <summary>
        /// End block/ range of the IP Address
        /// </summary>
        public Int64 EndBlock { get; private set; }

		#endregion Properties

        #region Compare

        int IComparable<IPCity>.CompareTo(IPCity obj)
        {
            if (this.StartBlock < obj.StartBlock)
                return (-1);
            else if (this.StartBlock > obj.StartBlock)
                return (1);
            else
            {
                if (this.Version > obj.Version)
                    return (-1);
                else if (this.Version < obj.Version)
                    return (1);

                return (0);
            }
        }

        #endregion Compare
    }
}