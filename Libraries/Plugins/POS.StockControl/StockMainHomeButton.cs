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
 *  File: StockMainHomeButton.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  23/08/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
