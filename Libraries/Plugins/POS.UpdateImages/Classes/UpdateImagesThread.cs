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
 *  File: UpdateImagesThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.IO;

using Library.BOL.Websites;
using POS.Base.Classes;
using Shared.Classes;

namespace POS.Images.Classes
{

    public class UpdateImagesThread : ThreadManager
    {
        #region Private Members

        private List<UpdatedFile> _updatedFiles = new List<UpdatedFile>();

        #endregion Private Members

        #region Delegates

        #endregion Delegates

        #region Constructors

        public UpdateImagesThread()
            : base(null, new TimeSpan())
        {
#if DEBUG
            this.HangTimeout = 5000;
#else
            this.HangTimeout = 500;
#endif
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            try
            {
                foreach (Website site in Websites.All())
                {
                    if (site.TestFTPConnection(false))
                    {
                        ftp ftpClient = new ftp(site.FtpHost, site.FtpUserName, site.FtpPassword, 2048,
                            true, true, true, site.FtpPort);
                        try
                        {
                            foreach (string imgType in Enum.GetNames(typeof(ImageTypes)))
                            {
                                string remoteFolder = String.Format(StringConstants.IMAGE_FTP_ROOT, site.RootPath, imgType, String.Empty); 

                                ftpClient.CreateDirectory(remoteFolder);

                                string[] details = ftpClient.DirectoryListDetailed(remoteFolder);
                                List<FTPEntry> items = new List<FTPEntry>();

                                foreach (string line in details)
                                {
                                    FTPEntry entry = null;

                                    if (FTPEntry.ParseFTPLine(line, ref entry))
                                        items.Add(entry);
                                }

                                CompareFoldersLocalToRemote(site, ftpClient, items, (ImageTypes)Enum.Parse(typeof(ImageTypes), imgType));
                                CompareFoldersRemoteToLocal(site, ftpClient, items, (ImageTypes)Enum.Parse(typeof(ImageTypes), imgType));
                            }
                        }
                        finally
                        {
                            ftpClient = null;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }

            return (false);
        }

        #endregion Overridden Methods

        #region Private Methods

        private void CompareFoldersLocalToRemote(Website site, ftp client, List<FTPEntry> remoteFiles, ImageTypes imageType)
        {
            string localPath = AppController.POSFolder(imageType);

            string[] files = Directory.GetFiles(localPath, "*.*");

            foreach (string localFile in files)
            {
                string file = Path.GetFileName(localFile);

                bool found = false;

                foreach (FTPEntry entry in remoteFiles)
                {
                    System.Threading.Thread.Sleep(0);

                    if (entry.Type != FTPEntry.EntryType.File)
                        continue;

                    if (entry.Name.EndsWith(file, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // compare file sizes, if the same then buyakka, it's been found!
                        FileInfo info = new FileInfo(localFile);

                        if (info.Length == entry.Size)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    // log to upload the file...
                    _updatedFiles.Add(new UpdatedFile(true, localFile, imageType));
                   string remoteFolder = String.Format(StringConstants.IMAGE_FTP_ROOT, site.RootPath, imageType.ToString(), file);

                    try
                    {
                        client.Upload(remoteFolder, localFile);
                    }
                    catch (Exception err)
                    {
                        Shared.EventLog.Add(err, String.Format("Failed to upload image file: {0}", localFile));
                    }
                    
                }
            }
        }

        private void CompareFoldersRemoteToLocal(Website site, ftp client, List<FTPEntry> remoteFiles, ImageTypes imageType)
        {
            string localPath = AppController.POSFolder(imageType);

            string[] files = Directory.GetFiles(localPath, "*.*");

            foreach (FTPEntry remoteFile in remoteFiles)
            {
                if (remoteFile.Type != FTPEntry.EntryType.File)
                    continue;

                bool found = false;

                foreach (string localFile in files)
                {
                    System.Threading.Thread.Sleep(0);

                    string file = Path.GetFileName(localFile);

                    if (remoteFile.Name.EndsWith(file, StringComparison.InvariantCultureIgnoreCase))
                    {
                        // compare file sizes, if the same then buyakka, it's been found!
                        FileInfo info = new FileInfo(localFile);

                        if (info.Length == remoteFile.Size)
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                {
                    // log to upload the file...
                    _updatedFiles.Add(new UpdatedFile(true, remoteFile.Name, imageType));
                    string remoteFolder = String.Format(StringConstants.IMAGE_FTP_ROOT, site.RootPath, imageType.ToString(), remoteFile.Name);

                    try
                    {
                        client.Download(remoteFolder, Shared.Utilities.AddTrailingBackSlash(localPath) + remoteFile.Name);
                    }
                    catch (Exception err)
                    {
                        Shared.EventLog.Add(err, String.Format("Failed to download image file: {0}", remoteFolder));
                    }
                }
            }
        }

        #endregion Private Methods

        #region Static Methods

        public static void ResizeImage(string imageFile, int width, int height)
        {
            try
            {
                if (!System.IO.File.Exists(imageFile))
                    return;

                System.Drawing.Image image = System.Drawing.Image.FromFile(imageFile);
                try
                {
                    System.Drawing.Bitmap Result = new System.Drawing.Bitmap(width, height);
                    try
                    {
                        Result.SetResolution(300, 300);
                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Result);
                        try
                        {
                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                            // Resize the original
                            g.DrawImage(image, 0, 0, width, height);
                        }
                        finally
                        {
                            g.Dispose();
                            g = null;
                        }

                        Result.Save(imageFile.Replace(StringConstants.IMAGE_SIZE_DEFAULT, width.ToString()));
                    }
                    finally
                    {
                        Result.Dispose();
                        Result = null;
                    }
                }
                finally
                {
                    image.Dispose();
                    image = null;
                }
            }
            catch (Exception err)
            {
                if (err.Message.Contains("asddf"))
                {

                }
                throw;
            }
        }

#endregion Static Methods
    }
}
