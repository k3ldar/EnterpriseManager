using System;
using System.Collections;

using Shared.Classes;

namespace Library.BOL
{
	/// <summary>
	/// BaseBOLCollection is the base class for all BOL collection classes.
	/// </summary>
    [Serializable]
	public class BaseCollection : CollectionBase
    {
        #region Constructors

        /// <summary>
		/// Constructor for BaseBOLCollection
		/// </summary>
		public BaseCollection()
		{

		}

		#endregion Constructors

        #region Caching

        /// <summary>
        /// Returns an item from the cache
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static CacheItem CachedItemGet(string name)
        {
            return (DAL.DALHelper.InternalCache.Get(name));
        }

        /// <summary>
        /// Adds an item to the cache
        /// </summary>
        /// <param name="name"></param>
        /// <param name="item"></param>
        protected static void CachedItemAdd(string name, CacheItem item)
        {
            DAL.DALHelper.InternalCache.Add(name, item);
        }

        /// <summary>
        /// Determines wether caching is available or not
        /// </summary>
        protected static bool CacheAvailable
        {
            get
            {
                return (DAL.DALHelper.AllowCaching);
            }
        }

        #endregion Caching

        #region Public Methods

        public void Reverse()
        {
            this.InnerList.Reverse();
        }

        #endregion Public Methods
    }
}
