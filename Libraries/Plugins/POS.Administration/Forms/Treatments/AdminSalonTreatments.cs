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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: AdminSalonTreatments.cs
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

using Library;
using Library.BOL.Appointments;

using POS.Base.Classes;
using SharedControls.Classes;

namespace POS.Administration.Forms.Treatments
{
    public partial class AdminSalonTreatments : POS.Base.Controls.BaseTabControl
    {
        #region Private Members

        private AppointmentTreatments _treatments;
        private WebsiteAdministration _Admin;

        #endregion Private Members

        #region Constructors

        public AdminSalonTreatments(WebsiteAdministration admin)
        {
            _Admin = admin;
            TreatmentsLoaded = false;
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainSearch.Image = POS.Base.Icons.SearchIcon();

            toolStripMainEdit.Enabled = false;
            RebuildContextMenu(toolStripMain, contextMenuList);

            LoadTreatments();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Indicates wether treatments have been loaded or not
        /// </summary>
        private bool TreatmentsLoaded { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripMainFilterLabel.Text = LanguageStrings.AppFilter;

            colHeaderActive.Text = LanguageStrings.AppActive;
            colHeaderCost.Text = LanguageStrings.Price;
            colHeaderPrice.Text = LanguageStrings.AppCost;
            colHeaderLength.Text = LanguageStrings.AppSalonTreatmentLength;
            colHeaderName.Text = LanguageStrings.AppName;

            toolStripMainAdd.ToolTipText = LanguageStrings.AppHintNew;
            toolStripMainDelete.ToolTipText = LanguageStrings.AppHintDelete;
            toolStripMainRefresh.ToolTipText = LanguageStrings.AppHintRefresh;
            toolStripMainEdit.ToolTipText = LanguageStrings.AppHintEdit;
            toolStripMainFilterText.ToolTipText = LanguageStrings.AppHintTreatmentSearch;
            toolStripMainSearch.ToolTipText = LanguageStrings.AppHintSearch;

            LoadTreatments();
        }


        protected override void SetPermissions()
        {
            toolStripMainAdd.Enabled = AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerSalonTreatments);
            toolStripMainDelete.Enabled = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadTreatments()
        {
            if (TreatmentsLoaded)
                return;

            this.Cursor = Cursors.WaitCursor;
            lstTreatments.BeginUpdate();
            try
            {
                toolStripMainEdit.Enabled = false;
                lstTreatments.Items.Clear();
                int i = 0;
                _treatments = AppointmentTreatments.Get();

                foreach (AppointmentTreatment treat in _treatments)
                {
                    if (treat.Name.ToLower().Contains(toolStripMainFilterText.Text.ToLower()))
                    {
                        ListViewItem item = lstTreatments.Items.Add(treat.Name);

                        decimal vat = Library.Utils.SharedUtils.VATCalculate(treat.Cost, POS.Base.Classes.AppController.LocalCountry.VATRate);
                        item.SubItems.Add(Library.Utils.SharedUtils.FormatMoney(treat.Cost + vat, AppController.LocalCurrency));
                        item.SubItems.Add(Library.Utils.SharedUtils.FormatMoney(treat.Cost, AppController.LocalCurrency));
                        item.SubItems.Add(Shared.Utilities.TimeToString(treat.Duration));
                        item.SubItems.Add(treat.IsActive ? LanguageStrings.AppYes : LanguageStrings.AppNo);
                        item.SubItems.Add(treat.ID.ToString());
                        item.Tag = treat;
                        ++i;
                    }
                }


                string StatusText = LanguageStrings.AppSalonTreatmentsFoundMulti;

                if (_treatments.Count == 1)
                    StatusText = LanguageStrings.AppSalonTreatmentsFoundSingle;

                if (i != _treatments.Count)
                    StatusText += String.Format(LanguageStrings.AppSalonTreatmentsDisplayed, i);

                toolStripStatusLabelCount.Text = String.Format(StatusText, _treatments.Count);
            }
            finally
            {
                lstTreatments.EndUpdate();
                TreatmentsLoaded = true;
                this.Cursor = Cursors.Arrow;
            }
        }

        private void lstTreatments_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in lstTreatments.SelectedItems)
            {
                AppointmentTreatment treat = (AppointmentTreatment)itm.Tag;

                if (treat != null)
                {
                    AdminSalonTreatmentEdit ate = new AdminSalonTreatmentEdit(_Admin, treat);
                    try
                    {
                        ate.ShowDialog(this);

                        //Refresh the view for the treatment
                        itm.Text = treat.Name;
                        itm.SubItems[0].Text = treat.Name;
                        decimal vat = Library.Utils.SharedUtils.VATCalculate(treat.Cost, AppController.LocalCountry.VATRate);
                        itm.SubItems[1].Text = Library.Utils.SharedUtils.FormatMoney(treat.Cost + vat, AppController.LocalCurrency);
                        itm.SubItems[2].Text = Library.Utils.SharedUtils.FormatMoney(treat.Cost, AppController.LocalCurrency);
                        itm.SubItems[3].Text = Shared.Utilities.TimeToString(treat.Duration);
                        itm.SubItems[4].Text = treat.IsActive ? LanguageStrings.AppYes : LanguageStrings.AppNo;
                        itm.SubItems[5].Text = treat.ID.ToString();
                    }
                    finally
                    {
                        ate.Dispose();
                        ate = null;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadTreatments();
        }

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            InputBoxResult result = InputBox.Show(LanguageStrings.AppSalonTreatmentNewPrompt,
                LanguageStrings.AppSalonTreatmentNew, LanguageStrings.AppSalonTreatmentNewName);

            if (result.ReturnCode == DialogResult.OK && result.Text != String.Empty)
            {

                AppointmentTreatment newTreat = new AppointmentTreatment(-1, false,
                    result.Text, 15, false, 0.00m, 0, String.Empty);
                try
                {
                    AppointmentTreatments.Create(newTreat);
                }
                catch (Exception error)
                {
                    if (error.Message.Contains(StringConstants.ERROR_VIOLATION_UNIQUE_KEY))
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppSalonTreatmentNameExists);
                        return;
                    }
                    else
                        throw;
                }

                AdminSalonTreatmentEdit ate = new AdminSalonTreatmentEdit(_Admin, newTreat);
                try
                {
                    ate.ShowDialog(this);
                }
                finally
                {
                    ate.Dispose();
                    ate = null;
                }

                TreatmentsLoaded = false;
                LoadTreatments();
            }
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            lstTreatments_DoubleClick(sender, e);
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            TreatmentsLoaded = false;
            LoadTreatments();
        }

        private void lstTreatments_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripMainEdit.Enabled = lstTreatments.SelectedItems.Count > 0;
        }

        private void toolStripMainSearch_Click(object sender, EventArgs e)
        {
            TreatmentsLoaded = false;
            LoadTreatments();
        }

        #endregion Private Methods
    }
}
