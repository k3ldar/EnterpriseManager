using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.CustomWebPages;
using Library.BOL.Countries;

using SieraDelta.Website.Controls;

namespace SieraDelta.Website.Staff.Admin
{
    public partial class CustomPages : BaseWebFormStaff
    {
        private const string FILE_LOCATION = "{0}wwwroot\\images\\custom\\";
        private const string FILE_LOCATION2 = "{0}/images/custom/";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.ManageCustomPages))
                DoRedirect("/Error/InvalidPermissions.aspx", true);

            Library.DAL.DALHelper.SetCustomPages();

            LeftContainerControl2.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl2.SubOptions = GetAccountOptions();

            btnLoad.Click += btnLoad_Click;
            btnSave.Click += btnSave_Click;

            if (!IsPostBack)
            {
                LoadCountries();
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            CustomPage page = Library.BOL.CustomWebPages.CustomPages.Get(lstPage.Items[lstPage.SelectedIndex].ToString(), Countries.Get(Convert.ToInt32(lstCountry.SelectedValue)), Library.DAL.DALHelper.WebsiteID);
            page.PageText = txtContent.Text.Replace("&gt;", ">").Replace("&lt;", "<");
            page.IsActive = cbActive.Checked;
            page.Save();

            txtContent.Text = page.PageText;
        }

        void btnLoad_Click(object sender, EventArgs e)
        {
            CustomPage page = Library.BOL.CustomWebPages.CustomPages.Get(lstPage.Items[lstPage.SelectedIndex].ToString(), Countries.Get(Convert.ToInt32(lstCountry.SelectedValue)), Library.DAL.DALHelper.WebsiteID);
            txtContent.Text = page.PageText;
            cbActive.Checked = page.IsActive;
        }

        protected void HtmlEditorExtender1_ImageUploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string[] files = Directory.GetFiles(String.Format(FILE_LOCATION, Global.RootPath));

            int Count = files.Count() + 1;
            string NewFile = String.Format("{0}{1}{2}", String.Format(FILE_LOCATION, Global.RootPath),
                Count, Path.GetExtension(e.FileName));

            HtmlEditorExtender1.AjaxFileUpload.SaveAs(NewFile);
            e.PostedUrl = Page.ResolveUrl(String.Format(FILE_LOCATION2, Global.RootURL) + Path.GetFileName(NewFile));
        }

        private void LoadCountries()
        {
            lstCountry.Items.Clear();
            Countries countries = Countries.Get();

            foreach (Country country in countries)
            {
                if (country.CanLocalize)
                {
                    ListItem item = new ListItem(country.Name, country.ID.ToString());
                    lstCountry.Items.Add(item);
                }
            }

            LoadCustomPages();
        }

        private void LoadCustomPages()
        {
            int countryID = SharedUtils.StrToInt(lstCountry.SelectedItem.Value, -1);

            foreach (CustomPage page in Library.BOL.CustomWebPages.CustomPages.GetAll(Library.DAL.DALHelper.WebsiteID))
            {
                if (page.Country.ID == countryID)
                    lstPage.Items.Add(new ListItem(page.Title));
            }

            if (lstPage.SelectedIndex == -1)
                lstPage.SelectedIndex = 0;

            CustomPage page1 = null;

            if (lstPage.SelectedIndex > -1)
                page1 = Library.BOL.CustomWebPages.CustomPages.Get(lstPage.Items[lstPage.SelectedIndex].ToString(), Countries.Get(Convert.ToInt32(lstCountry.SelectedValue)), Library.DAL.DALHelper.WebsiteID);

            if (page1 != null)
                txtContent.Text = page1.PageText;
        }

        protected void lstCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustomPages();
        }

        protected void lstPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomPage page1 = null;

            if (lstPage.SelectedIndex > -1)
                page1 = Library.BOL.CustomWebPages.CustomPages.Get(lstPage.Items[lstPage.SelectedIndex].ToString(), Countries.Get(Convert.ToInt32(lstCountry.SelectedValue)), Library.DAL.DALHelper.WebsiteID);

            if (page1 != null)
                txtContent.Text = page1.PageText;
        }
    }
}