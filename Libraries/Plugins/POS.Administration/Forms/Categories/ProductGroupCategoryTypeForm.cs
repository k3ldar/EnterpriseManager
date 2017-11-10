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
 *  File: ProductGroupCategoryTypeForm.cs
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
    public partial class ProductGroupCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public ProductGroupCategoryTypeForm()
            :base (CategoryType.ProductGroupTypes)
        {
            InitializeComponent();
        }

        public ProductGroupCategoryTypeForm(ref ProductGroupType groupType)
            : this()
        {
            GroupType = groupType;
            IsNew = GroupType == null;

            if (!IsNew)
            {
                Description = groupType.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private ProductGroupType GroupType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductGroupType;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                GroupType = ProductGroupTypes.Create(Description);
            }
            else
            {
                GroupType.Description = Description;
                GroupType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref ProductGroupType productGroupType)
        {
            bool Result = false;

            ProductGroupCategoryTypeForm frm = new ProductGroupCategoryTypeForm(ref productGroupType);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                productGroupType = frm.GroupType;
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