using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.Staff.Controls.Wizards.Commission.ClientPay
{
    public partial class Step1 : SharedControls.WizardBase.BaseWizardPage
    {
        #region Private Members

        private bool _canCancel = true;

        #endregion Private Members

        #region Constructors

        public Step1()
        {
            InitializeComponent();

            dtpPayDate.MinDate = DateTime.Now;
            dtpPayDate.MaxDate = DateTime.Now.AddMonths(2);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Date commission should be paid
        /// </summary>
        public DateTime PayDate 
        { 
            get
            {
                return (dtpPayDate.Value);
            }

            set
            {

                if (value < dtpPayDate.MinDate || value > dtpPayDate.MaxDate)
                    dtpPayDate.Value = DateTime.Now.AddMonths(1);
                else
                    dtpPayDate.Value = value;
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblPayClientCommissionDesc.Text = String.Format(Languages.LanguageStrings.AppCommissionClientPayDescription,
                POS.Base.Classes.AppController.LocalSettings.CommissionDueSoonDays);
            lblSelectPayDate.Text = Languages.LanguageStrings.AppCommissionPayDate;
        }

        public override bool CanCancel()
        {
            return (_canCancel);
        }

        public override bool BeforeFinish()
        {

            return (true);
        }

        #endregion Overridden Methods
    }
}
