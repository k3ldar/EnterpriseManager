﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.BOL.Products;

using Heavenskincare.PointOfSale.Classes;
using SieraDelta.POS.Classes;

namespace Heavenskincare.PointOfSale.Controls
{
    public partial class BasketProductButton : SieraDelta.Controls.BaseControl
    {
        #region Private Members

        private ProductCost _product;

        #endregion Private Members

        #region Constructors

        public BasketProductButton()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public ProductCost Product
        {
            get
            {
                return (_product);
            }

            set
            {
                _product = value;

                LoadProductDetails();
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadProductDetails()
        {
            btnAddProduct.Text = _product.Product.Name + StringConstants.SYMBOL_CRLF + _product.Size;

            if (!AppController.LocalSettings.TillShowButtonImages)
                return;

            //load product image
            string image = String.Empty;

            if (_product.Product.PrimaryProduct.ID == ProductTypes.Get("Professional").ID)
                image = String.Format(StringConstants.FOLDER_PRODUCT_IMAGES, StringConstants.FOLDER_IMAGE_PRODUCT);
            else
                image = String.Format(StringConstants.FOLDER_PRODUCT_IMAGES, StringConstants.FOLDER_IMAGE_STRATOSPHERE);

            string imageFile = image + _product.Product.Image.Replace(StringConstants.IMAGE_SIZE_DEFAULT, StringConstants.IMAGE_SIZE_BASKET);

            if (File.Exists(imageFile))
            {
                Image img = Image.FromFile(imageFile);
                btnAddProduct.Image = img;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (AddProductToBasket != null)
                AddProductToBasket(this, EventArgs.Empty);
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Event for when a product needs to be added to the basket
        /// </summary>
        public event EventHandler AddProductToBasket;

        #endregion Events
    }
}
