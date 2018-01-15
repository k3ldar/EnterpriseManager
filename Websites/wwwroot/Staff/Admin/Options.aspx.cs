using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Invoices;

using SieraDelta.Website.Controls;

namespace SieraDelta.Website.Staff.Admin
{
    public partial class Options : BaseWebFormAdmin, WebsiteOptions
    {
        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(SecurityEnums.SecurityPermissionsWebsite.AlterWebsiteOptions))
                DoRedirect("/Site-Error/Invalid-Permission/", true);

            WebsiteSettings settings = new WebsiteSettings();
            string currentOption = GetFormValue("Option", "General Settings");

            LeftContainerControl2.SubHeader = "Website Options";
            LeftContainerControl2.SubOptions = GetWebsiteOptions(settings, currentOption);

            List<string> Options;

            if (String.IsNullOrEmpty(currentOption))
                Options = settings.WebSiteOptionHeaders();
            else
                Options = settings.WebSiteSubOptions(currentOption);


            settings.WebSiteOptions(currentOption, this);
        }

        private string GetWebsiteSubOptions(WebsiteSettings settings, string selectedOption,
            string currentOption, int depth)
        {
            string Result = String.Empty;

            List<string> subOptions = settings.WebSiteSubOptions(currentOption);

            if (subOptions.Count > 0)
            {
                foreach (string subOption in subOptions)
                {
                    Result += String.Format("<li {1} style=\"left: {2}px;\"><a href=\"/Staff/Admin/Options.aspx?Option={0}\">{0}</a></li>",
                        subOption, subOption == currentOption ? "class=\"current\"" : "", depth);

                    Result += GetWebsiteSubOptions(settings, selectedOption, subOption, depth + 15);
                }
            }

            return (Result);
        }

        private string GetWebsiteOptions(WebsiteSettings settings, string currentOption)
        {
            string Result = String.Empty;

            List<string> options = settings.WebSiteOptionHeaders();

            foreach (string option in options)
            {
                Result += String.Format("<li><a href=\"/Staff/Admin/Options.aspx?Option={0}\">{0}</a></li>",
                    option, option == currentOption ? "class=\"current\"" : "");

                Result += GetWebsiteSubOptions(settings, currentOption, option, 15);
            }

            return (Result);
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            Global.LoadWebsiteSettingsFromDatabase();
            SharedWebBase.ResetWebTitleCache();
            Shared.Classes.CacheManager.ClearAllCaches();
        }

        #endregion Protected Methods

        #region WebsiteOptions Methods

        public void AddHeader(string header)
        {
            HtmlGenericControl pSpacer = new HtmlGenericControl("p");
            pSpacer.InnerHtml = "&nbsp;";
            divOptions.Controls.Add(pSpacer);

            HtmlGenericControl h2 = new HtmlGenericControl("h2");
            h2.InnerText = header;
            divOptions.Controls.Add(h2);
        }

        public void AddDescription(string description)
        {
            HtmlGenericControl p = new HtmlGenericControl("p");
            p.InnerHtml = description;
            divOptions.Controls.Add(p);
        }

        public void AddOption(string name, int value, string description, string reference, int defaultValue,
            int minValue, int maxValue, bool isGlobal = false)
        {
            EditSettingsText settings = (EditSettingsText)LoadControl("~/Staff/Controls/EditSettingsText.ascx");
            settings.UpdateSetting(name, value, description, reference, value, minValue, maxValue, isGlobal);
            divOptions.Controls.Add(settings);
        }

        public void AddOption(string name, double value, string description, string reference, bool isGlobal)
        {
            AddOption(name, value.ToString(), description, reference, 100, isGlobal);
        }

        public void AddOption(string name, decimal value, string description, string reference, bool isGlobal = false)
        {
            AddOption(name, value.ToString(), description, reference, 100, isGlobal);
        }

        public void AddOption(string name, bool value, string description, string reference, bool isGlobal = false)
        {
            EditSettingsText settings = (EditSettingsText)LoadControl("~/Staff/Controls/EditSettingsText.ascx");
            settings.UpdateSetting(name, value, description, reference, 100, isGlobal);
            divOptions.Controls.Add(settings);
        }

        public void AddOption(string name, string value, string description, string reference, int width = 300,
            bool isPassword = false, bool isCulture = false, int numberOfLines = 1, bool isGlobal = false)
        {
            EditSettingsText settings = (EditSettingsText)LoadControl("~/Staff/Controls/EditSettingsText.ascx");
            settings.UpdateSetting(name, value, description, reference, width, isPassword, isCulture, numberOfLines, isGlobal);
            divOptions.Controls.Add(settings);
        }

        public void AddOption(string name, DateTime value, string description, string reference, bool isGlobal)
        {
            EditSettingsText settings = (EditSettingsText)LoadControl("~/Staff/Controls/EditSettingsText.ascx");
            settings.UpdateSetting(name, value, description, reference, isGlobal);
            divOptions.Controls.Add(settings);
        }

        #endregion WebsiteOptions Methods
    }
}