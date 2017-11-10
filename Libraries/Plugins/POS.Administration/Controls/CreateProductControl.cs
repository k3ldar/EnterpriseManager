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
 *  File: CreateProductControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Reflection;
using System.Windows.Forms;

using Library;
using Library.BOL.Products;

using Languages;
using POS.Base.Classes;


namespace POS.Administration.Controls
{
    public partial class CreateProductControl : SharedControls.BaseControl
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public CreateProductControl()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
            {
                LoadPrimaryTypes();
                LoadGroups();
                cmbGroup.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbGroup_Format);
                cmbPrimaryType.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.cmbPrimaryType_Format);
            }
        }

        #endregion Constructors

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPrimaryProduct.Text = Languages.LanguageStrings.AppPrimaryProduct;
            lblProductName.Text = Languages.LanguageStrings.AppProductName;
            lblPrimaryGroup.Text = Languages.LanguageStrings.AppProductGroup;
        }


        #region Public Methods

        public Product Create(WebsiteAdministration admin)
        {
            Product Result = null;

            try
            {
                if (String.IsNullOrEmpty(txtProductName.Text))
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNameMissing);
                    return (Result);
                }

                if (cmbGroup.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectGroup);
                    return (Result);
                }

                if (cmbPrimaryType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectPrimaryType);
                    return (Result);
                }

                Result = admin.ProductInsert(txtProductName.Text.Trim(), 
                    (ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex],
                    (ProductGroup)cmbGroup.Items[cmbGroup.SelectedIndex]);

            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_PRODUCT_PRODUCT_NAME))
                {
                    ShowError(Languages.LanguageStrings.AppCreateProduct,
                        String.Format(Languages.LanguageStrings.AppCreateProductExistsGroup, txtProductName.Text,
                        ((ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]).Description));
                }
                else
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err);
                    ShowError(Languages.LanguageStrings.AppError,
                        String.Format(Languages.LanguageStrings.AppErrorCreatingProduct, err.Message));
                }
            }

            return (Result);
        }

        #endregion public Methods

        #region Private Methods

        private void LoadGroups()
        {
            cmbGroup.Items.Clear();

            foreach (ProductGroup group in ProductGroups.Get(MemberLevel.StandardUser, false))
            {
                cmbGroup.Items.Add(group);
            }

            if (cmbGroup.Items.Count > 0)
                cmbGroup.SelectedIndex = 0;
        }

        private void LoadPrimaryTypes()
        {
            cmbPrimaryType.Items.Clear();

            foreach (ProductType item in ProductTypes.Get())
            {
                cmbPrimaryType.Items.Add(item);
            }

            if (cmbPrimaryType.Items.Count > 0)
                cmbPrimaryType.SelectedIndex = 0;
        }

        private void cmbPrimaryType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductType primary = (ProductType)e.ListItem;
            e.Value = primary.Description;
        }

        private void cmbGroup_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroup group = (ProductGroup)e.ListItem;
            e.Value = group.Description;
        }

        #endregion Private Methods
    }
}
