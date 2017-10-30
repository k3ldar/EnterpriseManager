using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Treatments;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class PageTreatments : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.ShowTreatmentsMenu)
                DoRedirect("/Index.aspx");

            pViewBrochure.Visible = Global.ShowTreatmentsBrochure;
        }

        protected string BuildPagination(int PageSize)
        {
            string Result = "";

            bool allProducts = GetFormValue("GroupID", -1) == -1;
            int Count = 0;

            if (allProducts)
                Count = Library.BOL.Treatments.Treatments.GetCount();
            else
            {
                TreatmentGroup group = Library.BOL.Treatments.TreatmentGroups.Get(GetFormValue("GroupID", -1));
                Count = group != null ? group.Treatments.Count : 0;
            }

            if (allProducts)
                Result = BuildPagination(Count, PageSize, GetFormValue("Page", 1), "/Treatments.aspx");
            else
                Result = BuildPagination(Count, PageSize, GetFormValue("Page", 1), "/Treatments.aspx", "GroupID=" + GetFormValue("GroupID"));

            return (Result);
        }
    }
}