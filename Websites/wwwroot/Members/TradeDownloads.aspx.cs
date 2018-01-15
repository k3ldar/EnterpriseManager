using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Downloads;

namespace Heavenskincare.WebsiteTemplate.Members
{
    public partial class TradeDownloads : BaseWebFormSalonOwner
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();

            LoadFiles();
        }

        private void LoadFiles()
        {
            Library.BOL.Downloads.Downloads files = Library.BOL.Downloads.Downloads.Get(6, GetFormValue("Page", 1), 0);

            foreach (Library.BOL.Downloads.Download file in files)
            {
                Heavenskincare.WebsiteTemplate.Members.Controls.DownloadableFile df = (Heavenskincare.WebsiteTemplate.Members.Controls.DownloadableFile)LoadControl("~/Members/Controls/DownloadableFile.ascx");
                df.Refresh(file);
                pPlaceHolder.Controls.Add(df);
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = Library.BOL.Downloads.Downloads.GetCount(0, true);

            Result = BuildPagination(Count, 6, GetFormValue("Page", 1), "/Members/TradeDownloads.aspx");

            return (Result);
        }
    }
}