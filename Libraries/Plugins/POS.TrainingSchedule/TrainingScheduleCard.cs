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
 *  File: TrainingScheduleCard.cs
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


using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Appointments;

using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.TrainingSchedule
{
    public class TrainingScheduleCard : HomeCard
    {
        #region Private Members

        Forms.TrainingScheduleForm _trainingSchedule;

        #endregion Private Members

        public TrainingScheduleCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageTrainingSchedule));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.TrainingSchedule);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.TrainingSchedule);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_trainingSchedule == null)
                _trainingSchedule = new Forms.TrainingScheduleForm();

            return (_trainingSchedule);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTrainingSchedule);
        }

        public override int StatusPanelCount()
        {
            return (_trainingSchedule.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_trainingSchedule.GetStatusText(index));
        }

        #region Internal Methods

        internal void ShowTill(Appointment appointment)
        {
            if (AppController.ActiveUser.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ViewTill))
            {
                if (HomeTabButton == null)
                    return;

                HomeTabButton.ForceClick();
            }
            else
                MessageBox.Show(String.Format(LanguageStrings.AppErrorInvalidPermissions,
                    LanguageStrings.AppPermissionViewTill),
                    LanguageStrings.AppErrorPermisions, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Internal Methods
    }
}
