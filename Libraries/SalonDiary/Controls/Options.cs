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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Options.cs
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

using Library;
using Library.Utils;
using Library.BOL.Appointments;
using Languages;

namespace SalonDiary.Controls
{
    public partial class Options : SharedControls.BaseControl
    {
        #region Private Members

        private SalonDiary _salonDiary;

        #endregion Private Members

        #region Constructors

        public Options()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                LoadAppointmentStatuses();
        }

        #endregion Constructors

        #region Properties

        public SalonDiary SalonDiary
        {
            set
            {
                _salonDiary = value;

#if CACHE_APPOINTMENTS
                cbCacheAppointments.Checked = _salonDiary.CacheAppointments;
#else
                cbCacheAppointments.Checked = false;
                cbCacheAppointments.Enabled = false;
#endif

                trackBarAutoLock.Value = _salonDiary.AppointmentLockTime / 15;
                trackBarBirthday.Value = _salonDiary.BirthdayNotification;
                trackBarTooltip.Value = _salonDiary.ToolTipDelay / 100;
                trackBarScrollMovement.Value = _salonDiary.ScrollAmount;
                cbAutoComplete.Checked = _salonDiary.AutoCompleteOnPayment;
                cbOverlays.Checked = _salonDiary.ShowImageOverlays;

                cbNoShowAppointments.Checked = _salonDiary.ImageOverlaysHasCancelled;
                cbAppointmentLinked.Checked = _salonDiary.ImageOverlaysLinked;
                cbOverlayLockedAppt.Checked = _salonDiary.ImageOverlaysLocked;
                cbUserNotes.Checked = _salonDiary.ImageOverlaysNotes;
                cbWorkingOverride.Checked = _salonDiary.ImageOverlaysOverridden;
                cbNoAppointments.Checked = _salonDiary.ImageOverlaysNoTreatments;



                pbOverlayLocked.Image = _salonDiary.imageAppointmentOverlays.Images[7];
                pbLinked.Image = _salonDiary.imageAppointmentOverlays.Images[9];
                pbNoAppointments.Image = _salonDiary.imageHeaderOverlays.Images[1];
                pbNoShow.Image = _salonDiary.imageAppointmentOverlays.Images[1];
                pbNotes.Image = _salonDiary.imageAppointmentOverlays.Images[0];
                pbOverride.Image = _salonDiary.imageHeaderOverlays.Images[0];

                txtIgnoreUsers.Text = _salonDiary.AutoHideUsers.Replace(StringConstants.SYMBOL_DOLLAR, StringConstants.CARRIAGE_RETURN_AND_LINE_FEED);
                dtpOldestDate.Value = _salonDiary.MinimumDate;

                rbApptTextName.Checked = _salonDiary.ShowNameFirst;
                rbApptTextTreatment.Checked = !_salonDiary.ShowNameFirst;

                LoadLunchDurations();

                UpdateUI();
            }
        }

        public int ActiveTabID
        {
            get
            {
                return (tabControlOptions.SelectedIndex);
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
            tabPageGeneral.Text = LanguageStrings.AppGeneral;
            cbAutoCompleteNonTreatments.Text = LanguageStrings.AppDiaryAutoCompleteNon;
            label2.Text = LanguageStrings.AppDiaryOldestDate;
            cbAutoComplete.Text = LanguageStrings.AppDiaryAutoComplete;
            tabPageColors.Text = LanguageStrings.AppColors;
            btnTextColor.Text = LanguageStrings.AppColorText;
            btnBackColor.Text = LanguageStrings.AppColorBack;
            lblChangesImmediate.Text = LanguageStrings.AppDiaryChangesImmediate;
            btnResetAll.Text = LanguageStrings.AppMenuButtonResetAll;
            gbPreview.Text = LanguageStrings.AppPreview;
            lblPreview.Text = LanguageStrings.AppPreview;
            lblApptStatusDesc.Text = LanguageStrings.AppDiaryApptStatus;
            tabPageImageOverLays.Text = LanguageStrings.AppImageOverlays;
            cbNoShowAppointments.Text = LanguageStrings.AppDiaryCancelOrNoShow;
            cbNoAppointments.Text = LanguageStrings.AppDiaryApptNone;
            cbWorkingOverride.Text = LanguageStrings.AppDiaryWorkingOverride;
            cbUserNotes.Text = LanguageStrings.AppUserNotes;
            cbAppointmentLinked.Text = LanguageStrings.AppDiaryApptLinked;
            cbOverlayLockedAppt.Text = LanguageStrings.AppDiaryApptLocked;
            cbOverlays.Text = LanguageStrings.AppImageOverlayShow;
            tabPageUsers.Text = LanguageStrings.AppAutoHide;
            lblAutoHideDesc.Text = LanguageStrings.AppDiaryAutoHideStaff;
            tabPageTimes.Text = LanguageStrings.AppTimes;
            label5.Text = LanguageStrings.AppDiaryMaxLunchBreak;
            tabPageAdvanced.Text = LanguageStrings.AppAdvanced;
            gbAppointmentText.Text = LanguageStrings.AppDiaryApptText;
            rbApptTextTreatment.Text = LanguageStrings.AppDiaryAppTreatmentFirst;
            rbApptTextName.Text = LanguageStrings.AppDiaryAppNameFirst;
            cbCacheAppointments.Text = LanguageStrings.AppDiaryApptCache;

            UpdateUI();
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadAppointmentStatuses()
        {
            cmbAppointmentStatus.Items.Clear();

            AppointmentStatuses apptStatuses = AppointmentStatuses.Get();

            foreach (AppointmentStatus status in apptStatuses)
            {
                cmbAppointmentStatus.Items.Add(status);
            }

            AppointmentStatus selAppt = new AppointmentStatus(Consts.APPT_STATUS_ID_SELECTED, Consts.APPT_STATUS_SELECTED, 10000);
            cmbAppointmentStatus.Items.Add(selAppt);
        }

        private void LoadLunchDurations()
        {
            int i = 15;

            while (i < 195)
            {
                int idx = cmbLunchDurations.Items.Add(i);

                if (_salonDiary.MaxLunchDuration == i)
                        cmbLunchDurations.SelectedIndex = idx;

                i += 15;
            }
        }

        private void UpdateUI()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            lblLockAppointments.Text = String.Format(LanguageStrings.AppDiaryLockAppointments, trackBarAutoLock.Value * 15);
            lblBirthday.Text = String.Format(LanguageStrings.AppDiaryBirthdayAlert, trackBarBirthday.Value);
            lblScroll.Text = String.Format(LanguageStrings.AppDiaryScrolling, trackBarScrollMovement.Value * 15);
            lblTooltip.Text = String.Format(LanguageStrings.AppDiaryTooltipDelay, trackBarTooltip.Value * 100);


            try
            {
                cmbAppointmentStatus.SelectedIndex = 0;
            }
            catch
            {
                cmbAppointmentStatus.SelectedIndex = -1;
            }

            pbOverlayLocked.Enabled = cbOverlays.Checked;
            cbOverlayLockedAppt.Enabled = cbOverlays.Checked;
            cbAppointmentLinked.Enabled = cbOverlays.Checked;
            cbAppointmentLinked.Enabled = cbOverlays.Checked;
            cbUserNotes.Enabled = cbOverlays.Checked;
            cbWorkingOverride.Enabled = cbOverlays.Checked;
            cbNoAppointments.Enabled = cbOverlays.Checked;
            cbNoShowAppointments.Enabled = cbOverlays.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void trackBarBirthday_Scroll(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
#if CACHE_APPOINTMENTS
            _salonDiary.CacheAppointments = cbCacheAppointments.Checked;
#else
            _salonDiary.CacheAppointments = false;
#endif

            _salonDiary.AppointmentLockTime = trackBarAutoLock.Value * 15;
            _salonDiary.BirthdayNotification = trackBarBirthday.Value;
            _salonDiary.AutoCompleteOnPayment = cbAutoComplete.Checked;
            _salonDiary.ToolTipDelay = trackBarTooltip.Value * 100;

            _salonDiary.ShowImageOverlays = cbOverlays.Checked;
            _salonDiary.ImageOverlaysHasCancelled = cbNoShowAppointments.Checked;
            _salonDiary.ImageOverlaysLinked = cbAppointmentLinked.Checked;
            _salonDiary.ImageOverlaysLocked = cbOverlayLockedAppt.Checked;
            _salonDiary.ImageOverlaysNotes = cbUserNotes.Checked;
            _salonDiary.ImageOverlaysOverridden = cbWorkingOverride.Checked;
            _salonDiary.ImageOverlaysNoTreatments = cbNoAppointments.Checked;
            _salonDiary.ShowNameFirst = rbApptTextName.Checked;

            _salonDiary.ScrollAmount = trackBarScrollMovement.Value;

            _salonDiary.MinimumDate = dtpOldestDate.Value;
            _salonDiary.AutoHideUsers = txtIgnoreUsers.Text.Replace(StringConstants.CARRIAGE_RETURN_AND_LINE_FEED, StringConstants.SYMBOL_DOLLAR);

            if (!_salonDiary.AutoHideUsers.EndsWith(StringConstants.SYMBOL_DOLLAR))
                _salonDiary.AutoHideUsers += StringConstants.SYMBOL_DOLLAR;

            _salonDiary.MaxLunchDuration = Convert.ToInt32(cmbLunchDurations.Items[cmbLunchDurations.SelectedIndex]);
            _salonDiary.ForceRefresh(false);
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            _salonDiary.AppointmentSelected = Color.Aqua;
            _salonDiary.AppointmentSelectedText = Color.Black;
            _salonDiary.AppointmentRequested = ColorTranslator.FromHtml("#0099CC");
            _salonDiary.AppointmentRequestedText = Color.Black;
            _salonDiary.AppointmentConfirmed = ColorTranslator.FromHtml("#66FF66");
            _salonDiary.AppointmentConfirmedText = Color.Black;
            _salonDiary.AppointmentCancelledByUser = ColorTranslator.FromHtml("#CC0066");
            _salonDiary.AppointmentCancelledByUserText = System.Drawing.Color.White;
            _salonDiary.AppointmentCancelledByStaff = ColorTranslator.FromHtml("#CC0066");
            _salonDiary.AppointmentCancelledbyStaffText = System.Drawing.Color.Black;
            _salonDiary.AppointmentNoShow = ColorTranslator.FromHtml("#FF00FF");
            _salonDiary.AppointmentNoShowText = Color.Black;
            _salonDiary.AppointmentCompleted = ColorTranslator.FromHtml("#FF9966");
            _salonDiary.AppointmentCompletedText = Color.Black;
            _salonDiary.AppointmentArrived = ColorTranslator.FromHtml("#FF9900");
            _salonDiary.AppointmentArrivedText = Color.Black;
        }

        private void cmbAppointmentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppointmentStatus status = (AppointmentStatus)cmbAppointmentStatus.SelectedItem;

            switch (status.Description)
            {
                case Consts.APPT_STATUS_SELECTED:
                    lblPreview.BackColor = _salonDiary.AppointmentSelected;
                    lblPreview.ForeColor = _salonDiary.AppointmentSelectedText;
                    break;
                case Consts.APPT_STATUS_REQUESTED:
                    lblPreview.BackColor = _salonDiary.AppointmentRequested;
                    lblPreview.ForeColor = _salonDiary.AppointmentRequestedText;
                    break;
                case Consts.APPT_STATUS_CONFIRMED:
                    lblPreview.BackColor = _salonDiary.AppointmentConfirmed;
                    lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                    break;
                case Consts.APPT_STATUS_ARRIVED:
                    lblPreview.BackColor = _salonDiary.AppointmentArrived;
                    lblPreview.ForeColor = _salonDiary.AppointmentArrivedText;
                    break;
                case Consts.APPT_STATUS_CANCELLED_BY_USER:
                    lblPreview.BackColor = _salonDiary.AppointmentCancelledByUser;
                    lblPreview.ForeColor = _salonDiary.AppointmentCancelledByUserText;
                    break;
                case Consts.APPT_STATUS_CANCELLED_BY_STAFF:
                    lblPreview.BackColor = _salonDiary.AppointmentCancelledByStaff;
                    lblPreview.ForeColor = _salonDiary.AppointmentCancelledbyStaffText;
                    break;
                case Consts.APPT_STATUS_NO_SHOW:
                    lblPreview.BackColor = _salonDiary.AppointmentNoShow;
                    lblPreview.ForeColor = _salonDiary.AppointmentNoShowText;
                    break;
                case Consts.APPT_STATUS_COMPLETED:
                    lblPreview.BackColor = _salonDiary.AppointmentCompleted;
                    lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                    break;
            }

            lblPreview.Text = cmbAppointmentStatus.Text;
        }

        private void cmbAppointmentStatus_Format(object sender, ListControlConvertEventArgs e)
        {
            AppointmentStatus status = (AppointmentStatus)e.ListItem;

            switch (status.Description)
            {
                case Consts.APPT_STATUS_SELECTED:
                    e.Value = LanguageStrings.AppDiaryApptStatusSelected;
                    break;
                case Consts.APPT_STATUS_REQUESTED:
                    e.Value = LanguageStrings.AppDiaryApptStatusRequested;
                    break;
                case Consts.APPT_STATUS_CONFIRMED:
                    e.Value = LanguageStrings.AppDiaryApptStatusConfirmed;
                    break;
                case Consts.APPT_STATUS_ARRIVED:
                    e.Value = LanguageStrings.AppDiaryApptStatusArrived;
                    break;
                case Consts.APPT_STATUS_CANCELLED_BY_USER:
                    e.Value = LanguageStrings.AppDiaryApptStatusCancelledByUser;
                    break;
                case Consts.APPT_STATUS_CANCELLED_BY_STAFF:
                    e.Value = LanguageStrings.AppDiaryApptStatusCancelledByStaff;
                    break;
                case Consts.APPT_STATUS_NO_SHOW:
                    e.Value = LanguageStrings.AppDiaryApptStatusNoShow;
                    break;
                case Consts.APPT_STATUS_COMPLETED:
                    e.Value = LanguageStrings.AppDiaryApptStatusCompleted;
                    break;
                case Consts.APPT_STATUS_DELETED:
                    e.Value = LanguageStrings.AppDiaryApptStatusDeleted;
                    break;
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = lblPreview.BackColor;

            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {

                switch (cmbAppointmentStatus.Text)
                {
                    case Consts.APPT_STATUS_SELECTED:
                        _salonDiary.AppointmentSelected = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentSelected;
                        lblPreview.ForeColor = _salonDiary.AppointmentSelectedText;
                        break;
                    case Consts.APPT_STATUS_REQUESTED:
                        _salonDiary.AppointmentRequested = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentRequested;
                        lblPreview.ForeColor = _salonDiary.AppointmentRequestedText;
                        break;
                    case Consts.APPT_STATUS_CONFIRMED:
                        _salonDiary.AppointmentConfirmed = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentConfirmed;
                        lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                        break;
                    case Consts.APPT_STATUS_ARRIVED:
                        _salonDiary.AppointmentArrived = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentArrived;
                        lblPreview.ForeColor = _salonDiary.AppointmentArrivedText;
                        break;
                    case Consts.APPT_STATUS_CANCELLED_BY_USER:
                        _salonDiary.AppointmentCancelledByUser = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCancelledByUser;
                        lblPreview.ForeColor = _salonDiary.AppointmentCancelledByUserText;
                        break;
                    case Consts.APPT_STATUS_CANCELLED_BY_STAFF:
                        _salonDiary.AppointmentCancelledByStaff = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCancelledByStaff;
                        lblPreview.ForeColor = _salonDiary.AppointmentCancelledbyStaffText;
                        break;
                    case Consts.APPT_STATUS_NO_SHOW:
                        _salonDiary.AppointmentNoShow = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentNoShow;
                        lblPreview.ForeColor = _salonDiary.AppointmentNoShowText;
                        break;
                    case Consts.APPT_STATUS_COMPLETED:
                        _salonDiary.AppointmentCompleted = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCompleted;
                        lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                        break;
                    case Consts.APPT_STATUS_DELETED:
                        _salonDiary.AppointmentDeleted = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentDeleted;
                        lblPreview.ForeColor = _salonDiary.AppointmentDeletedText;
                        break;
                }
            }
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = lblPreview.ForeColor;

            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {

                switch (cmbAppointmentStatus.Text)
                {
                    case Consts.APPT_STATUS_SELECTED:
                        _salonDiary.AppointmentSelectedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentSelected;
                        lblPreview.ForeColor = _salonDiary.AppointmentSelectedText;
                        break;
                    case Consts.APPT_STATUS_REQUESTED:
                        _salonDiary.AppointmentRequestedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentRequested;
                        lblPreview.ForeColor = _salonDiary.AppointmentRequestedText;
                        break;
                    case Consts.APPT_STATUS_CONFIRMED:
                        _salonDiary.AppointmentConfirmedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentConfirmed;
                        lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                        break;
                    case Consts.APPT_STATUS_ARRIVED:
                        _salonDiary.AppointmentArrivedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentArrived;
                        lblPreview.ForeColor = _salonDiary.AppointmentArrivedText;
                        break;
                    case Consts.APPT_STATUS_CANCELLED_BY_USER:
                        _salonDiary.AppointmentCancelledByUserText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCancelledByUser;
                        lblPreview.ForeColor = _salonDiary.AppointmentCancelledByUserText;
                        break;
                    case Consts.APPT_STATUS_CANCELLED_BY_STAFF:
                        _salonDiary.AppointmentCancelledbyStaffText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCancelledByStaff;
                        lblPreview.ForeColor = _salonDiary.AppointmentCancelledbyStaffText;
                        break;
                    case Consts.APPT_STATUS_NO_SHOW:
                        _salonDiary.AppointmentNoShowText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentNoShow;
                        lblPreview.ForeColor = _salonDiary.AppointmentNoShowText;
                        break;
                    case Consts.APPT_STATUS_COMPLETED:
                        _salonDiary.AppointmentCompletedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentCompleted;
                        lblPreview.ForeColor = _salonDiary.AppointmentConfirmedText;
                        break;
                    case Consts.APPT_STATUS_DELETED:
                        _salonDiary.AppointmentDeletedText = colorDialog1.Color;
                        lblPreview.BackColor = _salonDiary.AppointmentDeleted;
                        lblPreview.ForeColor = _salonDiary.AppointmentDeletedText;
                        break;
                }
            }
        }

        private void trackBarScrollMovement_Scroll(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void cbOverlays_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void trackBarTooltip_Scroll(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void cmbLunchDurations_Format(object sender, ListControlConvertEventArgs e)
        {
            int i = (int)e.ListItem;

            int h = i / 60;
            int m = (i - (h * 60));

            string duration;

            switch (h)
            {
                case 0:
                    duration = String.Format(LanguageStrings.AppDiaryLunchMins, m);
                    break;
                case 1:
                    if (m == 0)
                        duration = LanguageStrings.AppDiaryLunch1Hour;
                    else
                        duration = String.Format(LanguageStrings.AppDiaryLunch1HourMins, m);
                    break;
                default:
                    if (m == 0)
                        duration = String.Format(LanguageStrings.AppDiaryLunchHours, h);
                    else
                        duration = String.Format(LanguageStrings.AppDiaryLunchHoursMins, h, m);
                    break;
            }

            e.Value = duration;
        }

        private void tabControlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnTabChanged != null)
                OnTabChanged(this, EventArgs.Empty);
        }

        #endregion Private Members

        #region Events

        public event EventHandler OnTabChanged;

        #endregion Events
    }
}
