using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.MailList
{
    /// <summary>
    /// Class for mail list subscribers
    /// </summary>
    [Serializable]
    public sealed class MailLists
    {
        #region Static Methods

        /// <summary>
        /// Returns a collection of mail list subscribers
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> Subscribers()
        {
            return (DAL.FirebirdDB.MailListSubscribers());
        }

        /// <summary>
        /// Subscribes a user to the mail list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public static void Subscribe(string name, string email)
        {
            DAL.FirebirdDB.MailListSubscribe(name, email);
        }

        /// <summary>
        /// Removes a user from the mail list
        /// </summary>
        /// <param name="email"></param>
        /// <param name="reason"></param>
        public static bool UnSubscribe(string email, string reason)
        {
            return (DAL.FirebirdDB.MailListUnsubscribe(email, reason));
        }

        #endregion Static Methods
    }
}
