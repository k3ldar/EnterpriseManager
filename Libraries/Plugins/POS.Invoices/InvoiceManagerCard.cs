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
 *  File: InvoiceManagerCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;
using Languages;

using SharedBase;
using SharedBase.BOL.Users;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    public class InvoiceManagerCard : HomeCard
    {
        #region Private Members

        Controls.InvoiceManagerControl _invoiceManager;

        #endregion Private Members

        public InvoiceManagerCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewInvoiceManager));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Invoices);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.InvoiceManager);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_invoiceManager == null)
            {
                _invoiceManager = new Controls.InvoiceManagerControl();
            }

            return (_invoiceManager);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppInvoiceManager);
        }

        public override int StatusPanelCount()
        {
            return (_invoiceManager.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_invoiceManager.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_invoiceManager.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (160);
        }

        #region Private Members


        #endregion Private Members
    }
}
