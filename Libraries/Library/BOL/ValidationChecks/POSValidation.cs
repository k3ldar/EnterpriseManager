using System;
using System.Collections.Generic;
using System.Text;

using Library.BOL.Users;

namespace Library.BOL.ValidationChecks
{
    [Serializable]
    public sealed class POSValidation
    {
        #region Constructors

        public POSValidation(Int64 id, Int64 userID, string userName, DateTime dateStamp, ValidationReasons checkType, string reason)
        {
            ID = id;
            UserID = userID;
            UserName = userName;
            DateStamp = dateStamp;
            CheckType = checkType;
            Reason = reason;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// User ID of user bypassing validation check
        /// </summary>
        public Int64 UserID { get; private set; }

        /// <summary>
        /// Name of user bypassing validation check
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Date/Time validation stamp ignored
        /// </summary>
        public DateTime DateStamp { get; private set; }

        /// <summary>
        /// Type of check
        /// </summary>
        public ValidationReasons CheckType { get; private set; }

        /// <summary>
        /// Reason to ignore check
        /// </summary>
        public string Reason { get; private set; }

        #endregion Properties

        #region Static Methods

        /// <summary>
        /// Adds a validation check
        /// </summary>
        /// <param name="user"></param>
        /// <param name="checkType"></param>
        /// <param name="reason"></param>
        public static void Add(User user, ValidationReasons checkType, string reason)
        {
            try
            {
                DAL.FirebirdDB.ValidationCheckAdd(user, checkType, reason);
            }
            catch (Exception err)
            {
                // if it's replicated then ignore, it's only a validation check after all!!!
                if (!err.Message.Contains("Foreign key reference target does not exist"))
                    throw;
            }
        }

        #endregion Static Methods
    }
}
