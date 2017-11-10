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
 *  File: Step2.cs
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
using Library.BOL.Staff;
using POS.Base.Classes;

using POS.Staff.Classes;
using System.Globalization;

namespace POS.Staff.Controls.Wizards.Expenses
{
    public partial class Step2 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private ExpensesSettings _settings;

        private DateTime _accountYearStart;
        private decimal _totalMiles;

        #endregion Private Members

        #region Constructors

        public Step2()
        {
            InitializeComponent();

            _accountYearStart = new DateTime(DateTime.Now.Year,
                AppController.LocalSettings.AccountYearStart.Month,
                AppController.LocalSettings.AccountYearStart.Day);
            txtReason.AllowedCharacters = StringConstants.EXPENSES_ALLOWED_CHARS;
        }

        public Step2(Classes.ExpensesSettings settings)
            : this ()
        {
            _settings = settings;

            LoadExpenseTypes();

            if (_settings.Edit)
            {
                txtLocation.Text = _settings.Expense.Location;
                txtReason.Text = _settings.Expense.Reason;
                udCost.Value = _settings.Expense.ExpenseAmount;
                udQuantity.Value = _settings.Expense.ExpenseQuantity;
                udTaxPaid.Value = _settings.Expense.TaxPaid;
                dtpExpenseDate.Value = _settings.Expense.ExpenseDate;

                if (_settings.Expense.HasReceipt)
                    picReceipt.Image = _settings.Expense.Receipt;
            }
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblDate.Text = LanguageStrings.Date;
            lblLocation.Text = LanguageStrings.Location;
            lblType.Text = LanguageStrings.AppType;
            lblCost.Text = LanguageStrings.AppCost;
            lblQuantity.Text = LanguageStrings.Quantity;
            lblReason.Text = LanguageStrings.AppReason;
            lblTaxPaid.Text = LanguageStrings.AppTaxPaid;

            gbReceipt.Text = LanguageStrings.Receipt;
            btnSelect.Text = LanguageStrings.AppMenuButtonSelect;
            
            dtpExpenseDate.CustomFormat = Shared.Utilities.DateFormat(false, true);
        }

        public override void PageShown()
        {
            AppController.ActiveHelpTopic = HelpTopics.StaffCreateExpensesStep1;

            if (!_settings.Edit && cmbExpenseType.SelectedIndex == -1)
                cmbExpenseType.DroppedDown = true;

            _totalMiles = StaffExpenses.TotalMiles(_settings.Employee, _accountYearStart);
        }

        public override bool CanGoFinish()
        {
            return (udCost.Value > 0.00m);
        }

        public override bool BeforeFinish()
        {
            if (udCost.Value < 0.01m)
            {
                ShowError(LanguageStrings.Error, LanguageStrings.AppStaffExpensesInvalidCost);
                return (false);
            }

            MainWizardForm.Cursor = Cursors.WaitCursor;
            try
            {
                StaffExpense expense = null;

                if (_settings.Edit)
                {
                    expense = new StaffExpense(_settings.Expense.Id,
                        _settings.Expense.StaffId, _settings.Expense.DateCreated,
                        dtpExpenseDate.Value, txtLocation.Text, txtReason.Text,
                        (EmployeeExpenseType)cmbExpenseType.SelectedItem, udCost.Value,
                        udQuantity.Value, String.Empty, udTaxPaid.Value,
                        _settings.Expense.Status, _settings.Expense.ApprovedBy,
                        _settings.Expense.ApprovedDate);
                }
                else
                {
                    expense = new StaffExpense(-1,
                        _settings.Employee.ID, DateTime.Now,
                        dtpExpenseDate.Value, txtLocation.Text, txtReason.Text,
                        (EmployeeExpenseType)cmbExpenseType.SelectedItem, udCost.Value,
                        udQuantity.Value, String.Empty, udTaxPaid.Value,
                        EmployeeExpenseStatus.Submitted, -1, DateTime.MinValue);
                }

                if (picReceipt.Image != null)
                    expense.Receipt = picReceipt.Image;

                _settings.Expense = StaffExpenses.InsertUpdate(expense);

                return (true);
            }
            finally
            {
                MainWizardForm.Cursor = Cursors.Arrow;
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void LoadExpenseTypes()
        {
            cmbExpenseType.Items.Clear();

            foreach (EmployeeExpenseType expenseType in Enum.GetValues(typeof(EmployeeExpenseType)))
            {
                int idx = cmbExpenseType.Items.Add(expenseType);

                if (_settings.Edit && _settings.Expense.ExpenseType == expenseType)
                {
                    cmbExpenseType.SelectedIndex = idx;
                }
            }
        }

        private void cmbExpenseType_Format(object sender, ListControlConvertEventArgs e)
        {
            EmployeeExpenseType type = (EmployeeExpenseType)e.ListItem;
            e.Value = Base.EnumTranslations.Translate(type);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Image fileImage = Image.FromFile(openFileDialog1.FileName);
                fileImage = ScaleImage(fileImage, 500, 800);
                picReceipt.Image = fileImage;
            }
        }

        private void cmbExpenseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLocation.Enabled = true;
            lblReason.Enabled = true;
            txtLocation.Enabled = true;
            txtReason.Enabled = true;
            udCost.Enabled = true;
            lblCost.Enabled = true;

            if (cmbExpenseType.SelectedItem == null)
                return;

            EmployeeExpenseType type = (EmployeeExpenseType)cmbExpenseType.SelectedItem;

            switch (type)
            {
                case EmployeeExpenseType.Parking:
                case EmployeeExpenseType.Tolls:
                    lblQuantity.Text = LanguageStrings.Quantity;
                    lblQuantity.Enabled = false;
                    udQuantity.Enabled = false;
                    break;

                case EmployeeExpenseType.MealBreakfast:
                case EmployeeExpenseType.MealDinner:
                case EmployeeExpenseType.MealLunch:
                    lblLocation.Enabled = false;
                    lblReason.Enabled = false;
                    txtLocation.Enabled = false;
                    txtReason.Enabled = false;
                    lblQuantity.Text = LanguageStrings.Quantity;
                    lblQuantity.Enabled = false;
                    udQuantity.Enabled = false;
                    break;

                case EmployeeExpenseType.Mileage:
                    lblQuantity.Text = LanguageStrings.AppExpensesTotalMiles;
                    lblQuantity.Enabled = true;
                    udQuantity.Enabled = true;
                    udCost.Enabled = false;
                    lblCost.Enabled = false;
                    break;

                case EmployeeExpenseType.Lodgings:
                    lblQuantity.Text = LanguageStrings.AppExpensesNights;
                    lblQuantity.Enabled = true;
                    udQuantity.Enabled = true;
                    break;

                default:
                    lblQuantity.Text = LanguageStrings.Quantity;
                    lblQuantity.Enabled = true;
                    udQuantity.Enabled = true;
                    break;
            }

        }

        /// <summary>
        /// Resizes an image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void udCost_ValueChanged(object sender, EventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        private void udQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateMileage();
        }

        private void CalculateMileage()
        { 
            EmployeeExpenseType type = (EmployeeExpenseType)cmbExpenseType.SelectedItem;

            if (type != EmployeeExpenseType.Mileage)
                return;

            decimal totalMiles = udQuantity.Value + _totalMiles;

            if (totalMiles <= AppController.LocalSettings.ExpensesMileageFirstX)
                udCost.Value = udQuantity.Value * AppController.LocalSettings.ExpensesMileageRate1;
            else
                udCost.Value = udQuantity.Value * AppController.LocalSettings.ExpensesMileageRate2;
        }

        private void udQuantity_Leave(object sender, EventArgs e)
        {
            CalculateMileage();
        }

        private void udCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (MainWizardForm != null)
                MainWizardForm.UpdateUI();
        }

        #endregion Private Methods
    }
}
