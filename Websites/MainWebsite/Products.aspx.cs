using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Library.BOL.Products;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate
{
    public partial class PageProducts : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(false, false);
            string SKU = GetFormValue("SKU", "").ToUpper();

            if (SKU != "" && IsValidProductSKU(SKU))
            {
                Library.BOL.Products.Products products = Library.BOL.Products.Products.GetBySKU(SKU);
                DoRedirect(String.Format("/Products/Product.aspx?ID={0}", products.First().ID));
            }

            int prodGroup = GetFormValue("GroupID", -1);
            ProductGroup group = ProductGroups.Get(prodGroup);

            if (group == null)
            {
                headerH2.Visible = false;
                headerH1.Visible = true;
            }
            else
            {
                ProductGroupType grpOther = ProductGroupTypes.Get("Other");
                headerH1.Visible = group.GroupType.ID == grpOther.ID;
                headerH2.Visible = group.GroupType.ID != grpOther.ID;

                headerH2.Attributes["class"] = String.Format("{0} {1}", headerH2.Attributes["class"], group.GroupType.Description);
            }

            if (prodGroup > -1 && (group == null || !group.ShowOnWebsite || (int)group.MemberLevel > GetUsersMemberLevel()))
                DoRedirect("/Products.aspx", true);
        }

        private bool IsValidProductSKU(string SKU)
        {
            bool IsValidSKU = Library.BOL.Products.Products.IsValidSKU(SKU);

            return (IsValidSKU);
        }

        protected string GetProductGroupName()
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(GetFormValue("GroupID", -1));

            if (group != null)
                Result = group.Description;

            return (Result);
        }

        protected string GetProductGroupTitle(int productGroup)
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(productGroup);

            if (group != null)
                Result = group.Description;

            return (Result);
        }

        protected string GetProductGroupSubHeader(int productGroup)
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(productGroup);

            if (group != null)
                Result = group.SubHeader;

            return (Result);
        }

        protected string GetProductGroupHeader(int productGroup)
        {
            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(productGroup);

            if (group != null)
                Result = group.MainHeader;

            return (Result);
        }

        protected string BuildPagination()
        {
            string Result = "";

            bool allProducts = GetFormValue("GroupID", -1) == -1;
            int Count = 0;

            if (allProducts)
                Count = Library.BOL.Products.Products.GetCount(ProductTypes.Get("Stratosphere"));
            else
                Count = Library.BOL.Products.Products.CountByProduct(ProductGroups.Get(GetFormValue("GroupID", 1)));

            //if no products showing for normal stuff then redirect to stratosphere
            //if (Count == 0)
            //    DoRedirect("/Products/ProductsS.aspx");

            if (allProducts)
                Result = BuildPagination(Count, 12, GetFormValue("Page", 1), "/Products.aspx");
            else
                Result = BuildPagination(Count, 12, GetFormValue("Page", 1), "/Products.aspx", "GroupID=" + GetFormValue("GroupID"));

            return (Result);
        }

        #region Virtual Methods


        protected override string GetWebTitle()
        {
            int ProductID = GetFormValue("GroupID", -1);

            string Result = Languages.LanguageStrings.AllProducts;

            ProductGroup group = ProductGroups.Get(ProductID);

            if (group != null)
                Result = group.Description;

            return (Result);
        }



        #endregion Virtual Methods
    }
}