using System;
using System.Drawing;
using System.Windows.Forms;
using Languages;


using Library;
using Library.BOL.Users;
using Library.BOL.Appointments;

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
