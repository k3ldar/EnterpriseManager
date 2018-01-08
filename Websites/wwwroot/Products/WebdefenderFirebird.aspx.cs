using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.Products;
using Library.BOL.Users;
using Library.BOL.Basket;
using Library.BOL.Countries;
using Library.BOL.CustomWebPages;

namespace SieraDelta.Website.Products
{
    public partial class WebdefenderFirebird : BaseWebFormProduct
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAddToBasket.Text = Languages.LanguageStrings.AddToBag;
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.Categories;
            LeftContainerControl1.SubOptions = GetProductCategories(ProductGroupTypes.Get("Products"));

            Product = Library.BOL.Products.Products.Get(1);

            if (!IsPostBack)
            {
                LoadPoductTypes(lstProductTypes);
                LoadQuantities(lstQuantity);
            }
            else
            {
                UpdateNotificationSettings();
            }

            MediaLinks1.ProductLink = Product;

            if (!AllowShowCostData() || !ShowPriceData)
            {
                pProductCost.Visible = false;
            }

            divVideoLink.Visible = !String.IsNullOrEmpty(Product.VideoLink.Trim());

            //translated data
            UpdateCustomTranslatedPageData("WebDefender Firebird Features", divFeaturesTranslated);
            UpdateCustomTranslatedPageData("WebDefender Firebird Description", divDescriptionTranslated);
        }

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            int Count = SharedUtils.StrToIntDef(lstQuantity.SelectedItem.Text, 1);

            // caused an error if nothing selected
            if (lstProductTypes.SelectedItem == null)
                return;

            // product cost/type
            int prodType = SharedUtils.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
            Product.UpdateProductCosts(GetUser());
            ProductCost item = ProductCosts.Get(prodType, GetUser());

            if (item.OutOfStock && Global.OutOfStockAllowNotifyUser)
            {
                if (!Global.OutOfStockInPage)
                {
                    DoRedirect(String.Format("/Products/OutOfStock.aspx?ItemID={0}", item.ID));
                }
            }
            else
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Add(item, Count, GetUser(), ProductCostItemType.Product, 
                    localData.Basket.Currency.PriceColumn);
            }
        }

        protected override void UpdateNotificationSettings()
        {
            if (BaseWebApplication.OutOfStockAllowNotifyUser && BaseWebApplication.OutOfStockInPage && 
                lstProductTypes.SelectedIndex > -1)
            {
                //SieraDeltaUtils u = new SieraDeltaUtils();
                int prodType = SharedUtils.StrToIntDef(lstProductTypes.SelectedItem.Value, -1);
                ProductCost prodItem = ProductCosts.Get(prodType, GetUser());

                if (prodItem.OutOfStock)
                {
                    spanNotifications.Visible = false;
                    pProductCost.Style.Add("height", "60px");
                }
                else
                {
                    spanNotifications.Visible = true;
                    pProductCost.Style.Remove("height");
                }
            }

        }
    }
}