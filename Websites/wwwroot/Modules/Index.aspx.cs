using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.BOL.ModuleDocumentation;
using Library.Utils;
using Website.Library.Classes;

namespace SieraDelta.Website.Modules
{
    public partial class Index : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = "Classes";
            
            foreach (ModuleClass modClass in ModuleClasses.Get())
            {
                if (!modClass.IsPrimary)
                    continue;

                LeftContainerControl1.SubOptions += String.Format("<li><a href=\"/Modules/Class.aspx?id={1}\">{0}</a></i>",
                    modClass.Name, modClass.ID);
            }
        }

        protected string GetModuleNames()
        {
            ModuleNames modules = ModuleNames.GetModules();

            string Result = String.Empty;

            foreach (ModuleName module in modules)
            {
                Result += String.Format("<h3 style=\"text-transform:none;\">{0}</h3><p>{1}</p><ul>", 
                    module.Name, module.Description);

                ModuleClasses classes = module.Classes;

                foreach (ModuleClass mClass in classes)
                {
                    if (!mClass.IsPrimary)
                        continue;

                    Result += String.Format("<li style=\"padding-bottom:8px;\"><a href=\"/Modules/Class.aspx?id={0}\" style=\"display:block;\">{1}</a><br />{2}</li>",
                        mClass.ID, mClass.Name, mClass.Description);
                }

                Result += "</ul>";
            }

            return (Result);
        }
    }
}