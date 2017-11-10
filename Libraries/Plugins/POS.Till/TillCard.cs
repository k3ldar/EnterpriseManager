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
 *  File: TillCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Windows.Forms;
using Languages;

using Library;
using Library.BOL.Appointments;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.Till
{
    public class TillCard : HomeCard
    {
        #region Private Members

        Controls.TillControl _tillControl;

        #endregion Private Members

        public TillCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewTill));
        }

        public override Image ButtonImage()
        {
            return (POS.Till.Properties.Resources.TillImage);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Till);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tillControl == null)
                _tillControl = new POS.Till.Controls.TillControl();

            return (_tillControl);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTillTab);
        }

        public override int StatusPanelCount()
        {
            return (_tillControl.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tillControl.GetStatusText(index));
        }

        public override int SortOrder()
        {
            return (10);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            if (_tillControl != null)
            {
                switch (e.EventName)
                {
                    case StringConstants.PLUGIN_EVENT_TREATMENT_ADD_REMOVE_UPDATE:
                        _tillControl.TreatmentsUpdated();
                        break;

                    case StringConstants.PLUGIN_EVENT_PRODUCT_ADD_REMOVE_UPDATE:
                        _tillControl.ProductsUpdated();
                        break;
                }
            }
        }

        #region Internal Methods

        internal void ShowTill(Appointment appointment)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewTill))
            {
                if (HomeTabButton == null)
                    return;

                HomeTabButton.ForceClick();

                TabContents();
                _tillControl.TakePayment(appointment);
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionViewTill),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Internal Methods

    }
}
