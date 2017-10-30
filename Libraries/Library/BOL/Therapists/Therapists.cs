using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif
using System.Collections;

using Shared.Classes;

namespace Library.BOL.Therapists
{
    [Serializable]
    public sealed class Therapists : BaseCollection
    {
        #region Constructors / Destructors

        public Therapists()
        {
            
        }


        #endregion Constructors / Destructors

        #region Static Methods

        /// <summary>
        /// Returns a list of Therapists
        /// </summary>
        /// <returns>Therapists collection</returns>
        public static Therapists Get()
        {
            CacheItem therapists = CachedItemGet("All Therapists");

            if (therapists == null)
            {
                therapists = new CacheItem("All Therapists", DAL.FirebirdDB.TherapistsGet());
                CachedItemAdd("All Therapists", therapists);
            }

            return ((Therapists)therapists.Value);
        }

        /// <summary>
        /// Returns an individual Therapist
        /// </summary>
        /// <param name="TherapistID">ID of the Therapist to return</param>
        /// <returns>Therapists collection containing the Therapist</returns>
        public static Therapist Get(Int64 TherapistID)
        {
            return (DAL.FirebirdDB.TherapistsGet(TherapistID));
        }

        public static Therapist GetTherapist(Int64 therapistID)
        {
            string name = String.Format("Therapist {0}", therapistID);

            CacheItem therapist = CachedItemGet(name);

            if (therapist != null)
            {
                return ((Therapist)therapist.Value);
            }

            foreach (Therapist ther in Get())
            {
                if (ther.EmployeeID == therapistID)
                {
                    therapist = new CacheItem(name, ther);
                    CachedItemAdd(name, therapist);

                    return (ther);
                }
            }

            return (null);
        }

        public static Therapists Get(bool PublicOnly)
        {
            return (DAL.FirebirdDB.TherapistsGet(PublicOnly));
        }

        #endregion Static Methods

        #region Public Methods

        public Therapist Index(Int64 Index)
        {
            Therapist Result = null;
            int i = 0;

            foreach (Therapist therapist in this)
            {
                if (i == Index)
                {
                    Result = therapist;
                    break;
                }

                i++;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        public Therapist this[int Index]
        {
            get
            {
                return ((Therapist)this.InnerList[Index]);
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
        public int Add(Therapist value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Therapist value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Therapist value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Therapist value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Therapist value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Therapists.Therapist";
        private const string OBJECT_TYPE_ERROR = "Must be of type Therapist";


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