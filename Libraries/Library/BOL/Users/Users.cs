using System;
#if !ANDROID
using System.Web;
#endif

using Library.BOLEvents;

namespace Library.BOL.Users
{
    [Serializable]
    public sealed class Users : BaseCollection
    {
        #region Public Methods

        /// <summary>
        /// Removes a user from the collection
        /// </summary>
        /// <param name="userID">ID of user being removed</param>
        public void Remove(Int64 userID)
        {
            foreach (User user in this)
            {
                if (user.ID == userID)
                {
                    Remove(user);
                    break;
                }
            }
        }

        public User First()
        {
            User Result = null;

            foreach (User user in this)
            {
                Result = user;
                break;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Static Methods

        public static Users Get(HookEvent hookEvent)
        {
            return (DAL.FirebirdDB.UsersGet(hookEvent));
        }

        /// <summary>
        /// Registers a user for a competition
        /// </summary>
        /// <param name="firstName">Users first name</param>
        /// <param name="lastName">Users last name</param>
        /// <param name="email">Users email address</param>
        /// <param name="dateOfBirth">Users Date of Birth (optional)</param>
        /// <param name="receiveUpdates">Indicates wether the user will receive email updates</param>
        /// <param name="country">Users Country</param>
        /// <param name="campaign">Campaign user is registering for</param>
        public static void RegisterUserForCompetition(string firstName, string lastName, string email, 
            DateTime dateOfBirth, bool receiveUpdates, Countries.Country country, Campaigns.Campaign campaign)
        {
            DAL.FirebirdDB.RegisterUserForCompetition(firstName, lastName, email, 
                Shared.Utilities.GetRandomPassword(), dateOfBirth, receiveUpdates, country, campaign);
        }

        /// <summary>
        /// Retrieves all users and provides progress on retrieval
        /// </summary>
        /// <param name="progress">Progress object</param>
        /// <returns>Users collection</returns>
        public static Users Get(Progress progress)
        {
            return (DAL.FirebirdDB.UsersGet(progress));
        }

        /// <summary>
        /// Merge two customer records together, keeping primaryRecord and removing secondaryRecord
        /// </summary>
        /// <param name="currentUser">current user merging records</param>
        /// <param name="primaryRecord">primary record
        /// 
        /// This is the record that will be kept</param>
        /// <param name="secondaryRecord">secondaryRecord
        /// 
        /// This is the record that will be deleted</param>
        public static void Merge(User currentUser, User primaryRecord, User secondaryRecord)
        {
            DAL.FirebirdDB.UserMergeRecords(currentUser, primaryRecord, secondaryRecord);
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public User this[int Index]
        {
            get
            {
                return ((User)this.InnerList[Index]);
            }

            set
            {
                this.InnerList[Index] = value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds an item to the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(User value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(User value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, User value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(User value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(User value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Users.User";
        private const string OBJECT_TYPE_ERROR = "Must be of type User";


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
}