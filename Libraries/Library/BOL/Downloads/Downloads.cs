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
 *  File: Downloads.cs
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
using System.Collections;

namespace Library.BOL.Downloads
{
    [Serializable]
    public sealed class Downloads : BaseCollection
    {
        #region Static Methods

        public static void AddDownload(Download downloadFile)
        {
            DAL.FirebirdDB.DownloadAdd(downloadFile);
        }

        /// <summary>
        /// Creates a new download
        /// </summary>
        /// <param name="FileName">The filename of the file on disk</param>
        /// <param name="Description">Description of the file</param>
        /// <returns>Download</returns>
        public static Download Create(string FileName, string Description)
        {
            return (DAL.FirebirdDB.DownloadCreate(FileName, Description));
        }

        /// <summary>
        /// Returns the number of available downloads
        /// </summary>
        /// <returns></returns>
        public static int GetCount(int DownloadType, bool isActive)
        {
            return (DAL.FirebirdDB.DownloadCount(DownloadType, isActive));
        }

        /// <summary>
        /// Returns x Downloads
        /// </summary>
        /// <param name="PageSize">Number of entries to return</param>
        /// <param name="PageNumber">Page Number</param>
        /// <returns></returns>
        public static Downloads Get(int PageSize, int PageNumber, int DownloadType)
        {
            return (DAL.FirebirdDB.DownloadsGet(PageSize, PageNumber, DownloadType));
        }

        /// <summary>
        /// Retrieves a download based on it's id
        /// </summary>
        /// <param name="downloadID"></param>
        /// <param name="DownloadType"></param>
        /// <returns></returns>
        public static Download Get(int downloadID, int DownloadType)
        {
            Downloads downloads = DAL.FirebirdDB.DownloadsGet(1000, 1, DownloadType);

            foreach (Download download in downloads)
            {
                if (download.ID == downloadID)
                {
                    return (download);
                }
            }

            return (null);
        }

        /// <summary>
        /// deletes a download item
        /// </summary>
        /// <param name="download">item to be deleted</param>
        public static void Delete(Download download)
        {
            DAL.FirebirdDB.DownloadDelete(download);
        }

        #endregion Static Methods

        #region Public Methods

        public Download Find(int DownloadID)
        {
            Download Result = null;

            foreach (Download dist in this)
            {
                if (dist.ID == DownloadID)
                {
                    Result = dist;
                    break;
                }
            }

            return (Result);
        }

        #endregion Public Methods

        #region Generic CollectionBase Code

        #region Properties

        /// <summary>
        /// Indexer Property
        /// </summary>
        /// <param name="Index">Index of object to return</param>
        /// <returns>Video object</returns>
        public Download this[int Index]
        {
            get
            {
                return ((Download)this.InnerList[Index]);
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
        public int Add(Download value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Returns the index of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(Download value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// Inserts an item into the collection
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, Download value)
        {
            List.Insert(index, value);
        }


        /// <summary>
        /// Removes an item from the collection
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Download value)
        {
            List.Remove(value);
        }


        /// <summary>
        /// Indicates the existence of an item within the collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(Download value)
        {
            // If value is not of type OBJECT_TYPE, this will return false.
            return (List.Contains(value));
        }

        #endregion Public Methods

        #region Private Members

        private const string OBJECT_TYPE = "Library.BOL.Downloads.Download";
        private const string OBJECT_TYPE_ERROR = "Must be of type Download";


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
