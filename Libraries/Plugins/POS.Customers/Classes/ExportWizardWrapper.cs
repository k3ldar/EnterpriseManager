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
 *  File: ExportWizardWrapper.cs
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

using Languages;
using Library;
using Library.BOL.Countries;
using Library.BOL.Export;
using Library.BOL.Users;
using SharedControls.WizardBase;

namespace POS.Customers.Classes
{
    internal static class ExportWizardWrapper
    {
        internal static bool ShowExportWizard()
        {
            ExportSettings exportSettings = new ExportSettings();

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppCustomerExport,
                new Controls.Wizards.Export.Step1(exportSettings),
                new Controls.Wizards.Export.Step2(exportSettings),
                new Controls.Wizards.Export.Step3(exportSettings),
                new Controls.Wizards.Export.Step4(exportSettings),
                new Controls.Wizards.Export.Step5(exportSettings),
                new Controls.Wizards.Export.Step6(exportSettings));

            return (Result);
        }
    }

    public enum MemberLevelType { Above, Below, Equal, EqualBelow }

    public sealed class ExportSettings
    {
        public ExportSettings()
        {
            UserRecords = new Users();
            SelectedCountries = new Countries();
            ExportItems = ExportableItems.Get(POS.Base.Classes.StringConstants.TABLE_MEMBERS);
        }

        public bool CountrySelected(Country country)
        {
            foreach (Country cntry in SelectedCountries)
            {
                if (cntry.ID == country.ID)
                    return (true);
            }

            return (false);
        }

        #region Properties

        public ExportableItems ExportItems { get; private set; }

        public Countries SelectedCountries { get; private set; }

        public bool AllCountries { get; set; }

        public bool OfferEmail { get; set; }

        public bool OfferTelephone { get; set; }

        public bool OfferPostal { get; set; }

        public bool ValidEmail { get; set; }

        public bool IgnoreBusiness { get; set; }

        public bool HasBusinessName { get; set; }

        public bool ExcludeInvalidAddress { get; set; }

        public MemberLevel MemberLevel { get; set;}

        public MemberLevelType MemberLevelType { get; set; }

        public Users UserRecords { get; private set; }

        #endregion Properties

    }
}
