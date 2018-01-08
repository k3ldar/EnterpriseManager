using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Downloads;

namespace SieraDelta.Website.Staff.Downloads
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

            foreach (Library.BOL.Downloads.Download file in files)
            {
                SieraDelta.Website.Controls.DownloadableFle df = (SieraDelta.Website.Controls.DownloadableFle)LoadControl("~/Staff/Controls/DownloadableFile.ascx");
                df.Refresh(file);
                pPlaceHolder.Controls.Add(df);
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = Library.BOL.Downloads.Downloads.GetCount(0, false);

            Result = BuildPagination(Count, 6, GetFormValue("Page", 1), "/Downloads/Index.aspx", false);

            return (Result);
        }

    }
}