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
 *  File: AppointmentChanges.cs
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

using SharedBase.Utils;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;

namespace POS.Diary.Forms
{
    public partial class AppointmentChanges : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public AppointmentChanges()
        {
            InitializeComponent();

        }

        public AppointmentChanges(SharedBase.BOL.Appointments.AppointmentChanges changes)
            : this()
        {
            //load changes
            foreach (AppointmentChangeItem item in changes)
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Date.ToShortDateString();
                li.SubItems.Add(Shared.Utilities.DoubleToTime(item.StartTime));
                li.SubItems.Add(item.Duration.ToString());
                li.SubItems.Add(Shared.Utilities.SplitCamelCase(item.Status.ToString()));
                li.SubItems.Add(item.Type.ToString());
                li.SubItems.Add(item.Employee);
                li.SubItems.Add(item.Treatment);
                li.SubItems.Add(item.Notes.Replace(StringConstants.SYMBOL_RETURN.ToString(), StringConstants.SYMBOL_SPACE));
                li.SubItems.Add(item.LastAltered.Year == 1 ? String.Empty : item.LastAltered.ToString(StringConstants.SYMBOL_DATE_FORMAT_G));
                li.SubItems.Add(item.AlteredBy);
                lvChanges.Items.Add(li);
            }

        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryApptChanges;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiaryApptChanges;

            lblDescription.Text = LanguageStrings.AppDiaryApptChangesDescription;

            btnClose.Text = LanguageStrings.AppMenuButtonClose;

            colHeaderAlteredBy.Text = LanguageStrings.AppDiaryLastAlteredBy;
            colHeaderDate.Text = LanguageStrings.AppDate;
            colHeaderDateAltered.Text = LanguageStrings.AppDiaryLastAltered;
            colHeaderDuration.Text = LanguageStrings.AppDiaryDuration;
            colHeaderEmployee.Text = LanguageStrings.AppEmployee;
            colHeaderNotes.Text = LanguageStrings.AppNotes;
            colHeaderStatus.Text = LanguageStrings.AppDiaryStatus;
            colHeaderTime.Text = LanguageStrings.AppDiaryStartTime;
            colHeaderTreatment.Text = LanguageStrings.AppDiaryTreatment;
        }

        #endregion Overridden Methods
    }
}
