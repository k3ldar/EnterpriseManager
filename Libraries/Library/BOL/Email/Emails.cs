/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Emails.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using Library.BOL.Websites;
using Library.Utils;
using Library.BOL.Users;

namespace Library.BOL.Mail
{
	/// <summary>
	/// Class used to hold a collection of Email objects
	/// </summary>
    [Serializable]
    public sealed class Emails : BaseCollection
	{
		#region Constructors/Destructors

		/// <summary>
		/// Constructor
		/// </summary>
		public Emails()
		{

		}

		
		#endregion Constructors/Destructors

		#region Private Members

		private const string OBJECT_TYPE = "Library.BOL.Mail.Email";
		private const string OBJECT_TYPE_ERROR = "Must be of type Email";

		#endregion Private Members

		#region Properties

		/// <summary>
		/// Retrieves an item from the collection
		/// </summary>
		public Email this[int index] 
		{
			get  
			{ 
				return((Email) List[index]);
			}
			

			set
			{ 
				List[index] = value;
			}
		}


		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Adds an item to the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int Add(Email value) 
		{
			return(List.Add(value));
		}


		/// <summary>
		/// Returns the index of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(Email value) 
		{
			return(List.IndexOf(value));
		}


		/// <summary>
		/// Inserts an item into the collection
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, Email value) 
		{
			List.Insert(index, value);
		}


		/// <summary>
		/// Removes an item from the collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(Email value) 
		{
			List.Remove(value);
		}


		/// <summary>
		/// Indicates the existence of an item within the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(Email value) 
		{
			// If value is not of type OBJECT_TYPE, this will return false.
			return(List.Contains(value));
		}


		#endregion Public Methods

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

        #region Static Methods

        public static void QueueStatistics(out Int64 QueueSize)
        {
            DAL.FirebirdDB.EmailQueueStatistics(out QueueSize);
        }

        public static Emails Get(bool IncludeSentEmail, Int16 MaxSendAttempts)
        {
            return (DAL.FirebirdDB.EmailsGet(IncludeSentEmail, MaxSendAttempts));
        }

        public static void DeleteSent()
        {
            DAL.FirebirdDB.EmailDeleteSent();
        }

        /// <summary>
        /// Send individual email
        /// </summary>
        /// <param name="ToName"></param>
        /// <param name="ToEMail"></param>
        /// <param name="FromName"></param>
        /// <param name="FromEMail"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static Int64 Add(string ToName, string ToEMail, string FromName,
            string FromEMail, string Subject, string Message)
        {
            Int64 Result = -1;

            //What if Message is longer than 20000 characters?  Split into parts
            while (Message.Length > 0)
            {
                string MessagePart = Message.Substring(0, Message.Length > 20000 ? 20000 : Message.Length);
                Message = Message.Substring(Message.Length > 20000 ? 20000 : Message.Length);
                Result = DAL.FirebirdDB.EmailAdd(ToName, ToEMail, FromName, FromEMail, Subject, MessagePart);
            }

            return (Result);
        }

        /// <summary>
        /// emails the developers with an error message
        /// </summary>
        /// <param name="err">Exception raised</param>
        public static void EmailError(Exception err, string applicationVersion)
        {
            string Message = String.Format("StoreID: {0}<br />Till ID: {1}<br />Database Version: {2}<br />Application Version: {3}<p>An unhandled error occured</p>",
                DAL.DALHelper.StoreID, DAL.DALHelper.TillID, DAL.DALHelper.DatabaseVersion, applicationVersion);
            
            Message += "<p>information:" + err.Message + "</p><p>Stack trace</p>" + err.StackTrace == null ? "StackTrace Error" : err.StackTrace.Replace("\r", "<br />").Replace("\n", "<br />");

            DAL.FirebirdDB.EmailAdd("noreply@sieradelta.com", "noreply@sieradelta.com", "noreply@sieradelta.com", "noreply@sieradelta.com", "System Error " + err.Message, Message);
        }

        /// <summary>
        /// Sends mass email, must be formatted as html page
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="memberLevel"></param>
        /// <returns></returns>
        public static Int64 MassEmail(string Subject, string Message, MemberLevel memberLevel, bool SendToAboveLevels)
        {
            return (DAL.FirebirdDB.EmailAdd(memberLevel, SendToAboveLevels, Subject, Message));
        }

        public static Int64 MassEmail(string Subject, string Message, Countries.Country country)
        {
            return (DAL.FirebirdDB.EmailAdd(country, Subject, Message));
        }

        /// <summary>
        /// Sends mass email to all member level and above, simple messages
        /// </summary>
        /// <param name="CurrentUser">Current Logged on user</param>
        /// <param name="Subject">Subject of Message</param>
        /// <param name="Message">Message body</param>
        /// <param name="memberLevel">Lowest member level</param>
        /// <returns></returns>
        public static Int64 MassEmail(User CurrentUser, string Subject, string Message, MemberLevel memberLevel)
        {
            Int64 Result = 0;

            WebsiteAdministration Admin = new WebsiteAdministration(CurrentUser);
            Users.Users users = Admin.UsersGet(memberLevel);
            DateTime send = DateTime.Now;

            int i = 0;

            foreach (User user in users)
            {
                if (user.OffersEmail)
                {
                    string sMsg = Message;
                    string sTitle = Subject;
                    string sTo = user.UserName;
                    string sToEmail = user.Email;

                    sMsg = String.Format("Hi {0},\r\r{1}", user.FirstName, sMsg);
                    sMsg = LibUtils.PreProcessPost(WebsiteSettings.RootURL, sMsg);

                    sMsg += String.Format("<P>If you do not wish to receive special offers and promotions " +
                        "please change your preferences by <a href=\"{0}/Account/Special-Offers/\">clicking here</a></p>",
                        WebsiteSettings.RootURL);

                    try
                    {
                        if (Shared.Utilities.IsValidEmail(user.Email))
                            WebsiteAdministration.EmailMassAdd(sTo, sToEmail, "Copyright (c) Shifoo Systems", 
                                "opt-in-marketing@heavenskincare.com", sTitle, sMsg, send);
                    }
                    catch (Exception err)
                    {
                        if (!err.Message.Contains("validation error for column TO_EMAIL"))
                            throw;
                    }

                    Result++;

                    if (i % 200 == 0)
                    {
                        send = send.AddMinutes(5);
                    }

                    i++;
                }
            }

            return (Result);
        }

        #endregion Static Methods
    }
}
