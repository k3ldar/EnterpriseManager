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
 *  File: GenerateRecurringInvoiceThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;

using SharedBase;
using SharedBase.BOL.Accounts;
using SharedBase.BOL.Basket;
using SharedBase.BOL.Mail;
using SharedBase.BOL.Invoices;
using SharedBase.BOL.Orders;

using POS.Base.Classes;
using Reports.Accounts;
using Shared;

#pragma warning disable IDE0017

namespace POS.Invoices.Classes
{
    internal sealed class GenerateRecurringInvoiceThread : Shared.Classes.ThreadManager
    {
        #region Constructors

        internal GenerateRecurringInvoiceThread()
            : base(null, new TimeSpan(1, 0, 0))
        {
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            foreach (RecurringInvoice invoice in RecurringInvoices.All())
            {
                if (invoice.NextRun < DateTime.Now)
                {
                    Order newOrder = GenerateOrder(invoice);

                    if (newOrder != null)
                    {
                        EventLog.Add(String.Format(StringConstants.EVENT_LOG_RECURR_INV_GENERATED, 
                            newOrder.ID, invoice.ToString()));
                        invoice.NextRun = NextOccurance(invoice);
                        invoice.Save();

                        if (invoice.Options.HasFlag(RecurringInvoiceOptions.SendEmail))
                        {
                            SendEmailInvoice(invoice, newOrder);
                        }
                    }
                }
            }

            return (!HasCancelled());
        }

        #endregion Overridden Methods

        #region Private Methods

        private void SendEmailInvoice(RecurringInvoice invoice, Order order)
        {
            PDFOrder report = new PDFOrder(
                order, AppController.LocalSettings.InvoiceHeaderRight,
                AppController.LocalSettings.InvoiceFooter, 
                AppController.LocalSettings.InvoiceAddress,
                AppController.LocalSettings.InvoiceVATRegistrationNumber,
                AppController.LocalSettings.CustomCulture,
                SharedBase.DAL.DALHelper.HideVATOnWebsiteAndInvoices,
                AppController.LocalSettings.InvoiceShowProductDiscount,
                AppController.LocalSettings.InvoiceFooterInvoiceDue,
                AppController.LocalSettings.InvoicePrefix);
            string fileName = report.FileName;

            if (File.Exists(fileName))
            {
                SendOrderEmail(invoice, order, fileName);
                File.Delete(fileName);
            }
        }

        private void SendOrderEmail(RecurringInvoice invoice, Order order, string filename)
        {
            Shared.Communication.Email mailClient = new Shared.Communication.Email();

            SystemEmail email = SystemEmails.Get(SystemEmailType.RecurringInvoiceCreated);

            if (email.AllowSend)
            {
                if (mailClient.SendEmail(mailClient.User, invoice.Customer.UserName, invoice.Customer.Email,
                    email.Format(order),
                    email.Subject,
                    true,
                    filename))
                {
                    EventLog.Add(String.Format(StringConstants.EVENT_LOG_RECURR_INV_SENT,
                        order.ID, invoice.ToString()));
                }
                else
                {
                    EventLog.Add(String.Format(StringConstants.EVENT_LOG_RECURR_INV_NOT_SENT,
                        order.ID, invoice.ToString()));
                }
            }
        }

        private Order GenerateOrder(RecurringInvoice invoice)
        {
            ShoppingBasket basket = new ShoppingBasket(AppController.LocalCountry, 
                AppController.LocalCurrency,
                AppController.LocalSettings.ShippingIsTaxable);
            try
            {
                basket.IgnoreBasketQuantityRestrictions = true;
                basket.IgnoreCostMultiplier = true;
                basket.IgnoreAutoDiscount = true;
                basket.User = invoice.Customer;
                basket.UseSageDiscountLogic = true;
                basket.ShippingCosts = 0;

                if (invoice.Discount > 0)
                {
                    basket.ApplyDiscount(invoice.Discount, StringConstants.STORE_DISCOUNT);
                }

                foreach (RecurringInvoiceItem item in invoice.Items)
                {
                    basket.Add(item.ProductItem, item.Quantity, invoice.Customer, item.ProductItem.ItemType, 0);
                }

                Order Result = basket.ConvertToOrder(
                    PaymentStatuses.Get(StringConstants.PAYMENT_OFFICE_NOT_PAID), 
                    invoice.Customer.Email,
                    StringConstants.PAYMENT_OFFICE,
                    AppController.LocalSettings.CustomCulture);

                return (Result);
            }
            catch (Exception err)
            {
                EventLog.Add(err, invoice.ToString());
            }
            finally
            {
                basket = null;
            }

            return (null);
        }

        private DateTime NextOccurance(RecurringInvoice invoice)
        {
            switch (invoice.Type)
            {
                case RecurringType.Day:
                    return (invoice.NextRun.AddDays(invoice.Frequency));

                case RecurringType.Month:
                    return (invoice.NextRun.AddMonths(invoice.Frequency));

                case RecurringType.Week:
                    return (invoice.NextRun.AddDays(invoice.Frequency * 7));

                case RecurringType.Year:
                    return (invoice.NextRun.AddYears(invoice.Frequency));

                default:
                    throw new Exception(StringConstants.ERROR_INVALID_TYPE);
            }
        }

        #endregion Private Methods
    }
}
