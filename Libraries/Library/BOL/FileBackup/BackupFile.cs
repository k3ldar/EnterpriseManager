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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BackupFile.cs
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

namespace Library.BOL.FileBackup
{
    [Serializable]
    public sealed class BackupFile : BaseObject
    {
        #region Private Members

        /// <summary>
        /// contents of file
        /// </summary>
        //private string _contents;

        #endregion Private Members

        #region Constructors

        public BackupFile (Int64 id, string fileName, string fileExtension, 
            string filePath, int version, string crc, string computerName,
            Int64 fileSize, DateTime lastUpdated)
        {
            ID = id;
            FileName = fileName;
            FileExtension = fileExtension;
            FilePath = filePath;
            Version = version;
            CRC = crc;
            ComputerName = computerName;
            Size = fileSize;
            LastUpdated = lastUpdated;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for record
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// File Extension
        /// </summary>
        public string FileExtension { get; private set; }

        /// <summary>
        /// Path of file
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Version of document within file store
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// CRC of file
        /// </summary>
        public string CRC { get; private set; }

        /// <summary>
        /// Contents of file
        /// </summary>
        public string Contents 
        { 
            get
            {
                return (DAL.FirebirdDB.BackupFileGetContents(this));
            }
        }

        /// <summary>
        /// Size of file in bytes
        /// </summary>
        public Int64 Size { get; private set; }

        /// <summary>
        /// Name of computer where file was originally located
        /// </summary>
        public string ComputerName { get; private set; }

        /// <summary>
        /// Date / Time last updated
        /// </summary>
        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// User who last made changes
        /// </summary>
        public Users.User User { get; private set; }

        /// <summary>
        /// All previous versions of a specific file
        /// </summary>
        public Files Versions
        {
            get
            {
                return (DAL.FirebirdDB.BackupFileGetVersions(this));
            }
        }

        #endregion Properties

        #region Overridden Methods

        public void Save(DateTime lastWriteTime, string contents, string crc, Int64 size)
        {
            Version++;
            LastUpdated = lastWriteTime;
            CRC = crc;
            Size = size;

            DAL.FirebirdDB.BackupFileSave(this, contents);

            string cacheName = String.Format(Consts.CACHE_NAME_BACKUP_FILE,
                ComputerName, FilePath, FileName, FileExtension);


            CachedItemAdd(cacheName, new CacheItem(cacheName, this));
        }

        #endregion Overridden Methods
    }
}
