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
 *  File: ProductCategoryTypeForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library.BOL.Products;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class ProductCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductCategoryTypeForm()
            :base (CategoryType.ProductTypes)
        {
            InitializeComponent();
        }

        public ProductCategoryTypeForm(ref ProductType productType)
            : this()
        {
            ProdType = productType;
            IsNew = ProdType == null;

            if (!IsNew)
            {
                Description = productType.Description;
                cbPrimary.Checked = productType.PrimaryType;
            }
        }

        #endregion Constructors

        #region Properties

        private ProductType ProdType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductType;
            cbPrimary.Text = LanguageStrings.AppPrimary;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                ProdType = ProductTypes.Create(Description, cbPrimary.Checked);
            }
            else
            {
                ProdType.Description = Description;
                ProdType.PrimaryType = cbPrimary.Checked;
                ProdType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductType productType)
        {
            bool Result = false;

            ProductCategoryTypeForm frm = new ProductCategoryTypeForm(ref productType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productType = frm.ProdType;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods
    }
}
