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
 *  File: Step1.cs
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
using SharedBase.BOL.Staff;

using POS.Staff.Classes;

namespace POS.Staff.Controls.Wizards.StaffSick.ReturnFromSickness
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private SicknessWizardSettings _returnToWork;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();

            dtpDateReturned.CustomFormat = Shared.Utilities.DateFormat(true, true);
            dtpDateReturned.Value = DateTime.Now;
        }

        public Step1(SicknessWizardSettings returnToWork)
            : this()
        {
            _returnToWork = returnToWork;
            cbCertificateProvided.Checked = _returnToWork.Record.Certificate;
            dtpDateReturned.MinDate = _returnToWork.Record.DateStarted;
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDateReturned.Text = LanguageStrings.AppSicknessDateFinished;
            lblNotes.Text = LanguageStrings.Notes;
            cbCertificateProvided.Text = LanguageStrings.AppSicknessCertificateProvided;
            cbRTWInterviewCompleted.Text = LanguageStrings.AppSicknessInterviewCompleted;

            POS.Base.Classes.AppController.ActiveHelpTopic = POS.Base.Classes.HelpTopics.StaffSickReturnTowork;
        }

        public override bool BeforeFinish()
        {
            _returnToWork.Record.Certificate = cbCertificateProvided.Checked;
            _returnToWork.Record.DateFinished = dtpDateReturned.Value;
            _returnToWork.Record.Notes = txtNotes.Text;
            _returnToWork.Record.ReturnInterviewCompleted = cbRTWInterviewCompleted.Checked;
            _returnToWork.Record.ReturnInterviewer = POS.Base.Classes.AppController.ActiveUser.ID;
            _returnToWork.Record.Save();

            return base.BeforeFinish();
        }

        #endregion Overridden Methods
    }
}
