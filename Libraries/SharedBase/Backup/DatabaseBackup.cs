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
 *  File: DatabaseBackup.cs
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
using System.IO;
using System.Threading;
using System.Reflection;

using Shared.Classes;

using SharedBase.Utils;

namespace SharedBase.Backup
{
    /// <summary>
    /// Database backup class
    /// </summary>
    public sealed class DatabaseBackupThread : ThreadManager
    {
        #region Private Members

        private static Object lockObject = new Object();

        private static Dictionary<string, DatabaseBackupOptions> _backups = new Dictionary<string, DatabaseBackupOptions>();

        #endregion Private Members

        #region Public Static Methods

        /// <summary>
        /// Backup database
        /// </summary>
        /// <param name="backupPath">Path to where backups are sent</param>
        public static void BackupDatabase(string backupPath, bool upload, bool useSiteID, int siteID, 
            string name, string threadName, string connectionString, string ftpHost, string ftpUsername, 
            string ftpPassword, int ftpPort)
        {
            DatabaseBackupOptions options = new DatabaseBackupOptions(backupPath, useSiteID, siteID, name, upload,
                String.IsNullOrEmpty(connectionString) ? DAL.DALHelper.BackupConnectionString() : connectionString, 
                ftpHost, ftpUsername, ftpPassword, ftpPort);

            DoOnStageChanged(DatabaseBackupStage.BackupStarted);

            if (!Directory.Exists(backupPath))
                Directory.CreateDirectory(backupPath);


            // check if we are already backing up the database or not
            using (TimedLock.Lock(lockObject))
            {
                if (_backups.ContainsKey(name))
                    throw new Exception("Backup is already in progress!");

                _backups.Add(name, options);
            }

            DatabaseBackupThread backupThread = new DatabaseBackupThread(options);
            backupThread.HangTimeout = 30;
            Shared.Classes.ThreadManager.ThreadStart(backupThread, threadName, ThreadPriority.Normal);
        }

        #endregion Public Static Methods

        #region Constructors

        public DatabaseBackupThread(DatabaseBackupOptions options)
            : base(options, new TimeSpan())
        {

        }

        #endregion Constructors

        #region Public Properties

        public static bool BackupsInProgress
        {
            get
            {
                bool Result = false;

                using (TimedLock.Lock(lockObject))
                {
                    Result = _backups.Count > 0;
                }

                return (Result);
            }
        }

        /// <summary>
        /// Returns wether a backup is in progress
        /// </summary>
        public static bool BackupInProgress(string name)
        {
            bool Result = false;

            using (TimedLock.Lock(lockObject))
            {
                Result = _backups.ContainsKey(name);
            }

            return (Result);
        }

        #endregion Public Properties

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            DatabaseBackupOptions options = (DatabaseBackupOptions)parameters;

            try
            {
                string backupFile = String.Format(@"{0}Backup-{4}-{1}{2}{3}.fbk", 
                    Shared.Utilities.AddTrailingBackSlash(options.Path), 
                    DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                    options.UseSiteID ? options.SiteID.ToString() : options.Name);

                //backup database
                DoOnStageChanged(DatabaseBackupStage.BackingUpDatabase);

                try
                {
                    FirebirdSql.Data.Services.FbBackup backupSvc = new FirebirdSql.Data.Services.FbBackup();
                    backupSvc.ConnectionString = options.ConnectionString;

                    backupSvc.BackupFiles.Add(new FirebirdSql.Data.Services.FbBackupFile(backupFile, 2048));
                    backupSvc.Verbose = true;

                    backupSvc.Options = FirebirdSql.Data.Services.FbBackupFlags.IgnoreLimbo | 
                        FirebirdSql.Data.Services.FbBackupFlags.NoGarbageCollect;

                    backupSvc.Execute();
                }
                catch (Exception err)
                {
                    ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, options);

                    if (!System.IO.File.Exists(backupFile))
                        return (false);
                }

                DoOnStageChanged(DatabaseBackupStage.DatabaseBackupComplete);

                // compress it
                DoOnStageChanged(DatabaseBackupStage.CompressingBackup);
                ZipFiles.CompressFile(backupFile.Replace(".fbk", ".zip"), backupFile, true);
                DoOnStageChanged(DatabaseBackupStage.BackupCompressed);

                if (!System.IO.File.Exists(backupFile.Replace(".fbk", ".zip")))
                {
                    Shared.EventLog.Add("Zip File Not Found");
                    return (false);
                }

                if (options.Upload)
                {
                    //upload the file
                    DoOnStageChanged(DatabaseBackupStage.SendingFileToServer);

                    ftp uploader = new ftp(options.FTPHost, options.FTPUsername, options.FTPPassword, 2048, true, true, true, options.FTPPort);
                    uploader.Upload(Path.GetFileName(backupFile.Replace(".fbk", ".zip")), backupFile.Replace(".fbk", ".zip"));

                    DoOnStageChanged(DatabaseBackupStage.FileSentToServer);
                }
            }
            catch (Exception err)
            {
                ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, options);
            }
            finally
            {
                using (TimedLock.Lock(lockObject))
                {
                    _backups.Remove(options.Name);
                }

                DoOnStageChanged(DatabaseBackupStage.BackupComplete);
            }

            return (false);
        }

        #endregion Overridden Methods

        #region Private Methods

        private static void DoOnStageChanged(DatabaseBackupStage Stage)
        {
            if (OnStageChanged != null)
                OnStageChanged(Stage);
        }

        #endregion Private Methods

        #region Public Events

        /// <summary>
        /// Event raised when a stage changes
        /// </summary>
        public static event DatabaseBackupEventHandler OnStageChanged;

        #endregion Public Events

    }

    /// <summary>
    /// Class containing backup options
    /// </summary>
    public sealed class DatabaseBackupOptions
    {
        #region Constructors

        public DatabaseBackupOptions(string path, bool useSiteID, int siteID, string name, 
            bool upload, string connectionString, string ftpHost, string ftpUsername,
            string ftpPassword, int ftpPort)
        {
            Path = path;
            UseSiteID = useSiteID;
            SiteID = siteID;
            Name = name;
            Upload = upload;
            ConnectionString = connectionString;
            FTPHost = ftpHost;
            FTPUsername = ftpUsername;
            FTPPassword = ftpPassword;
            FTPPort = ftpPort;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Database backup Path
        /// </summary>
        internal string Path { get; private set; }

        /// <summary>
        /// indicates weather the store id forms part of the backup name
        /// </summary>
        internal bool UseSiteID { get; private set; }

        /// <summary>
        /// Name to be used as part of backup name if UseStoreId is false
        /// </summary>
        internal string Name { get; private set; }

        /// <summary>
        /// Indicates wether the backup is uploaded to a server via FTP
        /// </summary>
        internal bool Upload { get; private set; }

        /// <summary>
        /// Connection String used to connect to the database
        /// </summary>
        internal string ConnectionString { get; private set; }

        /// <summary>
        /// Site ID of backup
        /// </summary>
        internal int SiteID { get; private set; }

        internal string FTPHost {get; private set; }
        internal string FTPUsername { get; private set; }
        internal string FTPPassword { get; private set; }
        internal int FTPPort { get; private set; }

        #endregion Properties

        #region Public Overridden Methods

        public override string ToString()
        {
            return (String.Format("{0} - {1}", Name, Path));
        }

        #endregion Public Overridden Methods
    }

    /// <summary>
    /// Enum containing the different stages of a backup
    /// </summary>
    public enum DatabaseBackupStage
    {
        BackupStarted,

        BackingUpDatabase,

        DatabaseBackupComplete,

        CompressingBackup,

        BackupCompressed,

        SendingFileToServer,

        FileSentToServer,

        BackupComplete
    }

    public sealed class DatabaseBackupEventArgs : EventArgs
    {
        #region Constructors

        public DatabaseBackupEventArgs(DatabaseBackupStage stage)
        {
            Stage = stage;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Readonly current stage of backup
        /// </summary>
        public DatabaseBackupStage Stage { private set; get; }

        #endregion Properties
    }

    public delegate void DatabaseBackupEventHandler(DatabaseBackupStage e);
}
