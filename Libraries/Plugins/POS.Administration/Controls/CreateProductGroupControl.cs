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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CreateProductGroupControl.cs
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

using SharedBase;
using SharedBase.BOL.Products;

using Languages;
using POS.Base.Classes;

namespace POS.Administration.Controls
{
    public partial class CreateProductGroupControl : SharedControls.BaseControl
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public CreateProductGroupControl()
        {
            InitializeComponent();

            if (AppController.ApplicationRunning)
            {
                LoadPrimaryTypes();
                cmbPrimaryType.Format += new ListControlConvertEventHandler(cmbPrimaryType_Format);
            }
        }

        #endregion Constructors

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblGroupName.Text = LanguageStrings.AppProductGroupName;
            lblPrimaryProductGroup.Text = LanguageStrings.AppProductGroupPrimaryType;
        }


        #region Public Methods

        public ProductGroup Create(WebsiteAdministration admin)
        {
            ProductGroup Result = null;

            try
            {
                if (String.IsNullOrEmpty(txtProductGroupName.Text))
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNameMissing);
                    return (Result);
                }

                if (cmbPrimaryType.SelectedIndex == -1)
                {
                    ShowError(LanguageStrings.AppProductNewProduct, LanguageStrings.AppProductNewSelectPrimaryType);
                    return (Result);
                }

                Result = admin.ProductGroupCreate(txtProductGroupName.Text,
                    (ProductGroupType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]);
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_VIOLATION_UNIQUE_KEY))
                {
                    ShowError(LanguageStrings.AppError,
                        String.Format(LanguageStrings.AppCreateProductGroupExists, txtProductGroupName.Text,
                        ((ProductType)cmbPrimaryType.Items[cmbPrimaryType.SelectedIndex]).Description));
                }
                else
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err);
                    ShowError(LanguageStrings.AppError,
                        String.Format(LanguageStrings.AppErrorCreatingProductGroup, err.Message));
                }
            }

            return (Result);
        }

        #endregion public Methods

        #region Private Methods

        private void LoadPrimaryTypes()
        {
            cmbPrimaryType.Items.Clear();

            foreach (ProductGroupType item in ProductGroupTypes.Get())
            {
                cmbPrimaryType.Items.Add(item);
            }

            cmbPrimaryType.SelectedIndex = 0;
        }

        private void cmbPrimaryType_Format(object sender, ListControlConvertEventArgs e)
        {
            ProductGroupType primary = (ProductGroupType)e.ListItem;
            e.Value = primary.Description;
        }

        #endregion Private Methods
    }
}
