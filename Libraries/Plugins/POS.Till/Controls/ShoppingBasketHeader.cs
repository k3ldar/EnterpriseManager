using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

namespace POS.Till.Controls
{
    public partial class ShoppingBasketHeader : SharedControls.BaseControl
    {
        #region Constructors

        public ShoppingBasketHeader()
        {
            InitializeComponent();

            if (!DesignMode && POS.Base.Classes.AppController.ApplicationRunning)
                lblVAT.Visible = POS.Base.Classes.AppController.LocalSettings.ShowPricesWithoutVAT;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblCost.Text = LanguageStrings.AppCost;
            lblDescription.Text = LanguageStrings.AppProduct;
            lblDiscount.Text = LanguageStrings.AppDiscountTypePercent;
            lblPrice.Text = LanguageStrings.AppPrice;
            lblQuantity.Text = LanguageStrings.AppQuantity;
            lblVAT.Text = LanguageStrings.AppVAT;
            lblStaffMember.Text = LanguageStrings.AppStaffMember;
        }

        #endregion Overridden Methods
    }
}
