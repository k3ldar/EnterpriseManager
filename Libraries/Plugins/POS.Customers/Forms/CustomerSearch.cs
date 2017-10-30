using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Users;
using POS.Base;
using POS.Base.Classes;
using POS.Base.Forms;

namespace POS.Customers.Forms
{
    public partial class CustomerSearch : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public CustomerSearch()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.CustomerSearch;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppCustomersAdministration;

        }

        #endregion Overridden Methods
    }
}
