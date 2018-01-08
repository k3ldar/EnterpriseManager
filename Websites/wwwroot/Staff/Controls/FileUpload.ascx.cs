using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Website.Library.Classes;

namespace SieraDelta.Website.Controls
{
    public partial class FileUpload : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxFileUpload1.UploadComplete += new EventHandler<AjaxControlToolkit.AjaxFileUploadEventArgs>(AjaxFileUpload1_UploadComplete);
        }

        void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string path = String.Format("{1}Download\\Files\\Temp\\{0}", e.FileName, Global.Path);
            
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            AjaxFileUpload1.SaveAs(path);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            RaiseNextPage(1);
        }

        #region Events

        private void RaiseNextPage(int Page)
        {
            if (OnNextPage != null)
                OnNextPage(this, new NextPageArgs(Page));
        }

        public event WizardNextPageDelegate OnNextPage;

        #endregion Events


    }
}