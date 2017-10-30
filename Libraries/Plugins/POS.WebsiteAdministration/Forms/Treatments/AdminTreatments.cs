using System;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Treatments;

using POS.Base.Classes;
using SharedControls.Classes;

namespace POS.WebsiteAdministration.Forms.Treatments
{
    public partial class AdminTreatments : POS.Base.Controls.BaseTabControl
    {
        #region Constructors

        public AdminTreatments()
        {
            InitializeComponent();

            if (!AppController.ApplicationRunning)
                return;

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadTreatments();
        }

        #endregion Constructors

        #region Overridden Methods


        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderName.Text = LanguageStrings.AppName;

            string StatusText = LanguageStrings.AppTreatmentSalonFoundMulti;

            if (lstTreatments.Items.Count == 1)
                StatusText = LanguageStrings.AppTreatmentSalonFoundSingle;

            toolStripStatusLabelCount.Text = String.Format(StatusText, lstTreatments.Items.Count);

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;

        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.NewSalonTreatments);
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadTreatments()
        {
            this.Cursor = Cursors.WaitCursor;
            lstTreatments.BeginUpdate();
            try
            {
                lstTreatments.Items.Clear();
                Library.BOL.Treatments.Treatments treatments = Library.BOL.Treatments.Treatments.Get(1, 1000);

                foreach (Treatment treat in treatments)
                {
                    ListViewItem item = lstTreatments.Items.Add(treat.Name);
                    item.Tag = treat;
                    item.SubItems.Add(treat.ID.ToString());
                }


                string StatusText = LanguageStrings.AppTreatmentSalonFoundMulti;

                if (treatments.Count == 1)
                    StatusText = LanguageStrings.AppTreatmentSalonFoundSingle;

                toolStripStatusLabelCount.Text = String.Format(StatusText, treatments.Count);
            }
            finally
            {
                lstTreatments.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstTreatments_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstTreatments.SelectedItems)
            {
                Treatment treat = (Treatment)itm.Tag;

                if (treat != null)
                {
                    AdminTreatmentEdit ate = new AdminTreatmentEdit(treat);
                    try
                    {
                        ate.ShowDialog(this);
                        LoadTreatments();
                    }
                    finally
                    {
                        ate.Dispose();
                        ate = null;
                    }
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show(LanguageStrings.AppTreatmentSalonNewPrompt,
                LanguageStrings.AppTreatmentSalonNewName, LanguageStrings.AppTreatmentSalonNew);

            if (result.ReturnCode == System.Windows.Forms.DialogResult.OK && result.Text != String.Empty)
            {
                Treatment newTreat = new Treatment(-1, result.Text, StringConstants.COST_ZERO,
                    String.Format(LanguageStrings.AppMinutes, 15), String.Empty, String.Empty,
                    String.Empty, 100, 15, false);
                newTreat = AppController.Administration.TreatmentCreate(newTreat);

                AdminTreatmentEdit ate = new AdminTreatmentEdit(newTreat);
                try
                {
                    ate.ShowDialog(this);
                    LoadTreatments();
                }
                finally
                {
                    ate.Dispose();
                    ate = null;
                }
            }
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowDelete))
            {
                if (ShowHardConfirm(LanguageStrings.AppTreatmentsDelete,
                    LanguageStrings.AppTreatmentsDeletePrompt))
                {
                    foreach (ListViewItem itm in lstTreatments.SelectedItems)
                    {
                        Treatment treat = (Treatment)itm.Tag;

                        treat.Delete(AppController.ActiveUser);
                        lstTreatments.Items.Remove(itm);
                    }
                }
            }
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstTreatments_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadTreatments();
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstTreatments.SelectedItems.Count > 0;
        }

        #endregion Private Methods
    }
}
