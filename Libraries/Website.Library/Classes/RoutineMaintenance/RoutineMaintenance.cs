using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Xml;

using System.IO;

using lib = Library;
using Languages;
using Website.Library;
using Website.Library.Classes;

namespace Classes.RoutineMaintenance
{
    public class RoutineMaintenance
    {
        public static List<ImageCreateLocation> ImageLocations = new List<ImageCreateLocation>();

        /// <summary>
        /// Executes archive log data routine maintenance
        /// </summary>
        public void RunArchiveLogData()
        {
            try
            {
                if (Website.Library.GlobalClass.AllowRoutineMaintenance)
                {
                    //Library.WebsiteAdministration.RoutineMaintenance(RoutineMaintenanceType.ArchiveLogs);
                }
            }
            catch (Exception err)
            {
                string Message = String.Format("<p>{0}</p><p>{1}</p>", err.Message, err.StackTrace.ToString());
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }
        }

        /// <summary>
        /// Executes routine maintenance for campaigns
        /// </summary>
        public void RunCampaigns()
        {
            try
            {
                if (Website.Library.GlobalClass.AllowRoutineMaintenance)
                {
                    Library.WebsiteAdministration.RoutineMaintenance(lib.RoutineMaintenanceType.Campaign);
                }
            }
            catch (Exception err)
            {
                string Message = String.Format("<p>{0}</p><p>{1}</p>", err.Message, err.StackTrace.ToString());
                Library.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }
        }

        /// <summary>
        /// Run executes all routine maintenance tasks
        /// </summary>
        public void Run()
        {
            try
            {
                if (GlobalClass.CreateXMLImageFiles)
                    CreateXMLImageFiles();

                if (GlobalClass.AllowRoutineMaintenance)
                {
                    UpdateDistributorDetails();
                    lib.WebsiteAdministration.RoutineMaintenance(lib.RoutineMaintenanceType.General);
                    ProcessUnpaidOrders();
                    TicketMaintenance();
                }

                ClearTempImages();
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("Thread was being aborted"))
                {
                    string Message = String.Format("<p>{0}</p><p>{1}</p>", err.Message, err.StackTrace.ToString());
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                }
                else if (err.Message.Contains(" lock conflict on no wait transaction"))
                {

                }
                else
                    throw;

            }
        }

        private void CreateXMLImageFile(string path, string searchString, string rootName, string outputFile)
        {
            Shared.EventLog.Add("CreateXMLFile", path);

            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] rgFiles = di.GetFiles(searchString);
                XmlDocument doc = new XmlDocument();

                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);// Create the root element
                XmlElement root = doc.CreateElement(rootName);
                doc.AppendChild(root);
                try
                {
                    foreach (FileInfo fi in rgFiles)
                    {
                        XmlElement name = doc.CreateElement("Name");
                        name.InnerText = fi.Name.ToUpper();
                        root.AppendChild(name);
                    }
                }
                finally
                {
                    string xmlOutput = doc.OuterXml;
                    CreateFile(outputFile, xmlOutput);
                }
            }
            else
            {
                Shared.EventLog.Add("Create XML File", String.Format("Path not found: {0}", path));
            }
        }

        private void CreateXMLImageFiles()
        {
            foreach (ImageCreateLocation location in ImageLocations)
            {
                try
                {
                    CreateXMLImageFile(location.SearchPath, location.SearchPattern, location.RootNode, location.XMLFile);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains("it is being used by another process"))
                        lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                }                
            }

        }

        private void CreateFile(string FileName, string Text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FileName, false);
                try
                {
                    sw.Write(Text);
                }
                finally
                {
                    sw.Close();
                    sw.Dispose();
                    sw = null;
                }
            }
            catch (Exception err)
            {
                if (!err.Message.Contains("it is being used by another process"))
                    lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
            }
        }

        /// <summary>
        /// Rebuilds Index.html to the same as Index.aspx
        /// </summary>
        private void BuildFrontPage(string file, string fileURL)
        {
            try
            {
                File.Delete(file);
                WebClient client = new WebClient();
                client.Headers["USER-AGENT"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
                client.DownloadFile(fileURL, file);
                client.Dispose();
            }
            catch (Exception err)
            {
                lib.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, file, fileURL);
            }
        }

        /// <summary>
        /// Updates distributor details
        /// 
        /// Used by system emails
        /// </summary>
        private void UpdateDistributorDetails()
        {
            try
            {
                Library.LibraryHelperClass.SettingsSetMeta("SITE.URL", GlobalClass.RootURL);
                Library.LibraryHelperClass.SettingsSetMeta("SITE.ADDRESS", String.Format("{0}\r\n{1}\r\n{2}", BaseWebApplication.AddressLine1, BaseWebApplication.AddressLine2, BaseWebApplication.AddressLine3));
                Library.LibraryHelperClass.SettingsSetMeta("SITE.TELEPHONE", BaseWebApplication.WebsiteTelephoneNumber);
            }
            catch (Exception err)
            {
                if (!err.Message.Contains(StringConstants.ERROR_FIREBIRD_LOCK_CONFLICT_1) && !err.Message.Contains(StringConstants.ERROR_FIREBIRD_LOCK_CONFLICT_2))
                    Shared.EventLog.Add(err);
            }
        }

        private void ProcessUnpaidOrders()
        {
            lib.LibraryHelperClass Web = new Library.LibraryHelperClass();
            Web.ProcessUnpaidOrders();
        }

        private void TicketMaintenance()
        {
            lib.BOL.Helpdesk.SupportTickets.Maintenance();
        }

        private void ClearTempImages()
        {
            string ImageDirectory = GlobalClass.RootPath + @"Admin\Reports\WebChartGraphs\";

            if (Directory.Exists(ImageDirectory))
            {
                // looking for files 20 minutes old or older
                TimeSpan ts = new TimeSpan(0, 20, 0);

                foreach (string f in Directory.GetFiles(ImageDirectory, "*.png"))
                {
                    if (DateTime.Now - File.GetCreationTime(f) >= ts)
                    {
                        try
                        {
                            File.Delete(f);
                        }
                        catch (Exception err)
                        {
                            if (err.Message.IndexOf("is denied") < 5)
                                throw new Exception(err.Message);
                        }
                    }
                }
            }
        }
    }


    public class ImageCreateLocation
    {
        public ImageCreateLocation(string path, string searchPattern, string rootNode, string xmlFile)
        {
            SearchPath = path;
            SearchPattern = searchPattern;
            RootNode = rootNode;
            XMLFile = xmlFile;
        }

        #region Properties

        /// <summary>
        /// Path where search will take place
        /// </summary>
        public string SearchPath { get; private set; }
        
        /// <summary>
        /// Search Pattern for files to find
        /// </summary>
        public string SearchPattern { get; private set; }

        /// <summary>
        /// Name of root node in xml file
        /// </summary>
        public string RootNode { get; private set; }

        /// <summary>
        /// XML File that will be saved
        /// </summary>
        public string XMLFile { get; private set; }

        #endregion Properties
    }
}