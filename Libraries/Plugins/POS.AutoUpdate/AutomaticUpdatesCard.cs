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
 *  File: AutomaticUpdatesCard.cs
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

namespace POS.AutoUpdate
{
    public class AutomaticUpdatesCard : HomeCard
    {
        #region Private Members

        Forms.AutoUpdatesForm _autoUpdate;

        #endregion Private Members

        public AutomaticUpdatesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(Library.SecurityEnums.SecurityPermissionsPOS.ManageAutoUpdates));
        }
        public override Image ButtonImage()
        {
            return (Properties.Resources.AutoUpdate);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Diary);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_autoUpdate == null)
            {
                _autoUpdate = new Forms.AutoUpdatesForm();
            }

            return (_autoUpdate);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppAutoUpdateTab);
        }

        public override int StatusPanelCount()
        {
            return (_autoUpdate.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_autoUpdate.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_autoUpdate.GetStatusHint(index));
        }

        #region Private Members

        #endregion Private Members
    }
}
