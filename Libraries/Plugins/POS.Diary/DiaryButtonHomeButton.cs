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
 *  File: DiaryButtonHomeButton.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  23/08/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Appointments;
using Library.BOL.Users;
using Library.BOL.Therapists;
using Library.BOL.ValidationChecks;

using POS.Base.Classes;
using POS.Base.Plugins;
using POS.Diary.Forms;
using POS.Diary.Classes;

namespace POS.Diary
{
#if BUTTON_INTERFACE
    public class DiaryButtonHomeButton : HomeButton
    {
    #region Private Members

        private SalonCalendar _diary;

    #endregion Private Members

    #region Constructors

        public DiaryButtonHomeButton(BasePluginModule parent, string buttonName, 
            string description, Image image)
            : base(parent, buttonName, description, image)
        {

        }
            
    #endregion Constructors

    #region Overridden Methods


        public override void ButtonClicked(object sender, EventArgs e)
        {
            RaisePluginUsage(POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_DIARY);

            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewDiary))
            {
                if (AppController.POSApplication.AllAppointments == null)
                {
                    MessageBox.Show(LanguageStrings.AppAppointmentsNotLoaded,
                        LanguageStrings.AppWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.WaitCursor;

                if (_diary == null)
                {
                    _diary = new Forms.SalonCalendar(AppController.ActiveUser);
                    _diary.FormClosed += new FormClosedEventHandler(_diary_FormClosed);
                    _diary.PayNow += new SalonDiary.Controls.PayNowEventHandler(diary_PayNow);
                    _diary.AppointmentStatusChanged += _diary_AppointmentStatusChanged;
                }

                _diary.Show();
                _diary.BringToFront();

                if (_diary.WindowState == FormWindowState.Minimized)
                    _diary.WindowState = FormWindowState.Normal;

                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppSalonDiary),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override string ToString()
        {
            return (POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_DIARY);
        }

    #endregion Overridden Methods

    #region Private Methods

        private void _diary_AppointmentStatusChanged(object sender, EventArgs e)
        {
            ((DiaryPluginModule)Parent).ResetTrayNotifications();
        }

        private void _diary_FormClosed(object sender, FormClosedEventArgs e)
        {
            _diary.Dispose();
            _diary = null;
            RaiseBringToFront();
        }

        private void diary_PayNow(object sender, SalonDiary.Controls.AppointmentPayNowEventArgs e)
        {
            Parent.RaiseEventNotification(new NotificationEventArgs(StringConstants.PLUGIN_EVENT_TAKE_PAYMENT, e.Appointment));
        }


    #endregion Private Methods
    }
#endif
}
