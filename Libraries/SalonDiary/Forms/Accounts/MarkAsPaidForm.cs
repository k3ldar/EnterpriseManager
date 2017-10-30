using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Heavenskincare.Library;
using Heavenskincare.Library.Utils;

namespace SalonDiary.Forms.Accounts
{
    public partial class MarkAsPaidForm : Form
    {
        private Enums.PaymentStatus _payType;

        public MarkAsPaidForm(bool IsTill)
        {
            InitializeComponent();

            cmbPaymentType.Items.Clear();

            if (IsTill)
            {
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCash);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCard);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCheque);
            }
            else
            {
                cmbPaymentType.Items.Add(Enums.PaymentStatus.PaypalPaid);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.PhonePaid);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.ChequePaid);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.PaynetPaid);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCash);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCard);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.InStorePaidCheque);
                cmbPaymentType.Items.Add(Enums.PaymentStatus.OfficePaid);
            }

            cmbPaymentType.SelectedIndex = 1;
        }

        #region Properties

        public Enums.PaymentStatus PaymentStatus
        {
            get
            {
                return (_payType);
            }
        }

        public string AdditionalPaymentInformation
        {
            get
            {
                return (txtAdditionalInformation.Text);
            }
        }

        #endregion Properties

        private void cmbPaymentType_Format(object sender, ListControlConvertEventArgs e)
        {
            Enums.PaymentStatus payType = (Enums.PaymentStatus)e.ListItem;
            HSCUtils u = new HSCUtils();
            e.Value = u.SplitCamelCase(payType.ToString().Replace("Paid", ""));
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _payType = (Enums.PaymentStatus)cmbPaymentType.Items[cmbPaymentType.SelectedIndex];
        }

    }
}
