using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

namespace SalonDiary.WizardSteps
{
    public partial class NewCourseIndividualDates : SharedControls.BaseControl
    {
        #region Private Members

        private int _day;

        #endregion Private Members

        #region Constructors

        public NewCourseIndividualDates()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblDay.Text = String.Format(LanguageStrings.AppDiaryCourseDay, _day);
        }

        #endregion Overridden Methods

        /// <summary>
        /// Date of course
        /// </summary>
        public DateTime Date
        {
            get
            {
                return (dtpCourseDate.Value.Date);
            }

            set
            {
                dtpCourseDate.Value = value.Date;
            }
        }

        public int Day
        {
            set
            {
                _day = value;
                lblDay.Text = String.Format(LanguageStrings.AppDiaryCourseDay, _day);
            }

            get
            {
                return (_day);
            }
        }
    }
}
