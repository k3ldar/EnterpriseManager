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
    public sealed class WaitingListWizardWrapper
    {
        public static void ShowWaitingListWizard(Controls.SalonDiary salonDiary)
        {
            if (salonDiary == null)
                throw new ArgumentNullException();

            WaitingListWizardOptions options = new WaitingListWizardOptions();
            options.Diary = salonDiary;

            WizardForm.ShowWizard(LanguageStrings.AppSalonNewWaitingListWizard,
                new Controls.Wizards.WaitingListWizard.Step1(options),
                new Controls.Wizards.WaitingListWizard.Step2(options),
                new Controls.Wizards.WaitingListWizard.Step3(options),
                new Controls.Wizards.WaitingListWizard.Summary(options));

            salonDiary.RaiseWaitingListUpdated();
        }
    }

    /// <summary>
    /// Options for waiting list
    /// </summary>
    public sealed class WaitingListWizardOptions
    {
        #region Properties

        /// <summary>
        /// Indicates that its a new item for the waiting list
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Waiting list item being created/edited
        /// </summary>
        public WaitingList WaitingListItem { get; set; }

        /// <summary>
        /// Salon Diary
        /// </summary>
        public Controls.SalonDiary Diary { get; set; }

        #endregion Properties
    }
}
