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
 *  File: ZipFiles.cs
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

using ICSharpCode.SharpZipLib.Zip;

namespace SharedBase
{
    public static class ZipFiles
    {
        #region Public Static Methods

        /// <summary>
        /// Creates a zip file and adds all folders/sub folders into the zip file.
        /// </summary>
        /// <param name="zipFile">Zip File to Create</param>
        /// <param name="folderToZip">Folder to be zipped</param>
        public static bool ZipFolder(string zipFile, string folderToZip)
        {
            bool Result = true;

            ZipOutputStream zip = new ZipOutputStream(File.Create(zipFile));
            try
            {
                zip.SetLevel(9);
                string folder = folderToZip;
                Result = zipFolder(folder, folder, zip, zipFile);
                zip.Finish();
            }
            finally
            {
                zip.Close();
                zip.Dispose();
                zip = null;
            }

            return Result;
        }

        /// <summary>
        /// Unzips a zip file to a specific folder
        /// </summary>
        /// <param name="fileName">zip file to be unzipped</param>
        /// <param name="unpackFolder">folder where zip file is to be unzipped</param>
        public static void UnzipToFolder(string fileName, string unpackFolder)
        {
            FastZip zip = new FastZip();
            zip.ExtractZip(fileName, unpackFolder, "");
        }

        public static void Unpack(string ZipFile, string ZipExtractPath)
        {
            try
            {
                if (!File.Exists(ZipFile))
                {
                    return;
                }

                ZipInputStream s = new ZipInputStream(File.OpenRead(ZipFile));
                try
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(ZipExtractPath + directoryName);
                        }

                        if (fileName != String.Empty)
                        {
                            string destination = ZipExtractPath + theEntry.Name;

                            FileStream streamWriter = File.Create(destination);
                            try
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                streamWriter.Flush();
                            }
                            finally
                            {
                                streamWriter.Close();
                                streamWriter.Dispose();
                                streamWriter = null;
                            }
                        }
                    }
                }
                finally
                {
                    s.Close();
                    s.Dispose();
                    s = null;
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, ZipFile, ZipExtractPath);
            }
            finally
            {
                //Update Status
            }
        }

        /// <summary>
        /// Creates a zip file and add's a single file
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="fileToZip"></param>
        /// <param name="deleteOriginal"></param>
        public static void CompressFile(string zipFile, string fileToZip, bool deleteOriginal = true)
        {
            ZipOutputStream zip = new ZipOutputStream(File.Create(zipFile));
            try
            {
                zip.SetLevel(9);
                addFileToZip(zip, String.Empty, fileToZip);
                zip.Finish();
            }
            finally
            {
                zip.Close();
                zip.Dispose();
                zip = null;
            }
            if (deleteOriginal)
            {
                //delete backup file
                File.Delete(fileToZip);
            }
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static bool zipFolder(string RootFolder, string CurrentFolder, ZipOutputStream zStream, string zipFile)
        {

            string[] SubFolders = Directory.GetDirectories(CurrentFolder);

            foreach (string Folder in SubFolders)
                if (!zipFolder(RootFolder, Folder, zStream, zipFile))
                    return false;

            string relativePath = CurrentFolder.Substring(RootFolder.Length) + "/";

            if (relativePath.Length > 1)
            {
                ZipEntry dirEntry;
                dirEntry = new ZipEntry(relativePath);
                dirEntry.DateTime = DateTime.Now;
            }

            foreach (string file in Directory.GetFiles(CurrentFolder))
            {
                if (!RaiseFileAddedToZip(file, zipFile))
                    return false;

                addFileToZip(zStream, relativePath, file);
            }

            return true;
        }

        private static void addFileToZip(ZipOutputStream zStream, string relativePath, string file)
        {
            byte[] buffer = new byte[4096];
            string fileRelativePath = (relativePath.Length > 1 ? relativePath : string.Empty) + Path.GetFileName(file);
            ZipEntry entry = new ZipEntry(fileRelativePath);
            entry.DateTime = DateTime.Now;
            zStream.PutNextEntry(entry);

            using (FileStream fs = File.OpenRead(file))
            {
                int sourceBytes;
                do
                {
                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                    zStream.Write(buffer, 0, sourceBytes);

                } while (sourceBytes > 0);
            }
        }

        private static bool RaiseFileAddedToZip(string fileName, string archive)
        {
            ZipFileAddEventArgs args = new ZipFileAddEventArgs(fileName, archive);

            if (ZipFileAddedToArchive != null)
                ZipFileAddedToArchive(null, args);

            return !args.Cancel;
        }

        #endregion Private Static Methods

        /// <summary>
        /// Event raised when a file is added to the archive
        /// </summary>
        public static event ZipFileAddEventHandler ZipFileAddedToArchive;
    }

    public sealed class ZipFileAddEventArgs
    {
        public ZipFileAddEventArgs(string fileName, string archive)
        {
            FileName = fileName;
            Archive = archive;
            Cancel = false;
        }

        public string FileName { get; private set; }


        public string Archive { get; private set; }

        /// <summary>
        /// Allows user to cancel the operation
        /// </summary>
        public bool Cancel { get; set; }
    }

    public delegate void ZipFileAddEventHandler(object sender, ZipFileAddEventArgs e);
}
