using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Website.Library.Classes;
using Library.BOL.Downloads;

namespace SieraDelta.Website.Controls
{
    public partial class FileUpload1 : BaseControlClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool LoadNextFile()
        {
            bool Result = false;
            string rootPath = String.Format("{0}Download\\Files\\Temp\\", Global.Path);

            foreach (string nextFile in Directory.GetFiles(rootPath))
            {

                txtFileName.Text = nextFile.Substring(rootPath.Length).ToLower();
                txtDescription.Text = "";
                Result = true;
                break;
            }

            return (Result);
        }


        #region Events

        private void RaiseNextPage(int Page)
        {
            if (OnNextPage != null)
                OnNextPage(this, new NextPageArgs(Page));
        }

        public event WizardNextPageDelegate OnNextPage;

        #endregion Events

        protected void btnNext_Click(object sender, EventArgs e)
        {
            // save file to proper location
            string rootPathSource = String.Format("{0}Download\\Files\\Temp\\", Global.Path);
            string rootPathDestination = String.Format("{0}download\\Files\\", Global.Path);

            if (System.IO.File.Exists(rootPathDestination + txtFileName.Text))
                System.IO.File.Delete(rootPathDestination + txtFileName.Text);

            File.Move(rootPathSource + txtFileName.Text, rootPathDestination + txtFileName.Text);
            Library.BOL.Downloads.Downloads.Create(rootPathDestination + txtFileName.Text, txtDescription.Text);

            //get next file or finish
            if (!LoadNextFile())
                RaiseNextPage(2);
        }


    }
}