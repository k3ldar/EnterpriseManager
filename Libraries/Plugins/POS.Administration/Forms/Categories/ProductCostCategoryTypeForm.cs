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
 *  File: ProductCostCategoryTypeForm.cs
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

using SharedBase;
using SharedBase.BOL.Products;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class ProductCostCategoryTypeForm : Base.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductCostCategoryTypeForm()
        {
            InitializeComponent();
        }

        public ProductCostCategoryTypeForm(ref ProductCostType productCostType)
            : this()
        {
            ProdCostType = productCostType;
            IsNew = ProdCostType == null;

            if (!IsNew)
            {
                Description = productCostType.Description;
            }

            foreach (ProductCostItemType type in Enum.GetValues(typeof(ProductCostItemType)))
            {
                int idx = cmbItemType.Items.Add(type);

                if (!IsNew && ProdCostType.ItemType == type)
                {
                    cmbItemType.SelectedIndex = idx;
                    cmbItemType.Enabled = false;
                }
            }

            if (cmbItemType.SelectedIndex == -1)
                cmbItemType.SelectedIndex = 0;
        }

        #endregion Constructors

        #region Properties

        protected ProductCostType ProdCostType { get; set; }

        protected bool IsNew { get; set; }

        /// <summary>
        /// description
        /// </summary>
        protected string Description
        {
            get
            {
                return (txtName.Text);
            }

            set
            {
                txtName.Text = value;
            }
        }

        protected ProductCostItemType ItemType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductCostType;
            lblName.Text = LanguageStrings.Description;
            lblItemType.Text = LanguageStrings.AppItemType;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductCostType productCostType)
        {
            bool Result = false;

            ProductCostCategoryTypeForm frm = new ProductCostCategoryTypeForm(ref productCostType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productCostType = frm.ProdCostType;
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
