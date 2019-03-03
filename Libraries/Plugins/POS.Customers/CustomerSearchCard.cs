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
 *  File: CustomerSearchCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using Languages;
using SharedBase.BOL.Users;
using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.Customers
{
    public class CustomerSearchCard : HomeCard
    {
        #region Private Members

        POS.Customers.Controls.CustomerSearchControl _searchControl;

        #endregion Private Members

        public CustomerSearchCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SharedBase.SecurityEnums.SecurityPermissionsPOS.SearchUsers));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Users);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_searchControl == null)
                _searchControl = new POS.Customers.Controls.CustomerSearchControl();

            return (_searchControl);
        }

        public override string HepString()
        {
            return (HelpTopics.CustomerSearch);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCustomerTab);
        }

        public override int StatusPanelCount()
        {
            return (_searchControl.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_searchControl.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_searchControl.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (100);
        }
    }
}
