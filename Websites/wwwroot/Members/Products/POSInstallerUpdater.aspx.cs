using System;

using Website.Library.Classes;

namespace SieraDelta.Website.Members.Products
{
    public partial class POSInstallerUpdater : BaseWebForm
    {
        protected override void OnLoad(EventArgs e)
        {
            int storeID = GetFormValue("STORE", -1);
            int tillID = GetFormValue("TILL", -1);
            string hashConfirm = GetFormValue("HASH");
            string currentVersion = GetFormValue("VERSION");
            string Result = String.Empty;

            string rootPosPath = Library.BOL.Websites.WebsiteSettings.RootPath + "Download\\Files\\POS\\";
            string rootPosURL = Library.BOL.Websites.WebsiteSettings.RootURL + "/Download/Files/Pos/";

            foreach (string param in Request.Form.AllKeys)
            {
                string paramValue = Request.Form[param];

                switch (param)
                {
                    case "STORE":
                        break;
                    case "TILL":
                        break;
                    case "HASH":
                        if (Shared.Utilities.HashStringMD5(String.Format("{0} - {1}", storeID, tillID)) != hashConfirm)
                        {
                            Result = "Invalid Hash Value";
                            break;
                        }

                        break;
                    case "VERSION":
                        Version VerLocal = new Version(paramValue);
                        string remoteVer = Library.XML.GetXMLValue(rootPosPath + "POSVersion2.xml", "Application", "Version");
                        Version VerRemote = new Version(String.IsNullOrEmpty(remoteVer) ? "1.0.0.0" : remoteVer);

                        if (VerRemote.CompareTo(VerLocal) > 0)
                        {
                            Result = String.Format("New Version#{0}\r", Library.XML.GetXMLValue(rootPosPath + "POSVersion2.xml", "Application", "Location"));
                        }

                        break;

                    default:
                        break;
                }
            }

            Response.Write(String.IsNullOrEmpty(Result) ? "No Updates Available" : Result);
            Response.End();
        }
    }
}