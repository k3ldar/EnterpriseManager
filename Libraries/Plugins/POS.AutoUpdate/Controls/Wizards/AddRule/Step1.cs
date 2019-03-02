/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Step1.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase.BOL.DatabaseUpdates;
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
