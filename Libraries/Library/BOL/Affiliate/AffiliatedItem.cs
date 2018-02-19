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
 *  File: AffiliatedItem.cs
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

using Library.BOL.Users;

namespace Library.BOL.Affiliate
{
    [Serializable]
    public sealed class AffiliatedItem : BaseObject
    {
        #region Private Members

        private string _url;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <param name="affiliateID"></param>
        /// <param name="url"></param>
        /// <param name="percentage"></param>
        /// <param name="pricePerClick"></param>
        public AffiliatedItem(Int64 id, User user, string affiliateID, string url, 
            decimal percentage, decimal pricePerClick, bool isActive)
        {
            ID = id;
            User = user;
            AffiliateID = affiliateID;
            Url = url;
            Percentage = percentage;
            PricePerClick = pricePerClick;
            Active = isActive;
        }

        #endregion Construcors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }
        
        /// <summary>
        /// User
        /// </summary>
        public User User { get; private set; }
        
        /// <summary>
        /// Affiliate ID
        /// </summary>
        public string AffiliateID { get; set; }
        
        /// <summary>
        /// Url of customer website
        /// </summary>
        public string Url 
        { 
            get
            {
                return (_url);
            }

            set
            {
                _url = value.ToLower().Replace("www.", "").Replace("http://", "https://").Replace("https://", "");

                if (_url.Contains("/"))
                    _url = _url.Substring(0, _url.IndexOf("/"));
            }
        }
        
        /// <summary>
        /// Percentage for each purchase
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        /// Price per click for customer
        /// </summary>
        public decimal PricePerClick { get; set; }

        /// <summary>
        /// Determines wether the affiliate site is active or not
        /// </summary>
        public bool Active { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Delete()
        {
            this.Active = false;
            DAL.FirebirdDB.AffiliatedSiteDelete(this);
        }

        public override void Save()
        {
            if (ID == -1)
                DAL.FirebirdDB.AffiliatedSiteCreate(this);
            else
                DAL.FirebirdDB.AffiliatedSiteUpdate(this);
        }

        #endregion Overridden Methods

        #region Public Methods

        /// <summary>
        /// Adds a new click to the click table to show a visitor has arrived
        /// </summary>
        /// <param name="ipAddress"></param>
        public void AddWebClick(string ipAddress)
        {
            DAL.FirebirdDB.AffiliatedSiteWebClick(this, ipAddress);
        }

        #endregion Public Methods
    }
}
