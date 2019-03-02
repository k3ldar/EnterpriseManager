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
 *  File: NewTrainingCourseWizard.cs
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

using SalonDiary.Classes;
using SalonDiary.WizardSteps;

using SharedControls.WizardBase;

using Languages;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;

namespace POS.TrainingSchedule.Forms
{
    public partial class NewTrainingCourseWizard : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private int _page;
        private NewCourseOptions _options;
        private BaseWizardPage _currentPage;

        #endregion Private Members

        #region Constructors

        public NewTrainingCourseWizard()
        {
            InitializeComponent();
            _page = 0;
            _options = new NewCourseOptions(AppController.ActiveUser, 
                AppController.ApplicationController.AllAppointments);
            _options.StartDate = DateTime.Now.AddDays(2);
            _options.ConsecutiveDays = true;
            _options.ExcludeSaturday = true;
            _options.ExcludeSunday = true;
            _options.CreateAppointment += _options_CreateAppointment;

            LoadWizard();
            SetButtons();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.TrainingScheduleCreateStep1;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiaryCourseNewWizard;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnFinish.Text = LanguageStrings.AppMenuButtonFinish;
            btnNext.Text = LanguageStrings.AppMenuButtonNext;
            btnPrevious.Text = LanguageStrings.AppMenuButtonPrevious;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void _options_CreateAppointment(object sender, Appointment appointment)
        {
            AppController.ApplicationController.AllAppointments.Add(appointment);
        }


        private void LoadWizard()
        {
            _currentPage = new NewCourseStep1(_options);
            flowPanelWizard.Controls.Add(_currentPage);
            _page = 1;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (_currentPage.BeforeFinish())
            {
                _options.CreateCourse();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_currentPage.NextClicked())
                return;

            switch (_page)
            {
                case 1:
                    flowPanelWizard.Controls.Clear();

                    if (_options.ConsecutiveDays)
                    {
                        _currentPage = new NewCourseStep3(_options);
                        _page = 3;
                    }
                    else
                    {
                        _currentPage = new NewCourseStep2(_options);
                        _page = 2;
                    }

                    break;

                case 2:
                    _currentPage = new NewCourseStep3(_options);
                    _page = 3;
                    break;

            }

            flowPanelWizard.Controls.Add(_currentPage);

            SetButtons();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            flowPanelWizard.Controls.Clear();

            switch (_page)
            {
                case 2:
                    _currentPage = new NewCourseStep1(_options);
                    _page = 1;
                    break;

                case 3:
                    if (_options.ConsecutiveDays)
                    {
                        _currentPage = new NewCourseStep1(_options);
                        _page = 1;
                    }
                    else
                    {
                        _currentPage = new NewCourseStep2(_options);
                        _page = 2;
                    }

                    break;

            }

            flowPanelWizard.Controls.Add(_currentPage);
            SetButtons();
        }

        private void SetButtons()
        {
            btnFinish.Enabled = _page == 3;
            btnPrevious.Enabled = _page > 1;
            btnNext.Enabled = _page != 3;
            btnFinish.Enabled = _page == 3;
        }

        #endregion Private Methods
    }
}
