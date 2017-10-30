using System;
using System.Collections.Generic;
using System.Text;

//using Library.BOL.Orders;

namespace Library.BOL.Invoices
{
    [Serializable]
    public sealed class InvoiceViewItems: BaseCollection
    {
        #region Static Methods

        //public static InvoiceViewItems Get(OrderItems items)
        //{
        //    InvoiceViewItems Result = new InvoiceViewItems();

        //    foreach (OrderItem item in items)
        //    {
        //        Result.Add(new InvoiceViewItem(item.SKU, item.Description, item.Price, item.Quantity, item.Cost,
        //            item.ItemType.ToString(), item.StaffMember.UserName, item.UserDiscount, item.UserDiscountValue,
        //            item.ProductDiscount, item.ProductDiscountValue));
        //    }

        //    return (Result);
        //}

        public static InvoiceViewItems Get(InvoiceItems items)
        {
            InvoiceViewItems Result = new InvoiceViewItems();

            foreach (InvoiceItem item in items)
            {
                Result.Add(new InvoiceViewItem(item.SKU, item.Description, item.Price, item.Quantity, item.Cost,
                    item.ItemType.ToString(), item.StaffMemberID == -1 ? String.Empty : item.StaffMember.UserName, 
                    item.UserDiscount, item.UserDiscountValue,
                    item.ProductDiscount, item.ProductDiscountValue));
            }

            return (Result);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>InvoiceViewItem object</returns>
        public InvoiceViewItem this[int Index]
        {
            get
            {
                return ((InvoiceViewItem)this.InnerList[Index]);
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
        public int Add(InvoiceViewItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(InvoiceViewItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, InvoiceViewItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(InvoiceViewItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(InvoiceViewItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Invoices.InvoiceViewItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type InvoiceViewItem";


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
