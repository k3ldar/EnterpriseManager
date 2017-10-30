using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SieraDelta.POS.WebsiteAdministration.Forms
{
    public partial class BaseOptionsForm : SieraDelta.POS.Forms.BaseForm
    {
        public BaseOptionsForm()
        {
            InitializeComponent();
        }

        #region Properties

        protected bool IsEditing { get; set; }

        #endregion Properties

        #region Protected Methods

        protected virtual void OnCreate()
        {

        }

        protected virtual void OnDelete()
        {

        }

        protected virtual void OnSave()
        {

        }

        protected virtual void UpdateUI(bool itemSelected)
        {
            if (itemSelected)
            {
                toolStripButtonDelete.Enabled = true;
                toolStripButtonSave.Enabled = IsEditing;
            }
            else
            {
                toolStripButtonDelete.Enabled = false;
                toolStripButtonSave.Enabled = false;
            }

            toolStripButtonCreate.Enabled = !IsEditing;
        }

        #endregion Protected Methods

        #region Private Methods

        private void toolStripButtonCreate_Click(object sender, EventArgs e)
        {
            OnCreate();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        #endregion Private Methods
    }
}
