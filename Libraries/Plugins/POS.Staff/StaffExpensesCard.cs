using System.Drawing;
using Languages;
using Library.BOL.Users;
using POS.Base.Plugins;

namespace POS.Staff
{
    public class StaffExpensesCard : HomeCard
    {
        #region Private Members

        Forms.StaffExpensesControl _tabFormPage;

        #endregion Private Members

        public StaffExpensesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            // always true, if user does not have permission
            // to manage expenses, then they will only see their
            // own expenses
            return (true);
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.EmployeeExpenses);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.StaffExpenses);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.StaffExpensesControl();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppStaffExpenses);
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

        public override int SortOrder()
        {
            return (230);
        }

        #region Private Members


        #endregion Private Members
    }
}
