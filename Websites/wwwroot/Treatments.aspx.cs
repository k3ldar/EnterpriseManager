using System;
using System.Web.UI;

using Website.Library.Classes;
using Website.Library;
using Library.Utils;
using Library.BOL.Treatments;

namespace SieraDelta.Website
{
    public partial class PageTreatments : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GlobalClass.ShowTreatmentsMenu)
                DoRedirect("/Home/");
        }

        protected string BuildPagination(int PageSize)
        {
            string Result = "";

            bool allProducts = GetTreatmentGroupID() == -1;
            int Count = 0;

            if (allProducts)
                Count = Treatments.GetCount();
            else
            {
                TreatmentGroup group = TreatmentGroups.Get(GetTreatmentGroupID());
                Count = group != null ? group.Treatments.Count : 0;
            }

            if (allProducts)
                Result = BuildPagination(Count, PageSize, GetTreatmentPage(), "/Treatments/", true);
            else
                Result = BuildPagination(Count, PageSize, GetTreatmentPage(), String.Format("/Treatments/Group/{0}/", GetTreatmentGroupID()), true);

            return (Result);
        }
    }
}