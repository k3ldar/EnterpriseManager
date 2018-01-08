using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Downloads;

namespace SieraDelta.Website.Download
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            //LeftContainerControl1.SubOptions = GetAccountOptions();

            LoadFiles();
        }

        private void LoadFiles()
        {
            Library.BOL.Downloads.Downloads files = Library.BOL.Downloads.Downloads.Get(6, GetFormValue("Page", 1), 0);

            foreach (Library.BOL.Downloads.Download file in files)
            {
                if (file.IsPublic)
                {
                    SieraDelta.Website.Members.Controls.DownloadableFile df = (SieraDelta.Website.Members.Controls.DownloadableFile)LoadControl("~/Members/Controls/DownloadableFile.ascx");
                    df.Refresh(file);
                    pPlaceHolder.Controls.Add(df);
                }
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = Library.BOL.Downloads.Downloads.GetCount(0, true);

            Result = BuildPagination(Count, 6, GetFormValue("Page", 1), "/Download/Index.aspx", false);

            return (Result);
        }
    }
}