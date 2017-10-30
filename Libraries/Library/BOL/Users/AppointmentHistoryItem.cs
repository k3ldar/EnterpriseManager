using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Users
{
    /// <summary>
    /// Appointment history item.
    /// </summary>
    [Serializable]
    public sealed class AppointmentHistoryItem : BaseObject
    {
        #region Private Members

        private string _timeFrame;
        private string _status;
        private int _count;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeFrame">Time Frame of Appointment</param>
        /// <param name="status">Status of Appointment</param>
        /// <param name="count">Count of Time Frame/Status</param>
        public AppointmentHistoryItem(string timeFrame, string status, int count)
        {
            _timeFrame = timeFrame;
            _status = status;
            _count = count;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Timeframe of appointment (6 months or older)
        /// </summary>
        public string TimeFrame
        {
            get
            {
                return (_timeFrame);
            }
        }

        /// <summary>
        /// Status of appointment
        /// </summary>
        public string Status
        {
            get
            {
                return (_status);
            }
        }

        /// <summary>
        /// Count of appointment types for time frame
        /// </summary>
        public int Count
        {
            get
            {
                return (_count);
            }
        }

        #endregion Properties

    }
}
