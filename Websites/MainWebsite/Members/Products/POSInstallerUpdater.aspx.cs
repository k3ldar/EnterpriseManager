using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members.Products
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

            string rootPosPath = Global.Path + "Download\\Files\\POS\\";
            string rootPosURL = Global.RootURL + "/Download/Files/Pos/";

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