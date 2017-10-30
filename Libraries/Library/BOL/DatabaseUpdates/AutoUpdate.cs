using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class AutoUpdate : BaseObject
    {
        #region Constructors

        public AutoUpdate (Int64 id, string name, string sql, DateTime runDate, bool complete,
            User createdBy, DateTime createdDate)
        {
            ID = id;
            Name = name;
            SQL = sql;
            RunDate = runDate;
            Complete = complete;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Name of rule
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Sql to run
        /// </summary>
        public string SQL { get; private set; }

        /// <summary>
        /// Date and time to run
        /// </summary>
        public DateTime RunDate { get; set; }

        /// <summary>
        /// Indicates wether it is complete or not
        /// </summary>
        public bool Complete { get; private set; }

        /// <summary>
        /// User who created the auto update
        /// </summary>
        public User CreatedBy { get; private set; }

        /// <summary>
        /// Date time created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        #endregion Properties
    }
}
