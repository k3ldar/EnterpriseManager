using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.Products
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
