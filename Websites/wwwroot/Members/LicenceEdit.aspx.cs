using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.BOL.Users;

namespace SieraDelta.Website.Members
{
    public partial class LicenceEdit : BaseWebFormMember
    {
        #region Private Members

        private Library.BOL.Licencing.Licence _licence;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnSendEmail.Text = Languages.LanguageStrings.SendEmail;
            btnUpdate.Text = Languages.LanguageStrings.LicenceUpdate;
            divUpdated.Visible = false;

            User user = GetUser();

            _licence = user.Licences.Find(GetFormValue("id", -1));

            if (_licence == null)
                DoRedirect("/Account/Licences/", true);

            if (!IsPostBack)
                UpdateFields();

            LoadLicenceText();
        }

        protected string GetLicenceID()
        {
            return (_licence.ID.ToString());
        }

        protected string GetTrialLicence()
        {
            return (_licence.IsTrial ? Languages.LanguageStrings.Yes : Languages.LanguageStrings.No);
        }

        protected string GetIsValidLicenceDescription()
        {
            return (_licence.IsValid && _licence.Expires > DateTime.Now ? Languages.LanguageStrings.LicenceUpdateDescription : String.Empty);
        }

        protected string GetIsValidLicence()
        {
            return (_licence.IsValid && _licence.Expires > DateTime.Now ? Languages.LanguageStrings.Yes : Languages.LanguageStrings.No);
        }

        protected string GetExpireyDate()
        {
            return (_licence.Expires.ToString());
        }

        protected string GetLicenceUpdates()
        {
            return (String.Format(" {0} {1}", _licence.IsValid ? 2 - _licence.Updates : 0, Languages.LanguageStrings.LicenceUpdates));
        }

        protected string GetLicenceType()
        {
            return (_licence.LicenceTypeText);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _licence.Domain = txtDomain.Text;
            _licence.Save();
            DoRedirect(String.Format("/Account/Licences/Edit/{0}/", _licence.ID));
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            divUpdated.Visible = true;
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadLicenceText()
        {
            User user = GetUser();
            string lic = String.Format("ID={0}\rStartDate={1}\rExpireDate={2}\rLicenceType={3}\rDomain={4}" +
                "\rRegisteredTo={5}\rTrialLicence={6}\rValid={7}\rCount={8}",
                _licence.ID, _licence.CreateDate.ToString("dd/MM/yyyy"), _licence.Expires.ToString("dd/MM/yyyy"),
                (int)_licence.LicenceType, _licence.Domain, String.IsNullOrEmpty(user.BusinessName) ? user.UserName : user.BusinessName, 
                _licence.IsTrial, _licence.IsValid, _licence.Count);
            lic = SieraDelta.Website.Members.Licence.StringCipher.Encrypt(lic, SieraDelta.Website.Members.Licence.StringCipher._licPassword);
            txtLicenceText.Text = lic;

            txtLicenceText.Visible = _licence.IsValid;
            pnlLicence.Visible = _licence.IsValid;
            btnSendEmail.Visible = _licence.IsValid;
            btnUpdate.Visible = _licence.IsValid;
        }

        private void UpdateFields()
        {
            txtDomain.Text = _licence.Domain;

            spEmptyDomain.Visible = String.IsNullOrEmpty(_licence.Domain);

            btnUpdate.Visible = _licence.IsValid && _licence.Updates < 2;
            txtDomain.Enabled = _licence.IsValid && _licence.Updates < 2;
        }

        #endregion Private Methods
    }
}