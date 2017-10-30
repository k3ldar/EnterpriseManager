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
