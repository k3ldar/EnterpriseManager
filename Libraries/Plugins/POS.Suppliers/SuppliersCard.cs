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
 *  File: SuppliersCard.cs
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

namespace POS.Suppliers
{
    public class SuppliersCard : HomeCard
    {
        #region Private Members

        private SuppliersListTab _supplierTab;

        #endregion Private Members

        public SuppliersCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionAccounts(Library.SecurityEnums.SecurityPermissionsAccounts.ViewSuppliers));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Suppliers);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Suppliers);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            if (_supplierTab == null)
                _supplierTab = new SuppliersListTab();

            return (_supplierTab);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppSuppliers);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int SortOrder()
        {
            return (350);
        }

        public override bool OwnerDrawn()
        {
            return (false);
        }

        #region Private Members


        #endregion Private Members
    }
}
