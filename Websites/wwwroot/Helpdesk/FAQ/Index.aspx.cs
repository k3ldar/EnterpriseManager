using System;

using Website.Library.Classes;
using Library.BOL.Helpdesk;
using Library.BOL.Users;

namespace SieraDelta.Website.Helpdesk.FAQ
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GroupBreadCrumb()
        {
            return ("");
        }

        protected string GetGroups()
        {
            string Result = "";
            User user = GetUser();

            KBGroups groups = KBGroups.Get(user);
            if (groups == null || groups.Count == 0)
                groups = KBGroups.Get(user);

            foreach (KBGroup grp in groups)
            {
                KBGroups subGroups = grp.SubGroups(GetUser());
                string Sub = "";

                if (subGroups.Count > 0)
                    Sub = String.Format(" ({1} {4}{2})<br /><span>{0} {3}</span>", subGroups.Count, grp.Items.Count, grp.Items.Count == 1 ? "" : "s", Languages.LanguageStrings.SubGroups, Languages.LanguageStrings.Item);
                else
                    Sub = String.Format(" ({0} {2}{1})", grp.Items.Count, grp.Items.Count == 1 ? "" : "s", Languages.LanguageStrings.Item);

                Result += String.Format("<li><a href=\"/Help-Desk/Frequently-Asked-Questions/Group/{1}/{0}/\">{0}</a>{2}</li>", grp.Name, grp.ID, Sub);
            }

            return (Result);
        }
    }
}