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
 *  File: TagLines.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedBase.BOL.TagLines
{
    [Serializable]
    public sealed class TagLines : BaseCollection
    {
        #region Static Members

        private static TagLines _tagLines = null;

        #endregion Static Members

        #region Static Methods

        /// <summary>
        /// Retrieves a random tag line
        /// </summary>
        /// <returns>TagLine object</returns>
        public static TagLine RandomTagLine()
        {
            if (_tagLines == null)
            {
                _tagLines = DAL.FirebirdDB.TagLinesGet();
            }

            Random rnd = new Random(DateTime.Now.Second);

            int idx = rnd.Next(_tagLines.Count -1);

            return (_tagLines[idx]);
        }

        /// <summary>
        /// Returns a collection of TagLines
        /// </summary>
        public static TagLines Tags()
        {
            if (_tagLines == null)
            {
                _tagLines = DAL.FirebirdDB.TagLinesGet();
            }

            return (_tagLines);
        }

        /// <summary>
        /// finds a tag line based on it's id
        /// </summary>
        /// <param name="id">ID of tag line to find</param>
        /// <returns>TagLine object if found, otherwise null</returns>
        public static TagLine Find(Int64 id)
        {
            TagLine Result = null;

            foreach(TagLine tag in Tags())
            {
                if (tag.ID == id)
                {
                    Result = tag;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Resets the taglines forcing a fresh load from the database
        /// </summary>
        public static void Reset()
        {
            _tagLines = null;
        }

        /// <summary>
        /// Creates a new TagLine
        /// </summary>
        /// <returns>TagLine object</returns>
        public static TagLine New()
        {
            TagLine Result = DAL.FirebirdDB.TagLineCreate("");

            _tagLines = null;

            return (Result);
        }

        /// <summary>
        /// Delete's a tag line
        /// </summary>
        /// <param name="tagLine">TagLine to be deleted</param>
        public static void Delete(TagLine tagLine)
        {
            DAL.FirebirdDB.TagLineDelete(tagLine);
            _tagLines = null;
        }

        #endregion Static Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Retrieves an item from the collection
        /// </summary>
        public TagLine this[int Index]
        {
            get
            {
                return ((TagLine)this.InnerList[Index]);
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
        public int Add(TagLine value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(TagLine value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Determines wether a tag exists based on it's ID
        /// </summary>
        /// <param name="tagID">ID of tag</param>
        /// <returns>bool, true if the tag exists, otherwise false</returns>
        public bool IndexOf(Int64 tagID)
        {
            bool Result = false;

            foreach (TagLine tag in this)
            {
                if (tag.ID == tagID)
                {
                    Result = true;
                    break;
                }
            }

            return (Result);
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, TagLine value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(TagLine value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(TagLine value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "SharedBase.BOL.TagLines.TagLine";
        private const string OBJECT_TYPE_ERROR = "Must be of type TagLine";


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
