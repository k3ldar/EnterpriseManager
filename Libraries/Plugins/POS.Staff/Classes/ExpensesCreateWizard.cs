using System;

using Languages;
using POS.Base.Classes;
using Library.BOL.Users;
using Library.BOL.Staff;
using SharedControls.WizardBase;
using POS.Staff.Controls;

namespace POS.Staff.Classes
{
    internal class ExpensesWizard
    {
        internal static bool ExpensesCreateWizard(ref StaffExpense expense)
        {
            ExpensesSettings settings = new ExpensesSettings(expense != null);
            settings.Expense = expense;

            bool Result = WizardForm.ShowWizard(LanguageStrings.AppStaffSubmitExpenses,
                new Controls.Wizards.Expenses.Step1(settings),
                new Controls.Wizards.Expenses.Step2(settings));

            if (Result)
                expense = settings.Expense;

            return (Result);
        }
    }

    public class ExpensesSettings
    {
        public ExpensesSettings(bool edit)
        {
            Edit = edit;
        }

        public bool Edit { get; private set; }

        public User Employee { get; set; }

        public StaffExpense Expense { get; set; }
    }
}
