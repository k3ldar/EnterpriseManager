using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Salons;
using Library.BOL.Users;
using Library;
using POS.Base.Classes;

namespace POS.WebsiteAdministration.Forms.Salons
{
    public partial class AdminSalons : POS.Base.Forms.BaseForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public AdminSalons()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainSearch.Image = POS.Base.Icons.SearchIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            SearchSalons();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.WebSalons;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSalonAdministrationSalons;

            colHeaderContactName.Text = LanguageStrings.AppContactName;
            colHeaderEmail.Text = LanguageStrings.AppEmail;
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderVIP.Text = LanguageStrings.AppSalonVIP;
            colHeaderWebsite.Text = LanguageStrings.AppWebsite;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
            toolStriMainSalonName.ToolTipText = LanguageStrings.AppHintSalonSearch;
            toolStripMainSearch.Text = LanguageStrings.AppHintSearch;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AllowCreateNew);
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void SearchSalons()
        {
            int Count = 0;
            this.Cursor = Cursors.WaitCursor;
            lstSalons.BeginUpdate();
            try
            {
                Library.BOL.Salons.Salons salons = AppController.Administration.SalonsGet(toolStriMainSalonName.Text);

                lstSalons.Items.Clear();

                foreach (Salon salon in salons)
                {
                    if (salon.SalonType != Enums.SalonType.Distributor)
                    {
                        ListViewItem lvi = lstSalons.Items.Add(salon.Name);
                        lvi.SubItems.Add(salon.ContactName);
                        lvi.SubItems.Add(salon.Email);
                        lvi.SubItems.Add(salon.URL);

                        if (salon.VIPSalon)
                            lvi.SubItems.Add(LanguageStrings.AppYes);
                        else
                            lvi.SubItems.Add(String.Empty);

                        lvi.SubItems.Add(salon.ID.ToString());
                        Count++;
                    }
                }
            }
            finally
            {
                lstSalons.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }

            toolStripStatusLabelCount.Text = String.Format(LanguageStrings.AppSalonFoundQuanity, Count);
        }

        private void lstSalons_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstSalons.SelectedItems)
            {
                Library.BOL.Salons.Salon salon = AppController.Administration.SalonGet(Convert.ToInt32(itm.SubItems[5].Text));

                if (salon != null)
                {
                    AdminSalonsEdit salonedit = new AdminSalonsEdit(salon);
                    try
                    {
                        salonedit.ShowDialog(this);
                    }
                    finally
                    {
                        salonedit.Dispose();
                        salonedit = null;
                    }
                }
            }
        }

        #endregion Private Methods

        private void toolStripMainSearch_Click(object sender, EventArgs e)
        {
            SearchSalons();
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            Salon salon = Library.BOL.Salons.Salons.Create(
                String.Format(LanguageStrings.AppSalonNewName, lstSalons.Items.Count + 1), Enums.SalonType.Salon);
            AdminSalonsEdit salonedit = new AdminSalonsEdit(salon);
            try
            {
                salonedit.ShowDialog(this);
            }
            finally
            {
                salonedit.Dispose();
                salonedit = null;
            }
        }

        private void lstSalons_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstSalons.SelectedItems.Count > -1;
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstSalons_DoubleClick(sender, e);
        }
    }
}
