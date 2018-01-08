using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;
using Library.BOL;
using Library.BOL.ModuleDocumentation;

using SieraDelta.Website.Controls;

namespace SieraDelta.Website.Staff.Admin
{
    public partial class EditObject : BaseWebFormStaff
    {
        private ModuleMember _member;
        private ModuleClass _class;

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            Int64 id = GetFormValue("id", -1);

            if (id == -1)
                DoRedirect("/staff/");

            string type = GetFormValue("type", String.Empty);

            if (String.IsNullOrEmpty(type))
                DoRedirect("/staff/");

            switch (type)
            {
                case "member":
                    _member = ModuleMembers.Get(id);
                    break;
            }

            if (_member == null)
                DoRedirect("/staff/");

            _class = _member.Class;

            if (!IsPostBack)
            {
                LoadModule();
            }

            LoadParamaters();

            string sProperties = "<h6>Properties</h6><ul>";
            string sConstructors = "<h6>Constructors</h6><ul>";
            string sEvents = "<h6>Events</h6><ul>";
            string sMethods = "<h6>Methods</h6><ul>";

            foreach (ModuleMember member in _class.Members)
            {
                string item = String.Format("<li><a href=\"/Staff/Admin/Edit/EditMember.aspx?type=member&id={1}\">{0}</a></i>",
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

        }

        protected string GetMemberID()
        {
            return (_member.ID.ToString());
        }

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
                        sParams += p.ParamTypeShort;
                    }
                    else
                    {
                        sParams += String.Format(", {0}", p.ParamTypeShort);
                    }
                }

                sParams += ")";
            }

            return (String.Format("{0}.{1} {2} {3}", _class.Name, _member.Name, sType, sParams));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _member.Description = txtDescription.Text;
            _member.ReturnValueDescription = txtReturnDescription.Text;
            _member.ExampleUsage = txtExample.Text;


            foreach (ParamaterEditor editor in pParamaters.Controls)
            {
                foreach (ModuleParameter parm in _member.Parameters)
                {
                    if (editor.PropertyName == parm.Name)
                    {
                        parm.Description = editor.Description;
                        break;
                    }
                }
            }

            _member.Save();
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadModule()
        {
            txtDescription.Text = _member.Description;
            txtExample.Text = _member.ExampleUsage;
            txtReturnDescription.Text = _member.ReturnValueDescription;
        }

        private void LoadParamaters()
        {
            foreach (ModuleParameter parm in _member.Parameters)
            {
                ParamaterEditor editor = (ParamaterEditor)LoadControl("~/Staff/Controls/ParamaterEditor.ascx");

                editor.Initialise(parm.Name, parm.Description);
                pParamaters.Controls.Add(editor);
            }
        }

        #endregion Private Methods
    }
}