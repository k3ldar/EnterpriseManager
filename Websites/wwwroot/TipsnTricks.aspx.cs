using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SieraDelta.Website.Library.Classes;

using SieraDelta.Library.Utils;
using SieraDelta.Library.BOL.TipsTricks;

namespace SieraDelta.WebsiteTemplate.Website
{
    public partial class TipsnTricks : BaseWebForm
    {
        private TipsTrick _tip;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.ShowTipsAndTricksMenu)
                DoRedirect("/Index.aspx");

            _tip = TipsTricks.Get(GetFormValue("ID", -1));

            if (_tip == null)
            {
                TipsTricks tricks = TipsTricks.Get(GetFormValue("Page", 1), 1);
                _tip = tricks.First();

                if (_tip == null)
                    DoRedirect("/TipsnTricks.aspx", true);
            }
        }

        protected string GetTipName()
        {
            string Result = _tip.Name;

            return (Result);
        }

        protected string GetTipDescription()
        {
            string Result = _tip.Description;
            HSCUtils u = new HSCUtils();
            Result = u.PreProcessPost(Result);
            return (Result);
        }
    }
}