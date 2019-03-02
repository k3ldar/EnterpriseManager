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
 *  File: ProductCostType.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedBase.BOL.Products
{
    [Serializable]
    public sealed class ProductCostType : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of product cost type</param>
        /// <param name="description">Description of product cost type</param>
        /// <param name="primaryType">Primary Type</param>
        /// <param name="itemType">Type of item</param>
        public ProductCostType(int id, string description, ProductCostItemType itemType)
        {
            ID = id;
            Description = description;
            ItemType = itemType;
        }

        #endregion Constructors

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
        /// Type of item
        /// </summary>
        public ProductCostItemType ItemType { get; set; }

        #endregion Properties

        #region Public Methods

        public bool HasStock()
        {
            switch (ItemType)
            {
                case ProductCostItemType.Product:
                case ProductCostItemType.Voucher:
                    return (true);
                default:
                    return (false);
            }
        }

        #endregion Public Methods

        #region Overridden Methods

        public override void Delete()
        {
            DAL.FirebirdDB.ProductCostTypeDelete(this);
        }

        public override void Save()
        {
            DAL.FirebirdDB.ProductCostTypeSave(this);
        }
        #endregion Overridden Methods
    }
}
