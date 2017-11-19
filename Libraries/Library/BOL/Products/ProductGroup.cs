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
 *  File: ProductGroup.cs
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

using Library;
using Library.BOL.Users;

namespace Library.BOL.Products
{
    [Serializable]
    public sealed class ProductGroup
    {
        #region Private Members

        private Int64 _ID;
        private string _Description;
        private int _SortOrder;
        private string _TagLine;
        private bool _ShowOnWebsite;
        private MemberLevel _memberLevel;
        private string _url;

        #endregion Private Members

        #region Constructors / Destructors

        public ProductGroup(Int64 ID, string Description, int SortOrder, string TagLine, bool ShowOnWebsite,
            MemberLevel MemberLevel, string url, 
            ProductGroupType groupType, string mainHeader, string subHeader,
            string mobileImage, bool mobileWebsite)
        {
            _ID = ID;
            _Description = Description;
            _SortOrder = SortOrder;
            _TagLine = TagLine;
            _ShowOnWebsite = ShowOnWebsite;
            _memberLevel = MemberLevel;
            _url = url;
            GroupType = groupType;
            MainHeader = mainHeader;
            SubHeader = subHeader;
            MobileWebsite = mobileWebsite;
            MobileImage = mobileImage;
        }

        #endregion Constructors / Destructors

        #region Properties

        /// <summary>
        /// ID of the product group
        /// </summary>
        public Int64 ID
        {
            get
            {
                return (_ID);
            }
        }

        /// <summary>
        /// URL overriding the normal product group web page
        /// </summary>
        public string URL
        {
            get
            {
                return (_url);
            }

            set
            {
                _url = value;
            }
        }

        public string SEODescripton
        {
            get
            {
                return (Utils.SharedUtils.SEOName(_Description));
            }
        }

        /// <summary>
        /// Product Group Description
        /// </summary>
        public string Description
        {
            get
            {
                return (_Description);
            }

            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// Sort Order
        /// </summary>
        public int SortOrder
        {
            get
            {
                return (_SortOrder);
            }

            set
            {
                _SortOrder = value;
            }
        }

        /// <summary>
        /// Determines wether the product group is shown on the website
        /// </summary>
        public bool ShowOnWebsite
        {
            get
            {
                return (_ShowOnWebsite);
            }

            set
            {
                _ShowOnWebsite = value;
            }
        }

        public Products Products(ProductType primaryProductType)
        {
            return (DAL.FirebirdDB.ProductsGet(primaryProductType, 1, 10000, this));
        }

        /// <summary>
        /// Tagline to be displayed
        /// </summary>
        public string TagLine
        {
            get
            {
                return (_TagLine);
            }

            set
            {
                _TagLine = value;
            }
        }

        /// <summary>
        /// Member level where this product is visible to
        /// </summary>
        public MemberLevel MemberLevel
        {
            get
            {
                return (_memberLevel);
            }

            set
            {
                _memberLevel = value;
            }
        }

        /// <summary>
        /// Group Type for color coding
        /// </summary>
        public ProductGroupType GroupType { get; set; }

        /// <summary>
        /// Main Header if GroupType is not Other
        /// </summary>
        public string MainHeader { get; set; }

        /// <summary>
        /// Sub Header if GroupType is not Other
        /// </summary>
        public string SubHeader { get; set; }

        /// <summary>
        /// Indicates wether shown on mobile home page
        /// </summary>
        public bool MobileWebsite { get; set; }

        /// <summary>
        /// Indicates wether a custom image is shown on the mobile home page
        /// </summary>
        public string MobileImage { get; set; }

        #endregion Properties

        #region Public Methods

        public void Delete(User user)
        {
            Utils.LibUtils.CanDelete(user);
            DAL.FirebirdDB.AdminProductGroupDelete(this);
        }

        public void Save(User user)
        {
            Utils.LibUtils.CanUpdate(user);
            DAL.FirebirdDB.AdminProductGroupUpdate(this);
        }

        #endregion Public Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("ProductGroup: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods
    }
}