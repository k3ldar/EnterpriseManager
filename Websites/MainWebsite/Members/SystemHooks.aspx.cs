using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.Hooks;

namespace Heavenskincare.WebsiteTemplate.Website.Members
{
    public partial class SystemHooks : BaseWebFormStaff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();

            Hooks allHooks = Hooks.Get(GetUser());
            int actionID = GetFormValue("id", -1);

            if (actionID > -1)
            {
                HookEvent h = (HookEvent)actionID;

                switch (GetFormValue("action"))
                {
                    case "add":
                        if (!allHooks.Exists(h))
                            Hooks.Add(h, GetUser());
                        allHooks = Hooks.Get(GetUser());
                        break;
                    case "remove":
                        if (allHooks.Exists(h))
                            Hooks.Remove(h, GetUser());
                        allHooks = Hooks.Get(GetUser());
                        break;
                }
            }

            foreach (string hook in Enum.GetNames(typeof(HookEvent)))
            {
                HookEvent currHook = (HookEvent)Enum.Parse(typeof(HookEvent), hook);
                HtmlTableRow r = new HtmlTableRow();
                tblHooks.Rows.Add(r);

                HtmlTableCell cHookName = new HtmlTableCell();
                cHookName.InnerText = hook;
                r.Cells.Add(cHookName);

                HtmlTableCell cHookAction = new HtmlTableCell();
                

                if (allHooks.Exists(currHook))
                {
                    cHookAction.InnerHtml = String.Format("<a href=\"/Members/SystemHooks.aspx?action=remove&id={0}\">Remove</a>",
                        (int)currHook);
                }
                else
                {
                    cHookAction.InnerHtml = String.Format("<a href=\"/Members/SystemHooks.aspx?action=add&id={0}\">Add</a>",
                        (int)currHook);
                }

                r.Cells.Add(cHookAction);
            }
        }
    }
}