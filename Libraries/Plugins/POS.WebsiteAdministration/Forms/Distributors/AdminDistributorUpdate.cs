using System;

using Languages;
using Library.BOL.Salons;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Distributors
{
    public partial class AdminSalonUpdate : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Salon _salon;

        #endregion Private Members

        #region Constructors

        public AdminSalonUpdate(Salon salon, Salon salonUpdate)
        {
            InitializeComponent();

            _salon = salon;
            salonUpdateCurrent.Refresh(salon);
            salonUpdateNew.Refresh(salonUpdate);
            salonUpdateNew.ShowChanges(salon);
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebSalonUpdate;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonUpdateAdministration;

            btnAccept.Text = LanguageStrings.AppMenuButtonAcceptChanges;
            btnReject.Text = LanguageStrings.AppMenuButtonRejectChanges;

            lblCurrentSalonDetails.Text = LanguageStrings.AppSalonCurrentDetails;
            lblNewSalonDetails.Text = LanguageStrings.AppSalonNewDetails;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnReject_Click(object sender, EventArgs e)
        {
            AppController.Administration.SalonOwnerUpdateDelete(_salon.UpdateOwner(), _salon);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AppController.Administration.SalonOwnerUpdateMerge(_salon.UpdateOwner(), _salon);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #endregion Private Methods
    }
}
