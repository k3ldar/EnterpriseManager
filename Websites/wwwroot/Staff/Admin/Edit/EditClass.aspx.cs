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

namespace SieraDelta.Website.Staff.Admin.Edit
{
    public partial class EditClass : BaseWebFormStaff
    {
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
                case "class":
                    _class = ModuleClasses.Get(id);
                    break;
            }

            if (_class == null)
                DoRedirect("/staff/");

            if (!IsPostBack)
            {
                LoadClass();
            }

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

        protected string GetClassID()
        {
            return (_class.ID.ToString());
        }

        protected string GetClassName()
        {
            string sType = String.Empty;

            return (String.Format("{0}", _class.Name));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            _class.Description = txtDescription.Text;
            _class.ExampleUsage = txtExample.Text;
            _class.IsPrimary = cbPrimary.Checked;

            _class.Save();
        }

        #endregion Protected Methods

        #region Private Methods

        private void LoadClass()
        {
            txtDescription.Text = _class.Description;
            txtExample.Text = _class.ExampleUsage;
            cbPrimary.Checked = _class.IsPrimary;
        }

        #endregion Private Methods
    }
}