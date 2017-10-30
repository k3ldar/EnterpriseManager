using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

using Library;

namespace Reports
{
    /// <summary>
    /// Collection of Report Items
    /// </summary>
    public class ReportItems : CollectionBase
    {
        #region Generic CollectionBase Code

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(ReportItem value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(ReportItem value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, ReportItem value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(ReportItem value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(ReportItem value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Reports.ReportItem";
        private const string OBJECT_TYPE_ERROR = "Must be of type ReportItem";


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

    /// <summary>
    /// Report Item - Individual Report item
    /// </summary>
    public class ReportItem
    {
        #region Constructor

        public ReportItem(string name, Type classType, string method, 
            SecurityEnums.SecurityPermissionsReports permission, 
            bool activeUser, string helpTopic)
        {
            Name = name;
            ClassType = classType;
            Method = method;
            Permission = permission;
            SendActiveUser = activeUser;
            HelpTopic = helpTopic;
        }

        #endregion Constructor

        #region Properties

        public bool SendActiveUser { get; private set; }

        public string Name { get; private set; }

        public Type ClassType { get; private set; }

        public string Method { get; private set; }

        public SecurityEnums.SecurityPermissionsReports Permission { get; private set; }

        public string HelpTopic { get; private set; }

        #endregion Properties
    }
}
