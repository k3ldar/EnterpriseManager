using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentStatus : BaseObject
    {
        #region Private / Protected Members

        private int _ID;
        private string _Description;
        private int _SortOrder;

        #endregion Private / Protected Members

        #region Constructors / Destructors

        public AppointmentStatus(int ID, string Description, int SortOrder)
        {
            _ID = ID;
            _Description = Description;
            _SortOrder = SortOrder;
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

        public int SortOrder
        {
            get
            {
                return (_SortOrder);
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Status: {0}; ID: {1}", _Description, ID));
        }

        #endregion Overridden Methods

    }
}
