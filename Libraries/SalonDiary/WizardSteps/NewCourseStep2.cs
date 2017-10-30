using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using Library.Utils;

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
