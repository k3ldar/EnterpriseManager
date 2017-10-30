using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Products;

using SharedControls.Classes;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Products
{
    public partial class AdminProductGroups : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private ProductGroups _Groups;

        #endregion Private Members

        #region Constructors

        public AdminProductGroups()
        {
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
            HelpTopic = POS.Base.Classes.HelpTopics.WebProductGroups;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppProductGroupAdministration;

            colHeaderGroupName.Text = LanguageStrings.AppProductGroupName;
            colHeaderPrimaryGroup.Text = LanguageStrings.AppPrimaryGroup;
            colHeaderSortOrder.Text = LanguageStrings.AppSortOrder;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.MemberLevel > MemberLevel.AdminReadOnly;
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
                bool setRightToLeft = false;

                lstProductGroups.Items.Clear();

                _Groups = AppController.Administration.ProductGroupsGet(1, 1000);

                foreach (ProductGroup group in _Groups)
                {
                    if (!setRightToLeft && Shared.Utilities.IsRightToLeftCharacter(group.Description))
                        setRightToLeft = true;

                    ListViewItem item = lstProductGroups.Items.Add(group.Description);
                    item.SubItems.Add(group.SortOrder.ToString());
                    item.SubItems.Add(group.GroupType.Description);
                    item.SubItems.Add(group.ID.ToString());
                }

                string StatusText = LanguageStrings.AppProductGroupsFound;

                if (_Groups.Count == 1)
                    StatusText = LanguageStrings.AppProductGroupFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, _Groups.Count);

                lstProductGroups.RightToLeft = setRightToLeft ? RightToLeft.Yes : RightToLeft.No;
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
                Library.BOL.Products.ProductGroup group = AppController.Administration.ProductGroupGet(
                    Convert.ToInt32(itm.SubItems[3].Text));

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
            InputBoxResult result = InputBox.Show(LanguageStrings.AppProductGroupEnterNewName,
                String.Format(LanguageStrings.AppProductGroupNewName, String.Empty),
                String.Format(LanguageStrings.AppProductGroupNewName, lstProductGroups.Items.Count + 1));

            if (result.ReturnCode == System.Windows.Forms.DialogResult.OK && result.Text != String.Empty)
            {
                try
                {
                    ProductGroups groups = ProductGroups.Get(AppController.ActiveUser.MemberLevel);
                    AppController.Administration.ProductGroupCreate(result.Text, groups.First().ID);
                    LoadGroups();
                }
                catch (Exception err)
                {
                    if (err.Message.Contains(StringConstants.ERROR_VIOLATION_UNIQUE_KEY))
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppProductGroupNameExists);
                    else
                        throw;
                }
            }
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstProductGroups_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void lstProductGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstProductGroups.SelectedItems.Count > -1;
        }

        #endregion Private Methods
    }
}
