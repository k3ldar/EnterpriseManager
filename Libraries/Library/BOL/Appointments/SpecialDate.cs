using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class SpecialDate : BaseObject
    {
        #region Private Members

        private int _id;
        private string _description;
        private DateTime _dateStart;
        private DateTime _dateEnd;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of special date</param>
        /// <param name="description">Description of special date</param>
        /// <param name="date">Date of special date</param>
        public SpecialDate(int id, string description, DateTime dateStart, DateTime dateEnd)
        {
            _id = id;
            _description = description;
            _dateStart = dateStart;
            _dateEnd = dateEnd.AddHours(23).AddMinutes(59);
            //_dateEnd = _dateEnd.AddDays(1);
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// ID of special date
        /// </summary>
        public int ID
        {
            get
            {
                return (_id);
            }
        }

        /// <summary>
        /// Description of special date
        /// </summary>
        public string Description
        {
            get
            {
                return (_description);
            }
        }

        /// <summary>
        /// Start date of special date
        /// </summary>
        public DateTime DateStart
        {
            get
            {
                return (_dateStart);
            }
        }

        /// <summary>
        /// End date of special date
        /// </summary>
        public DateTime DateEnd
        {
            get
            {
                return (_dateEnd);
            }
        }

        #endregion Properties


        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("SpecialDate: {0}; Description: {1}", ID, Description));
        }

        #endregion Overridden Methods

    }
}
