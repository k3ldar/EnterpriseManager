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
 *  File: SickLeaveWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Languages;
using POS.Base.Classes;
using SharedBase.BOL.Staff;
using SharedControls.WizardBase;
using POS.Staff.Controls;

namespace POS.Staff.Classes
{
    public class SicknessWizardSettings
    {
        public SicknessWizardSettings(bool continuation, StaffMember staffMember)
        {
            AppointmentUpdates = new List<SicknessAppointment>();
            Continuation = continuation;
            Staff = staffMember;
        }

        public bool Continuation { get; set; }

        public StaffSickRecord Record { get; set; }
        public StaffMember Staff { get; set; }
        public bool AllowSelectStaff { get; set; }
        public DateTime DateNotified { get; set; }
        public DateTime DateFrom { get; set; }
        public bool Certificate { get; set; }
        public bool PreBooked { get; set; }
        public string Reason { get; set; }
        public List<SicknessAppointment> AppointmentUpdates { get; set; }

        public int CancelledCount
        {
            get
            {
                int Result = 0;

                foreach (SicknessAppointment appt in AppointmentUpdates)
                    if (appt.Cancelled)
                        Result++;

                return (Result);
            }
        }

        public int RescheduledCount
        {
            get
            {
                int Result = 0;

                foreach (SicknessAppointment appt in AppointmentUpdates)
                    if (!appt.Cancelled)
                        Result++;

                return (Result);
            }
        }
    }

    internal static class SickLeaveWizard
    {
        internal static bool SickLeaveAdd(StaffMember member, bool continuation, StaffMember staffMember)
        {
            SicknessWizardSettings rtw = new SicknessWizardSettings(continuation, staffMember);
            rtw.Staff = member;
            rtw.AllowSelectStaff = member == null;
            string title = rtw.AllowSelectStaff ? LanguageStrings.AppSickLeaveWizard :
                String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppSickLeaveWizard, member.UserRecord.UserName);

            return (WizardForm.ShowWizard(title,
                new POS.Staff.Controls.Wizards.StaffSick.CreateSickness.Step1(rtw),
                new POS.Staff.Controls.Wizards.StaffSick.CreateSickness.Step2(rtw),
                new POS.Staff.Controls.Wizards.StaffSick.CreateSickness.Step3(rtw),
                new POS.Staff.Controls.Wizards.StaffSick.CreateSickness.Summary(rtw)));
        }

        internal static bool SickLeaveReturn(StaffMember member, StaffSickRecord record)
        {
            SicknessWizardSettings rtw = new SicknessWizardSettings(false, null);
            rtw.Staff = member;
            rtw.Record = record;

            return (WizardForm.ShowWizard(String.Format(LanguageStrings.AppSickLeaveReturnWizard, member.UserRecord.UserName),
                new POS.Staff.Controls.Wizards.StaffSick.ReturnFromSickness.Step1(rtw)));
        }
    }
}
