using System;
using System.IO;

namespace Library.BOL.Downloads
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
