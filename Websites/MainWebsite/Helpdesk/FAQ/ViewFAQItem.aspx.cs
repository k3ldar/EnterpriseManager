using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;
using Library.BOL.Users;

namespace Heavenskincare.WebsiteTemplate.Helpdeks.FAQ
{
    public partial class ViewFAQItem : BaseWebForm
    {       
        #region Private Members

        private FAQItem _item;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {
            _item = FAQItems.Get(GetFormValue("ItemID", -1));

            if (_item == null)
                DoRedirect("/Helpdesk/FAQ/Index.aspx");

            _item.ViewCount += 1;
        }

        protected string GroupBreadCrumb()
        {
            string Result = String.Format("<li><a href=\"/Helpdesk/FAQ/FAQ.aspx?GroupID={0}\">{1}</a></li>", _item.Parent.ID, _item.Parent.Name);
            KBGroup root = _item.Parent;

            while (root.Parent != null)
            {
                root = root.Parent;
                Result = String.Format("<li><a href=\"/Helpdesk/FAQ/FAQ.aspx?GroupID={2}\">{0}</a></li><li>&rsaquo;</li>{1}", root.Name, Result, root.ID);
            }

            return (Result);
        }

        protected string GetItemName()
        {
            return (_item.Description);
        }

        protected string GetItem()
        {
            return (_item.Content);
        }
    }
}