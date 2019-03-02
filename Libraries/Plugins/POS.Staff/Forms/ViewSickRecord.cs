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
 *  File: ViewSickRecord.cs
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
using SharedBase.BOL.Staff;

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
