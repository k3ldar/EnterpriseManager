using System;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.HashTags;

using webLib = Website.Library;

#pragma warning disable IDE1006

namespace SieraDelta.Website.Controls
{
    public partial class WebPageTags : BaseControlClass
    {
        private HashTags _pageTags = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetUserSession().MobileRedirect)
            {
                this.Visible = false;
                return;
            }

            tdError.InnerText = String.Empty;

            if (GetUser() == null)
                this.Visible = false;
            else
                this.Visible = GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ManageHashTags);

            if (!IsPostBack)
            {
                //Get hash tags for page
                _pageTags = HashTags.GetPageTags(Request.Url);

                foreach (HashTag tag in _pageTags)
                {
                    ulTags.InnerHtml += String.Format("<li class=\"hashTag\">#{0}</li>", tag.Tag);
                }

                if (tblTagManager.Visible)
                {
                    btnAddTag.Enabled = _pageTags.Count < 12;

                    //load admin stuff up here
                    HashTags allTags = HashTags.GetTags();

                    foreach (HashTag tag in allTags)
                    {
                        if (_pageTags.IndexOf(tag.ID))
                            lstRemoveTags.Items.Add(new ListItem((string)tag.Tag, tag.ID.ToString()));
                        else
                            lstAddTags.Items.Add(new ListItem((string)tag.Tag, tag.ID.ToString()));
                    }

                    string page = Request.Url.ToString();

                    if (page.Length > 38)
                    {
                        page = page.Substring(page.Length - 38);
                    }

                    txtDescription.Text = Library.LibraryHelperClass.SettingsGetMeta(String.Format("DESCRIPTION:{0}", page)).Trim(); 
                    txtTitle.Text = Library.LibraryHelperClass.SettingsGetMeta(String.Format("TITLE:{0}", page)).Trim();
                }
            }
        }

        protected void btnCreateTag_Click(object sender, EventArgs e)
        {
            try
            {
                HashTags.CreateHashTag(Request.Url, txtCreateTag.Text);
                webLib.Classes.BaseMasterClassWebForm.ResetMetaDescriptions();
                tdError.Visible = false;
                DoRedirect(Request.Url.ToString());
            }
            catch (Exception err)
            {
                trError.Visible = true;
                tdError.InnerHtml = err.Message.Replace("\n", "<br />");
            }
        }

        protected void btnRemoveTag_Click(object sender, EventArgs e)
        {
            try
            {
                // add the tag to the page list
                ListItem item = lstRemoveTags.SelectedItem;

                if (item == null)
                    return;

                HashTags.RemoveHashTag(new HashTag(Convert.ToInt64(item.Value), item.Text), Request.Url);
                webLib.Classes.BaseMasterClassWebForm.ResetMetaDescriptions();
                trError.Visible = false;
                DoRedirect(Request.Url.ToString());
            }
            catch (Exception err)
            {
                trError.Visible = true;
                tdError.InnerHtml = err.Message.Replace("\n", "<br />");
            }
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            try
            {
                // add the tag to the page list
                ListItem item = lstAddTags.SelectedItem;

                if (item == null)
                    return;

                HashTags.AddHashTag(new HashTag(Convert.ToInt64(item.Value), item.Text), Request.Url);
                webLib.Classes.BaseMasterClassWebForm.ResetMetaDescriptions();
                trError.Visible = false;
                DoRedirect(Request.Url.ToString());
            }
            catch (Exception err)
            {
                trError.Visible = true;
                tdError.InnerHtml = err.Message.Replace("\n", "<br />");
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string page = Request.Url.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            Library.LibraryHelperClass.SettingsSetMeta(String.Format("DESCRIPTION:{0}", page), txtDescription.Text);
            BaseMasterClassWebForm.ResetMetaDescriptions();
        }

        protected void btnSaveTitle_Click(object sender, EventArgs e)
        {
            string page = Request.Url.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            Library.LibraryHelperClass.SettingsSetMeta(String.Format("TITLE:{0}", page), txtTitle.Text);

            webLib.Classes.SharedWebBase.ResetWebTitleCache();
        }
    }
}