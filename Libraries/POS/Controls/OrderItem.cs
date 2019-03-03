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
 *  File: OrderItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;

using SharedBase.BOL.Invoices;
using POS.Base.Classes;

using Languages;
using SharedBase;

#pragma warning disable IDE1005 // Delegate invocation can be simplified
#pragma warning disable IDE0017 // object initialization can be simplified
#pragma warning disable IDE0029 // Null checks can be simplified
#pragma warning disable IDE1006 // naming rule violation
#pragma warning disable IDE0016 // null check simplified

namespace POS.Base.Controls
{
    public partial class OrderItem : SharedControls.BaseControl
    {
        #region Constructor

        public OrderItem()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Status of item within the order
        /// </summary>
        public ProcessItemStatus ItemStatus { get; set; }

        public bool IsReady
        {
            get
            {
                return (ItemStatus == ProcessItemStatus.Dispatched || 
                    ItemStatus == ProcessItemStatus.Dispatching ||
                    ItemStatus == ProcessItemStatus.OnHold);
            }
        }

        public int DescriptionWidth
        {
            get
            {
                return (lblProduct.Width);
            }
        }

        public string ProductDescription
        {
            get
            {
                return (lblProduct.Text);
            }
        }

        public int AvailableStock { get; private set; }

        /// <summary>
        /// ID Of item being manipulated
        /// </summary>
        public int ItemID { get; private set; }

        #endregion Properties

        #region Overridden Methods

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnAdd.Text = Languages.LanguageStrings.Packed;
            btnNotSent.Text = Languages.LanguageStrings.OnHold;
        }

        #endregion Overridden Methods

        #region Public Methods

        public void Refresh(int availableStock, InvoiceItem item)
        {
            string description = item.Description;

            if (AppController.LocalSettings.InvoiceShowProductDiscount && item.UserDiscount > 0.00m)
            {
                description = String.Format(LanguageStrings.AppProductDiscount, description, item.UserDiscount);
            }

            AvailableStock = availableStock;
            lblProduct.Text = description;
            lblQuanity.Text = item.Quantity.ToString();
            lblSKU.Text = item.SKU;
            ItemID = item.ID;


            switch (item.ItemType)
            {
                case ProductCostItemType.FreeProduct:
                case ProductCostItemType.Product:
                case ProductCostItemType.Voucher:
                    btnAdd.Enabled = AvailableStock >= item.Quantity;
                    if (AvailableStock < item.Quantity)
                    {
                        this.ForeColor = Color.Red;
                    }

                    break;
                default:
                    btnAdd.Enabled = false;
                    btnNotSent.Enabled = false;
                    ForeColor = Color.DarkGray;
                    break;
            }

            switch (item.ItemStatus)
            {
                case ProcessItemStatus.Dispatched:
                case ProcessItemStatus.Cancelled:
                case ProcessItemStatus.Refund:
                case ProcessItemStatus.Returned:
                    Font newFont = new Font(Font.FontFamily, this.Font.Size, FontStyle.Strikeout);
                    lblProduct.Font = newFont;
                    lblQuanity.Font = newFont;
                    lblSKU.Font = newFont;
                    btnNotSent.Font = newFont;
                    btnAdd.Font = newFont;
                    btnAdd.Enabled = false;
                    btnNotSent.Enabled = false;
                    ItemStatus = item.ItemStatus;
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ItemStatus = ProcessItemStatus.Dispatching;

            RaiseItemStatusChanged();
        }

        private void btnNotSent_Click(object sender, EventArgs e)
        {
            ItemStatus = ProcessItemStatus.OnHold;

            RaiseItemStatusChanged();
        }

        private void RaiseItemStatusChanged()
        {
            btnAdd.Enabled = false;
            btnNotSent.Enabled = false;

            if (OnItemStatusChanged != null)
                OnItemStatusChanged(this, EventArgs.Empty);
        }

        #endregion Private Methods

        #region Events

        public event EventHandler OnItemStatusChanged;

        #endregion Events
    }
}
