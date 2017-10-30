using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Heavenskincare.WebsiteTemplate.Controls;
using Library.BOL.Helpdesk;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Staff.Admin.FAQ
{
    public partial class Index : BaseWebFormAdmin
    {
        private WebsiteAdministration _admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            _admin = new WebsiteAdministration(GetUser());

            LoadFAQItems();
        }

        protected void LoadFAQItems()
        {
            FAQItems items = FAQItems.Get(GetFormValue("Page", 1), 10);

            foreach (FAQItem item in items)
            {
                KnowledgeBaseItem ctl = (KnowledgeBaseItem)LoadControl("~/Staff/Controls/KnowledgeBaseItem.ascx");
                ctl.Refresh(item);
                pFAQItems.Controls.Add(ctl);
            }
        }

        protected string BuildPagination()
        {
            string Result = "";

            int Count = 0;

            Count = FAQItems.GetCount();

            Result = BuildPagination(Count, 10, GetFormValue("Page", 1), "/Staff/Admin/FAQ/Index.aspx");

            return (Result);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            FAQItem newFAQ = FAQItems.Create();
            DoRedirect(String.Format("/Staff/Admin/FAQ/Edit.aspx?ID={0}", newFAQ.ID));
        }

    }
}