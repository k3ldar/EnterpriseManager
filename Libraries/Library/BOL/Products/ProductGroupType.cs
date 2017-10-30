using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Products
{
    [Serializable]
    public sealed class ProductGroupType : BaseObject
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id of product group type</param>
        /// <param name="description">Description of product group type</param>
        /// <param name="primaryType">Primary Type</param>
        public ProductGroupType(int id, string description)
        {
            ID = id;
            Description = description;
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

        #endregion Properties

        #region Public Methods

        
        public Products GetProducts()
        {
            return (DAL.FirebirdDB.ProductGroupTypesGetProducts(this));
        }


        #endregion Public Methods

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.ProductGroupTypeSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.ProductGroupTypeDelete(this);
        }

        #endregion Overridden Methods
    }
}
