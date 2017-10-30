using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Users;
using Library.BOL.Invoices;

namespace POS.Base.Forms
{
    public partial class TrackingReference : BaseForm
    {
        #region Constructors

        public TrackingReference(string CurrentTrackingReference)
        {
            InitializeComponent();

            txtTrackingReference.Text = CurrentTrackingReference;
        }

        #endregion Constructors

        #region Properties

        public string TrackingRef
        {
            get
            {
                return (txtTrackingReference.Text);
            }
        }

        #endregion Properties

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            HelpTopic = POS.Base.Classes.HelpTopics.TrackingReference;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTrackingReference;

            lblShippingReference.Text = LanguageStrings.AppTrackingReference;
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
