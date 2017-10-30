using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

using SieraDelta.Library;
using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.Basket;
using SieraDelta.Library.BOL.Appointments;
using SieraDelta.Library.BOL.Users;

using SieraDelta.POS.Classes;

namespace SieraDelta.POS.Orders
{
    public partial class ShoppingBasketItem : SieraDelta.Controls.BaseControl
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

        public void UpdateQuantity(int newQuantity)
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
                    return (0.00m);

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

                if (_Item.ItemType == Enums.BasketType.Product && _Item.Size != String.Empty)
                    lblDescription.Text = String.Format(StringConstants.PRODUCT_COST_SIZE_DEFAULT, 
                        value.Description, value.Size);
                else
                {
                    if (_Item.ItemType == Enums.BasketType.FreeProduct)
                        lblDescription.Text = String.Format(StringConstants.PRODUCT_COST_SIZE_DEFAULT, 
                            value.Description, value.Size);
                    else
                        lblDescription.Text = value.Description;
                }

                //if (_Item.ItemType != Enums.BasketType.Treatment &&
                //    _Item.ProductType != ProductCostType.Silver)
                //{
                    lblDescription.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                        _Item.ProductType.Description, lblDescription.Text);
                //}

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
                lblCost.Text = SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(
                    _Item.PriceWithDiscount * _Item.Quantity, AppController.LocalCountry),
                    AppController.LocalCurrency);
                lblPrice.Text = SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(_Item.Price,
                    AppController.LocalCountry), AppController.LocalCurrency);
                lblVAT.Text = SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATCalculatePaid(_Item.PriceWithDiscount * _Item.Quantity,
                    AppController.LocalCountry.VATRate), AppController.LocalCurrency);

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostIncludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.Price * _Item.Quantity, AppController.LocalCurrency), 
                    _Item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.Price, AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.Price, AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblDescription, String.Format(LanguageStrings.AppItemCostIncludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.Price, AppController.LocalCurrency), _Item.Description));
            }
            else
            {
                lblCost.Text = SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.PriceWithDiscount * _Item.Quantity,
                    AppController.LocalCurrency);

                lblPrice.Text = SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(_Item.Price, AppController.LocalCurrency);

                toolTip1.SetToolTip(lblCost, String.Format(LanguageStrings.AppCostExcludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(_Item.Price, AppController.LocalCountry) *
                    _Item.Quantity, AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblPrice, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(_Item.Price, AppController.LocalCountry),
                    AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(this, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(_Item.Price, AppController.LocalCountry),
                    AppController.LocalCurrency), _Item.Description));

                toolTip1.SetToolTip(lblDescription, String.Format(LanguageStrings.AppItemCostExcludingVAT,
                    SieraDelta.Library.Utils.SieraDeltaUtils.FormatMoney(HSCUtils.VATRemove(_Item.Price, AppController.LocalCountry),
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
            int Qty = SieraDelta.Shared.Utilities.StrToIntDef(txtQuantity.Text, 1);

            if (txtQuantity.Text != Qty.ToString())
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
                _Item.UserDiscount = SieraDelta.Shared.Utilities.StrToIntDef(txtDiscount.Text, 1);
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
