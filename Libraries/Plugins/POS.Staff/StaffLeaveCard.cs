using System;
using System.Drawing;
using Languages;
using Library.BOL.Users;
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
