using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;
using Library.BOL.Appointments;
using Library.BOL.Basket;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Till.Forms;


namespace POS.Till
{
#if BUTTON_INTERFACE
    public class TillButtonPluginModule : HomeButton
    {
    #region Private Members

        internal Forms.MainScreenPOS _till;

    #endregion Private Members

    #region Constructors

        public TillButtonPluginModule(BasePluginModule parent, string buttonName, string description, Image image)
            : base(parent, buttonName, description, image)
        {

        }

    #endregion Constructors

    #region Overridden Methods

        public override void ButtonClicked(object sender, EventArgs e)
        {
            ShowTill(null);
        }

        public override string ToString()
        {
            return (POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_TILL);
        }

    #endregion Overridden Methods

    #region Internal Methods

        internal void ShowTill(Appointment appointment)
        {
            RaisePluginUsage(POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_TILL);

            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewPOS))
            {
                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.WaitCursor;

                if (_till == null)
                {
                    _till = new POS.Till.Forms.MainScreenPOS(AppController.ActiveUser);
                    _till.FormClosed += new FormClosedEventHandler(till_FormClosed);
                }

                _till.Show();

                if (appointment != null)
                    _till.TakePayment(appointment);

                _till.BringToFront();

                if (_till.WindowState == FormWindowState.Minimized)
                    _till.WindowState = FormWindowState.Normal;

                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionViewTill), 
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    #endregion Internal Methods

    #region Private Methods

        private void till_FormClosed(object sender, FormClosedEventArgs e)
        {
            _till.Dispose();
            _till = null;
            RaiseBringToFront();
        }

    #endregion Private Methods
    }
#endif
}
