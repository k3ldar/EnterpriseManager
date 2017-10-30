using System;

using Library.BOL.Users;

namespace Library.BOL.Helpdesk
{
    [Serializable]
    public sealed class CustomerComments : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Adds a customer comment
        /// </summary>
        /// <param name="user">User object, if user logged on</param>
        /// <param name="Username">Name of user</param>
        /// <param name="Comments">Comments to be added</param>
        /// <returns></returns>
        public static Int64 Add(User user, string Username, string Comments)
        {
            return (DAL.FirebirdDB.HelpdeskCustomerCommentsAdd(user, Username, Comments));
        }

        /// <summary>
        /// Retrieves page of customer comments viewable on the website
        /// </summary>
        /// <param name="PageNumber">Current Page Number</param>
        /// <param name="PageSize">Page Size</param>
        /// <returns>CustomerComments collection</returns>
        public static CustomerComments Get(int PageNumber, int PageSize)
        {
            return (DAL.FirebirdDB.HelpdeskCustomerCommentsGet(PageNumber, PageSize));
        }

        /// <summary>
        /// Retrieves all customer comments viewable on the website
        /// </summary>
        /// <returns>CustomerComments collection</returns>
        public static CustomerComments Get()
        {
            return (DAL.FirebirdDB.HelpdeskCustomerCommentsGet());
        }

        public static CustomerComments GetAll()
        {
            return (DAL.FirebirdDB.AdminHelpdeskCustomerCommentsGet(1, 10000));
        }

        public static CustomerComment Get(int id)
        {
            return (DAL.FirebirdDB.HelpdeskCustomerCommentGet(id));
        }

        public static int GetCount()
        {
            return (DAL.FirebirdDB.AdminHelpdeskCustomerCommentsCount());
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public CustomerComment this[int Index]
        {
            get
            {
                return ((CustomerComment)this.InnerList[Index]);
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
        public int Add(CustomerComment value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(CustomerComment value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, CustomerComment value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(CustomerComment value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(CustomerComment value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Helpdesk.CustomerComment";
        private const string OBJECT_TYPE_ERROR = "Must be of type CustomerComment";


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