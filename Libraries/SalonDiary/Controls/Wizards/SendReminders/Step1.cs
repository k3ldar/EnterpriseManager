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
 *  File: Step1.cs
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

using SalonDiary.Classes;
using Languages;
using Library.BOL.Therapists;
using Library.BOL.Appointments;
using SharedControls.WizardBase;

namespace SalonDiary.Controls.Wizards.SendReminders
{
    public partial class Step1 : BaseWizardPage
    {
        #region Private Members

        private NewSendAppointmentOptions _options;

        #endregion Private Members

        #region Constructors

        public Step1(NewSendAppointmentOptions options)
        {
            InitializeComponent();
            _options = options;
            txtMessage_TextChanged(this, EventArgs.Empty);
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblHeader.Text = LanguageStrings.AppDiaryReminderHeader;
            lblInstructions.Text = LanguageStrings.AppDiaryReminderDetails;
        }

        public override bool NextClicked()
        {
            if (String.IsNullOrEmpty(txtMessage.Text))
            {
                ShowError(LanguageStrings.AppError, LanguageStrings.AppDiaryReminderMessageEmpty);
            }

            _options.Message = txtMessage.Text;
            Shared.Utilities.FileWrite(Shared.Utilities.AddTrailingBackSlash(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + StringConstants.SMS_FILE, txtMessage.Text);
            return base.NextClicked();
        }

        public override void PageShown()
        {
            string message = Shared.Utilities.FileRead(Shared.Utilities.AddTrailingBackSlash(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + StringConstants.SMS_FILE, false);

            if (!String.IsNullOrEmpty(message))
                txtMessage.Text = message;
        }

        public override void LoadFromFile(string fileName)
        {
            txtMessage.Text = "";
        }

        public override void SaveToFile(string fileName)
        {
            base.SaveToFile(fileName);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            lblSize.Text = String.Format(StringConstants.CHARACTER_LENGTH, txtMessage.Text.Length,
                txtMessage.MaxLength, Languages.LanguageStrings.AppCharacters);
        }

        private void btnSpellCheck_Click(object sender, EventArgs e)
        {
            //SharedControls.SpellChecker.SpellChecker.ShowSpellChecker(this,
            //    AppController.LocalSettings.CustomDictionary,
            //    AppController.POSFolder(FolderType.Dictionary, true),
            //    txtProductName, productEditTextDescription.TextBox, productEditTextFeatures.TextBox,
            //    productEditTextHowToUse.TextBox, productEditTextIngredients.TextBox);

        }

        #endregion Private Methods
    }
}
