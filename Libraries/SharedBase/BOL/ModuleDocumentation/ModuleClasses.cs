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
 *  File: ModuleClasses.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using Shared.Classes;

namespace SharedBase.BOL.ModuleDocumentation
{
    [Serializable]
    public sealed class ModuleClasses : BaseCollection
    {
        #region Static Methods

        /// <summary>
        /// Get's all module classes
        /// </summary>
        /// <returns>Collection of Module Classes</returns>
        public static ModuleClasses Get()
        {
            // has it been cached
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(Consts.CACHE_NAME_ALL_CLASSES);

            if (cachedResult == null)
            {
                cachedResult = new CacheItem(Consts.CACHE_NAME_ALL_CLASSES, DAL.FirebirdDB.ModuleClassSelectAll());
                DAL.DALHelper.InternalCache.Add(Consts.CACHE_NAME_ALL_CLASSES, cachedResult);
            }

            return (ModuleClasses)cachedResult.Value;
        }

        public static ModuleClass Get(string name)
        {
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(String.Format(Consts.CACHE_NAME_CLASS_NAME, name));

            if (cachedResult == null)
            {
                foreach (ModuleClass mClass in Get())
                {
                    if (mClass.Namespace + "." + mClass.Name == name)
                    {
                        DAL.DALHelper.InternalCache.Add(String.Format(Consts.CACHE_NAME_CLASS_NAME, name),
                            new CacheItem(String.Format(Consts.CACHE_NAME_CLASS_NAME, name), mClass));
                        return mClass;
                    }
                }
            }
            else
                return (ModuleClass)cachedResult.Value;

            DAL.DALHelper.InternalCache.Add(String.Format(Consts.CACHE_NAME_CLASS_NAME, name),
                new CacheItem(String.Format(Consts.CACHE_NAME_CLASS_NAME, name), null));
            return null;
        }

        public static ModuleClass Get(Int64 id)
        {
            CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(String.Format(Consts.CACHE_NAME_CLASS, id));

            if (cachedResult == null)
            {
                cachedResult = new CacheItem(String.Format(Consts.CACHE_NAME_CLASS, id), DAL.FirebirdDB.ModuleClassSelect(id));
                DAL.DALHelper.InternalCache.Add(String.Format(Consts.CACHE_NAME_CLASS, id), cachedResult);
            }

            return (ModuleClass)cachedResult.Value;
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        public ModuleClass this[int Index]
        {
            get
            {
                return (ModuleClass)this.InnerList[Index];
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
        public int Add(ModuleClass value)
        {
            return List.Add(value);
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(ModuleClass value)
        {
            return List.IndexOf(value);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, ModuleClass value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(ModuleClass value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(ModuleClass value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return List.Contains(value);
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.ModuleDocumentation.ModuleClass";
        private const string OBJECT_TYPE_ERROR = "Must be of type ModuleClass";


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
