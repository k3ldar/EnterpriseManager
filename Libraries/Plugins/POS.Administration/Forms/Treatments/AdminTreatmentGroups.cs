using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.BOL.Users;
using Library.BOL.Treatments;

using POS.Base.Classes;
using POS.Administration.Forms.Products;

namespace POS.Administration.Forms.Treatments
{
    public partial class AdminTreatmentGroups : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _Admin;
        private TreatmentGroups _Groups;

        #endregion Private Members

        #region Constructors

        public AdminTreatmentGroups(WebsiteAdministration Admin)
        {
            _Admin = Admin;

            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadGroups();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TreatmentGroups;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTreatmentGroupAdmin;

            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderSortOrder.Text = LanguageStrings.AppSortOrder;

            string StatusText = LanguageStrings.AppTreatmentGroupFoundMulti;

            if (_Groups.Count == 1)
                StatusText = LanguageStrings.AppTreatmentGroupFoundSingle;

            toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;

        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionWebsite(
                SecurityEnums.SecurityPermissionsWebsite.AdministerTreatmentGroups);
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadGroups()
        {
            this.Cursor = Cursors.WaitCursor;
            lstProductGroups.BeginUpdate();
            try
            {
                lstProductGroups.Items.Clear();

                _Groups = TreatmentGroups.Get();

                foreach (TreatmentGroup group in _Groups)
                {
                    ListViewItem item = lstProductGroups.Items.Add(group.Description);
                    item.SubItems.Add(group.SortOrder.ToString());
                    item.SubItems.Add(group.ID.ToString());
                }

                string StatusText = LanguageStrings.AppTreatmentGroupFoundMulti;

                if (_Groups.Count == 1)
                    StatusText = LanguageStrings.AppTreatmentGroupFoundSingle;

                toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);
            }
            finally
            {
                lstProductGroups.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstProductGroups_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstProductGroups.SelectedItems)
            {
                Library.BOL.Treatments.TreatmentGroup group = TreatmentGroups.Get(Convert.ToInt32(itm.SubItems[2].Text));

                if (group != null)
                {
                    AdminProductGroupEdit productEdit = new AdminProductGroupEdit(group);
                    try
                    {
                        productEdit.ShowDialog(this);
                        LoadGroups();
                        break;
                    }
                    finally
                    {
                        productEdit.Dispose();
                        productEdit = null;
                    }
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            TreatmentGroups.Create(AppController.ActiveUser, LanguageStrings.AppTreatmentGroupNew);
            LoadGroups();
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void lstProductGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstProductGroups.SelectedItems.Count > -1;
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstProductGroups_DoubleClick(sender, e);
        }

        #endregion Private Methods
    }
}
