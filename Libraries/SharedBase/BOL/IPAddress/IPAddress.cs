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
 *  File: IPAddress.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Shared;

namespace SharedBase.BOL.IPAddresses
{
    [Serializable]
    public sealed class IPAddress
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public IPAddress()
        {
            DataSentToServer = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ipAddress">IP Address to add to list</param>
        /// <param name="canExpire">bool, indicates wether the address can expire or not</param>
        /// <param name="blackListed">bool, indicates wether the address is black listed (true) or white listed (false)</param>
        /// <param name="description">string, description of the address</param>
        /// <param name="searchEngine">Indicates the search address is a search engine</param>
        public IPAddress(Int64 id, string ipAddress, bool canExpire, bool blackListed, string description, 
            bool searchEngine, DateTime date, AddressType addressType, bool isActive, string firewallRule)
            :this()
        {
            ID = id;
            Description = description;
            IpAddress = ipAddress;
            CanExpire = canExpire;
            BlackListed = blackListed;
            SearchEngine = searchEngine;
            AddDate = date;
            AddressType = addressType;
            IsActive = isActive;
            FirewallRule = firewallRule;

            Expire = AddDate.AddDays(5);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ipAddress">IP Address to add to list</param>
        /// <param name="canExpire">bool, indicates wether the address can expire or not</param>
        /// <param name="blackListed">bool, indicates wether the address is black listed (true) or white listed (false)</param>
        /// <param name="description">string, description of the address</param>
        /// <param name="searchEngine">Indicates the search address is a search engine</param>
        public IPAddress(Int64 id, string ipAddress, bool canExpire, bool blackListed, string description,
            bool searchEngine, DateTime date, AddressType addressType, bool isActive, string firewallRule, DateTime expires)
            :this(id, ipAddress, canExpire, blackListed, description, searchEngine, date, addressType, isActive, firewallRule)
        {
            Expire = expires;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of record
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// IP Address for list
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Indicates wether the IP Address can expire or not
        /// </summary>
        public bool CanExpire { get; set; }

        /// <summary>
        /// Date IP Address added to the list
        /// </summary>
        public DateTime AddDate { get; set; }

        /// <summary>
        /// Indicates wether the address is black listed (true) or white listed (false)
        /// </summary>
        public bool BlackListed { get; set; }

        /// <summary>
        /// Description of the address
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates the IP Address is a search engine
        /// </summary>
        public bool SearchEngine { get; set; }

        /// <summary>
        /// Type of Address
        /// </summary>
        public AddressType AddressType { get; set; }

        /// <summary>
        /// Determines wether this record is active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// DateTime the address can expire
        /// </summary>
        public DateTime Expire { get; set; }

        /// <summary>
        /// Determines wether the ip address has expired
        /// </summary>
        public bool IsExpired
        {
            get
            {
                return IsActive && CanExpire && Expire < DateTime.Now;
            }
        }

        /// <summary>
        /// Name of firewall rule ip address attached to
        /// </summary>
        public string FirewallRule { get; set; }


        public bool DataSentToServer { get; set; }

        #endregion Properties
    }
}
