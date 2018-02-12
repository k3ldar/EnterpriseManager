using System;

using Library.BOL.Websites;

using Website.Library.Classes;

#pragma warning disable IDE1005
#pragma warning disable IDE1006

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
            string path = String.Format("{1}Download\\Files\\Temp\\{0}", e.FileName, WebsiteSettings.RootPath);
            
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