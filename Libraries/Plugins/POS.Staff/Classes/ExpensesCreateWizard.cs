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
 *  File: ExpensesCreateWizard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;
using POS.Base.Classes;
using SharedBase.BOL.Users;
using SharedBase.BOL.Staff;
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
