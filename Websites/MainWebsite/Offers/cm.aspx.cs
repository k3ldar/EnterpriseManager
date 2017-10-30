using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Campaigns;
using Library.BOL.Products;

namespace Heavenskincare.WebsiteTemplate.Offers
{
    public partial class cm : BaseWebForm
    {
        private Campaign _currentCampaign = null;

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //load the campaign
            _currentCampaign = Campaign.Get(GetFormValue("cmp", String.Empty));

            if (_currentCampaign == null || (_currentCampaign.OfferProduct1 == -1 && _currentCampaign.OfferProduct2 == -1 && _currentCampaign.OfferProduct3 == -1 &&
                _currentCampaign.OfferProduct4 == -1 && _currentCampaign.OfferProduct5 == -1 && _currentCampaign.OfferProduct6 == -1))
                DoRedirect("/Index.aspx", true);

            pDescription.InnerHtml = _currentCampaign.OffersPageText;
            imgPromotion.Src = _currentCampaign.ImageOffersPage;

            SetBuyItNowControl(BuyItNow1, _currentCampaign.OfferProduct1);
            SetBuyItNowControl(BuyItNow2, _currentCampaign.OfferProduct2);
            SetBuyItNowControl(BuyItNow3, _currentCampaign.OfferProduct3);
            SetBuyItNowControl(BuyItNow4, _currentCampaign.OfferProduct4);
        }

        protected string GetCampaignName()
        {
            return (_currentCampaign.Title);
        }

        protected string GetCampaignURL()
        {
            return (_currentCampaign.CampaignName);
        }

        #endregion Protected Methods

        #region Private Methods

        private void SetBuyItNowControl(Controls.BuyItNow control, Int64 offerProduct)
        {
            control.Visible = offerProduct > -1;

            // there is a product on offer here :-)
            if (offerProduct > -1)
            {
                ProductCost productCost = ProductCosts.Get(offerProduct);

                if (productCost != null)
                {
                    control.UseProductName = true;
                    //control.ShowPriceData = GetUserCountry();
                    Product prod = Library.BOL.Products.Products.Get(productCost.ProductID);

                    if (prod == null)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Product = productCost;
                        string image = HSCUtils.ResizeImage(prod.Image, 178);

                        image = "https://static.heavenskincare.com/Images/Products/" + image;
                        control.Image = image;
                        control.Contains = HSCUtils.PreProcessPost(prod.Description);
                    }
                }
                else
                {
                    control.Visible = false;
                }
            }
        }

        #endregion Private Methods
    }
}