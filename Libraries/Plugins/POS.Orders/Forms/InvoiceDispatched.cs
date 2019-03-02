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
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: InvoiceDispatched.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using Languages;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Invoices;

using POS.Base.Classes;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Orders.Forms
{
    public partial class InvoiceDispatched : POS.Base.Forms.BaseForm
    {
        #region Private Members

        private Invoice _CurrentInvoice;
        private User _CurrentUser;
        private bool _partialDispatch;

        #endregion Private Members

        #region Constructors

        public InvoiceDispatched(User CurrentUser, Invoice CurrentInvoice, bool partialDispatch)
        {
            _CurrentInvoice = CurrentInvoice;
            _CurrentUser = CurrentUser;
            _partialDispatch = partialDispatch;

            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.OrdersDispatchTracking;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppOrderDispatch;

            lblShippingReference.Text = LanguageStrings.AppTrackingReference;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnDispatchOrder.Text = LanguageStrings.AppMenuButtonDispatchOrder;

            btnInternal.Text = LanguageStrings.AppLocal;
            btnInternational.Text = LanguageStrings.AppInternational;

        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnInternal_Click(object sender, EventArgs e)
        {
            string Prefix = String.Empty;
            string Suffix = String.Empty;
            long UniqueNumber = 0;

            GetRecordedDeliveryLocal(ref Prefix, ref UniqueNumber, ref Suffix);
            txtTrackingReference.Text = String.Format(StringConstants.TRACKING_REFERENCE, 
                Prefix, UniqueNumber, Suffix);
        }

        private void btnInternational_Click(object sender, EventArgs e)
        {
            string Prefix = String.Empty;
            string Suffix = String.Empty;
            long UniqueNumber = 0;

            GetRecordedDeliveryInternational(ref Prefix, ref UniqueNumber, ref Suffix);
            txtTrackingReference.Text = String.Format(StringConstants.TRACKING_REFERENCE, 
                Prefix, UniqueNumber, Suffix);
        }

        private void btnDispatchOrder_Click(object sender, EventArgs e)
        {
            string stockMessage = String.Empty;

            try
            {
                if ((_CurrentInvoice.TotalCost > AppController.LocalSettings.InvoiceMinimumValueTrackingReference) &&
                    txtTrackingReference.Text.Trim() == String.Empty)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppDispatchTrackingRefBlank);
                    return;
                }

                _CurrentInvoice.TrackingReference = txtTrackingReference.Text;
                _CurrentInvoice.SetDispatched(_CurrentUser, 
                    _partialDispatch ? ProcessStatus.PartialDispatch : ProcessStatus.Dispatched, 
                    txtTrackingReference.Text);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception error)
            {
                if (error.Message.Contains(StringConstants.ERROR_LOCK_CONFLICT))
                {
                    ShowInformation(LanguageStrings.AppLockConflict, LanguageStrings.AppLockConflictStatement);
                }
                else if (error.Message.Contains(StringConstants.ERROR_STOCK_ZERO))
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppErrorStockZero +
                        StringConstants.SYMBOL_CRLF + StringConstants.SYMBOL_CRLF +
                        stockMessage);
                }
                else
                    throw;
            }
        }

        #endregion Private Methods
    }
}
