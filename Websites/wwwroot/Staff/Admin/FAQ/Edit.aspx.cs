using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Website.Library.Classes;
using Library.BOL.Helpdesk;

namespace SieraDelta.Website.Staff.Admin.FAQ
{
    public partial class Edit : BaseWebFormAdmin
    {
        private const string FILE_LOCATION = "{0}wwwroot\\images\\faq\\";
        private const string FILE_LOCATION2 = "{1}/images/faq/";

        private FAQItem _faqItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack || _faqItem == null)
                _faqItem = FAQItems.Get(GetFormValue("ID", 1));

            if (_faqItem == null)
                DoRedirect("/Staff/Admin/FAQ/Index.aspx");

            if (!IsPostBack)
            {
                LoadKBGroups();

                txtDescription.Text = _faqItem.Description;
                txtContent.Text = _faqItem.Content;
            }
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

        private void LoadKBGroups()
        {
            lstLocation.Items.Clear();

            KBGroups grps = KBGroups.Get();

            foreach (KBGroup group in grps)
            {
                ListItem itm = new ListItem(group.Name, group.ID.ToString());
                lstLocation.Items.Add(itm);

                if (itm.Value == _faqItem.Parent.ID.ToString())
                    itm.Selected = true;
            }
        }

        protected string GetItemID() 
        {
            return (_faqItem.ID.ToString());
        }

        protected string GetItemName()
        {
            return (_faqItem.Description);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _faqItem.Description = txtDescription.Text;
            _faqItem.Content = txtContent.Text.Replace("&gt;", ">").Replace("&lt;", "<");
            _faqItem.Parent = KBGroups.Get(GetUser(), Convert.ToInt32(lstLocation.Items[lstLocation.SelectedIndex].Value));
            _faqItem.Save();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _faqItem.Delete();
            DoRedirect("/Staff/Admin/FAQ/Index.aspx");
        }
    }
}