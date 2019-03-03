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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CreateOrderCard.cs
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

using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE1017 // Object Initialization can be simplified

namespace POS.Invoices
{ 
    public class CreateOrderCard : HomeCard
    {
        #region Private Members

        Forms.CreateOrder _createOrder;

        #endregion Private Members

        #region Constructors

        public CreateOrderCard(BasePlugin parent)
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
            return (Properties.Resources.Orders);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.InvoiceCreateOrder);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_createOrder == null)
            {
                _createOrder = new Forms.CreateOrder();
            }

            return (_createOrder);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCreateInvoice);
        }

        public override int StatusPanelCount()
        {
            return (_createOrder.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_createOrder.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_createOrder.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (190);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            if (e.EventName == StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE)
            {
                if (_createOrder != null)
                    _createOrder.ProductsUpdated();
            }
        }

        #endregion Overridden Methods

        #region Private Members


        #endregion Private Members
    }
}
