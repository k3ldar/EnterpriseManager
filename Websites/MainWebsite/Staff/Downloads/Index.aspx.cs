using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Downloads;

namespace Heavenskincare.WebsiteTemplate.WebsiteDownloads
{
    public partial class Index : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void LoadFiles()
        {
            Library.BOL.Downloads.Downloads files = Library.BOL.Downloads.Downloads.Get(6, GetFormValue("Page", 1), 0);

            foreach (Download file in files)
            {
                Heavenskincare.WebsiteTemplate.Controls.DownloadableFle df = (Heavenskincare.WebsiteTemplate.Controls.DownloadableFle)LoadControl("~/Staff/Controls/DownloadableFile.ascx");
                df.Refresh(file);
                pPlaceHolder.Controls.Add(df);
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = Library.BOL.Downloads.Downloads.GetCount(0, true);

            Result = BuildPagination(Count, 6, GetFormValue("Page", 1), "/Downloads/Index.aspx");

            return (Result);
        }

    }
}