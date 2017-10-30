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
using Library.BOL.MissingLinks;

using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.MissingLinks
{
    public partial class AdminMissingLinks : POS.Base.Controls.BaseTabControl
    {
        #region Constructors

        public AdminMissingLinks()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadMissingLinks();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderMissingLink.Text = LanguageStrings.AppMissingLinkMissingPage;
            colHeaderRedirectPage.Text = LanguageStrings.AppMissingLinkRedirectPage;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.MemberLevel > Library.MemberLevel.AdminReadOnly;
            toolStripMainDelete.Enabled = false;
        }

        public override int GetStatusCount()
        {
            return (statusStrip1.Items.Count);
        }

        public override string GetStatusHint(int index)
        {
            return (statusStrip1.Items[index].ToolTipText);
        }

        public override string GetStatusText(int index)
        {
            return (statusStrip1.Items[index].Text);
        }

        #endregion Overridden Methods

        #region Private methods

        private void LoadMissingLinks()
        {
            this.Cursor = Cursors.WaitCursor;
            lstHints.BeginUpdate();
            try
            {
                lstHints.Items.Clear();
                Library.BOL.MissingLinks.MissingLinks links = AppController.Administration.MissingLinksGet(1, 1000);

                foreach (MissingLink link in links)
                {
                    ListViewItem item = lstHints.Items.Add(link.DeprecatedLink);
                    item.SubItems.Add(link.RedirectLink);
                }


                string StatusText = LanguageStrings.AppMissingLinksFound;

                if (links.Count == 1)
                    StatusText = LanguageStrings.AppMissingLinkFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, links.Count);
            }
            finally
            {
                lstHints.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstHints_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstHints.SelectedItems)
            {
                MissingLink link = AppController.Administration.MissingLinkGet(itm.SubItems[0].Text);

                if (link != null)
                {
                    AdminMissingLinkEdit mle = new AdminMissingLinkEdit(link);
                    try
                    {
                        mle.ShowDialog(this);
                    }
                    finally
                    {
                        mle.Dispose();
                        mle = null;
                    }

                    LoadMissingLinks();
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            MissingLink newLink = new MissingLink(-1, StringConstants.WEB_PAGE_MISSING_LINK,
                StringConstants.SYMBOL_FORWARD_SLASH);
            AdminMissingLinkEdit mle = new AdminMissingLinkEdit(newLink);
            try
            {
                mle.ShowDialog();
            }
            finally
            {
                mle.Dispose();
                mle = null;
            }

            LoadMissingLinks();
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstHints_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = false;
            LoadMissingLinks();
        }

        private void lstHints_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstHints.SelectedItems.Count > 0;
            toolStripMainDelete.Enabled = lstHints.SelectedItems.Count > 0;
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (!ShowQuestion(LanguageStrings.AppMissingLinkDelete, LanguageStrings.AppMissingLinkDeletePrompt))
                return;

            foreach (ListViewItem itm in lstHints.SelectedItems)
            {
                MissingLink link = AppController.Administration.MissingLinkGet(itm.SubItems[0].Text);

                if (link != null)
                {
                    link.Delete();

                    LoadMissingLinks();
                }
            }
        }

        #endregion Private Methods
    }
}
