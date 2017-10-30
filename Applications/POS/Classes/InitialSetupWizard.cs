using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Languages;
using Library.BOL.Websites;
using POS.Base.Classes;
using SharedControls.WizardBase;

namespace PointOfSale.Classes
{
    internal static class InitialSetupWizard
    {
        internal static void LoadInitialSetup()
        {
            string setupFile = AppController.POSFolder(FolderType.Root, true) + StringConstants.FILE_INITIAL_SETUP;

            if (!File.Exists(setupFile))
            {
                return;
            }

            InitialSetupSettings settings = new InitialSetupSettings();

            WizardForm.ShowWizard(LanguageStrings.AppInitialSetup,
                new Controls.InitialSetupWizard.Step1(settings),
                new Controls.InitialSetupWizard.Step2(settings),
                new Controls.InitialSetupWizard.Step3(settings),
                new Controls.InitialSetupWizard.Step4(settings),
                new Controls.InitialSetupWizard.Step5(settings),
                new Controls.InitialSetupWizard.FinalStep(settings));

#if !DEBUG
            File.Delete(setupFile);
#endif
        }
    }

    internal class InitialSetupSettings
    {
        // step 1 is set automagically!

        // step 2
        internal string BusinessName { get; set; }
        internal string Telephone { get; set; }
        internal string Email { get; set; }
        internal string Address { get; set; }
        internal string RegistrationNumber { get; set; }
        internal string VatNumber { get; set; }

        // step 3
        internal string Logo { get; set; }

        // step 4
        internal Website Website { get; set; }
        internal bool FTPTested { get; set; }


        // step 5
        internal string EmailUser { get; set; }
        internal string EmailPassword { get; set; }
        internal string EmailHost { get; set; }
        internal int EmailPort { get; set; }
        internal bool EmailSSL { get; set; }
        internal bool EmailTested { get; set; }
    }
}
