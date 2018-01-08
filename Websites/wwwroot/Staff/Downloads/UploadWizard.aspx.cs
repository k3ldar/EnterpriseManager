using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

namespace SieraDelta.Website.Staff.Downloads
{
    public partial class Downloads : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FileUpload1.Visible = true;
                FileUpload11.Visible = false;
            }

            FileUpload1.OnNextPage += new WizardNextPageDelegate(FileUpload1_OnNextPage);
            FileUpload11.OnNextPage += new WizardNextPageDelegate(FileUpload11_OnNextPage);
        }

        void FileUpload11_OnNextPage(object sender, NextPageArgs e)
        {
            DoRedirect("/Staff/Downloads/Index.aspx");
        }

        void FileUpload1_OnNextPage(object sender, NextPageArgs e)
        {
            FileUpload1.Visible = false;
            FileUpload11.Visible = true;

            if (!FileUpload11.LoadNextFile())
                DoRedirect("/Staff/Downloads/Index.aspx");
        }
    }
}