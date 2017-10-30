using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;

using PointOfSale.Classes;

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
