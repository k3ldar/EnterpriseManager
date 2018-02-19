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
 *  File: MainScreenPOS.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;
using Library.BOL.Appointments;
using Library.BOL.Users;

using POS.Base.Classes;

namespace POS.Till.Forms
{
    public partial class MainScreenPOS : POS.Base.Forms.BaseForm
    {
        #region Constructors / Destructors

        public MainScreenPOS()
        {
            InitializeComponent();
        }

        public MainScreenPOS(User user)
            : this()
        {
            AppController.ApplicationController.BarcodeReceived += User_BarcodeReceived;
        }

        #endregion Constructors / Destructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.Till;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            tillControl.OnFocus(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tillControl.OnFocus(e);
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            Text = String.Format(LanguageStrings.AppPointOfSale, AppController.ActiveUser.UserName);
        }

        protected override void LoadSettings()
        {
            tillControl.LoadTillSettings();
        }

        protected override void SaveSettings()
        {
            tillControl.SaveSettings();
        }

        #endregion Overridden Methods

        #region Public Methods

        public void TakePayment(Appointment appointment)
        {
            tillControl.TakePayment(appointment);
        }

        #endregion Public Methods

        #region Private Methods

        #region AppControler Events

        private void User_BarcodeReceived(object sender, AppController.BarcodeEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AppController.BarcodeHandler eh = new AppController.BarcodeHandler(User_BarcodeReceived);
                this.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                if (e.Barcode.StartsWith(StringConstants.TILL_BARCODE_PREFIX_HV))
                {
                    if (Form.ActiveForm == this)
                        ShowError(LanguageStrings.Error, LanguageStrings.AppTillNoScanVoucher);
                }
                else
                {
                    if (Form.ActiveForm == this && !e.Barcode.StartsWith(StringConstants.TILL_BARCODE_PREFIX_HHB))
                    {
                        tillControl.BarcodeReceived(sender, e);
                    }
                }
            }
        }

        #endregion AppControler Events


        #region Form

        private void MainScreenPOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppController.ApplicationController.BarcodeReceived -= User_BarcodeReceived;
        }

        private void MainScreen_Activated(object sender, EventArgs e)
        {
            MainScreenPOS_ResizeEnd(sender, e);
        }

        private void MainScreen_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                MainScreenPOS_ResizeEnd(sender, e);
        }

        private void MainScreenPOS_ResizeEnd(object sender, EventArgs e)
        {
            tillControl.ResizeEnd(sender, e);
        }

        #endregion form

        #endregion Private Methods
    }
}
