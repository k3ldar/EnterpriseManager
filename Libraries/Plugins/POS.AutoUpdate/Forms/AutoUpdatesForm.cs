using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.DatabaseUpdates;
using POS.Base.Classes;

namespace POS.AutoUpdate.Forms
{
    public partial class AutoUpdatesForm : POS.Base.Controls.BaseOptionsControl
    {
        #region Constructors

        public AutoUpdatesForm()
        {
            InitializeComponent();

            IsEditing = false;

            AddAllAutoUpdates();

            UpdateUI(false);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            base.LanguageChanged(culture);

            columnHeaderName.Text = LanguageStrings.AppName;
            columnHeaderRunDate.Text = LanguageStrings.AppAutoRuleRunDate;
            columnHeaderRun.Text = LanguageStrings.AppAutoRuleHasRun;
            columnHeaderCreatedBy.Text = LanguageStrings.AppCreatedBy;
            columnHeaderCreatedDate.Text = LanguageStrings.AppCreatedDate;
        }

        protected override void OnEditClicked()
        {
            if (lvAutoUpdateItems.SelectedItems.Count == 0)
                return;

            Library.BOL.DatabaseUpdates.AutoUpdate existingRule = (Library.BOL.DatabaseUpdates.AutoUpdate)lvAutoUpdateItems.SelectedItems[0].Tag;

            Classes.ExecuteNewAutoUpdateWizard.CreateNewAutoUpdate(existingRule);

            ListViewItem item = lvAutoUpdateItems.SelectedItems[0];
            item.Text = existingRule.Name;
            item.Tag = existingRule;
            item.SubItems.Add(Shared.Utilities.DateToStr(existingRule.RunDate, AppController.LocalCulture));
            item.SubItems.Add(existingRule.Complete ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            item.SubItems.Add(existingRule.CreatedBy.UserName);
            item.SubItems.Add(Shared.Utilities.DateToStr(existingRule.CreatedDate, AppController.LocalCulture));
        }

        protected override void OnSaveClicked()
        {
            base.OnSaveClicked();
        }

        protected override void OnCreateClicked()
        {
            Library.BOL.DatabaseUpdates.AutoUpdate newUpdate = Classes.ExecuteNewAutoUpdateWizard.CreateNewAutoUpdate(null);

            if (newUpdate != null)
                AddAutoUpdate(newUpdate);
        }

        protected override void OnDeleteClicked()
        {
            if (ShowQuestion(LanguageStrings.AppAutoRuleDelete, LanguageStrings.AppAutoRuleDeletePrompt))
            {
                AutoUpdates.Delete((Library.BOL.DatabaseUpdates.AutoUpdate)lvAutoUpdateItems.SelectedItems[0].Tag);
                AddAllAutoUpdates();
            }

            base.OnDeleteClicked();
        }

        protected override bool PromptSave()
        {
            return (false);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void AddAllAutoUpdates()
        {
            lvAutoUpdateItems.Items.Clear();
            AutoUpdates updates = AutoUpdates.Get();

            foreach (Library.BOL.DatabaseUpdates.AutoUpdate update in updates)
                AddAutoUpdate(update);
        }

        private void AddAutoUpdate(Library.BOL.DatabaseUpdates.AutoUpdate autoUpdate)
        {
            ListViewItem item = new ListViewItem();
            item.Text = autoUpdate.Name;
            item.Tag = autoUpdate;
            item.SubItems.Add(Shared.Utilities.DateToStr(autoUpdate.RunDate, AppController.LocalCulture));
            item.SubItems.Add(autoUpdate.Complete ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            item.SubItems.Add(autoUpdate.CreatedBy.UserName);
            item.SubItems.Add(Shared.Utilities.DateToStr(autoUpdate.CreatedDate, AppController.LocalCulture));
            lvAutoUpdateItems.Items.Add(item);
        }

        private void lvAutoUpdateItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowEdit = false;
            UpdateUI(lvAutoUpdateItems.SelectedItems.Count > 0);
        }

        #endregion Private Methods
    }
}
