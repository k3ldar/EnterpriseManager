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
 *  File: Step6.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using SharedBase;
using SharedBase.BOL.Countries;
using SharedBase.BOL.Export;
using SharedBase.BOL.Users;
using POS.Base.Classes;
using POS.Customers.Classes;
using SharedControls.WizardBase;

namespace POS.Customers.Controls.Wizards.Export
{
    public partial class Step6 : BaseWizardPage
    {
        #region Private Members

        private ExportSettings _settings;

        private ExportableItems _exportItems;

        private bool _fileSaved;

        #endregion Private Members

        #region Constructors

        public Step6(ExportSettings settings)
        {
            InitializeComponent();
            _settings = settings;
            _exportItems = new ExportableItems();
            btnSave.Visible = false;
            pbProgress.Visible = false;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnSelect.Text = LanguageStrings.AppMenuButtonSelect;
            lblSelectFileDesc.Text = LanguageStrings.AppCustomerExportSelectFile;

            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            cbCloseAfterSave.Text = LanguageStrings.AppCloseAfterSave;

            rbCSVFile.Text = LanguageStrings.AppFileTypeCSV;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerExportStep6;
        }

        public override bool CanCancel()
        {
            return (true);
        }

        public override bool CanGoNext()
        {
            return (false);
        }

        public override bool CanGoPrevious()
        {
            return (true);
        }

        public override bool CanGoFinish()
        {
            return (_fileSaved);
        }

        public override bool NextClicked()
        {

            return base.NextClicked();
        }

        public override bool PreviousClicked()
        {
            return base.PreviousClicked();
        }

        public override bool BeforeFinish()
        {
            return base.BeforeFinish();
        }

        public override bool CancelClicked()
        {
            return base.CancelClicked();
        }

        public override void PageShown()
        {
            _fileSaved = false;
            _exportItems.Clear();

            foreach (ExportItem item in _settings.ExportItems)
            {
                if (item.Selected)
                    _exportItems.Insert(item.Position, item);
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtFileName.Text = saveFileDialog1.FileName;
                btnSave.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pbProgress.Maximum = _settings.UserRecords.Count + 1;
            pbProgress.Value = 0;

            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                if (rbCSVFile.Checked)
                    SaveCSVFile();

                _fileSaved = true;
            }
            finally
            {
                MainWizardForm.Cursor = Cursors.Arrow;
                MainWizardForm.UpdateUI();

                if (cbCloseAfterSave.Checked)
                    MainWizardForm.ForceFinish();
            }
        }

        private void SaveCSVFile()
        {
            pbProgress.Visible = true;
            try
            {
                string csvFile = BuildCSVHeader();

                foreach (User user in _settings.UserRecords)
                {
                    csvFile += AddUserToCSV(user);
                    pbProgress.Value = pbProgress.Value + 1;
                    Application.DoEvents();
                }

                Shared.Utilities.FileWrite(txtFileName.Text, csvFile);
            }
            finally
            {
                pbProgress.Visible = false;
            }
        }

        private string BuildCSVHeader()
        {
            string Result = String.Empty;

            foreach (ExportItem item in _exportItems)
            {
                Result += String.Format(StringConstants.EXPORT_CSV_HEADER_ITEM, item.Column);
            }

            Result += StringConstants.SYMBOL_CRLF;

            return (Result);
        }

        private string AddUserToCSV(User user)
        {
            string Result = String.Empty;

            foreach (ExportItem item in _exportItems)
            {
                if (!String.IsNullOrEmpty(Result))
                    Result += StringConstants.SYMBOL_COMMA;

                switch (item.Column)
                {
                    case StringConstants.EXPORT_USER_COLUMN_ADDRESSLINE1:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.AddressLine1);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_ADDRESSLINE2:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.AddressLine2);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_ADDRESSLINE3:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.AddressLine3);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_BIRTH_DATE:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.BirthDate.ToLongDateString());
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_BUSINESSNAME:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.BusinessName);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_CITY:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.City);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_COUNTRY:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.Country.Name);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_COUNTY:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.County);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_EMAIL:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.Email);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_FIRSTNAME:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.FirstName);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_LASTNAME:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.LastName);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_NOTES:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.Notes);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_OFFER_EMAIL:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.OffersEmail.ToString());
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_OFFER_PHONE:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.OffersTelephone.ToString());
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_OFFER_POSTAL:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.OffersPost.ToString());
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_POSTCODE:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.PostCode);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_TELEPHONE:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.Telephone);
                        break;
                    case StringConstants.EXPORT_USER_COLUMN_USERNAME:
                        Result += String.Format(StringConstants.EXPORT_CSV_ITEM_COLUMN, user.UserName);
                        break;
                }
            }

            Result += StringConstants.SYMBOL_CRLF;

            return (Result);
        }

        #endregion Private Methods
    }
}
