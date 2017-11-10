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
 *  File: PrintSettings.cs
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
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Library.Utils;
using Library.BOL.Users;
using POS.Base.Classes;

namespace POS.Orders.Controls
{
    public partial class PrintSettings : SharedControls.BaseSettings
    {
        public PrintSettings()
        {
            InitializeComponent();
        }        
        
        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            gbLabelPrinter.Text = Languages.LanguageStrings.AppLabelPrinter;
        }

        public override bool SettingsSave()
        {
            if (cmbLabelPrinter.SelectedItem != null)
                XMLManipulation.SetXMLValue(XMLFile, StringConstants.XML_LABEL_PRINTER, 
                    StringConstants.XML_LABEL_NAME, cmbLabelPrinter.SelectedItem.ToString());


            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            LoadPrinters();
        }

        #endregion Overridden Methods

        #region Properties

        internal string XMLFile
        {
            get
            {
                string Result = Shared.Utilities.CurrentPath(false) + StringConstants.FILE_CONFIG;
                return (Result);
            }
        }

        #endregion Properties

        #region Private Methods

        private void LoadPrinters()
        {
            String pkInstalledPrinters;
            string CurrentLabelPrinter = XMLManipulation.GetXMLValue(XMLFile, StringConstants.XML_LABEL_PRINTER, 
                StringConstants.XML_LABEL_NAME, String.Empty);
            int PrinterID = -1;

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                cmbLabelPrinter.Items.Add(pkInstalledPrinters);

                if (pkInstalledPrinters == CurrentLabelPrinter)
                {
                    PrinterID = cmbLabelPrinter.Items.Count - 1;
                }
            }

            if (PrinterID > -1)
                cmbLabelPrinter.SelectedItem = cmbLabelPrinter.Items[PrinterID];
        }

        #endregion Private Methods
    }
}
