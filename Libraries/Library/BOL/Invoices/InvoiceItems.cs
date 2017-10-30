using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

using Library.Utils;

namespace Library.BOL.Invoices
{
    [Serializable]
    public sealed class InvoiceItems : BaseCollection
    {
        #region Private Members

        private Invoice _invoice;

        #endregion Private Members

        #region Public Methods

        public InvoiceItems(Invoice invoice)
        {
            _invoice = invoice;
        }

        public InvoiceItem First()
        {
            InvoiceItem Result = null;

            foreach (InvoiceItem item in this)
            {
                Result = item;
                break;
            }

            return (Result);
        }
        
        public string SubTotalStr
        {
            get
            {
                return (SharedUtils.FormatMoney(SubTotal, _invoice.Currency, false, true));
            }
        }

        public decimal SubTotal
        {
            get
            {
                decimal Result = 0.00m;

                foreach (InvoiceItem item in this)
                {
                    Result += item.Price;
                }

                return (Result);
            }
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public InvoiceItem this[int Index]
        {
            get
            {
                return ((InvoiceItem)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(InvoiceItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(InvoiceItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, InvoiceItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(InvoiceItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(InvoiceItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Invoices.InvoiceItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type InvoiceItem";


        #endregion Private Members

        #region Overridden Methods

        /// <summary>
        /// When Inserting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsert(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When removing an item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemove(int index, Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "value");
        }


        /// <summary>
        /// When Setting an Item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSet(int index, Object oldValue, Object newValue)
        {
            if (newValue.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR, "newValue");
        }


        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
            if (value.GetType() != Type.GetType(OBJECT_TYPE))
                throw new ArgumentException(OBJECT_TYPE_ERROR);
        }


        #endregion Overridden Methods

        #endregion Generic CollectionBase Code
    }
}