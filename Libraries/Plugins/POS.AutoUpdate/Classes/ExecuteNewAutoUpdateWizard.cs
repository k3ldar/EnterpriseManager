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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: ExecuteNewAutoUpdateWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using Library.BOL.DatabaseUpdates;
using SharedControls.WizardBase;

namespace POS.AutoUpdate.Classes
{
    internal static class ExecuteNewAutoUpdateWizard
    {
        internal static Library.BOL.DatabaseUpdates.AutoUpdate CreateNewAutoUpdate(
            Library.BOL.DatabaseUpdates.AutoUpdate updateRule)
        {
            Library.BOL.DatabaseUpdates.AutoUpdate Result = null;
            CreateAutoRuleSettings settings = new CreateAutoRuleSettings(updateRule);

            if (WizardForm.ShowWizard(LanguageStrings.AppAutoRuleCreateWizard,
               new Controls.Wizards.AddRule.Step1(settings),
               new Controls.Wizards.AddRule.Step2(settings),
               new Controls.Wizards.AddRule.Step3(settings),
               new Controls.Wizards.AddRule.Step5(settings),
               new Controls.Wizards.AddRule.Step6(settings)))
            {
                Result = settings.AutoUpdate;
            }

            return (Result);
        }
    }

    public sealed class CreateAutoRuleSettings
    {
        private AutoUpdateRule _rule;

        public CreateAutoRuleSettings(Library.BOL.DatabaseUpdates.AutoUpdate updateRule)
        {
            _rule = null;
            AutoUpdate = updateRule;
            ItemsAffected = new AutoUpdateItems();
        }

        public AutoUpdateItems ItemsAffected { get; set; }

        public AutoUpdateRule Rule 
        { 
            get
            {
                return (_rule);
            }

            set
            {
                _rule = value;

                if (OnRuleChanged != null)
                    OnRuleChanged(this, EventArgs.Empty);
            }
        }

        public Library.BOL.DatabaseUpdates.AutoUpdate AutoUpdate { get; set; }

        public event EventHandler OnRuleChanged;
    }
}
