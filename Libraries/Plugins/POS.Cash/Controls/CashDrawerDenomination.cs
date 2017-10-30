using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.Utils;
using Library.BOL.CashDrawer;
using POS.Base.Classes;

namespace POS.CashManager.Classes
{
    public partial class CashDrawerDenomination : UserControl
    {
        public CashDrawerDenomination(CashDenomination denomination)
        {
            InitializeComponent();
            Denomination = denomination;

            lblValue.Text = Library.Utils.SharedUtils.FormatMoney(denomination.Value, AppController.LocalCurrency, false);
            txtValue.Text = StringConstants.SYMBOL_ZERO;
        }

        #region Properties

        /// <summary>
        /// Current Cash Denomination
        /// </summary>
        public CashDenomination Denomination { get; private set; }

        /// <summary>
        /// Value input by user
        /// </summary>
        public int UserQuantity
        {
            get
            {
                return (Shared.Utilities.StrToIntDef(txtValue.Text, 0));
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Event handler for user value changed
        /// </summary>
        public event EventHandler OnValueChanged;

        #endregion Events

        #region Private Methods

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (OnValueChanged != null)
                OnValueChanged(this, e);
        }

        #endregion Private Methods
    }
}
