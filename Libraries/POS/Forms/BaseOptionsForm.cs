using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

namespace POS.Base.Forms
{
    public partial class BaseOptionsForm : BaseForm
    {
        public BaseOptionsForm()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainSave.Image = POS.Base.Icons.SaveIcon();

            toolStripMainRefresh.Enabled = false;
            toolStripMainEdit.Enabled = false;
        }

        #region Properties

        protected bool IsEditing { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;

            toolStripMainAdd.Text = LanguageStrings.AppCreate;
            toolStripMainDelete.Text = LanguageStrings.AppDelete;
            toolStripMainSave.Text = LanguageStrings.AppSave;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;

            toolStripMainAdd.ToolTipText = LanguageStrings.AppCreate;
            toolStripMainDelete.ToolTipText = LanguageStrings.AppDelete;
            toolStripMainSave.ToolTipText = LanguageStrings.AppSave;
        }

        #endregion Overridden Methods

        #region Protected Methods

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            e.Cancel = PromptSave();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnResizeEnd(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);

            btnOK.Top = this.Height - (btnOK.Height + 50);
            btnOK.Left = this.Width - (btnOK.Width + 30);

            btnCancel.Top = btnOK.Top;
            btnCancel.Left = btnOK.Left - (btnCancel.Width + 10);
        }

        protected virtual void OnCreateClicked()
        {

        }

        protected virtual void OnDeleteClicked()
        {

        }

        protected virtual void OnSaveClicked()
        {

        }

        protected virtual void OnRefreshClicked()
        {

        }

        protected virtual void OnEditClicked()
        {

        }

        protected virtual void UpdateUI(bool itemSelected)
        {
            if (itemSelected)
            {
                toolStripMainDelete.Enabled = true;
                toolStripMainSave.Enabled = IsEditing;
            }
            else
            {
                toolStripMainDelete.Enabled = false;
                toolStripMainSave.Enabled = false;
            }

            toolStripMainAdd.Enabled = !IsEditing;
        }

        protected virtual bool PromptSave()
        {
            return (true);
        }

        #endregion Protected Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            PromptSave();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PromptSave();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            OnCreateClicked();
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked();
        }

        private void toolStripMainSave_Click(object sender, EventArgs e)
        {
            OnSaveClicked();
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked();
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshClicked();
        }
 
        #endregion Private Methods
   }
}
