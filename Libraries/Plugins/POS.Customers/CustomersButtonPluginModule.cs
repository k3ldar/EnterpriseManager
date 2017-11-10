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
 *  File: CustomersButtonPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  24/08/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using SharedControls.Forms;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

using POS.Customers.Forms;

namespace POS.Customers
{
#if BUTTON_INTERFACE
    public class CustomersButtonPluginModule : HomeButton
    {
    #region Private Members

        private CustomerSearch _customerSearch;

    #endregion Private Members

    #region Constructors

        public CustomersButtonPluginModule(BasePluginModule parent, string buttonName,
            string description, Image image)
            : base(parent, buttonName, description, image)
        {

        }

    #endregion Constructors

    #region Overridden Methods


        public override void ButtonClicked(object sender, EventArgs e)
        {
            RaisePluginUsage(StringConstants.PLUGIN_MODULE_NAME_CUSTOMERS);

            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.SearchUsers))
            {
                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.WaitCursor;
                
                if (_customerSearch == null)
                {
                    _customerSearch = new CustomerSearch();
                    _customerSearch.FormClosed += new FormClosedEventHandler(customerSearch_FormClosed);
                }

                _customerSearch.Show();

                if (_customerSearch.WindowState != FormWindowState.Normal)
                    _customerSearch.WindowState = FormWindowState.Normal;

                _customerSearch.BringToFront();

                if (_customerSearch.WindowState == FormWindowState.Minimized)
                    _customerSearch.WindowState = FormWindowState.Normal;

                if (Parent.ParentForm != null)
                    Parent.ParentForm.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissionView,
                    LanguageStrings.AppSearchCustomers),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public override string ToString()
        {
            return (StringConstants.PLUGIN_MODULE_NAME_CUSTOMERS);
        }

    #endregion Overridden Methods

    #region Private Methods

        private void customerSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            _customerSearch.Dispose();
            _customerSearch = null;
            RaiseBringToFront();
        }

    #endregion Private Methods
    }
#endif
}
