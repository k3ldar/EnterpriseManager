using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library.BOL.ModuleDocumentation;
using Library;
using Website.Library.Classes;

namespace SieraDelta.Website.Modules
{
    public partial class Member : BaseWebForm
    {
        #region Private Members

        private ModuleClass _class;
        private ModuleMember _member;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            pEdit.Visible = GetUsersMemberLevel() >= (int)Library.MemberLevel.StaffMember;

            _member = ModuleMembers.Get(GetFormValue("id", 0));

            if (_member == null)
                DoRedirect("/Modules/Index.aspx", true);

            _class = _member.Class;

            if (_class == null)
                DoRedirect("/Modules/Index.aspx", true);

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

            LoadParameters();
            LoadReturnValue();
        }

        protected string GetModuleName()
        {
            return (_class.Module.Name);
        }

        protected string GetMemberNameShort()
        {
            return (_member.Name);
        }

        protected string GetMemberID()
        {
            return (_member.ID.ToString());
        }
        #endregion Protected Methods

        #region Protected Methods

        protected string GetMemberName()
        {
            string sType = String.Empty;

            if (_member.Properties.HasFlag(ModuleProperties.IsMethod))
                sType = "Method";
            else if (_member.Properties.HasFlag(ModuleProperties.IsConstructor))
                sType = "Constructor";
            else if (_member.Properties.HasFlag(ModuleProperties.IsProperty))
                sType = "Property";
            else if (_member.Properties.HasFlag(ModuleProperties.IsEvent))
                sType = "Event";

            ModuleParameters param = _member.Parameters;
            string sParams = String.Empty;

            if (param != null && param.Count > 0)
            {
                bool isFirst = true;

                sParams = "(";

                foreach (ModuleParameter p in param)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        sParams += String.Format("{0}{1}", p.ParamTypeShort, p.GetDefaultValue());
                    }
                    else
                    {
                        sParams += String.Format(", {0}{1}", p.ParamTypeShort, p.GetDefaultValue());
                    }
                }

                sParams += ")";
            }

            return (String.Format("{0}.{1} {2} {3}", _class.Name, _member.Name, sType, sParams));
        }

        protected string GetClassName()
        {
            return (_class.Name);
        }

        protected string GetMemberDescription()
        {
            return (String.Format("<p>{0}</p>", _member.Description.Replace("\r\n", "</p><p>")));
        }

        protected string GetClassID()
        {
            return (_class.ID.ToString());
        }

        protected string GetSampleUsage()
        {
            if (String.IsNullOrEmpty(_member.ExampleUsage))
                return ("None Available!");
            else
                return (_member.ExampleUsage);
        }

        protected string GetNameSpace()
        {
            return (_class.Namespace);
        }

        protected string GetSyntax()
        {
            string Result = String.Empty;

            if (_member.Properties.HasFlag(ModuleProperties.IsMethod) ||
                _member.Properties.HasFlag(ModuleProperties.IsConstructor))
            {
                if (_member.Properties.HasFlag(ModuleProperties.IsPublic))
                    Result = "public&ensp;";

                if (_member.Properties.HasFlag(ModuleProperties.IsStatic))
                    Result += "static&ensp;";

                if (_member.Properties.HasFlag(ModuleProperties.IsVirtual))
                    Result += "virtual&ensp;";
                
                if (_member.Properties.HasFlag(ModuleProperties.IsAbstract))
                    Result += "abstract&ensp;";

                Result += _member.ReturnValueShort + "&ensp;";

                Result += _member.Name + "&ensp;";

                Result += "(";
                bool isFirst = true;

                foreach (ModuleParameter parm in _member.Parameters)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        Result += String.Format("\r\n\t{0} {1}{2}", parm.ParamTypeShort, parm.ShortName, parm.GetDefaultValue());
                    }
                    else
                    {
                        Result += String.Format(",\r\n\t{0} {1}{2}", parm.ParamTypeShort, parm.ShortName, parm.GetDefaultValue());
                    }

                }

                Result += _member.Parameters.Count > 0 ? "\r\n)" : "&ensp;)";
            }

            if (_member.Properties.HasFlag(ModuleProperties.IsProperty))
            {
                if (_member.Properties.HasFlag(ModuleProperties.IsPublic))
                    Result = "public&ensp;";

                if (_member.Properties.HasFlag(ModuleProperties.IsStatic))
                    Result += "static&ensp;";

                Result += _member.ReturnValueShort + "&ensp;";

                Result += _member.Name + "&ensp;";
            }

            if (_member.Properties.HasFlag(ModuleProperties.IsEvent))
            {
                if (_member.Properties.HasFlag(ModuleProperties.IsPublic))
                    Result = "public&ensp;";

                if (_member.Properties.HasFlag(ModuleProperties.IsStatic))
                    Result += "static&ensp;";

                Result += "delegate&ensp;" + _member.ReturnValueShort + "&ensp;";

                Result += _member.Name + "&ensp;";
            }

            return (Result);
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadParameters()
        {
            string paramText = String.Empty;

            if (_member.Parameters.Count > 0)
            {
                hParameters.Visible = true;
                pParameters.Visible = true;

                foreach (ModuleParameter parm in _member.Parameters)
                {
                    ModuleClass paramClass = ModuleClasses.Get(parm.ParamType);

                    string type = parm.ParamType;

                    if (paramClass != null)
                        type = String.Format("<a href=\"/Modules/Class.aspx?id={0}\">{1}</a>", paramClass.ID, type);

                    paramText += String.Format("<dl><dt>{0}</dt><dd><span>Type: {1}<br />Default Value: {2}<br />{3}</span></dd></dl>",
                        parm.Name, type, parm.GetDefaultValue().Replace("= ", String.Empty), parm.Description.Replace("\r\n", "<br />"));
                }

                pParameters.InnerHtml = paramText;
            }
            else
            {
                hParameters.Visible = false;
                pParameters.Visible = false;
            }
        }

        private void LoadReturnValue()
        {
            if (!String.IsNullOrEmpty(_member.ReturnValue) && _member.ReturnValue != "Void")
            {
                hReturns.Visible = true;
                pReturns.Visible = true;

                ModuleClass paramClass = ModuleClasses.Get(_member.ReturnValue);

                string resultType = _member.ReturnValueShort;

                if (paramClass != null)
                    resultType = String.Format("<a href=\"/Modules/Class.aspx?id={0}\">{1}</a>", paramClass.ID, resultType);

                pReturns.InnerHtml = String.Format("<dl><dt><span>Type: {0}</span></dt></dl>", resultType);
            }
            else
            {
                hReturns.Visible = false;
                pReturns.Visible = false;
            }
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