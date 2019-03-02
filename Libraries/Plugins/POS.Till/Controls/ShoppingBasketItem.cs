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

#pragma warning disable IDE1006

namespace POS.Till.Controls
{
    public partial class ShoppingBasketItem : SharedControls.BaseControl
    {
        #region Private Members

        private ShoppingBasket _Basket;
        private BasketItem _Item;
        private AppointmentTreatment _Treatment;
        private Users _StaffMembers;
        private User _User;

        #endregion Private Members

        #region Events

        public event EventHandler Updated;
        public event EventHandler Deleted;

        #endregion Events

        #region Constructors

        public ShoppingBasketItem(Users StaffMembers, User user)
        {
            _User = user;
            InitializeComponent();
            _StaffMembers = StaffMembers;
            LoadStaffMembers();
        }

        #endregion Constructors

        #region Public Methods

        public void UpdateQuantity(decimal newQuantity)
        {
            if (_Item == null)
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
                    return (1.00m);

                return (AppController.LocalCurrency.Multiplier);
            }
        }

        public BasketItem Item
        {
            get
            {
                return (_Item);
            }

            set
            {
                _Item = value;

                lblDescription.Text = value.Description;

                txtQuantity.Text = value.Quantity.ToString();

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
            }
        }

        public AppointmentTreatment Treatment
        {
            set
            {
                _Treatment = value;
                lblDescription.Text = String.Format(StringConstants.PREFIX_NO_SPACE, value.Name);
                txtQuantity.Text = StringConstants.SYMBOL_ONE;
                UpdateLabels();
            }
        }

        public ShoppingBasket Basket
        {
            get
            {
                return (_Basket);
            }

            set
            {
                _Basket = value;
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadStaffMembers()
        {
            cmbStaffMember.Items.Clear();

            foreach (User user in _StaffMembers)
            {
                int idx = cmbStaffMember.Items.Add(user);

                if (user.ID == _User.ID)
                    cmbStaffMember.SelectedIndex = idx;
            }
        }

        private void UpdateLabels()
        {
            if (AppController.LocalSettings.ShowPricesWithoutVAT)
            {
                lblCost.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    _Item.PriceWithDiscount * _Item.Quantity, 
                    AppController.LocalCurrency);
                lblPrice.Text = SharedBase.Utils.SharedUtils.FormatMoney(_Item.Price, AppController.LocalCurrency);
                lblVAT.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    SharedUtils.VATCalculate(_Item.PriceWithDiscount * _Item.Quantity, _Basket.VATRate),
                    AppController.LocalCurrency);

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    (_Item.Price + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.Price, _Basket.VATRate), 2)) * _Item.Quantity, AppController.LocalCurrency), 
                    _Item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _Item.Price + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.Price, _Basket.VATRate), 2), AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _Item.Price + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.Price, _Basket.VATRate), 2), AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblDescription, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _Item.Price + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.Price, _Basket.VATRate), 2), AppController.LocalCurrency), _Item.Description));
            }
            else
            {
                lblCost.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    (_Item.PriceWithDiscount + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.PriceWithDiscount, _Basket.VATRate), 2)) * _Item.Quantity,
                    AppController.LocalCurrency);

                lblPrice.Text = SharedBase.Utils.SharedUtils.FormatMoney(
                    (_Item.Price + SharedUtils.BankersRounding(SharedUtils.VATCalculate(_Item.Price, _Basket.VATRate), 2)), AppController.LocalCurrency);

                lblVAT.Visible = false;

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(
                    _Item.Price * _Item.Quantity, AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_Item.Price,
                    AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_Item.Price,
                    AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblDescription, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SharedBase.Utils.SharedUtils.FormatMoney(_Item.Price,
                    AppController.LocalCurrency), _Item.Description));
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_Item != null)
                _Basket.Delete(_Item);

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

            _Item.UserID = user.ID;

            int Qty = Convert.ToInt32(txtQuantity.Text);
            _Basket.Update(_Item, Qty, user);

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

            if (Qty != _Item.Quantity)
            {
                _Basket.Update(_Item, Qty, User.UserGet(_Item.UserID));

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
                _Item.UserDiscount = Shared.Utilities.StrToIntDef(txtDiscount.Text, 1);
                _Basket.Update(_Item, _Item.Quantity, User.UserGet(_Item.UserID));
                UpdateLabels();
                OnUpdate();
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDiscount.Text))
                txtDiscount.Text = StringConstants.SYMBOL_ZERO;

            _Basket.Update(_Item, _Item.Quantity, User.UserGet(_Item.UserID));
        }

        #endregion Private Methods
    }
}
