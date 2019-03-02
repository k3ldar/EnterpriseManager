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
 *  File: OnlineTreatmentGroupsCard.cs
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

namespace POS.WebsiteAdministration
{
    class OnlineTreatmentGroupsCard : HomeCard
    {
        #region Private Members

        Forms.Treatments.AdminTreatmentGroups _tabFormPage;

        #endregion Private Members

        public OnlineTreatmentGroupsCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // if there are no websites, then don't show
            if (WebsiteAdministrationPluginModule.WebsiteCount == 0)
                return (false);

            return (user.HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AdministerTreatmentGroups));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.OnlineTreatmentGroups);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.WebTreatmentGroups);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Treatments.AdminTreatmentGroups();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTreatmentGroupsOnline);
        }

        public override int StatusPanelCount()
        {
            return (_tabFormPage.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tabFormPage.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tabFormPage.GetStatusHint(index));
        }

        public override Color ButtonFromColor()
        {
            return (Color.Purple);
        }

        public override Color ButtonToColor()
        {
            return (Color.MediumPurple);
        }

        public override int SortOrder()
        {
            return (30010);
        }

        #region Private Members


        #endregion Private Members
    }
}
