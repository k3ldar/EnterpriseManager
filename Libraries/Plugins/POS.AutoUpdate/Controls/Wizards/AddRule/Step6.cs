using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.BOL.DatabaseUpdates;
using POS.AutoUpdate.Classes;

namespace POS.AutoUpdate.Controls.Wizards.AddRule
{
    public partial class Step6 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step6(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            InitializeComponent();

            dtpRunTime.Value = DateTime.Now.AddDays(1);
            dtpRunTime.MinDate = DateTime.Now.AddDays(-1);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppAutoRuleCreateRule;
            lblName.Text = LanguageStrings.AppName;
            lblRunDate.Text = LanguageStrings.AppAutoRuleRunDate;

            dtpRunTime.CustomFormat = culture.DateTimeFormat.FullDateTimePattern;
        }

        public override bool NextClicked()
        {
            return (base.NextClicked());
        }

        public override void PageShown()
        {

        }

        public override bool BeforeFinish()
        {
            try
            {
                if (String.IsNullOrEmpty(txtName.Text))
                    throw new Exception(LanguageStrings.AppErrorAutoUpdateNameRequired);

                _settings.AutoUpdate = new Library.BOL.DatabaseUpdates.AutoUpdate(-1,
                    txtName.Text, _settings.Rule.SQL, dtpRunTime.Value, false,
                    POS.Base.Classes.AppController.ActiveUser, DateTime.Now);

                AutoUpdates.Create(_settings.AutoUpdate);

                return (base.BeforeFinish());
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppAutoRuleCreateError, err.Message));
                return (false);
            }
        }

        #endregion Overridden Methods

        #region Private Methods


        #endregion Private Methods
    }
}
