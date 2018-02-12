using System;
using System.Collections.Generic;
using System.Diagnostics;

using Website.Library.Classes;

namespace SieraDelta.Website.Members.Products
{
    public partial class PosModuleUpdater : BaseWebForm
    {
        protected override void OnLoad(EventArgs e)
        {
            int storeID = GetFormValue("STORE", -1);
            int tillID = GetFormValue("TILL", -1);
            bool LoadNew = true;
            string hashConfirm = GetFormValue("HASH");

            string Result = String.Empty;

            string rootPluginModulePath = Library.BOL.Websites.WebsiteSettings.RootPath + "Download\\Files\\POS\\Modules\\";
            string rootPluginURL = Library.BOL.Websites.WebsiteSettings.RootURL + "/Download/Files/Pos/Modules/";

            //rootPluginModulePath = @"T:\SieraDelta\Website\wwwroot\Download\Files\POS\Modules\";
            //rootPluginURL = "http://localhost:60001/Download/Files/Pos/Modules/";

            // get local plugins
            string[] pluginFiles = System.IO.Directory.GetFiles(rootPluginModulePath, "*.dll", System.IO.SearchOption.TopDirectoryOnly);

            List<string> files = new List<string>();

            // are there any new plugins the user can get
            foreach (string newFile in pluginFiles)
            {
                files.Add(System.IO.Path.GetFileName(newFile).ToLower());
            }

            foreach (string param in Request.Form.AllKeys)
            {
                string paramValue = Request.Form[param];

                switch (param)
                {
                    case "STORE":
                        break;
                    case "TILL":
                        break;
                    case "ALLOW NEW":
                        LoadNew = paramValue == "True";
                        break;
                    case "HASH":
                        if (Shared.Utilities.HashStringMD5(String.Format("{0} - {1}", storeID, tillID)) != hashConfirm)
                        {
                            Result = "Invalid Hash Value";
                            break;
                        }

                        break;
                    default:
                        string file = rootPluginModulePath + param;

                        if (files.Contains(param.ToLower()))
                            files.Remove(param.ToLower());

                        if (System.IO.File.Exists(file))
                        {
                            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(file);
                            Version VerLocal = new Version(ver.FileVersion);
                            Version VerRemote = new Version(paramValue);

                            if (VerLocal.CompareTo(VerRemote) > 0)
                            {
                                Result += String.Format("{1}#{0}{1}\r",
                                    rootPluginURL, param);
                            }
                        }

                        break;
                }
            }

            // are there any new plugins?
            if (LoadNew && storeID > -1)
            {
                foreach (string s in files)
                {
                    Result += String.Format("{1}#{0}{1}\r",
                        rootPluginURL, s);
                }
            }

            Response.Write(String.IsNullOrEmpty(Result) ? "No Updates Available" : Result);
            Response.End();
        }
    }
}