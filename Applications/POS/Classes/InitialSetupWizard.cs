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
 *  File: InitialSetupWizard.cs
 *
 *  Purpose:  Loads the initial setup wizard dialog
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.IO;

using Languages;
using SharedBase.BOL.Websites;
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
        #region Constructors

        internal InitialSetupSettings()
        {
            BusinessName = AppController.LocalSettings.BusinessName;
            Telephone = AppController.LocalSettings.BusinessTelephone;
            Email = AppController.LocalSettings.BusinessEmail;
            Address = AppController.LocalSettings.BusinessAddress;
            RegistrationNumber = AppController.LocalSettings.BusinessRegNo;
            VatNumber = AppController.LocalSettings.BusinessVatNo;

            Logo = AppController.POSFolder(ImageTypes.Logo) + 
                ImageTypes.Logo.ToString() + 
                StringConstants.IMAGE_DEFAULT
                + StringConstants.FILE_EXTENSION_JPG;
            LogoExists = File.Exists(Logo);

            Website = Websites.Primary();
            FTPTested = false;

            EmailUser = AppController.LocalSettings.EmailUser;
            EmailHost = AppController.LocalSettings.EmailServer;
            EmailSSL = AppController.LocalSettings.EmailSSL;
            EmailPassword = AppController.LocalSettings.EmailPassword;
            EmailPort = AppController.LocalSettings.EmailPort;
            EmailTested = false;
        }

        #endregion Constructors

        #region Properties

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
        internal bool LogoExists { get; set; }

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

        #endregion Properties
    }
}
