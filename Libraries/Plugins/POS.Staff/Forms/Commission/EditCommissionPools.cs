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
 *  File: EditCommissionPools.cs
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

using Library.Utils;

using Library.BOL.Accounts;
using Library.BOL.Locations;
using Library.BOL.Staff;

using POS.Base.Classes;

using Shared;

namespace POS.Staff.Forms
{
    public partial class EditCommissionPools : POS.Base.Forms.BaseOptionsForm
    {
        #region Private Members

        private CommissionPool _currentPool = null;

        #endregion Private Members

        #region Constructors

        public EditCommissionPools()
        {
            InitializeComponent();

            LoadLocations();
            LoadPaymentTypes();
            LoadCommissionPools();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCommissionPoolsEdit;

            lblName.Text = LanguageStrings.AppName;
            lblCommissionRate.Text = LanguageStrings.AppStaffCommissionRate;
            lblPaymentTypes.Text = LanguageStrings.AppPaymentType;
            lblStore.Text = LanguageStrings.AppLocation;
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        protected override void UpdateUI(bool itemSelected)
        {
            base.UpdateUI(lstItems.SelectedItems.Count > 0);

            if (lstItems.SelectedIndex == -1)
            {
                txtName.Text = String.Empty;
            }

            txtName.Enabled = lstItems.SelectedIndex > -1;
            udCommissionRate.Enabled = lstItems.SelectedIndex > -1;
            lstPaymentTypes.Enabled = lstItems.SelectedIndex > -1;
        }

        /// <summary>
        /// Validates changes and prompts to save changes
        /// </summary>
        /// <returns>If validation failed then returns false, otherwise returns true</returns>
        protected override bool PromptSave()
        {
            bool Result = false;

            if (IsEditing && ShowQuestion(LanguageStrings.AppCommissionPoolSave, LanguageStrings.AppCommissionPoolSaveDescription))
            {
                try
                {
                    //Validation.Validate(txtDescription.Text, 10, 100, LanguageStrings.AppDescription);
                    //Validation.Validate(txtVideoReference.Text, 5, 40, LanguageStrings.AppVideoReference);
                }
                catch (Exception err)
                {
                    ShowError(LanguageStrings.AppError, err.Message);
                    return (false);
                }

                OnSaveClicked();
                Result = true;
            }

            return (Result);
        }

        protected override void OnCreateClicked()
        {
            _currentPool = new CommissionPool(-1, LanguageStrings.AppNewCommissionPool, 0.000m, new Library.BOL.Accounts.PaymentStatuses(), null);

            int idx = lstItems.Items.Add(_currentPool);
            lstItems.SelectedIndex = idx;

            IsEditing = true;
            UpdateUI(true);
        }

        protected override void OnDeleteClicked()
        {
            if (ShowQuestion(LanguageStrings.AppCommissionPoolDelete, LanguageStrings.AppCommissionPoolDeleteDescription))
            {
                _currentPool.Delete();
                _currentPool = null;
                LoadCommissionPools();
                IsEditing = false;
            }
        }

        protected override void OnSaveClicked()
        {
            if (_currentPool == null)
                return;

            try
            {
                //Validation.Validate(txtDescription.Text, 10, 100, LanguageStrings.Description);
                //Validation.Validate(txtVideoReference.Text, 5, 40, LanguageStrings.AppVideoReference);
                _currentPool.Name = txtName.Text;
                _currentPool.CommissionRate = udCommissionRate.Value;

                _currentPool.PaymentStatus.Clear();

                foreach (PaymentStatus status in lstPaymentTypes.CheckedItems)
                {
                    _currentPool.PaymentStatus.Add(status);
                }

                if (_currentPool.PaymentStatus.Count == 0)
                    throw new Exception(LanguageStrings.AppErrorSelectPaymentStatus);

                _currentPool.Location = (StoreLocation)cmbStore.SelectedItem;
                _currentPool.Save();
                IsEditing = false;
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }

            UpdateUI(true);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadLocations()
        {
            cmbStore.Items.Clear();

            StoreLocation anyStore = new StoreLocation(-1, LanguageStrings.AppAny);
            cmbStore.Items.Add(anyStore);

            Locations stores = Locations.Get();

            foreach (StoreLocation location in stores)
            {
                cmbStore.Items.Add(location);
            }
        }

        private void LoadPaymentTypes()
        {
            lstPaymentTypes.Items.Clear();

            foreach (PaymentStatus status in PaymentStatuses.Get())
            {
                if (status.IsPaid)
                    lstPaymentTypes.Items.Add(status);
            }
        }

        private void LoadCommissionPools()
        {
            CommissionPools pools = CommissionPools.Get();

            lstItems.Items.Clear();

            foreach (CommissionPool pool in pools)
            {
                lstItems.Items.Add(pool);
            }

            UpdateUI(lstItems.SelectedItems.Count > 0);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            IsEditing = true;
            UpdateUI(lstItems.SelectedItems.Count > 0);
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsEditing)
                PromptSave();

            if (lstItems.SelectedItems.Count > 0)
            {
                if ((_currentPool != null && _currentPool.ID != -1) | (_currentPool == null))
                    _currentPool = (CommissionPool)lstItems.Items[lstItems.SelectedIndex];

                if (_currentPool != null)
                {
                    txtName.Text = _currentPool.Name;
                    udCommissionRate.Value = _currentPool.CommissionRate;

                    for (int i = 0; i < lstPaymentTypes.Items.Count; i++)
                    {
                        lstPaymentTypes.SetItemChecked(i, _currentPool.PaymentStatus.Contains((PaymentStatus)lstPaymentTypes.Items[i]));
                    }

                    if (_currentPool.Location == null || _currentPool.Location.ID == -1)
                    {
                        cmbStore.SelectedIndex = 0;
                    }
                    else
                    {
                        for (int i = 0; i < cmbStore.Items.Count; i++)
                        {
                            StoreLocation loc = (StoreLocation)cmbStore.Items[i];

                            if (loc.ID == _currentPool.Location.ID)
                            {
                                cmbStore.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    IsEditing = false;
                    txtName.Focus();
                }
            }
            else if (lstItems.SelectedItems.Count == 0 && IsEditing)
            {
                PromptSave();
            }

            UpdateUI(lstItems.SelectedItems.Count > 0);
        }

        private void lstItems_Format(object sender, ListControlConvertEventArgs e)
        {
            CommissionPool pool = (CommissionPool)e.ListItem;
            e.Value = pool.Name;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            IsEditing = true;

            UpdateUI(true);
        }

        private void lstPaymentTypes_Format(object sender, ListControlConvertEventArgs e)
        {
            PaymentStatus status = (PaymentStatus)e.ListItem;
            e.Value = status.Description;
        }

        private void lstPaymentTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            IsEditing = true;
            UpdateUI(lstItems.SelectedItems.Count > 0);
        }

        private void cmbStore_Format(object sender, ListControlConvertEventArgs e)
        {
            StoreLocation loc = (StoreLocation)e.ListItem;
            e.Value = loc.StoreName;
        }

        #endregion Private Methods
    }
}
