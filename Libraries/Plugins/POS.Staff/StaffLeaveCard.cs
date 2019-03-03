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
 *  File: StaffLeaveCard.cs
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
using POS.Base.Plugins;



namespace POS.Staff
{
    class StaffLeaveCard : HomeCard
    {
        #region Private Members

        Forms.ViewLeave _tabFormPage;

        #endregion Private Members

        public StaffLeaveCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // staff can always view their own leave requests
            return (true);
        }
        public override Image ButtonImage()
        {
            return (Properties.Resources.Staff_Leave);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.StaffViewLeave);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.ViewLeave();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppStaffLeave);
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
            return (225);
        }

        #region Private Members


        #endregion Private Members
    }
}
