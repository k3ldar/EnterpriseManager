using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

using Library.BOL.Downloads;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members.Controls
{
    public partial class DownloadableFile : BaseControlClass
    {
        private Library.BOL.Downloads.Download _download;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnDownload.Text = Languages.LanguageStrings.Download;
        }

        public void Refresh(Library.BOL.Downloads.Download file)
        {
            _download = file;
            lblDescription.InnerText = file.Description;
            lblFileName.InnerHtml = String.Format("{0} <span>({1})</span>", file.ShortFileName, file.FileSize);

            string rootPathDestination = String.Format("{0}/Download/trade/", Global.RootURL);
            switch (file.FileExtension)
            {
                case ".jpg":
                    rootPathDestination += file.ShortFileName;
                    break;
                case ".jpeg":
                    rootPathDestination += file.ShortFileName;
                    break;
                case ".gif":
                    rootPathDestination += file.ShortFileName;
                    break;
                case ".zip":
                    rootPathDestination = "https://www.heavenskincare.com/images/other/zipfile.jpg";
                    break;
                case ".xlsx":
                case ".xls":
                    rootPathDestination = "https://www.heavenskincare.com/images/other/xlsfile.jpg";
                    break;
                case ".pdf":
                    rootPathDestination = "https://www.heavenskincare.com/images/other/pdffile.jpg";
                    break;
                default:
                    rootPathDestination = "https://www.heavenskincare.com/images/other/file.jpg";
                    break;
            }

            imgPreview.ImageUrl = rootPathDestination.Replace("http:", "https:");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            //string file = String.Format("\\Downloads\\UPloads\\Final\\{0}", _download.ShortFileName);
            string file = String.Format("{1}download\\trade\\{0}", _download.ShortFileName, Global.Path);
            DownloadFile(file, true);
        }

        private void DownloadFile(string fname, bool forceDownload)
        {
            string path = fname; // MapPath(fname);
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".htm":
                    case ".html":
                        type = "text/HTML";
                        break;

                    case ".txt":
                        type = "text/plain";
                        break;

                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                }
            }
            if (forceDownload)
            {
                Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            }
            if (type != "")
                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}