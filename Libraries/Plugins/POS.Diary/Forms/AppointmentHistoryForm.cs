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
 *  File: AppointmentHistoryForm.cs
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

using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;

namespace POS.Diary.Forms
{
    public partial class AppointmentHistoryForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private User _user;

        #endregion Private Members

        public AppointmentHistoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor - Shows a users appointment history
        /// </summary>
        /// <param name="user">User who's appointment history is sought</param>
        public AppointmentHistoryForm(User user)
            : this ()
        {
            _user = user;

            lvApptHistory.Items.Clear();

            foreach (AppointmentHistoryItem item in user.History)
            {
                ListViewItem itm = new ListViewItem();
                itm.Text = item.TimeFrame;
                itm.SubItems.Add(item.Status);
                itm.SubItems.Add(item.Count.ToString());
                lvApptHistory.Items.Add(itm);
            }
        }

        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryApptHistory;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                LanguageStrings.AppDiaryApptHistory, _user.UserName);

            btnOK.Text = LanguageStrings.AppMenuButtonOK;

            lblDescription.Text = String.Format(LanguageStrings.AppDiaryApptHistoryDescription, _user.UserName);

            colTimeFrame.Text = LanguageStrings.AppTimeFrame;
            colStatus.Text = LanguageStrings.AppDiaryStatus;
            colApptCount.Text = LanguageStrings.AppDiaryApptCount;
        }
    }
}
