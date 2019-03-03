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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminDistributors.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.BOL.Salons;

using POS.Base.Classes;

using POS.WebsiteAdministration.Forms.Salons;

using SharedControls.Classes;

namespace POS.WebsiteAdministration.Forms.Distributors
{
    public partial class AdminDistributors : Base.Controls.BaseTabControl
    {
        #region Constructors

        public AdminDistributors()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            toolStripMainDistributorType.Items.Add(LanguageStrings.AppAll);
            toolStripMainDistributorType.SelectedIndex = 0;

            foreach (string distributorType in Enum.GetNames(typeof(Enums.SalonType)))
            {
                toolStripMainDistributorType.Items.Add(distributorType);
            }

            toolStripMainDistributorType.SelectedIndexChanged += toolStripMainDistributorType_SelectedIndexChanged;

            LoadDistributors();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            colHeaderName.Text = LanguageStrings.AppName;
            colHeaderWebPage.Text = LanguageStrings.AppWebsite;

            toolStripMainAdd.Text = LanguageStrings.AppHintNew;
            toolStripMainDelete.Text = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
        }

        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = false;
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

        #region Private Methods

        private void LoadDistributors()
        {
            int Count = 0;

            lstDistributors.BeginUpdate();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lstDistributors.Items.Clear();

                SharedBase.BOL.Salons.Salons dists = AppController.Administration.SalonsGet(1, 10000);

                foreach (Salon dist in dists)
                {
                    if (toolStripMainDistributorType.SelectedIndex == 0 ||
                        dist.SalonType.ToString() == toolStripMainDistributorType.Items[toolStripMainDistributorType.SelectedIndex].ToString())
                    {
                        ListViewItem item = lstDistributors.Items.Add(dist.Name);
                        item.SubItems.Add(dist.ContactName);
                        item.SubItems.Add(dist.Email);

                        if (dist.VIPSalon)
                            item.SubItems.Add(LanguageStrings.AppYes);
                        else
                            item.SubItems.Add(String.Empty);

                        item.SubItems.Add(dist.URL);
                        item.Tag = dist;
                        Count++;
                    }
                }


                string StatusText = LanguageStrings.AppDistributorsFound;

                if (dists.Count == 1)
                    StatusText = LanguageStrings.AppDistributorFound;

                toolStripStatusLabelCount.Text = String.Format(StatusText, Count);
            }
            finally
            {
                lstDistributors.EndUpdate();
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstDistributors_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstDistributors.SelectedItems)
            {
                Salon dist = (Salon)itm.Tag;

                if (dist != null)
                {
                    AdminDistributorEdit de = new AdminDistributorEdit(dist);
                    try
                    {
                        de.ShowDialog(this);
                        LoadDistributors();
                    }
                    finally
                    {
                        de.Dispose();
                        de = null;
                    }
                }
            }
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            Salon dist = null;

            if (toolStripMainDistributorType.SelectedIndex > 0)
            {
                Enums.SalonType type = (Enums.SalonType)Enum.Parse(typeof(Enums.SalonType),
                    (string)toolStripMainDistributorType.SelectedItem);
                dist = AppController.Administration.SalonCreate(
                    String.Format(LanguageStrings.NewItem, type), type);
            }
            else
            {
                dist = AppController.Administration.DistributorsCreate(LanguageStrings.NewDistributor);
            }
                
            AdminDistributorEdit de = new AdminDistributorEdit(dist);
            try
            {
                de.ShowDialog(this);
                LoadDistributors();
            }
            finally
            {
                de.Dispose();
                de = null;
            }
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm(LanguageStrings.AppSalonDelete, LanguageStrings.AppSalonDeletePrompt))
            {
                foreach (ListViewItem itm in lstDistributors.SelectedItems)
                {
                    Salon dist = (Salon)itm.Tag;

                    if (dist != null)
                    {
                        dist.Delete();

                        lstDistributors.Items.Remove(itm);
                    }
                }
            }
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstDistributors_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadDistributors();
        }

        private void lstDistributors_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstDistributors.SelectedItems.Count > 0;
        }

        private void toolStripMainDistributorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDistributors();
        }

        #endregion Overridden Methods
    }
}
