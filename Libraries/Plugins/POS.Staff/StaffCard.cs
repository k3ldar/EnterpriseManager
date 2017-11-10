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
 *  File: StaffCard.cs
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

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Staff
{
    public class StaffCard : HomeCard
    {
        #region Private Members

        Forms.AdminStaffEdit _staffEdit;

        #endregion Private Members

        public StaffCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.AdministerStaffMembers));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Staff);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            if (_staffEdit == null)
                return (String.Empty);
            else
                return (_staffEdit.GetHelpTopic());
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_staffEdit == null)
            {
                _staffEdit = new Forms.AdminStaffEdit(AppController.Administration, null);
            }

            return (_staffEdit);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppStaff);
        }

        public override int StatusPanelCount()
        {
            return (_staffEdit.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_staffEdit.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_staffEdit.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (220);
        }

        #region Private Members


        #endregion Private Members
    }
}
