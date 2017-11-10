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
 *  File: MarkAsPaidForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  08/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
