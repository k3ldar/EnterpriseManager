using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Products
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
