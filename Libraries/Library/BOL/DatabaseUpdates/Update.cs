using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class Update : BaseObject
    {
        #region Private Members

        private Int64 _id;
        private DateTime _updated;
        private string _column;
        private string _oldValue;
        private string _newValue;

        #endregion Private Members

        #region Constructors

        public Update(Int64 ID, DateTime Updated, string Column, string OldValue, string NewValue)
        {
            _id = ID;
            _updated = Updated;
            _column = Column;
            _oldValue = OldValue;
            _newValue = NewValue;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID
        {
            get
            {
                return (_id);
            }
        }

        public DateTime Updated
        {
            get
            {
                return(_updated);
            }
        }

        public string Column
        {
            get
            {
                return (_column);
            }
        }

        public string OldValue
        {
            get
            {
                return (_oldValue);
            }
        }

        public string NewValue
        {
            get 
            { 
                return (_newValue); 
            }
        }

        #endregion Properties
    }
}
