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
 *  File: InvoiceItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using SharedBase.Utils;
using SharedBase.BOL.Users;
using SharedBase.BOL.Products;

namespace SharedBase.BOL.Invoices
{
    [Serializable]
    public sealed class InvoiceItem : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Description;
        private decimal _Cost;
        private decimal _Quantity;
        private decimal _Price;
        private int _ItemID;
        private ProductCostItemType _ItemType;
        private string _SKU;
        private Int64 _StaffMember;
        private ProductCostType _ProductCostType;
        private Invoice _invoice;
        private User _staffMember;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public InvoiceItem(int ID, string Description, decimal Cost, decimal Quantity,
            decimal Price, int ItemID, ProductCostItemType ItemType, string SKU, 
            int StaffMember, ProductCostType ProductCostType, Invoice invoice,
            decimal userDiscount, decimal productDiscount, ProcessItemStatus itemStatus)
        {
            _ID = ID;
            _Description = Description.Replace("()", "");
            _Cost = Cost;
            _Quantity = Quantity;
            _Price = Price;
            _ItemID = ItemID;
            _ItemType = ItemType;
            _SKU = SKU;
            _StaffMember = StaffMember;
            _ProductCostType = ProductCostType;
            _invoice = invoice;
            UserDiscount = userDiscount;
            ProductDiscount = productDiscount;
            ItemStatus = itemStatus;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID
        {
            get
            {
                return (_ID);
            }
        }

        public string Description
        {
            get
            {
                return (_Description);
            }
        }

        public string CostStr
        {
            get
            {
                return (SharedUtils.FormatMoney(Cost, _invoice.Currency));
            }
        }

        public string PriceStr
        {
            get
            {
                return (SharedUtils.FormatMoney(Price, _invoice.Currency));
            }
        }

        public string DiscountStr
        {
            get
            {
                return (SharedUtils.FormatMoney(Discount, _invoice.Currency));
            }
        }

        public string VatStr
        {
            get
            {
                return (SharedUtils.FormatMoney(SharedUtils.VATCalculate(Price, _invoice.VATRate), 
                    _invoice.Currency, false, true));
            }
        }

        public decimal Discount
        {
            get
            {
                return (UserDiscount + ProductDiscount);
            }
        }

        public decimal ProductDiscountValue
        {
            get
            {
                if (ProductDiscount > 0)
                    return ((((_Cost * (decimal)_invoice.CostMultiplier) * (decimal)Quantity) / 100) * ProductDiscount);
                else
                    return (0);
            }
        }

        public decimal UserDiscountValue
        {
            get
            {
                if (UserDiscount == 0)
                    return (0);

                decimal Result = _Cost * (decimal)Quantity;

                if (ProductDiscount > 0.0m)
                {
                    Result = (Result - ((Result / 100) * ProductDiscount));
                }

                if (_invoice.Options.HasFlag(InvoiceOptions.SageDiscountType))
                {
                    if (_invoice.Discount > 0 && _invoice.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        Result = Result - ((Result / 100) * (decimal)_invoice.Discount);
                    }

                    if (UserDiscount > 0)
                    {
                        Result = ((Result / 100) * UserDiscount);
                    }
                }
                else
                {
                    if (UserDiscount > 0.00m)
                    {
                        Result = ((Result / 100) * UserDiscount);
                    }
                }

                return (Result);
            }
        }

        public decimal Cost
        {
            get
            {
                return (_Cost * (decimal)_invoice.CostMultiplier);
            }
        }

        public decimal DiscountCost
        {
            get
            {
                decimal Result = _Cost * (decimal)_invoice.CostMultiplier;

                if (ProductDiscount > 0.0m)
                {
                    Result = (Result - ((Result / 100) * ProductDiscount));
                }

                if (_invoice.Options.HasFlag(InvoiceOptions.SageDiscountType))
                {
                    if (_invoice.Discount > 0 && _invoice.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        Result = Result - ((Result / 100) * (decimal)_invoice.Discount);
                    }

                    if (UserDiscount > 0)
                    {
                        Result = Result - ((Result / 100) * UserDiscount);
                    }
                }
                else
                {
                    decimal totalDiscount = UserDiscount;

                    if (_invoice.Discount > 0 && _invoice.VoucherType == Enums.InvoiceVoucherType.Percent)
                    {
                        totalDiscount += (decimal)_invoice.Discount;
                    }

                    if (totalDiscount > 0.00m)
                    {
                        Result = Result - ((Result / 100) * totalDiscount);
                    }
                }

                return (Result);
            }
        }

        public decimal Quantity
        {
            get
            {
                return (_Quantity);
            }
        }


        public decimal Price
        {
            get
            {
                decimal Result = _Price;

                if (ProductDiscount > 0.00m)
                {
                    Result = Result - ((Result / 100) * ProductDiscount);
                }

                if (UserDiscount > 0.00m)
                {
                    Result = Result - ((Result / 100) * UserDiscount);
                }

                return (Result * (decimal)_invoice.CostMultiplier);
            }
        }

        public int ItemID
        {
            get
            {
                return (_ItemID);
            }
        }

        public ProductCostItemType ItemType
        {
            get
            {
                return (_ItemType);
            }
        }

        public string SKU
        {
            get
            {
                return (_SKU);
            }
        }

        /// <summary>
        /// Staff member making the sale
        /// </summary>
        public User StaffMember
        {
            get
            {
                if (_StaffMember > -1 && _staffMember == null)
                    _staffMember = User.UserGet(_StaffMember);

                return (_staffMember);
            }
        }


        public Int64 StaffMemberID
        {
            get
            {
                return (_StaffMember);
            }

            set
            {
                _StaffMember = value;

                _staffMember = User.UserGet(value);

                DAL.FirebirdDB.InvoiceItemUpdateSalesPerson(this, _staffMember);
            }
        }

        public ProductCostType ProductCostType
        {
            get
            {
                return (_ProductCostType);
            }
        }

        /// <summary>
        /// Product Discount given to product at time of sale
        /// </summary>
        public decimal ProductDiscount { get; private set; }

        /// <summary>
        /// Percentage of discount given to user for this item
        /// </summary>
        public decimal UserDiscount { get; private set; }

        /// <summary>
        /// Status of item within the invoice
        /// </summary>
        public ProcessItemStatus ItemStatus { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("InvoiceItem: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods

    }
}