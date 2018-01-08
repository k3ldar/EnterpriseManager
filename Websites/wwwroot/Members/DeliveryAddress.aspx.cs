using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.Utils;
using Library.BOL.Users;
using Library.BOL.DeliveryAddress;

namespace SieraDelta.Website.Members
{
    public partial class PageDeliveryAddress : BaseWebFormMember
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LeftContainerControl1.SubHeader = Languages.LanguageStrings.MyAccount;
            LeftContainerControl1.SubOptions = GetAccountOptions();
            btnNew.Text = Languages.LanguageStrings.New;
            LoadDeliveryAddresses();
        }


        private void LoadDeliveryAddresses()
        {
            DeliveryAddresses addresses = GetUser().DeliveryAddresses;

            foreach (DeliveryAddress address in addresses)
            {
                Controls.MemberDeliveryAddresses addr = (Controls.MemberDeliveryAddresses)LoadControl("~/Members/Controls/MemberDeliveryAddresses.ascx");
                addr.Refresh(address, Library.Enums.Mode.Edit);
                addr.SelectAddress += new SelectAddressDelegate(addr_SelectAddress);
                pDeliveryAddresses.Controls.Add(addr);
            }
        }

        private void addr_SelectAddress(object sender, DeliveryAddressEventArgs e)
        {
            DoRedirect(String.Format("/Members/DeliveryAddressEdit.aspx?ID={0}", e.Address.ID), true);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            User user = GetUser();
            DeliveryAddress deladdr = user.DeliveryAddresses.Create(user.ID, String.Empty, String.Empty, String.Empty,
                String.Empty, String.Empty, String.Empty, String.Empty, 0);

            DoRedirect(String.Format("/Members/DeliveryAddressEdit.aspx?ID={0}", deladdr.ID));
        }
    }
}