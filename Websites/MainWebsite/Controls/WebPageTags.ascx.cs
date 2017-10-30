using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.HashTags;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Controls
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
                tblTagManager.Visible = GetUser().HasPermissionWebsite(
                    Library.SecurityEnums.SecurityPermissionsWebsite.ManageHashTags);

            if (!IsPostBack)
            {
                //Get hash tags for page
                _pageTags = HashTags.GetPageTags(Request.RawUrl.ToString());

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

                    string page = Request.RawUrl.ToString();

                    if (page.Length > 38)
                    {
                        page = page.Substring(page.Length - 38);
                    }

                    txtDescription.Text = Library.LibraryHelperClass.SettingsGet(String.Format("DESCRIPTION:{0}", page), String.Empty).Trim();
                    txtTitle.Text = Library.LibraryHelperClass.SettingsGet(String.Format("TITLE:{0}", page), String.Empty).Trim();

                    txtEmbedCode.Text = GetEmbedCode();
                }
            }
        }

        protected void btnCreateTag_Click(object sender, EventArgs e)
        {
            try
            {
                HashTags.CreateHashTag(Request.RawUrl.ToString(), txtCreateTag.Text);
                BaseMasterClassWebForm.ResetMetaDescriptions();
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

                HashTags.RemoveHashTag(new HashTag(Convert.ToInt64(item.Value), item.Text), Request.RawUrl.ToString());
                BaseMasterClassWebForm.ResetMetaDescriptions();
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

                HashTags.AddHashTag(new HashTag(Convert.ToInt64(item.Value), item.Text), Request.RawUrl.ToString());
                BaseMasterClassWebForm.ResetMetaDescriptions();
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
            string page = Request.RawUrl.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            Library.LibraryHelperClass.SettingsSet(String.Format("DESCRIPTION:{0}", page), txtDescription.Text);
            BaseMasterClassWebForm.ResetMetaDescriptions();
        }

        protected void btnSaveTitle_Click(object sender, EventArgs e)
        {
            string page = Request.RawUrl.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            Library.LibraryHelperClass.SettingsSet(String.Format("TITLE:{0}", page), txtTitle.Text);

            SharedWebBase.ResetWebTitleCache();
        }

        private string GetEmbedCode()
        {
            string Result = String.Empty;

            Int64 productID = GetFormValue("ID", -1);

            if (Request.FilePath.ToLower().Contains("/products/") && productID > -1)
            {
                //try and get the product

                Library.BOL.Products.Product product = Library.BOL.Products.Products.Get(productID);

                if (product != null)
                {
                    string image = product.Image.ToLower();

                    if (!image.Contains(".png") && !image.Contains(".jpg"))
                        image += "_178.jpg";

                    image = Library.Utils.HSCUtils.ResizeImage(image, 178);


                    Result = String.Format("<a href=\"{0}\"><img src=\"https://static.heavenskincare.com/Images/Products/{1}\" /></a>",
                        Request.Url.ToString(), image);
                }
            }
            
            if (String.IsNullOrEmpty(Result))
                Result = String.Format("<a href=\"{0}\">{0}</a>", Request.Url.ToString());

            return (Result);
        }
    }
}