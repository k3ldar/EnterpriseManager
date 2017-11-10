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
 *  File: RecurringInvoiceCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{
    class RecurringInvoiceCard : HomeCard
    {
        #region Private Members

        Controls.RecurringInvocesControl _recurringInvoices;

        #endregion Private Members

        #region Constructors

        public RecurringInvoiceCard(BasePlugin parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(SecurityEnums.SecurityPermissionsAccounts.CreateOrder));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.RecurringInvoices);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.RecurringInvoices);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_recurringInvoices == null)
            {
                _recurringInvoices = new Controls.RecurringInvocesControl();
            }

            return (_recurringInvoices);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCreateRecurringInvoice);
        }

        public override int StatusPanelCount()
        {
            return (_recurringInvoices.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_recurringInvoices.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_recurringInvoices.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (200);
        }

        #endregion Overridden Methods

        #region Private Members


        #endregion Private Members
    }
}
