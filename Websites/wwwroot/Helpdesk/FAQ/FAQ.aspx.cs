using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Helpdesk;
using Library.BOL.Users;

namespace SieraDelta.Website.Helpdeks.FAQ
{
    public partial class FAQ : BaseWebForm
    {
        #region Private Members

        private KBGroup _group;


        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            _group = KBGroups.Get(GetUser(), GetFormValue("GroupID", -1));

            if (_group == null)
                DoRedirect("/Hel-Ddesk/FAQ/Index.aspx");
        }

        protected string GroupBreadCrumb()
        {
            string Result = String.Format("<li><a href=\"/Help-Desk/FAQ/FAQ.aspx?GroupID={0}\">{1}</a></li>", _group.ID, _group.Name);
            KBGroup root = _group;

            while (root.Parent != null)
            {
                root = root.Parent;
                Result = String.Format("<li><a href=\"/Help-Desk/FAQ/FAQ.aspx?GroupID={2}\">{0}</a></li><li>&rsaquo;</li>{1}", root.Name, Result, root.ID);
            }

            return (Result);
        }

        protected string GetSubGroups()
        {
            string Result = "";
            User user = GetUser();

            KBGroups groups = KBGroups.Get(user, _group);

            if (groups == null || groups.Count == 0)
                return (Result);

            foreach (KBGroup grp in groups)
            {
                KBGroups subGroups = grp.SubGroups(GetUser());
                string Sub = "";

                if (subGroups.Count > 0)
                    Sub = String.Format(" ({1} {4}{2})<br /><span>{0} {3}</span>", subGroups.Count, grp.Items.Count, grp.Items.Count == 1 ? "" : "s", Languages.LanguageStrings.SubGroups, Languages.LanguageStrings.Item);
                else
                    Sub = String.Format(" ({0} {2}{1})", grp.Items.Count, grp.Items.Count == 1 ? "" : "s", Languages.LanguageStrings.Item);

                Result += String.Format("<li><a href=\"/Help-Desk/FAQ/FAQ.aspx?GroupID={1}\">{0}</a>{2}</li>", grp.Name, grp.ID, Sub);
            }

            return (Result);
        }

        protected string GetGroupItems()
        {
            string Result = "";

            FAQItems items = _group.Items;

            foreach (FAQItem item in items)
            {
                Result += String.Format("<li><a href=\"/Help-Desk/Frequently-Asked-Questions/View/{0}/{1}/\">{1} ({2} views)</a></li>", item.ID, item.Description, item.ViewCount);
            }

            return (Result);
        }

        #endregion Protected Methods
    }
}