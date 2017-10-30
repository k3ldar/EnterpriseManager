﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Countries;
using Library.BOL.Export;
using Library.BOL.Users;
using POS.Base.Classes;
using POS.Customers.Classes;
using SharedControls.WizardBase;

namespace POS.Customers.Controls.Wizards.Export
{
    public partial class Step5 : BaseWizardPage
    {
        #region Private Members

        private ExportSettings _settings;

        private bool _cancel = false;

        private bool _processsing = false;

        private int _recordsProcessed;

        #endregion Private Members

        #region Constructors

        public Step5(ExportSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblFilterDesc.Text = LanguageStrings.AppCustomerExportFilterStart;
            lblProgress.Text = LanguageStrings.AppProgress;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.CustomerExportStep5;
        }

        public override bool CanCancel()
        {
            return (true);
        }

        public override bool CanGoNext()
        {
            return (!_processsing);
        }

        public override bool CanGoPrevious()
        {
            return (!_processsing);
        }

        public override bool CanGoFinish()
        {
            return base.CanGoFinish();
        }

        public override bool NextClicked()
        {
            FilterRecords();

            if (_cancel)
            {
                lblSelected.Visible = false;
                pbProgress.Visible = false;
                lblProcessed.Visible = false;
                lblProgress.Visible = false;
            }

            return (!_cancel);
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
            if (!_cancel)
            {
                _cancel = true;
                return (false);
            }

            return base.CancelClicked();
        }

        public override void PageShown()
        {
            lblSelected.Visible = false;
            pbProgress.Visible = false;
            lblProcessed.Visible = false;
            lblProgress.Visible = false;
            _cancel = false;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void FilterRecords()
        {
            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                _processsing = true;
                _cancel = false;
                _recordsProcessed = 0;
                _settings.UserRecords.Clear();
                lblSelected.Visible = true;
                pbProgress.Visible = true;
                lblProcessed.Visible = true;
                lblProgress.Visible = true;
                MainWizardForm.UpdateUI();

                Library.BOLEvents.Progress progress = new Library.BOLEvents.Progress();
                progress.OnProgress += progress_OnProgress;

                Library.BOL.Users.Users.Get(progress);
            }
            finally
            {
                _processsing = false;
                MainWizardForm.UpdateUI();
                MainWizardForm.Cursor = Cursors.Arrow;
            }
        }

        void progress_OnProgress(object sender, Library.BOLEvents.ProgressEventArgs e)
        {
            pbProgress.Value = e.Percent;

            if (_cancel)
            {
                e.Cancel = true;
                return;
            }

            if (e.User != null)
            {
                _recordsProcessed++;

                lblProcessed.Text = String.Format(LanguageStrings.AppCustomerExportProcessed, _recordsProcessed);
                Application.DoEvents();

                // correct member level
                switch (_settings.MemberLevelType)
                {
                    case MemberLevelType.Above:
                        if (e.User.MemberLevel <= _settings.MemberLevel)
                            return;

                        break;
                    case MemberLevelType.Below:
                        if (e.User.MemberLevel >= _settings.MemberLevel)
                            return;

                        break;
                    case MemberLevelType.Equal:
                        if (e.User.MemberLevel != _settings.MemberLevel)
                            return;

                        break;
                    case MemberLevelType.EqualBelow:
                        if (e.User.MemberLevel > _settings.MemberLevel)
                            return;

                        break;
                }

                // member level matches, test other criteria
                if (ValidateCriteria(e.User))
                {
                    _settings.UserRecords.Add(e.User);
                    lblSelected.Text = String.Format(LanguageStrings.AppCustomerExportSelected, _settings.UserRecords.Count);
                    Application.DoEvents();
                }
            }
        }

        private bool ValidateCriteria(User user)
        {
            if (_settings.OfferEmail && !user.OffersEmail)
                return (false);

            if (_settings.OfferPostal && !user.OffersPost)
                return (false);

            if (_settings.OfferTelephone && !user.OffersTelephone)
                return (false);

            if (_settings.ValidEmail && !Shared.Utilities.IsValidEmail(user.Email))
                return (false);

            if (_settings.ExcludeInvalidAddress && !user.ValidAddress())
                return (false);

            if (!_settings.AllCountries && !_settings.CountrySelected(user.Country))
                return (false);

            if (!_settings.IgnoreBusiness)
            {
                if (_settings.HasBusinessName)
                {
                    if (String.IsNullOrEmpty(user.BusinessName))
                        return (false);
                }
                else
                {
                    if (!String.IsNullOrEmpty(user.BusinessName))
                        return (false);
                }
            }

            return (true);
        }
        #endregion Private Methods
    }
}
