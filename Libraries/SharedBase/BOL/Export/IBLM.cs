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
 *  File: IBLM.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif
using System.IO;
using System.Net;
using System.Text;

#if !ANDROID
using System.Data;
using ICSharpCode.SharpZipLib.Zip;
#endif

namespace SharedBase.BOL.Export
{
    [Serializable]
    public sealed class IBLM : BaseObject
    {
        public static string ExtractData(Int64 StartFrom)
        {
            string Result = DAL.FirebirdDB.ExportIBLMData(StartFrom);
            CompressFile(Result + ".zip", Result);
            return Path.GetFileName(Result + ".zip");
        }

        public static Int64 GetLatestIBLMUpdate()
        {
            Int64 Result = (Int64)DAL.FirebirdDB.IBLMMaxOperationID();

            return Result;
        }

        private static void CompressFile(string ZipFile, string BackupFile)
        {
#if !ANDROID
            ZipOutputStream zipOut = new ZipOutputStream(File.Create(ZipFile));
            zipOut.Password = "shifoo";
            FileInfo fi = new FileInfo(BackupFile);
            ZipEntry entry = new ZipEntry(fi.Name);
            FileStream sReader = File.OpenRead(BackupFile);
            byte[] buff = new byte[Convert.ToInt32(sReader.Length)];
            sReader.Read(buff, 0, (int)sReader.Length);
            entry.DateTime = fi.LastWriteTime;
            entry.Size = sReader.Length;
            sReader.Close();
            zipOut.PutNextEntry(entry);
            zipOut.Write(buff, 0, buff.Length);
            zipOut.Finish();
            zipOut.Close();

            //delete backup file
            File.Delete(BackupFile);
#endif
        }

    }
}
