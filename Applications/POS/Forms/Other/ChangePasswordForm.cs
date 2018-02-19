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
 *  File: ChangePasswordForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using POS.Base.Classes;

#pragma warning disable IDE1006

namespace PointOfSale.Forms.Other
{
    public partial class ChangePasswordForm : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private bool _forceChange;
        private string _currentPassword;

        #endregion Private Members

        #region Constructors

        public ChangePasswordForm(bool forceChange)
        {
            InitializeComponent();

            _forceChange = forceChange;
            _currentPassword = AppController.ActiveUser.Password;
        }

        #endregion Constructors

        #region  Static Methods

        public static void ChangePassword(bool forceChange)
        {
            ChangePasswordForm frm = new ChangePasswordForm(forceChange);
            try
            {
                frm.ShowDialog();
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Static Methods

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ChangePassword;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppPasswordChange;

            lblConfirmPassword.Text = LanguageStrings.AppPasswordConfirm;
            lblNewPassword.Text = LanguageStrings.AppPasswordNew;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                AppController.ActiveUser.Password = txtNewPassword.Text;

                if (_forceChange)
                {
                    if (AppController.ActiveUser.Password == _currentPassword)
                    {
                        ShowError(LanguageStrings.AppError, LanguageStrings.AppPasswordMustBeChanged);
                    }
                    else
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                ShowError(LanguageStrings.AppError, err.Message);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (txtNewPassword.Text.Length > 5 && 
                txtNewPassword.Text == txtConfirmNewPassword.Text) &&
                (_forceChange ? txtConfirmNewPassword.Text != _currentPassword : true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_forceChange)
            {
                if (AppController.ActiveUser.Password == _currentPassword)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppPasswordMustBeChanged);
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        #endregion Private Methods
    }
}
