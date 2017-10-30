using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.Basket;
using Library.Utils;

using POS.Base.Classes;
using POS.Base.Forms;

namespace POS.Administration.Forms.Products
{
    public partial class AdminPriceCalculator : BaseForm
    {
        private bool _autoUpdate = false;

        public AdminPriceCalculator()
        {
            InitializeComponent();
            txtVATAmount.Text = Library.DAL.DALHelper.DefaultVATRate.ToString();
        }

        #region Static Methods

        public static bool ShowCostItemForm(ref decimal netValue)
        {
            AdminPriceCalculator costItem = new AdminPriceCalculator();
            try
            {
                costItem.NetValue = netValue;

                DialogResult result = costItem.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    netValue = costItem.NetValue;
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            finally
            {
                costItem.Dispose();
                costItem = null;
            }
        }

        #endregion Static Methods

        #region Properties

        public decimal NetValue
        {
            get
            {
                return (SharedUtils.StrToDecimal(txtNetAmount.Text, 0));
            }

            set
            {
                txtNetAmount.Text = value.ToString();
            }
        }

        #endregion Properties

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ProductPriceCalculator;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppPriceCalculator;
            lblCost.Text = LanguageStrings.AppCost;
            lblNetCost.Text = LanguageStrings.AppPrice;
            lblVATRate.Text = LanguageStrings.AppVAT;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            if (_autoUpdate)
                return;

            _autoUpdate = true;
            try
            {
                decimal net = SharedUtils.StrToDecimal(txtNetAmount.Text, 0);
                decimal vat = SharedUtils.StrToDecimal(txtVATAmount.Text, 20);
                decimal cost = net + SharedUtils.VATCalculate(net, (double)vat);

                txtCost.Text = SharedUtils.FormatMoney(cost,
                    AppController.LocalCurrency, true);
            }
            finally
            {
                _autoUpdate = false;
            }
        }

        private void txtVATAmount_TextChanged(object sender, EventArgs e)
        {
            if (_autoUpdate)
                return;

            _autoUpdate = true;
            try
            {
                decimal net = SharedUtils.StrToDecimal(txtNetAmount.Text, 0);
                decimal vat = SharedUtils.StrToDecimal(txtVATAmount.Text, 20);
                decimal cost = net + SharedUtils.VATCalculate(net, (double)vat);

                txtCost.Text = SharedUtils.FormatMoney(cost,
                    AppController.LocalCurrency, true);
            }
            finally
            {
                _autoUpdate = false;
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            if (_autoUpdate)
                return;

            _autoUpdate = true;
            try
            {
                decimal cost = SharedUtils.StrToDecimal(txtCost.Text, 0);
                decimal vat = SharedUtils.StrToDecimal(txtVATAmount.Text, 20);
                decimal net = SharedUtils.VATRemove(cost, (double)vat);

                txtNetAmount.Text = Math.Round(net, 5).ToString();
            }
            finally
            {
                _autoUpdate = false;
            }
        }

        #endregion Private Methods
    }
}
