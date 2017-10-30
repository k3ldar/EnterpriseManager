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
    public partial class Step5 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step5(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDescription.Text = LanguageStrings.AppAutoRuleGeneratedSQL;
        }

        public override bool NextClicked()
        {
            if (_settings.Rule.TestSQL() != _settings.ItemsAffected.Count)
            {

            }

            return (base.NextClicked());
        }

        public override void PageShown()
        {
            _settings.Rule.GenerateSQL(_settings.ItemsAffected);
            txtSQL.Text = _settings.Rule.SQL;
        }

        #endregion Overridden Methods

        #region Private Methods


        #endregion Private Methods
    }
}
