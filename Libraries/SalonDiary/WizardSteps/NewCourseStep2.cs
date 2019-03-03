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
 *  File: NewCourseStep2.cs
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
using SharedBase.Utils;

using SalonDiary.Classes;

using SharedControls.WizardBase;

namespace SalonDiary.WizardSteps
{
    public partial class NewCourseStep2 : BaseWizardPage
    {
        #region Private Members

        private NewCourseOptions _options;

        #endregion Private Members

        #region Constructor

        public NewCourseStep2(NewCourseOptions options)
        {
            InitializeComponent();

            _options = options;

            LoadDates();
        }

        #endregion Constructor

        #region Public Methods

        public override bool NextClicked()
        {
            // assume failure
            bool Result = false;

            //validate entries and set options
            
            //make sure all course dates are after each other
            DateTime lastDate = _options.StartDate;

            for (int i = 0; i < flowPanelDates.Controls.Count; i++)
            {
                NewCourseIndividualDates newDate = (NewCourseIndividualDates)flowPanelDates.Controls[i];

                if (newDate.Date <= lastDate.Date)
                {
                    ShowError(LanguageStrings.AppError, String.Format(LanguageStrings.AppDiaryCourseInvalidDate, newDate.Day));
                    return (Result);
                }
            }


            Result = true;

            return (Result);
        }

        #endregion Public Methods

        #region Private Methods

        private void LoadDates()
        {
            for (int i = 1; i <= _options.Course.CourseLength; i++)
            {
                NewCourseIndividualDates newDate = new NewCourseIndividualDates();
                newDate.Day = i;
                newDate.Date = _options.StartDate.AddDays(i);
                flowPanelDates.Controls.Add(newDate);
            }
        }

        #endregion Private Methods
    }
}
