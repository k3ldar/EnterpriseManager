using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Library;
using Library.Utils;
using Website.Library.Classes;
using Library.BOL.CustomWebPages;
using Library.BOL.Products;
using Library.BOL.Countries;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class BasketAddNail : BaseControlClass
    {
        #region Private Members

        private ProductCost _costItem;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Refresh(ProductCost cost)
        {
            _costItem = cost;
            nailImage.Alt = cost.Size;
            nailImage.Src = String.Format("https://static.heavenskincare.com/Images/Products/NAILS/{0}.png", cost.SKU);
            btnAddToBasket.Text = Languages.LanguageStrings.AddToBag;

            Country country = WebCountry;

            decimal price = cost.PriceGet(((LocalWebSessionData)GetUserSession().Tag).PriceColumn, country);

            if (BaseWebApplication.PricesIncludeVAT)
            {
                nailPrice.InnerText = SharedUtils.FormatMoney(price +
                    SharedUtils.VATCalculate(price, country.VATRate), 
                    GetWebsiteCurrency());
            }
            else
            {
                nailPrice.InnerText = SharedUtils.FormatMoney(price, GetWebsiteCurrency());
            }
        }

        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            if (_costItem != null)
            {
                LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
                localData.Basket.Add(_costItem, 1, GetUser(), localData.PriceColumn);

                if (AddToBasket != null)
                    AddToBasket(this, EventArgs.Empty);
            }
        }


        public event EventHandler AddToBasket;
    }
}