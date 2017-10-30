using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.StockControl;
using Library.BOL.Locations;
using Library.BOL.Products;
using POS.Base.Classes;
using POS.StockControl.Controls;

namespace POS.StockControl.Forms
{
    public partial class MainScreenStockControl : POS.Base.Forms.BaseForm
    {
        #region Private Members

        #endregion Private Members

        #region Constructors

        public MainScreenStockControl()
        {
            InitializeComponent();

            CheckFormPosition(this);
            mainStockControl1.Initialise();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StockControl;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppStockControl, AppController.ActiveUser.UserName);

        }

        #endregion Overridden Methods

        #region Private Methods

        #endregion Private Methods
    }
}
