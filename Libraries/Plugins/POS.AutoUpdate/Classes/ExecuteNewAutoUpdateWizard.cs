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
