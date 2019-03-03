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
 *  File: RecordedDeliverySettings.cs
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;

using POS.Base.Classes;

namespace POS.Orders.Controls
{
    public partial class RecordedDeliverySettings : SharedControls.BaseSettings
    {
        #region Constructors

        public RecordedDeliverySettings()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            gbInternational.Text = LanguageStrings.AppInternational;
            gbLocal.Text = LanguageStrings.AppLocal;

            lblInternationalPrefix.Text = LanguageStrings.AppPrefix;
            lblInternationalSuffix.Text = LanguageStrings.AppSuffix;
            lblInternationalUnique.Text = LanguageStrings.AppUniqueNumber;
            cbInternationalAutoIncrement.Text = LanguageStrings.AppAutoIncrement;

            lblLocalPrefix.Text = LanguageStrings.AppPrefix;
            lblLocalSuffix.Text = LanguageStrings.AppSuffix;
            lblLocalUnique.Text = LanguageStrings.AppUniqueNumber;
            cbLocalAutoIncrement.Text = LanguageStrings.AppAutoIncrement;
        }

        public override bool SettingsSave()
        {
            try
            {
                if (Shared.Utilities.StrToIntDef(txtLocalUniqueNumber.Text, 0) == -1)
                    throw new Exception(String.Format(LanguageStrings.AppUniqueNumberNotNumber, 
                        LanguageStrings.AppLocal));

                if (Shared.Utilities.StrToIntDef(txtInternationalUniqueNumber.Text, 0) == -1)
                    throw new Exception(String.Format(LanguageStrings.AppUniqueNumberNotNumber, 
                        LanguageStrings.AppInternational));

                string XMLFile = Shared.Utilities.CurrentPath(true) + 
                    StringConstants.XML_CONFIG_FILE;

                SetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                    StringConstants.XML_PREFIX, txtLocalPrefix.Text);
                SetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                    StringConstants.XML_UNIQUE_NUMBER, txtLocalUniqueNumber.Text);
                SetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                    StringConstants.XML_SUFFIX, txtLocalSuffix.Text);
                SetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                    StringConstants.XML_AUTO_INCREMENT, Shared.Utilities.BoolToStr(cbLocalAutoIncrement.Checked));

                SetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                    StringConstants.XML_PREFIX, txtInternationalPrefix.Text);
                SetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                    StringConstants.XML_UNIQUE_NUMBER, txtInternationalUniqueNumber.Text);
                SetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                    StringConstants.XML_SUFFIX, txtInternationalSuffix.Text);
                SetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                    StringConstants.XML_AUTO_INCREMENT, 
                    Shared.Utilities.BoolToStr(cbInternationalAutoIncrement.Checked));
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            string XMLFile = Shared.Utilities.CurrentPath(true) + 
                StringConstants.XML_CONFIG_FILE;

            txtLocalPrefix.Text = GetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                StringConstants.XML_PREFIX);
            txtLocalUniqueNumber.Text = GetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                StringConstants.XML_UNIQUE_NUMBER);
            txtLocalSuffix.Text = GetXMLValue(XMLFile, StringConstants.XML_LOCAL_DELIVERY, 
                StringConstants.XML_SUFFIX);
            cbLocalAutoIncrement.Checked = Shared.Utilities.StrToBool(GetXMLValue(XMLFile, 
                StringConstants.XML_LOCAL_DELIVERY, StringConstants.XML_AUTO_INCREMENT));

            txtInternationalPrefix.Text = GetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                StringConstants.XML_PREFIX);
            txtInternationalUniqueNumber.Text = GetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                StringConstants.XML_UNIQUE_NUMBER);
            txtInternationalSuffix.Text = GetXMLValue(XMLFile, StringConstants.XML_INTERNATIONAL_DELIVERY, 
                StringConstants.XML_SUFFIX);
            cbInternationalAutoIncrement.Checked = Shared.Utilities.StrToBool(GetXMLValue(XMLFile, 
                StringConstants.XML_INTERNATIONAL_DELIVERY, StringConstants.XML_AUTO_INCREMENT));
        }

        #endregion Overridden Methods

        #region Private Methods


        private string GetXMLValue(string ConfigFile, string ParentName, string KeyName)
        {
            return (XMLManipulation.GetXMLValue(ConfigFile, ParentName, KeyName, String.Empty));
        }

        private void SetXMLValue(string ConfigFile, string ParentName, string KeyName, string Value)
        {
            XMLManipulation.SetXMLValue(ConfigFile, ParentName, KeyName, Value);
        }


        #endregion Private Methods
    }
}
