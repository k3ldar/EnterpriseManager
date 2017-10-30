using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Languages;

using Library;
using Library.BOL.Accounts;
using Library.BOL.Users;
using Library.BOL.Orders;
using Library.BOL.Products;

using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Members.Stock
{
    public partial class ReOrderCheck : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CreateAutoStockReOrderInvoice();
            }
            catch (Exception err)
            {
                Shared.EventLog.Add(err);
                Response.Write("Error, please contact support");
                Response.End();
            }
        }

        private void CreateAutoStockReOrderInvoice()
        {
            string returnMessage = LanguageStrings.AppReOrderFailed;
            int count = GetFormValue("COUNT", 0);
            string userEmail = GetFormValue("USER_EMAIL", String.Empty);
            bool debug = GetFormValue("DEBUG", false);
            string debugInfo = String.Empty;

            bool productChange = false;
            Library.BOL.Users.User user = Library.BOL.Users.User.UserGet(userEmail);

            if (user == null)
            {
                returnMessage = LanguageStrings.InvalidUsernameOrPassword;
                Response.Write(returnMessage);
                Response.End();
            }
            else
            {
                if (count > 0)
                {
                    Library.BOL.Basket.ShoppingBasket basket = SharedWebBase.GetShoppingBasket(
                        Session, Request, Response);
                    basket.Empty();
                    basket.User = user;

                    string userRequesting = GetFormValue("USER_REQUESTING", String.Empty);

                    for (int i = 0; i < count; i++)
                    {
                        int id = GetFormValue(String.Format("ID{0}", i), -1);
                        string sku = GetFormValue(String.Format("SKU{0}", i), String.Empty);
                        int quantity = GetFormValue(String.Format("QUANTITY{0}", i), 1);
                        string name = GetFormValue(String.Format("NAME{0}", i), String.Empty);
                        string size = GetFormValue(String.Format("SIZE{0}", i), String.Empty);

                        ProductCost cost = ProductCosts.GetBySKU(sku);

                        if (cost != null)
                        {
                            basket.Add(cost, quantity, user, basket.Currency.PriceColumn);
                            debugInfo += String.Format("SKU: {0} found\r\n", sku);
                        }
                        else
                        {
                            debugInfo += String.Format("SKU: {0} not found\r\n", sku);
                        }
                    }

                    if (debug)
                    {
                        debugInfo += basket.ToString();
                        returnMessage = debugInfo;
                    }
                    else
                    {
                        basket.SaveBasket(String.Format(LanguageStrings.AppOrderSaveAs,
                            basket.User.UserName, basket.User,
                            DateTime.Now.ToString("G")), true);

                        returnMessage = String.Format(LanguageStrings.AppReOrderSuccess, basket.ID,
                            productChange ? LanguageStrings.AppReOrderItemsChanged : String.Empty,
                            Global.WebsiteTelephoneNumber);
                    }

                    Response.Write(returnMessage);
                    Response.End();
                }
            }
        }
    }
}