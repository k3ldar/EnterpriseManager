using System;
using System.Collections.Generic;
using System.Web;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentType : BaseObject
    {
        #region Private Members

        private int _ID;
        private string _Description;

        #endregion Private Members

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

        #endregion Properties

        #region Constructors / Destructors

        public AppointmentType(int ID, string Description)
        {
            _ID = ID;
            _Description = Description;
        }

        #endregion Constructors / Destructors

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("AppointmentType: {0}; Description: {1}", ID, _Description));
        }

        #endregion Overridden Methods

    }
}