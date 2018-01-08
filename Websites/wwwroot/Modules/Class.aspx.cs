using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Library.BOL.ModuleDocumentation;
using Library;
using Website.Library.Classes;

namespace SieraDelta.Website.Modules
{
    public partial class Class : BaseWebForm
    {
        #region Private Members

        private ModuleClass _class;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {
            _class = ModuleClasses.Get(GetFormValue("id", 0));

            if (_class == null)
                DoRedirect("/Modules/Index.aspx", true);

            pEdit.Visible = MemberLevel >= (int)Library.MemberLevel.StaffMember;
            
            LeftContainerControl1.SubHeader = "Members";

            string sProperties = "<h6>Properties</h6><ul>";
            string sConstructors = "<h6>Constructors</h6><ul>";
            string sEvents = "<h6>Events</h6><ul>";
            string sMethods = "<h6>Methods</h6><ul>";

            foreach (ModuleMember member in _class.Members)
            {
                string item = String.Format("<li><a href=\"/Modules/Member.aspx?id={1}\">{0}</a></i>",
                    member.Name, member.ID);//, GetMemberImages(member));

                if (member.Properties.HasFlag(ModuleProperties.IsMethod))
                    sMethods += item;
                else if (member.Properties.HasFlag(ModuleProperties.IsConstructor))
                    sConstructors += item;
                else if (member.Properties.HasFlag(ModuleProperties.IsProperty))
                    sProperties += item;
                else if (member.Properties.HasFlag(ModuleProperties.IsEvent))
                    sEvents += item;

            }

            LeftContainerControl1.SubOptionsPlain = String.Format("{0}</ul>{1}</ul>{2}</ul>{3}</ul>", sConstructors, sProperties, sMethods, sEvents);

            LoadMembers(GetUserSession().IsBrowserMobile);
        }

        protected string GetTableWidth()
        {
            if (GetUserSession().IsBrowserMobile)
                return ("100%");
            else
                return ("750px");
        }

        protected string GetClassName()
        {
            return (_class.Name);
        }

        protected string GetClassDescription()
        {
            return (String.Format("<p>{0}</p>", _class.Description.Replace("\r\n", "</p><p>")));
        }

        protected string GetSampleUsage()
        {
            if (String.IsNullOrEmpty(_class.ExampleUsage))
                return ("None Available!");
            else
                return (_class.ExampleUsage);
        }

        protected string GetClassID()
        {
            return (_class.ID.ToString());
        }

        protected string GetModuleName()
        {
            return (_class.Module.Name);
        }

        #region Private Methods

        private void LoadMembers(bool isMobile)
        {
            ModuleMembers members = _class.Members;

            foreach (ModuleMember member in members)
            {
                HtmlTableRow row = new HtmlTableRow();

                HtmlTableCell cellImages = new HtmlTableCell();
                cellImages.Style.Add("width", isMobile ? "10%" : "80px");
                cellImages.InnerHtml = GetMemberImages(member);
                row.Cells.Add(cellImages);

                HtmlTableCell cellName = new HtmlTableCell();
                cellName.Style.Add("width", isMobile ? "45%" : "220px");
                cellName.InnerHtml = GetMemberName(member);
                row.Cells.Add(cellName);

                HtmlTableCell cellDesc = new HtmlTableCell();
                cellDesc.Style.Add("width", isMobile ? "45%" : "410px");
                cellDesc.InnerText = member.Description;
                row.Cells.Add(cellDesc);

                if (member.Properties.HasFlag(ModuleProperties.IsStatic))
                {
                    if (member.Properties.HasFlag(ModuleProperties.IsProperty))
                        tblStaticProperties.Rows.Add(row);
                    else if (member.Properties.HasFlag(ModuleProperties.IsEvent))
                        tblStaticEvents.Rows.Add(row);
                    else
                        tblStaticMethods.Rows.Add(row);
                }
                else
                {
                    if (member.Properties.HasFlag(ModuleProperties.IsProperty))
                        tblProperties.Rows.Add(row);
                    else if (member.Properties.HasFlag(ModuleProperties.IsEvent))
                        tblEvents.Rows.Add(row);
                    else if (member.Properties.HasFlag(ModuleProperties.IsConstructor))
                        tblConstructors.Rows.Add(row);
                    else
                        tblMethods.Rows.Add(row);
                }
            }

            tblProperties.Visible = tblProperties.Rows.Count > 1;
            hProperties.Visible = tblProperties.Visible;
            tblStaticProperties.Visible = tblStaticProperties.Rows.Count > 1;
            hStaticProperties.Visible = tblStaticProperties.Visible;
            tblEvents.Visible = tblEvents.Rows.Count > 1;
            hEvents.Visible = tblEvents.Visible;
            tblStaticEvents.Visible = tblStaticEvents.Rows.Count > 1;
            hStaticEvents.Visible = tblStaticEvents.Visible;
            tblConstructors.Visible = tblConstructors.Rows.Count > 1;
            hConstructors.Visible = tblConstructors.Visible;
            tblMethods.Visible = tblMethods.Rows.Count > 1;
            hMethods.Visible = tblMethods.Visible;
            tblStaticMethods.Visible = tblStaticMethods.Rows.Count > 1;
            hStaticMethods.Visible = tblStaticMethods.Visible;
        }

        private string GetMemberName(ModuleMember member)
        {
            string Result = member.Name;

            if (member.Properties.HasFlag(ModuleProperties.IsConstructor) ||
                member.Properties.HasFlag(ModuleProperties.IsMethod))
            {

                ModuleParameters parameters = member.Parameters;

                if (parameters.Count == 0)
                {
                    Result += "()";
                }
                else
                {
                    bool first = true;
                    Result += "<span>(";

                    foreach (ModuleParameter param in parameters)
                    {
                        string paramType = param.ParamType;

                        if (paramType.StartsWith(_class.Namespace))
                            paramType = paramType.Substring(_class.Namespace.Length + 1);

                        Result += String.Format("{0}{1}", first ? String.Empty : ",&ensp;", paramType);

                        if (first)
                            first = false;
                    }

                    if (Result.EndsWith(",&ensp;"))
                        Result = Result.Substring(0, Result.Length - 7);
                    else if (Result.EndsWith(","))
                        Result = Result.Substring(0, Result.Length - 1);

                    Result += ")</span>";
                }
            }

            Result = String.Format("<a href=\"/Modules/Member.aspx?id={1}\">{0}</a>", Result, member.ID);
            return (Result);
        }

        private string GetMemberImages(ModuleMember member)
        {
            string Result = String.Empty;

            if (member.Properties.HasFlag(ModuleProperties.IsMethod))
            {
                if (member.Properties.HasFlag(ModuleProperties.IsProtected) ||
                    member.Properties.HasFlag(ModuleProperties.IsVirtual))
                {
                    Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC155188.jpeg\" alt=\"static\" />";
                }
                else
                {
                    Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg\" alt=\"static\" />";
                }
            }
            else if (member.Properties.HasFlag(ModuleProperties.IsEvent))
                Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC90369.jpeg\" alt=\"static\" />";
            else if (member.Properties.HasFlag(ModuleProperties.IsProperty))
                Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg\" alt=\"static\" />";
            else if (member.Properties.HasFlag(ModuleProperties.IsConstructor))
                Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg\" alt=\"static\" />";

            if (member.Properties.HasFlag(ModuleProperties.IsStatic))
            {
                Result += "<img src=\"https://i-msdn.sec.s-msft.com/dynimg/IC64394.jpeg\" alt=\"static\" />";
            }

            return (Result);
        }

        #endregion Private Methods
    }
}