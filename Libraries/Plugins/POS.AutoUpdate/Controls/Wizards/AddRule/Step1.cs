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
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step1(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectRule.Text = LanguageStrings.AppAutoRuleSelect;
        }

        public override bool NextClicked()
        {
            if (_settings.Rule == null)
                _settings.Rule = (AutoUpdateRule)cmbRules.SelectedItem;

            return (base.NextClicked());
        }

        public override void PageShown()
        {
            if (cmbRules.Items.Count == 0)
                LoadRules();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadRules()
        {
            cmbRules.Items.Clear();

            AutoUpdateRules rules = AutoUpdateRules.Get();

            foreach (AutoUpdateRule rule in rules)
            {
                cmbRules.Items.Add(rule);
            }

            if (cmbRules.Items.Count > 0)
                cmbRules.SelectedIndex = 0;
        }

        private void cmbRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoUpdateRule rule = (AutoUpdateRule)cmbRules.SelectedItem;
            _settings.Rule = rule;

            lblRuleDescription.Text = rule.Description;
        }

        private void cmbRules_Format(object sender, ListControlConvertEventArgs e)
        {
            AutoUpdateRule rule = (AutoUpdateRule)e.ListItem;

            e.Value = rule.Name;
        }

        #endregion Private Methods
    }
}
