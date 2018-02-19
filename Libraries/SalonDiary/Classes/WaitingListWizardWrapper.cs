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
 *  File: WaitingListWizardWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
