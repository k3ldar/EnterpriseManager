using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library;

namespace Heavenskincare.WebsiteTemplate.Staff.Admin
{
    public partial class StaticBanners : BaseWebFormStaff
    {
        #region Private Members


        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            pError.Visible = false;

            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.StaticHomePageBanners))
                DoRedirect("/Staff/Admin/Index.aspx", true);

            if (!System.IO.Directory.Exists(String.Format("{0}Images\\Campaigns\\", Global.Path)))
                System.IO.Directory.CreateDirectory(String.Format("{0}Images\\Campaigns\\", Global.Path));

            if (!IsPostBack)
                LoadBannerInformation();
        }

        private void AjaxFileUploadHomepageImage_UploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Protected Methods

        #region Private Methods

        protected void LoadBannerInformation()
        {
            //website changes
            imageHomeBanner1.ImageUrl = Global.ConfigSettingGet("HomeBanner1", String.Empty);
            btnClearHomeImage1.Visible = !String.IsNullOrEmpty(imageHomeBanner1.ImageUrl);

            txtBannerURL1.Text = Global.ConfigSettingGet("HomeBanner1Link", String.Empty);

            imageHomeBanner2.ImageUrl = Global.ConfigSettingGet("HomeBanner2", String.Empty);
            btnClearHomeImage2.Visible = !String.IsNullOrEmpty(imageHomeBanner2.ImageUrl);

            txtBannerURL2.Text = Global.ConfigSettingGet("HomeBanner2Link", String.Empty);

            imageHomeBanner3.ImageUrl = Global.ConfigSettingGet("HomeBanner3", String.Empty);
            btnClearHomeImage3.Visible = !String.IsNullOrEmpty(imageHomeBanner3.ImageUrl);

            txtBannerURL3.Text = Global.ConfigSettingGet("HomeBanner3Link", String.Empty);

            imageHomeBanner4.ImageUrl = Global.ConfigSettingGet("HomeBanner4", String.Empty);
            btnClearHomeImage4.Visible = !String.IsNullOrEmpty(imageHomeBanner4.ImageUrl);

            txtBannerURL4.Text = Global.ConfigSettingGet("HomeBanner4Link", String.Empty);

            imageHomeBanner5.ImageUrl = Global.ConfigSettingGet("HomeBanner5", String.Empty);
            btnClearHomeImage5.Visible = !String.IsNullOrEmpty(imageHomeBanner5.ImageUrl);

            txtBannerURL5.Text = Global.ConfigSettingGet("HomeBanner5Link", String.Empty);

            imageBlogBanner.ImageUrl = Global.ConfigSettingGet("BlogBanner", String.Empty);

            imageTradeBanner.ImageUrl = Global.ConfigSettingGet("TradeBanner", String.Empty);
        }

        #region Image 1

        protected void btnUploadHomeImage1_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeBanner1.HasFile)
            {
                string FileName = String.Format("homebanner1{0}", Path.GetExtension(FileUploadHomeBanner1.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeBanner1.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                Global.ConfigSettingSet("HomeBanner1", FileURL);
                Global.HomeBanner1 = FileURL;
                imageHomeBanner1.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearHomeImage1_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("HomeBanner1", String.Empty);
            Global.HomeBanner1 = "";
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image 1

        #region Image 2

        protected void btnUploadHomeImage2_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeBanner2.HasFile)
            {
                string FileName = String.Format("homebanner2{0}", Path.GetExtension(FileUploadHomeBanner2.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeBanner2.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                Global.ConfigSettingSet("HomeBanner2", FileURL);
                Global.HomeBanner2 = FileURL;
                imageHomeBanner2.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearHomeImage2_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("HomeBanner2", String.Empty);
            Global.HomeBanner2 = "";
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image 2

        #region Image 3

        protected void btnUploadHomeImage3_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeBanner3.HasFile)
            {
                string FileName = String.Format("homebanner3{0}", Path.GetExtension(FileUploadHomeBanner3.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeBanner3.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                Global.ConfigSettingSet("HomeBanner3", FileURL);
                Global.HomeBanner3 = FileURL;
                imageHomeBanner3.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearHomeImage3_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("HomeBanner3", String.Empty);
            Global.HomeBanner3 = "";
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image 3

        #region Image 4

        protected void btnUploadHomeImage4_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeBanner4.HasFile)
            {
                string FileName = String.Format("homebanner4{0}", Path.GetExtension(FileUploadHomeBanner4.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeBanner4.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                Global.ConfigSettingSet("HomeBanner4", FileURL);
                Global.HomeBanner4 = FileURL;
                imageHomeBanner4.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearHomeImage4_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("HomeBanner4", String.Empty);
            Global.HomeBanner4 = "";
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image 4

        #region Image 5

        protected void btnUploadHomeImage5_Click(object sender, EventArgs e)
        {
            if (FileUploadHomeBanner5.HasFile)
            {
                string FileName = String.Format("homebanner5{0}", Path.GetExtension(FileUploadHomeBanner5.FileName));

                if (File.Exists(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                FileUploadHomeBanner5.SaveAs(String.Format("{1}Images\\Campaigns\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Campaigns/" + FileName;
                Global.ConfigSettingSet("HomeBanner5", FileURL);
                Global.HomeBanner5 = FileURL;
                imageHomeBanner5.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearHomeImage5_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("HomeBanner5", String.Empty);
            Global.HomeBanner5 = "";
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image 5

        #region Image Blog Banner

        protected void btnUploadBlogBanner_Click(object sender, EventArgs e)
        {
            if (FileUploadBlog.HasFile)
            {
                string FileName = FileUploadBlog.FileName;

                if (File.Exists(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path));

                FileUploadBlog.SaveAs(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Banners/" + FileName;
                Global.ConfigSettingSet("BlogBanner", FileURL);
                Global.BlogBanner = FileURL;
                imageBlogBanner.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearBlogBanner_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("BlogBanner", String.Empty);
            Global.BlogBanner = String.Empty;
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image Blog Banner

        #region Image Trade Banner

        protected void btnUploadTradeBanner_Click(object sender, EventArgs e)
        {
            if (FileUploadTrade.HasFile)
            {
                string FileName = FileUploadTrade.FileName;

                if (File.Exists(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path)))
                    File.Delete(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path));

                FileUploadTrade.SaveAs(String.Format("{1}Images\\Banners\\{0}", FileName, Global.Path));

                string FileURL = Global.RootURL + "/Images/Banners/" + FileName;
                Global.ConfigSettingSet("TradeBanner", FileURL);
                Global.TradeBanner = FileURL;
                imageTradeBanner.ImageUrl = FileURL;
                DoRedirect("/Staff/Admin/StaticBanners.aspx");
            }
        }

        protected void btnClearTradeBanner_Click(object sender, EventArgs e)
        {
            Global.ConfigSettingSet("TradeBanner", String.Empty);
            Global.TradeBanner = String.Empty;
            DoRedirect("/Staff/Admin/StaticBanners.aspx");
        }

        #endregion Image Trade Banner


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.StaticHomePageBanners))
            {
                Global.ConfigSettingSet("HomeBanner1Link", txtBannerURL1.Text);
                Global.ConfigSettingSet("HomeBanner2Link", txtBannerURL2.Text);
                Global.ConfigSettingSet("HomeBanner3Link", txtBannerURL3.Text);
                Global.ConfigSettingSet("HomeBanner4Link", txtBannerURL4.Text);
                Global.ConfigSettingSet("HomeBanner5Link", txtBannerURL5.Text);

                Global.LoadWebsiteSettingsFromDatabase();
                SharedWebBase.ResetWebTitleCache();
            }
        }

        #endregion Private Methods
    }
}