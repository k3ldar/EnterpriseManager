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
 *  File: TherapistTakings.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Library;

namespace SharedBase.BOL.Therapists
{
    [Serializable]
    public sealed class TherapistTakings : BaseObject
    {
        #region Private Members

        private string _paymentType;

        #endregion Private Members

        #region Constructors

        public TherapistTakings(Therapist therapist, DateTime startDate, DateTime endDate, decimal invoiceTotal, decimal voucherTotal,
            decimal discountTotal, decimal cash, decimal card, decimal cheque, decimal products, decimal treatments, int invoiceCount)
        {
            Therapist = therapist;
            StartDate = startDate;
            EndDate = endDate;
            InvoiceTotal = invoiceTotal;
            VoucherTotal = voucherTotal;
            DiscountTotal = discountTotal;
            Cash = cash;
            Card = card;
            Cheque = cheque;
            Products = products;
            Treatments = treatments;
            InvoiceCount = invoiceCount;

            if (Cash > 0.00m)
            {
                _paymentType =  "Cash";
            }
            else
            {
                if (Cheque > 0.00m)
                    _paymentType = "Cheque";
                else
                    _paymentType = "Card";
            }

        }

        public TherapistTakings(Therapist therapist, DateTime startDate, DateTime endDate, decimal invoiceTotal, decimal voucherTotal,
            decimal discountTotal, decimal cash, decimal card, decimal cheque, decimal products, decimal treatments, Int64 invoiceID,
            decimal itemCost, int itemCount, string item)
        {
            Therapist = therapist;
            StartDate = startDate;
            EndDate = endDate;
            InvoiceTotal = invoiceTotal;
            VoucherTotal = voucherTotal;
            DiscountTotal = discountTotal;
            Cash = cash;
            Card = card;
            Cheque = cheque;
            Products = products;
            Treatments = treatments;
            InvoiceID = invoiceID;
            ItemCost = itemCost;
            ItemCount = itemCount;
            Item = item;

            if (Cash > 0.00m)
            {
                _paymentType = "Cash";
            }
            else
            {
                if (Cheque > 0.00m)
                    _paymentType = "Cheque";
                else
                    _paymentType = "Card";
            }
        }

        public TherapistTakings(Int64 invoiceID, DateTime date, string therapistName, 
            string customerName, decimal totalCost, string paymentType)
        {
            InvoiceID = invoiceID;
            StartDate = date;
            TherapistName = therapistName;
            CustomerName = customerName;
            InvoiceTotal = totalCost;
            _paymentType = paymentType;
        }

        public TherapistTakings(string item, int count, ProductCostItemType type)
        {
            Item = item;
            ItemType = type;
            Count = count;
        }

        /// <summary>
        /// Constructor - Therapist takings for products by date range
        /// 
        /// valid properties are:
        /// TherapistName
        /// Item
        /// ItemCount
        /// ItemCost
        /// </summary>
        /// <param name="therapistName">Name of therapist</param>
        /// <param name="productName">Name of product</param>
        /// <param name="quantitySold">Quantity Sold</param>
        /// <param name="totalSaleValue">Total Takings</param>
        public TherapistTakings(string therapistName, string productName, 
            int quantitySold, decimal totalSaleValue)
        {
            TherapistName = therapistName;
            Item = productName;
            ItemCount = quantitySold;
            ItemCost = totalSaleValue;
        }

        #endregion Constructors

        #region Properties

        public Therapist Therapist { get; set; }

        public string TherapistName { get; set; }

        public string CustomerName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Int64 InvoiceID { get; set; }

        public decimal InvoiceTotal { get; set; }

        public decimal VoucherTotal { get; set; }

        public decimal DiscountTotal { get; set; }

        public decimal Cash { get; set; }

        public decimal Card { get; set; }

        public decimal Cheque { get; set; }

        public decimal Products { get; set; }

        public decimal Treatments { get; set; }

        public int InvoiceCount { get; set; }

        public decimal ItemCost { get; set; }

        public int ItemCount { get; set; }

        public string Item { get; set; }

        public string SaleType
        {
            get
            {
                return (_paymentType);
            }
        }

        public ProductCostItemType ItemType { get; set; }

        public int Count { get; set; }

        #endregion Properties
    }
}
