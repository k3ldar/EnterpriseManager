using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;
using Library;
using POS.Base.Classes;
using POS.Base.Plugins;

using POS.StockControl.Controls;
using POS.Base.Forms;


namespace POS.StockControl
{
#if BUTTON_INTERFACE
    public class StockMainHomeButton : HomeButton
    {
    #region Private Members

        private POS.StockControl.Forms.MainScreenStockControl _stock;

    #endregion Private Members

    #region Constructors

        public StockMainHomeButton(BasePluginModule parent, string buttonName, 
            string description, Image image)
            : base(parent, buttonName, description, image)
        {

        }

    #endregion Constructors

    #region Overridden Methods


        public override void ButtonClicked(object sender, EventArgs e)
        {
            RaisePluginUsage(POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_STOCK);

            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewStockControl))
            {
                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.WaitCursor;

                if (_stock == null)
                {
                    _stock = new POS.StockControl.Forms.MainScreenStockControl();
                    _stock.FormClosed += new FormClosedEventHandler(stock_FormClosed);
                }

                _stock.Show();
                _stock.BringToFront();

                if (_stock.WindowState == FormWindowState.Minimized)
                    _stock.WindowState = FormWindowState.Normal;

                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppPermissionStockControl),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override string ToString()
        {
            return (POS.Base.Classes.StringConstants.PLUGIN_MODULE_NAME_STOCK);
        }

    #endregion Overridden Methods

    #region Private Methods

        private void stock_FormClosed(object sender, FormClosedEventArgs e)
        {
            _stock.Dispose();
            _stock = null;
            RaiseBringToFront();
        }

    #endregion Private Methods
    }
#endif
}
