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
 *  File: StockItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Threading;

using Library.BOL.Products;

namespace Library.BOL.StockControl
{
    [Serializable]
    public sealed class StockItem
    {
        #region Private / Protected Members

        private int _ID;
        private string _SKU;
        private string _Name;
        private string _Size;
        private int _Available;
        private int _MinLevel;
        private decimal _OrderQuantity;
        private int _StoreID;
        private ProductCostType _ProductType;
        private bool _hideGlobally;
        private bool _outOfStock;
        private bool _autoRestock;
        private string _location;
        private bool _Changed;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public StockItem(int id, string sku, string name, string size, int available, int minLevel,
            decimal orderQuantity, int storeID, ProductCostType productType, decimal cost, bool hideGlobally,
            bool outOfStock, bool autoRestock, string location)
            : this (id, sku, name, size, available, minLevel, orderQuantity, storeID, productType, 
                  hideGlobally, outOfStock, autoRestock, location)
        {
            Cost = cost;
        }

        public StockItem(int id, string sku, string name, string size, int available, int minLevel,
            decimal orderQuantity, int storeID, ProductCostType productType, bool hideGlobally,
            bool outOfStock, bool autoRestock, string location)
        {
            _ID = id;
            _SKU = sku;
            _Name = name;
            _Size = size;
            _Available = available;
            _MinLevel = minLevel;
            _OrderQuantity = orderQuantity;
            _Changed = false;
            _StoreID = storeID;
            _ProductType = productType;
            _hideGlobally = hideGlobally;
            Cost = 0.00m;
            OutOfStock = outOfStock;
            _autoRestock = autoRestock;
            _location = location;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int StoreID
        {
            get
            {
                return (_StoreID);
            }
        }

        public bool Changed
        {
            get
            {
                return (_Changed);
            }

            set
            {
                _Changed = value;
            }
        }

        public int ID
        {
            get
            {
                return (_ID);
            }
        }

        public string SKU
        {
            get
            {
                return (_SKU);
            }
        }

        public string Name
        {
            get
            {
                return (_Name);
            }
        }

        public string Size
        {
            get
            {
                return (_Size);
            }
        }

        /// <summary>
        /// Quantity Available, setting _Available will not change quantity available
        /// </summary>
        public int Available
        {
            get
            {
                return (_Available);
            }

            set
            {
                _Available = value;
            }
        }

        public int MinLevel
        {
            get
            {
                return (_MinLevel);
            }

            set
            {
                if (value > 0 && value != _MinLevel)
                {
                    _MinLevel = value;
                    _Changed = true;
                }
            }
        }

        public decimal OrderQuantity
        {
            get
            {
                return (_OrderQuantity);
            }

            set
            {
                if (value > 0 && value != _OrderQuantity)
                {
                    _OrderQuantity = value;
                    _Changed = true;
                }
            }
        }

        public ProductCostType ProductType
        {
            get
            {
                return (_ProductType);
            }
        }

        public decimal Cost
        {
            private set;
            get;
        }

        /// <summary>
        /// Determines wether the item is hidden globally across the site
        /// </summary>
        public bool HideGlobally
        {
            get
            {
                return (_hideGlobally);
            }

            set
            {
                _hideGlobally = value;
                DAL.FirebirdDB.StockItemShowGlobally(this, value);
            }
        }

        /// <summary>
        /// Indicates wether the item is currently out of stock or not
        /// </summary>
        public bool OutOfStock
        {
            get
            {
                return (_outOfStock);
            }

            set
            {
                _outOfStock = value;
            }
        }


        public bool AutoRestock
        {
            get
            {
                return (_autoRestock);
            }

            set
            {
                _autoRestock = value;
                _Changed = true;
            }
        }

        /// <summary>
        /// Physical location of stock item
        /// </summary>
        public string Location
        {
            get
            {
                return (_location);
            }

            set
            {
                _location = value;
                _Changed = true;
            }
        }

        #endregion Properties

        #region Public Methods

        public void StockAdd(int Quantity)
        {
            _Available += Quantity;
            AddStock(Quantity);
        }

        public void StockRemove(int Quantity)
        {
            _Available -= Quantity;

            RemoveStock(Quantity, 0);
        }

        public void StockAudit(int Quantity)
        {
            _Available = Quantity;
            //DAL.FirebirdDB.stockitema
        }

        #endregion PublicMethods

        #region Private Methods

        private void RemoveStock(int quantity, int attempt = 0)
        {
            try
            {
                DAL.FirebirdDB.StockItemAddStockOutQuantity(this, quantity);
            }
            catch (Exception err)
            {
                if (err.Message.Contains("lock conflict on no wait transaction"))
                {
                    if (attempt < DAL.DALHelper.LockConflictAttempts)
                    {
                        Thread.Sleep(100);
                        attempt = ++attempt;
                        RemoveStock(quantity, attempt);
                    }
                    else
                        throw; //we tried throw it back to the UI
                }
                else
                    throw; //not a lock conflict, throw it back to the UI
            }
        }

        private void AddStock(int quantity, int attempt = 0)
        {
            try
            {
                DAL.FirebirdDB.StockItemAddStockInQuantity(this, quantity);
            }
            catch (Exception err)
            {
                if (err.Message.Contains("lock conflict on no wait transaction"))
                {
                    if (attempt < DAL.DALHelper.LockConflictAttempts)
                    {
                        Thread.Sleep(100);
                        attempt = ++attempt;
                        AddStock(quantity, attempt);
                    }
                    else
                        throw; //we tried throw it back to the UI
                }
                else
                    throw; //not a lock conflict, throw it back to the UI
            }

        }
        
        #endregion Private Methods

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("StockItem: {0}; Name: {1}", ID, Name));
        }

        #endregion Overridden Methods
    }
}
