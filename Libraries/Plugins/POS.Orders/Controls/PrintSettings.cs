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
