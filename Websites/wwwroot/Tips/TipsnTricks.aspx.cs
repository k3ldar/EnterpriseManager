using System;

using Website.Library.Classes;

using Website.Library;
using Library.Utils;
using Library.BOL.TipsTricks;

namespace SieraDelta.Website.Tips
{
    public partial class TipsnTricks : BaseWebForm
    {
        private TipsTrick _tip;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowTipsAndTricksMenu)
                DoRedirect("/Home/");

            _tip = TipsTricks.Get(Shared.Utilities.StrToIntDef(GetTipPage(), -1));

            if (_tip == null)
            {
                TipsTricks tricks = TipsTricks.Get(GetFormValue("Page", 1), 1);
                _tip = tricks.First();

                if (_tip == null)
                    DoRedirect("/Tips-And-Tricks/", true);
            }
        }

        protected string GetTipName()
        {
            string Result = _tip.Name;

            return (Result);
        }

        protected int GetTipPageNumber()
        {
            return (SharedUtils.StrToIntDef(GetTipPage(), 1));
        }

        protected string GetTipPage()
        {
            if (Page.RouteData.Values["page"] == null)
                return ("1");

            return ((string)Page.RouteData.Values["page"]);
        }

        protected string GetTipDescription()
        {
            return (SharedUtils.PreProcessPost(String.Empty, _tip.Description));
        }
    }
}