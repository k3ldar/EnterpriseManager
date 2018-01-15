using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.DeliveryAddress;

namespace SieraDelta.Website.Basket
{
    public partial class BasketDeliveryAddress : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNew.Text = Languages.LanguageStrings.New;

            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            if (!localData.Basket.ProductsHaveShipping())
                DoRedirect("/Shopping/Basket/Confirm-Order/", true);

           // if (!IsPostBack)
                LoadDeliveryAddresses();
        }


        private void LoadDeliveryAddresses()
        {
            DeliveryAddresses addresses = GetUser().DeliveryAddresses;

            foreach (DeliveryAddress address in addresses)
            {
                Members.Controls.MemberDeliveryAddresses addr = (Members.Controls.MemberDeliveryAddresses)LoadControl("~/Members/Controls/MemberDeliveryAddresses.ascx");
                addr.Refresh(address, Library.Enums.Mode.Select);
                addr.SelectAddress += new SelectAddressDelegate(addr_SelectAddress);
                pDeliveryAddresses.Controls.Add(addr);
            }
        }

        private void addr_SelectAddress(object sender, DeliveryAddressEventArgs e)
        {
            // set the address id in session  
            LocalWebSessionData localData = (LocalWebSessionData)GetUserSession().Tag;
            localData.Basket.ShippingAddress = e.Address;
            localData.DeliveryAddressID = e.Address.ID;

            DoRedirect("/Shopping/Basket/Confirm-Order/", true);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            DeliveryAddress deladdr = user.DeliveryAddresses.Create(user.ID, String.Empty, String.Empty, String.Empty,
                String.Empty, String.Empty, String.Empty, String.Empty, 0);

            DoRedirect(String.Format("/Account/Address/Delivery/Edit/{0}/&redirect=/Shopping/Basket/Delivery-Address/", deladdr.ID));
        }
    }
}