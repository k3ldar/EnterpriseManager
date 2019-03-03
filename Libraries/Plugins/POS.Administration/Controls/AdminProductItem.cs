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
 *  File: AdminProductItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.Products;
using SharedBase.BOL.Users;
using SharedBase.BOL.StockControl;

using POS.Base.Classes;

#pragma warning disable IDE1006

namespace POS.Administration.Controls
{
    public partial class AdminProductItem : SharedControls.BaseControl
    {
        #region Private Members

        ProductCost _productCost;
        User _currentUser;

        #endregion Private Members

        #region Constructor

        public AdminProductItem(ProductCost productcost, User user)
        {
            _currentUser = user;
            _productCost = productcost;
            InitializeComponent();

            txtSize.Text = _productCost.Size;
            txtSKU.Text = _productCost.SKU;
            lblType.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN, 
                _productCost.ProductCostType.Description,
                SharedBase.Utils.SharedUtils.FormatMoney(_productCost.Cost1, AppController.LocalCurrency));

            AppController.ApplicationController.TableIDChanged += User_TableIDChanged;
        }

        #endregion Constructor

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnDelete.Text = Languages.LanguageStrings.AppDelete;
            btnEdit.Text = Languages.LanguageStrings.AppEdit;
            btnRemove.Text = LanguageStrings.AppMenuButtonRemove;
        }

        #endregion Overridden Methods

        #region Public Methods

        public bool Save()
        {
            bool Result = false;
            try
            {
                _productCost.SKU = txtSKU.Text;
                _productCost.Size = txtSize.Text;
                _productCost.Save();

                Result = true;
            }
            catch (Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_INPUT_STRING))
                    ShowError(Languages.LanguageStrings.AppInvalidNumber, Languages.LanguageStrings.AppErrorInvalidCost);
                else if (err.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                    ShowError(Languages.LanguageStrings.AppLockConflict, Languages.LanguageStrings.AppErrorLockConflictDesc);
                else
                    throw;
            }

            return (Result);
        }


        public void Refresh(ProductCost productCost)
        {
            _productCost = productCost;

            txtSize.Text = _productCost.Size;
            txtSKU.Text = _productCost.SKU;
        }

        #endregion Public Methods

        #region Properties

        public ProductCost ProductCostItem
        {
            get
            {
                return (_productCost);
            }
        }

        #endregion Properties

        #region Private Methods

        private void User_TableIDChanged(object sender, AppController.TableIDChangedEventArgs e)
        {
            //is the id of the item we are looking at changing?
            switch (e.Table)
            {
                case StringConstants.TABLE_PRODUCT_ITEMS:

                    if (e.OldID == _productCost.ID)
                    {
                        _productCost.ID = e.NewID;
                    }

                    break;
                case StringConstants.TABLE_PRODUCTS:

                    if (e.OldID == _productCost.ProductID)
                    {
                        _productCost.Product.ID = e.NewID;
                    }

                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowQuestion(Languages.LanguageStrings.AppDelete, 
                Languages.LanguageStrings.AppDeleteSelectedItem))
            {
                try
                {
                    _productCost.Delete();
                    RaiseOnDelete();
                }
                catch (Exception error)
                {
                    if (error.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                    {
                        if (ShowHardConfirm(LanguageStrings.AppError, 
                            LanguageStrings.AppProductDeleteFailedInUse))
                        {
                            try
                            {
                                _productCost.SoftDelete();
                                RaiseOnDelete();
                            }
                            catch (Exception err)
                            {
                                if (err.Message.Contains(StringConstants.ERROR_PRODUCT_HAS_STOCK))
                                {
                                    ShowError(LanguageStrings.AppError, String.Format(
                                        LanguageStrings.AppProductItemDeleteHasStock1,
                                        Stock.GetStockLocations(_productCost)));
                                }
                                else if (err.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                                {
                                    ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteFailedInUse);
                                }
                                else
                                    throw;
                            }
                        }
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (ShowQuestion(Languages.LanguageStrings.AppRemove, 
                String.Format(Languages.LanguageStrings.AppRemoveProductItem,
                _productCost.Size)))
            {
                try
                {
                    _productCost.SoftDelete();

                    RaiseOnDelete();
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_PRODUCT_HAS_STOCK))
                    {
                        ShowError(LanguageStrings.AppError, String.Format(
                            LanguageStrings.AppProductItemDeleteHasStock1, 
                            Stock.GetStockLocations(_productCost)));
                    }
                    else if (err.Message.Contains(StringConstants.ERROR_PRODUCT_IN_USE))
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppProductItemDeleteFailedInUse);
                    }
                    else
                        throw;

                }
            }
        }

        private void RaiseOnDelete()
        {
            if (OnDelete != null)
                OnDelete(this, EventArgs.Empty);
        }

        private void RaiseOnEdit()
        {
            if (OnEdit != null)
                OnEdit(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RaiseOnEdit();
        }

        private void cmbProductType_Format(object sender, ListControlConvertEventArgs e)
        {
            string value = e.ListItem.ToString();

            e.Value = Shared.Utilities.SplitCamelCase(value);
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Event raised when delete button clicked
        /// </summary>
        public event EventHandler OnDelete;

        /// <summary>
        /// Event raised when edit button is clicked
        /// </summary>
        public event EventHandler OnEdit;

        #endregion Events
    }
}
