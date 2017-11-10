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
 *  File: TextMagic.cs
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

using Library.BOL.Countries;
using POS.Base.Classes;

namespace POS.Diary.Controls
{
    public partial class TextMagic : SharedControls.BaseSettings
    {
        #region Constructors

        public TextMagic()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAPIKey.Text = Languages.LanguageStrings.AppAPIKeyInput;
            lblSenderName.Text = Languages.LanguageStrings.AppSenderName;
            lblUserName.Text = Languages.LanguageStrings.Username;
        }

        public override bool SettingsSave()
        {
            AppController.LocalSettings.TextMagicAPI = txtAPIKEy.Text;
            AppController.LocalSettings.TextMagicSender = txtSenderName.Text;
            AppController.LocalSettings.TextMagicUsername = txtUserName.Text;

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            txtAPIKEy.Text = AppController.LocalSettings.TextMagicAPI;
            txtSenderName.Text = AppController.LocalSettings.TextMagicSender;
            txtUserName.Text = AppController.LocalSettings.TextMagicUsername;
        }

        #endregion Overridden Methods
    }
}
