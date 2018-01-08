using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;

namespace SieraDelta.Website.Controls
{
    public partial class KnowledgeBaseItem : BaseControlClass
    {
        private FAQItem _item;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(FAQItem Item)
        {
            lblCategory.Text = Item.Parent.Name;
            lblDescription.Text = Item.Description;
            _item = Item;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            DoRedirect(String.Format("/Staff/Admin/FAQ/Edit.aspx?ID={0}", _item.ID));
        }
    }
}