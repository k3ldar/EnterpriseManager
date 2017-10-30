using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library;
using Library.BOL.Staff;

using POS.Base;
using POS.Base.Classes;

namespace POS.Staff.Forms
{
    public partial class ViewSickRecord : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public ViewSickRecord()
        {
            InitializeComponent();
        }

        public ViewSickRecord(StaffSickRecord record)
            : this()
        {
            lblCancelled.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppCancelled,
                record.Properties.HasFlag(SickOptions.Cancelled) ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            lblCertified.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppSicknessCertificateProvided,
                record.Certificate ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            lblInterviewed.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppSicknessInterviewCompleted,
                record.ReturnInterviewCompleted ? LanguageStrings.AppYes : LanguageStrings.AppNo);

            lblPrebooked.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppSicknessPreBooked, 
                record.PreBooked ? LanguageStrings.AppYes : LanguageStrings.AppNo);

            if (record.DateFinished == DateTime.MinValue)
            {
                lblDateFinished.Visible = false;
                lbldtpFinished.Visible = false;
            }
            else
            {
                lbldtpFinished.Text = Shared.Utilities.DateToStr(record.DateFinished,
                    POS.Base.Classes.AppController.LocalSettings.CustomUICulture);
            }

            lbldtpNotified.Text = Shared.Utilities.DateToStr(record.DateNotified,
                    POS.Base.Classes.AppController.LocalCulture);
            lbldtpStarted.Text = Shared.Utilities.DateToStr(record.DateStarted,
                    POS.Base.Classes.AppController.LocalCulture);

            txtNotes.Text = record.Notes;
            txtReason.Text = record.ReasonCited;
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.StaffViewSicknessRecord;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppSicknessViewSicknessRecord;
            btnClose.Text = LanguageStrings.AppMenuButtonClose;

            tabPageNotes.Text = LanguageStrings.AppNotes;
            tabPageReason.Text = LanguageStrings.AppSicknessReasonProvided;

            lblDateFinished.Text = LanguageStrings.AppSicknessDateFinished;
            lblDateNotified.Text = LanguageStrings.AppSicknessDateNotified;
            lblDateStarted.Text = LanguageStrings.AppSicknessDateStarted;
        }

        #endregion Overridden Methods
    }
}
