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
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private CreateAutoRuleSettings _settings;

        #endregion Private Members

        #region Constructors

        public Step2(CreateAutoRuleSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblSelectItems.Text = LanguageStrings.AppAutoRuleSelectItems;
        }

        public override bool NextClicked()
        {
            if (clbItems.CheckedItems.Count == 0)
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppAutoRuleSelectItemsToUpdateError);
                return (false);
            }

            _settings.ItemsAffected.Clear();

            foreach (AutoUpdateItem item in clbItems.CheckedItems)
                _settings.ItemsAffected.Add(item);

            return (base.NextClicked());
        }

        public override void PageShown()
        {
            LoadRuleItems();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadRuleItems()
        {
            clbItems.Items.Clear();
            AutoUpdateItems items = _settings.Rule.GetItems();

            foreach (AutoUpdateItem item in items)
            {
                int idx = clbItems.Items.Add(item);

                if (_settings.ItemsAffected.IndexOf(item) > -1)
                    clbItems.SetItemChecked(idx, true);
            }
        }

        private void clbItems_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((AutoUpdateItem)e.ListItem).Description;
        }

        #endregion Private Methods
    }
}
