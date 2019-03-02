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
 *  File: Download.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.IO;

namespace SharedBase.BOL.Downloads
{
    [Serializable]
    public sealed class Download : BaseObject
    {
        #region Private / Protected Members

        private int _id;
        private string _filename;
        private string _description;

        #endregion Private / Protected Members

        #region Constructors

        public Download(int id, string filename, string description, bool isPublic)
        {
            _id = id;
            _filename = filename;
            _description = description;
            IsPublic = isPublic;
        }

        #endregion Constructors

        #region Properties

        public int ID
        {
            get { return (_id); }
        }

        public string FileName
        {
            get { return (_filename); }


        }

        public string FileExtension
        {
            get
            {
                return (Path.GetExtension(_filename));
            }
        }

        public string FileSize
        {
            get
            {
                string readable = "0B";

                if (File.Exists(_filename))
                {
                    FileInfo fi = new FileInfo(_filename);

                    long bytes = fi.Length;
                    string[] suf = { "B", "KB", "MB", "GB", "TB", "PB" };
                    int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
                    double num = Math.Round(bytes / Math.Pow(1024, place), 1);
                    readable = num.ToString() + suf[place];
                }

                return (readable);
            }
        }

        public string ShortFileName
        {
            get
            {
                string Result = _filename;

                while (Result.Contains("\\"))
                {
                    Result = Result.Substring(1);
                }

                return (Result.ToLower());
            }
        }

        public string Description
        {
            get
            {
                return (_description);
            }

            set
            {
                _description = value;
                //update and save here
            }
        }

        /// <summary>
        /// Is publicly available download
        /// </summary>
        public bool IsPublic { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override string ToString()
        {
            return (String.Format("Download: {0}; FileName: {1}", ID, _filename));
        }

        #endregion Overridden Methods

    }
}
