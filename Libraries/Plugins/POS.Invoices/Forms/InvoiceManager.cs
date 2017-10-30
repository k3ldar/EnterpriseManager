using System;
using System.Windows.Forms;

using Library;
using Library.BOL.Accounts;
using Library.BOL.Invoices;
using Library.BOL.Coupons;
using Languages;

using Reports.Accounts;

using POS.Base.Plugins;
using POS.Base.Classes;
using POS.Base;

namespace POS.Invoices.Forms
{
    public partial class InvoiceManager : POS.Base.Forms.BaseForm
    {
        #region Private / Protected Members


        #endregion Private / Protected Members

        #region Constructors / Destructors

        public InvoiceManager()
        {
            InitializeComponent();
        }

        #endregion Constructors / Destructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.InvoiceManager;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppInvoiceManager;
        }

        #endregion Overridden Methods
    }
}
