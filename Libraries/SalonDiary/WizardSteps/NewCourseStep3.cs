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
 *  File: NewCourseStep3.cs
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

using SalonDiary.Classes;

using SharedControls.WizardBase;

namespace SalonDiary.WizardSteps
{
    public partial class NewCourseStep3 : BaseWizardPage
    {
        private NewCourseOptions _options;

        public NewCourseStep3(NewCourseOptions options)
        {
            InitializeComponent();

            _options = options;
        }


        public override bool NextClicked()
        {
            return (false);
        }

        public override bool BeforeFinish()
        {
            //does the trainer have appointments already on the days for the course, if so fail
            bool Result = _options.TrainerHasAppointments();

            if (Result)
                ShowError(LanguageStrings.AppDiaryTrainerAppts, LanguageStrings.AppDiaryTrainerApptsDesc);

            return (!Result);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblFinishDesc.Text = LanguageStrings.AppDiaryCourseFinish;
            lblReviewDesc.Text = LanguageStrings.AppDiaryCourseReviewOptions;

            lblCourseName.Text = String.Format(LanguageStrings.AppDiaryCourseName, _options.Course.Name);
            lblTrainer.Text = String.Format(LanguageStrings.AppDiaryCourseTrainer, _options.Trainer.EmployeeName);
            lblStartDate.Text = String.Format(LanguageStrings.AppDiaryCourseStartDate, _options.StartDate.Date.ToString(StringConstants.DIARY_DATE_DAY_ONLY));
            lblConsecutive.Text = String.Format(LanguageStrings.AppDiaryCourseConsecutiveDays, _options.ConsecutiveDays ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            lblExcludeSaturday.Text = String.Format(LanguageStrings.AppDiaryCourseExcludeSaturday, _options.ExcludeSaturday ? LanguageStrings.AppYes : LanguageStrings.AppNo);
            lblExcludeSunday.Text = String.Format(LanguageStrings.AppDiaryCourseExcludeSunday, _options.ExcludeSunday ? LanguageStrings.AppYes : LanguageStrings.AppNo);

        }
    }
}
