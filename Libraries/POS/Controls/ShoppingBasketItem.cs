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
 *  File: ShoppingBasketItem.cs
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

using SharedBase.Utils;
using SharedBase.BOL.Basket;
using SharedBase.BOL.Appointments;
using SharedBase.BOL.Users;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation

namespace POS.Base.Controls
{
    public partial class ShoppingBasketItem : SharedControls.BaseControl
    {
        #region Private Members

        private ShoppingBasket _basket;
        private BasketItem _item;
        private AppointmentTreatment _treatment;
        private Users _staffMembers;
        private User _user;

        #endregion Private Members

        #region Events

        public event EventHandler Updated;
        public event EventHandler Deleted;

        #endregion Events

        #region Constructors

        public ShoppingBasketItem(Users StaffMembers, User user)
        {
            _user = user;
            InitializeComponent();
            _staffMembers = StaffMembers;
            LoadStaffMembers();
        }

        #endregion Constructors

        #region Public Methods

        public void UpdateUserDiscount(int newDiscount)
        {
            txtDiscount.Text = newDiscount.ToString();
            UpdateLabels();
        }

        public void UpdateQuantity(decimal newQuantity)
        {
            if (_item == null)
                throw new Exception(StringConstants.ERROR_INVALID_PRODUCT_ITEM);

            txtQuantity.Text = newQuantity.ToString();
        }

        #endregion Public Methods

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            //Item = _Item;
            txtQuantity_Leave(this, EventArgs.Empty);
        }

        #endregion Overridden Methods

        #region Protected Methods

        protected virtual void OnUpdate()
        {
            if (Updated != null)
                Updated(this, new EventArgs());
        }

        protected virtual void OnDelete()
        {
            if (Deleted != null)
                Deleted(this, new EventArgs());
        }

        #endregion Protected Methods

        #region properties

        public bool IgnoreCostMultiplier { get; set; }

        public decimal CostMultiplier
        {
            get
            {
                if (IgnoreCostMultiplier)
                    return (0.00m);

                return (AppController.LocalCurrency.Multiplier);
            }
        }

        public BasketItem Item
        {
            get
            {
                return (_item);
            }

            set
            {
                _item = value;

                txtDescription.TextChanged -= txtDescription_TextChanged;
                try
                {
                    txtDescription.Text = value.Description;
                }
                finally
                {
                    txtDescription.TextChanged += txtDescription_TextChanged;
                }

                DescriptionChanged = false;

                txtQuantity.Text = value.Quantity.ToString();
                txtDiscount.Text = value.UserDiscount.ToString();

                UpdateLabels();

                foreach (object obj in cmbStaffMember.Items)
                {
                    User user = (User)obj;

                    if (user.ID == value.UserID)
                    {
                        int cmbID = cmbStaffMember.Items.IndexOf(user);
                        cmbStaffMember.SelectedIndex = cmbID;
                        break;
                    }
                }

                cmbStaffMember.SelectedIndexChanged += new System.EventHandler(
                    cmbStaffMember_SelectedIndexChanged);

                UpdateLabels();
            }

        }

        public AppointmentTreatment Treatment
        {
            set
            {
                _treatment = value;
                txtDescription.Text = String.Format(StringConstants.PREFIX_NO_SPACE, value.Name);
                txtQuantity.Text = StringConstants.SYMBOL_ONE;
                UpdateLabels();
            }
        }

        public ShoppingBasket Basket
        {
            get
            {
                return (_basket);
            }

            set
            {
                _basket = value;
            }
        }

        private bool DescriptionChanged { get; set; }

        #endregion Properties

        #region Private Methods

        private void LoadStaffMembers()
        {
            cmbStaffMember.Items.Clear();

            foreach (User user in _staffMembers)
            {
                int idx = cmbStaffMember.Items.Add(user);

                if (user.ID == _user.ID)
                    cmbStaffMember.SelectedIndex = idx;
            }
        }

        private void UpdateLabels()
        {
            if (AppController.LocalSettings.ShowPricesWithoutVAT)
            {
                decimal discountPrice = _item.PriceWithDiscount;
                lblCost.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    discountPrice * _item.Quantity,
                    AppController.LocalCurrency);
                lblPrice.Text = SharedBase.Utils.SharedUtils.FormatMoney(_item.Price,
                     AppController.LocalCurrency);
                lblVAT.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    SharedUtils.VATCalculate(SharedUtils.BankersRounding(discountPrice * _item.Quantity, 2), _basket.VATRate), 
                    AppController.LocalCurrency);

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _item.Price + SharedUtils.VATCalculate(discountPrice, _basket.VATRate) * _item.Quantity, AppController.LocalCurrency), 
                    _item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _item.Price + SharedUtils.VATCalculate(discountPrice, _basket.VATRate), AppController.LocalCurrency), _item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _item.Price + SharedUtils.VATCalculate(discountPrice, _basket.VATRate), AppController.LocalCurrency), _item.Description));

                toolTip1.SetToolTip(txtDescription, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _item.Price + SharedUtils.VATCalculate(discountPrice, _basket.VATRate), AppController.LocalCurrency), _item.Description));
            }
            else
            {
                lblCost.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    (_item.PriceWithDiscount + SharedUtils.VATCalculate(_item.PriceWithDiscount, _basket.VATRate)) * _item.Quantity,
                    AppController.LocalCurrency);

                lblPrice.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    (_item.Price + SharedUtils.VATCalculate(_item.Price, _basket.VATRate)), 
                    AppController.LocalCurrency);

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    (_item.Price + SharedUtils.VATCalculate(_item.Price, _basket.VATRate))* _item.Quantity, 
                    AppController.LocalCurrency), _item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_item.Price,
                    AppController.LocalCurrency), _item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_item.Price,
                    AppController.LocalCurrency), _item.Description));

                toolTip1.SetToolTip(txtDescription, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_item.Price,
                    AppController.LocalCurrency), _item.Description));
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_item != null)
                _basket.Delete(_item);

            OnDelete();
        }

        private void cmbStaffMember_Format(object sender, ListControlConvertEventArgs e)
        {
            User user = (User)e.ListItem;
            e.Value = user.UserName;
        }

        private void cmbStaffMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = (User)cmbStaffMember.SelectedItem;

            _item.UserID = user.ID;

            int Qty = Convert.ToInt32(txtQuantity.Text);
            _basket.Update(_item, Qty, user);

            OnUpdate();
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            UpdateQuantity();
        }

        private void UpdateQuantity()
        {
            string quantity = txtQuantity.Text;

            if (quantity.EndsWith(StringConstants.SYMBOL_FULL_STOP))
                quantity += StringConstants.SYMBOL_ZERO;

            decimal Qty = Shared.Utilities.StrToDecimal(quantity, 1);

            if (txtQuantity.Text != Qty.ToString() && !txtQuantity.Text.EndsWith(StringConstants.SYMBOL_FULL_STOP))
                txtQuantity.Text = Qty.ToString();

            if (Qty != _item.Quantity)
            {
                _basket.Update(_item, Qty, User.UserGet(_item.UserID));

                UpdateLabels();
                OnUpdate();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtQuantity.Text))
            {
                UpdateQuantity();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDiscount.Text))
            {
                _item.UserDiscount = Shared.Utilities.StrToIntDef(txtDiscount.Text, 1);
                _basket.Update(_item, _item.Quantity, User.UserGet(_item.UserID));
                UpdateLabels();
                OnUpdate();
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiscount.Text))
                txtDiscount.Text = StringConstants.SYMBOL_ZERO;

            UpdateLabels();
            _basket.Update(_item, _item.Quantity, User.UserGet(_item.UserID));
            OnUpdate();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescription.Text))
            {
                if (RaiseNameChange(txtDescription.Text))
                {
                    _item.Description = txtDescription.Text;
                    DescriptionChanged = true;
                }
                else
                {
                    txtDescription.TextChanged -= txtDescription_TextChanged;
                    try
                    {
                        if (txtDescription.Text != _item.Description)
                            txtDescription.Text = _item.Description;
                    }
                    finally
                    {
                        txtDescription.TextChanged += txtDescription_TextChanged;
                    }
                }
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (DescriptionChanged)
            {
                _item.Description = txtDescription.Text;
                _basket.Update(_item, _item.Quantity, User.UserGet(_item.UserID));
                DescriptionChanged = false;
            }
        }

        private bool RaiseNameChange(string name)
        {
            if (BeforeNameChange != null)
            {
                NameChangeEventArgs args = new NameChangeEventArgs(name, _item.ID);
                BeforeNameChange(this, args);
                return (args.Allowed);
            }

            return (false);
        }

        #endregion Private Methods

        #region Events

        public event NameChangeHandler BeforeNameChange;

        #endregion Events
    }
}
