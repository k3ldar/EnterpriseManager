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
 *  File: AdminProductCostItemAdd.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Products;
using POS.Base.Forms;

namespace POS.Administration.Forms.Products
{
    public partial class AdminProductCostItemAdd : BaseForm
    {
        #region Private Members

        Product _product = null;

        #endregion Private Members

        #region Constructors

        public AdminProductCostItemAdd(Product product)
            : this ()
        {
            _product = product;
        }

        public AdminProductCostItemAdd()
        {
            InitializeComponent();

            LoadProductTypes();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = Base.Classes.HelpTopics.ProductNewProductItem;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppProductNewProduct;
            lblName.Text = LanguageStrings.AppName;
            lblProductCostType.Text = LanguageStrings.AppProductType;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool CreateNewProductType(Form parent, Product product,
            ref string name, ref ProductCostType type)
        {
            name = String.Empty;
            type = null;

            AdminProductCostItemAdd frm = new AdminProductCostItemAdd(product);
            try
            {
                if (frm.ShowDialog(parent) == DialogResult.OK)
                {
                    name = frm.txtName.Text;
                    type = (ProductCostType)frm.cmbProductCostType.SelectedItem;
                    return (true);
                }
            }
            finally
            {
                frm.Close();
                frm.Dispose();
                frm = null;
            }

            return (false);
        }

        #endregion Static Methods

        #region Private Methods

        private void LoadProductTypes()
        {
            cmbProductCostType.Items.Clear();
            ProductCostTypes types = ProductCostTypes.Get();

            foreach (ProductCostType type in types)
            {
                cmbProductCostType.Items.Add(type);
            }

            if (cmbProductCostType.Items.Count > 0)
                cmbProductCostType.SelectedIndex = 0;
        }

        private void cmbProductCostType_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((ProductCostType)e.ListItem).Description;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();

            if (String.IsNullOrEmpty(txtName.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorInvalidProductName);
                return;
            }

            foreach (ProductCost item in _product.ProductCosts)
            {
                if (item.Size.Trim() == txtName.Text)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorInvalidProductNameDuplicate);
                    return;
                }
            }


            DialogResult = DialogResult.OK;
        }

        #endregion Private Methods
    }
}
