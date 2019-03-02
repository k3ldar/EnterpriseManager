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
 *  File: ProductType.cs
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

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductType : BaseObject
    {
        #region Static Members


        #endregion Static Member

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of product type</param>
        /// <param name="description">Description of product type</param>
        /// <param name="primaryType">Primary Type</param>
        public ProductType(int id, string description, bool primaryType)
        {
            ID = id;
            Description = description;
            PrimaryType = primaryType;
        }

        #endregion Constructors

        #region Static Properties

        /// <summary>
        /// Associated image file for product images
        /// </summary>
        public static string ImageFile { get; set; }

        #endregion Static Properties

        #region Properties

        /// <summary>
        /// ID of Product Type
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Description of Product Type
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Primary type for new records
        /// </summary>
        public bool PrimaryType { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.ProductTypeSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.ProductTypeDelete(this);
        }

        #endregion Overridden Methods
    }
}
