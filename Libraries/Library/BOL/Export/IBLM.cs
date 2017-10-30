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

namespace Library.BOL.Export
{
    [Serializable]
    public sealed class IBLM : BaseObject
    {
        public static string ExtractData(Int64 StartFrom)
        {
            string Result = DAL.FirebirdDB.ExportIBLMData(StartFrom);
            CompressFile(Result + ".zip", Result);
            return (Path.GetFileName(Result + ".zip"));
        }

        public static Int64 GetLatestIBLMUpdate()
        {
            Int64 Result = (Int64)DAL.FirebirdDB.IBLMMaxOperationID();

            return (Result);
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
