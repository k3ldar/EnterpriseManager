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
 *  File: AdminTreatments.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

using SharedBase;
using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Treatments;

using POS.Base.Classes;
using SharedControls.Classes;

namespace POS.Administration.Forms.Treatments
{
    public partial class AdminTreatments : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private WebsiteAdministration _Admin;

        #endregion Private Members

        #region Constructors

        public AdminTreatments(WebsiteAdministration admin)
        {
            _Admin = admin;

            InitializeComponent();

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
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.Treatments;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppTreatmentsSalonAdmin;

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
                SharedBase.BOL.Treatments.Treatments treatments = SharedBase.BOL.Treatments.Treatments.Get(1, 1000);

                foreach (Treatment treat in treatments)
                {
                    ListViewItem item = lstTreatments.Items.Add(treat.Name);
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
                Treatment treat = _Admin.TreatmentGet(Convert.ToInt32(itm.SubItems[1].Text));

                if (treat != null)
                {
                    AdminTreatmentEdit ate = new AdminTreatmentEdit(_Admin, treat);
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

        #endregion Private Methods

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show(LanguageStrings.AppTreatmentSalonNewPrompt,
                LanguageStrings.AppTreatmentSalonNewName, LanguageStrings.AppTreatmentSalonNew);

            if (result.ReturnCode == System.Windows.Forms.DialogResult.OK && result.Text != String.Empty)
            {
                Treatment newTreat = new Treatment(-1, result.Text, StringConstants.COST_ZERO,
                    String.Format(LanguageStrings.AppMinutes, 15), String.Empty, String.Empty,
                    String.Empty, 100, 15, false);
                newTreat = _Admin.TreatmentCreate(newTreat);

                AdminTreatmentEdit ate = new AdminTreatmentEdit(_Admin, newTreat);
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

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            LoadTreatments();
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstTreatments.SelectedItems.Count > 0;
        }
    }
}
