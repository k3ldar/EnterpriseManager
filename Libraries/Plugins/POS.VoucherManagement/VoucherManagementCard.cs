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
 *  File: VoucherManagementCard.cs
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
using POS.Base.Plugins;


namespace POS.VoucherManagement
{
    public class VoucherManagementCard : HomeCard
    {
        #region Private Members

        Forms.AssignVouchers _assignVouchers;

        #endregion Private Members

        public VoucherManagementCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerVoucherManagement));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.voucher_icon_vouchers);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.VoucherAssign);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_assignVouchers == null)
            {
                _assignVouchers = new Forms.AssignVouchers();
            }

            return (_assignVouchers);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppPluginVoucherManagement);
        }

        public override int StatusPanelCount()
        {
            return (_assignVouchers.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_assignVouchers.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_assignVouchers.GetStatusHint(index));
        }

        #region Private Members


        #endregion Private Members
    }
}
