using System;
using System.Collections.Generic;
using System.Text;

using SalonDiary.Controls;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using Library.BOL.Users;
using SharedControls.WizardBase;

namespace SalonDiary.Classes
{
    public static class NewAppointWizardWrapper
    {
        public static void ShowNewAppointmentWizard(Controls.SalonDiary salonDiary)
        {
            NewAppointmentOptionsDiary options = new NewAppointmentOptionsDiary();
            options.Diary = salonDiary;

            WizardForm.ShowWizard(LanguageStrings.AppSalonNewAppointmentWizard,
                new Controls.Wizards.NewAppointmentWizard.Step1(options),
                new Controls.Wizards.NewAppointmentWizard.Step2(options),
                new Controls.Wizards.NewAppointmentWizard.Step3(options));
        }
    }

    public sealed class NewAppointmentOptionsDiary : NewAppointmentOptions
    {
        #region Constructors

        public NewAppointmentOptionsDiary()
        {
        }

        #endregion Constructors

        #region Properties

        public Controls.SalonDiary Diary { get; set; }

        #endregion Properties
    }
}
