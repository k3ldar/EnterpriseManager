using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

using SieraDelta.Library.Utils;
using SieraDelta.Library;

using SieraDelta.Website.Library;

using System.Data;
using ICSharpCode.SharpZipLib.Zip;

namespace SieraDelta.Classes.GeoIP
{
    public class GeoIPUpdate
    {
        //#region Private / Protected Members

        //private string GeoUpdateFile = String.Format(@"{0}Admin\GeoUpdate\Update.txt", GlobalClass.RootPath);
        //private int Updated = 0;
        //private int Unchanged = 0;
        //private int Added = 0;
        //private int Unknown = 0;

        //#endregion Private / Protected Members

        //#region Public Methods

        //public void Run(string GeoUpdatePath)
        //{
        //    // this functionality has moved to a service and is no longer part of the website
        //    return;

        //    //try
        //    //{
        //    //    if (!GeoCanRunGeoUpdate())
        //    //        return;

        //    //    //IPAddressToCountryRecreateExternalFile(String.Format("{0}Admin\\GeoUpdate\\", GlobalClass.RootPath));
        //    //    GeoUpdateLastUpdate();

        //    //    string LocalFile = String.Format(@"{0}Admin\GeoUpdate\IpToCountry.csv.zip", GeoUpdatePath);

        //    //    //Download the file
        //    //    Download("http://software77.net/geo-ip/?DL=2", LocalFile);

        //    //    Unpack(LocalFile, GeoUpdatePath + "Admin\\GeoUpdate\\");

        //    //    File.Delete(LocalFile);

        //    //    string GeoFile = String.Format(@"{0}Admin\GeoUpdate\IpToCountry.csv", GeoUpdatePath);
        //    //    string GeoTempTable = String.Format(@"{0}Admin\GeoUpdate\FirebirdGeoTempTable.csv", GeoUpdatePath);

        //    //    if (File.Exists(GeoFile))
        //    //    {
        //    //        DateTime start = DateTime.Now;
        //    //        try
        //    //        {
        //    //            if (ProcessFile(GeoFile, GeoTempTable))
        //    //            {
        //    //                File.Delete(GeoFile);
        //    //            }
        //    //        }
        //    //        catch (Exception err)
        //    //        {
        //    //            SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, GeoUpdatePath);
        //    //        }
        //    //        //finally
        //    //        //{
        //    //        //    // build an email to send stats on progress etc
        //    //        //    GlobalClass.SendEmail(String.Format("Update Geo IP Data - {0}", GlobalClass.DistributorWebsite), String.Format("Start Time: {0}<br />Finish time: {1}<br />Updated: {2}<br />Added: {4}<br />Unchanged: {3}<br />Unknown: {5}",
        //    //        //        start, DateTime.Now, Updated, Unchanged, Added, Unknown));
        //    //        //}
        //    //    }

        //    //    //backup database and compress it
        //    //    //string BackupFile = String.Format(@"{0}Admin\GeoUpdate\{1}{2}{3}.fbk", GeoUpdatePath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //    //    //BackupDatabase(BackupFile);
        //    //    //CompressBackupDatabase(String.Format(@"{0}Admin\GeoUpdate\{1}{2}{3}.zip", GeoUpdatePath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
        //    //    //    BackupFile);

        //    //}
        //    //catch (Exception err)
        //    //{
        //    //    SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, GeoUpdatePath);
        //    //}
        //}

        //#endregion Public Methods

        //#region Private Methods

        //private void BackupDatabase(string BackupFile)
        //{
        //    try
        //    {
        //        SieraDelta.Library.WebsiteAdministration.BackupDatabase(BackupFile);
        //    }
        //    catch (Exception err)
        //    {
        //        SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, BackupFile);
        //    }
        //}

        //private void Download(string SourceFile, string DestinationFile)
        //{
        //    try
        //    {
        //        // Create a 'WebRequest' object with the specified url. 
        //        WebRequest myWebRequest = WebRequest.Create(SourceFile);
        //        try
        //        {

        //            // Send the 'WebRequest' and wait for response.
        //            WebResponse myWebResponse = myWebRequest.GetResponse();
        //            try
        //            {

        //                // Obtain a 'Stream' object associated with the response object.
        //                Stream ReceiveStream = myWebResponse.GetResponseStream();

        //                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

        //                // Pipe the stream to a higher level stream reader with the required encoding format. 
        //                StreamReader readStream = new StreamReader(ReceiveStream, encode);
        //                try
        //                {
        //                    FileStream sw = File.Create(DestinationFile);
        //                    try
        //                    {
        //                        int size = 2048;
        //                        byte[] data = new byte[2048];
        //                        while (true)
        //                        {
        //                            size = ReceiveStream.Read(data, 0, data.Length);
        //                            if (size > 0)
        //                            {
        //                                sw.Write(data, 0, size);
        //                            }
        //                            else
        //                            {
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    finally
        //                    {
        //                        sw.Close();
        //                    }

        //                }
        //                finally
        //                {
        //                    readStream.Close();
        //                }
        //            }
        //            finally
        //            {
        //                // Release the resources of response object.
        //                myWebResponse.Close();
        //            }
        //        }
        //        finally
        //        {
        //            //myWebRequest
        //        }
        //    }
        //    catch (Exception err)
        //    {
        //        SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, SourceFile, DestinationFile);
        //    }
        //}

        //private void Unpack(string GeoFile, string GeoPath)
        //{
        //    try
        //    {
        //        if (!File.Exists(GeoFile))
        //        {
        //            return;
        //        }

        //        ZipInputStream s = new ZipInputStream(File.OpenRead(GeoFile));
        //        try
        //        {

        //            ZipEntry theEntry;
        //            while ((theEntry = s.GetNextEntry()) != null)
        //            {
        //                string directoryName = Path.GetDirectoryName(theEntry.Name);
        //                string fileName = Path.GetFileName(theEntry.Name);

        //                // create directory
        //                if (directoryName.Length > 0)
        //                {
        //                    Directory.CreateDirectory(GeoFile);
        //                }

        //                if (fileName != String.Empty)
        //                {
        //                    FileStream streamWriter = File.Create(GeoPath + theEntry.Name);
        //                    try
        //                    {

        //                        int size = 2048;
        //                        byte[] data = new byte[2048];
        //                        while (true)
        //                        {
        //                            size = s.Read(data, 0, data.Length);
        //                            if (size > 0)
        //                            {
        //                                streamWriter.Write(data, 0, size);
        //                            }
        //                            else
        //                            {
        //                                break;
        //                            }
        //                        }

        //                        streamWriter.Flush();
        //                    }
        //                    finally
        //                    {
        //                        streamWriter.Close();
        //                    }
        //                }
        //            }
        //        }
        //        finally
        //        {
        //            s.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), ex, GeoFile, GeoPath);
        //    }
        //    finally
        //    {
        //        //Update Status
        //    }
        //}

        //private bool ProcessFile(string GeoFile, string GeoTempTable)
        //{
        //    bool Result = false;

        //    int Count = 0;

        //    Updated = 0;
        //    Added = 0;
        //    Unchanged = 0;
        //    Unknown = 0;

        //    try
        //    {
        //        CreateTemporaryTable(GeoFile, GeoTempTable);
        //        Count = SieraDelta.Library.Website.IPAddressToCountryProcessFile(GeoFile, GeoTempTable, out Updated, out Unchanged, out Added, out Unknown);
        //        Result = Count > 0;
        //    }
        //    catch (Exception err)
        //    {
        //        SieraDelta.Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, GeoFile, GeoTempTable);
        //    }

        //    return (Result);
        //}

        //private int CreateTemporaryTable(string GeoFile, string GeoTempTable)
        //{
        //    int Result = 0;
        //    StreamReader file = new StreamReader(GeoFile);
        //    try
        //    {
        //        //SieraDeltaUtils u = new SieraDeltaUtils();
        //        SieraDelta.Library.Website web = new SieraDelta.Library.Website();
        //        string line;

        //        StreamWriter csv = new StreamWriter(GeoTempTable);
        //        try
        //        {

        //            // connect to db and create a transaction
        //            while ((line = file.ReadLine()) != null)
        //            {
        //                // not interested in comments i.e begins with # char
        //                if (!line.StartsWith("#"))
        //                {
        //                    string[] row;

        //                    row = line.Split(',');
        //                    // 0 = IP From; 1 = IP To; 2 = registry (ignored); 3 = date assigned (ignored); 
        //                    // 4 =  2 digit country code; 5 = 3 digit country code (ignored); 6 = Country Name

        //                    Int64 IPFrom = SieraDeltaUtils.StrToInt64Def(SieraDeltaUtils.RemoveDblQuotes(row[0]), 0);
        //                    Int64 IPTo = SieraDeltaUtils.StrToInt64Def(SieraDeltaUtils.RemoveDblQuotes(row[1]), 0);
        //                    string CountryCode = SieraDeltaUtils.RemoveDblQuotes(row[4]);
        //                    string Country = SieraDeltaUtils.RemoveDblQuotes(row[6]);


        //                    csv.Write(Buffer(IPFrom.ToString(), 16));
        //                    csv.Write(Buffer(IPTo.ToString(), 16));
        //                    csv.Write(Buffer(CountryCode, 2));
        //                    csv.Write(Buffer(Country, 100));

        //                    Result++;

        //                }
        //            }
        //        }
        //        finally
        //        {
        //            csv.Flush();
        //            csv.Close();
        //        }
        //    }
        //    finally
        //    {
        //        file.Close();
        //    }

        //    return (Result);
        //}

        //private string Buffer(string Data, int Length)
        //{
        //    string Result = Data;

        //    while (Result.Length < Length)
        //        Result = Result + " ";

        //    return (Result);
        //}

        //private string BufferNumber(string Data, int Length)
        //{
        //    string Result = Data;

        //    while (Result.Length < Length)
        //        Result = "0" + Result;

        //    return (Result);
        //}

        //private string RemoveDblQuotes(string s)
        //{
        //    string Result = s;

        //    Result = Result.Substring(1, Result.Length - 2);

        //    return (Result);
        //}

        //private void GeoUpdateLastUpdate()
        //{
        //    StreamWriter tw = new StreamWriter(GeoUpdateFile);
        //    //SieraDeltaUtils u = new SieraDeltaUtils();
        //    DateTime NextRun = DateTime.Now.AddDays(1);

        //    tw.WriteLine(SieraDeltaUtils.DateTimeToStr(NextRun, "en-gb"));
        //    tw.Close();
        //}

        //private bool GeoCanRunGeoUpdate()
        //{
        //    bool Result = false;

        //    if (!File.Exists(GeoUpdateFile))
        //        Result = true;
        //    else
        //    {
        //        StreamReader sr = new StreamReader(GeoUpdateFile);
        //        //SieraDeltaUtils u = new SieraDeltaUtils();

        //        DateTime t = SieraDeltaUtils.StrToDateTime(sr.ReadLine(), "en-gb");

        //        Result = t < DateTime.Now;

        //        sr.Close();
        //    }

        //    return (Result);
        //}

        //#endregion Private Methods
    }
}