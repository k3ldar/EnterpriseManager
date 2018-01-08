using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.DeliveryAddress;
using Library.Utils;
using Library;

namespace SieraDelta.Website.Members.Controls
{
    public partial class MemberDeliveryAddresses : BaseControlClass
    {
        private DeliveryAddress _deliveryAddress;
        private Enums.Mode _mode;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSelect.Text = Languages.LanguageStrings.Select;
        }

        public void Refresh(DeliveryAddress address, Enums.Mode mode)
        {
            _deliveryAddress = address;
            pAddress.InnerHtml = _deliveryAddress.Address(true);

            //SieraDeltaUtils u = new SieraDeltaUtils();
            pPostageCost.InnerHtml = String.Format("{1} {0}", 
                SharedUtils.FormatMoney(_deliveryAddress.Country.ShippingCosts, GetWebsiteCurrency(), false),
                Languages.LanguageStrings.Postage);

            _mode = mode;

            if (mode == Enums.Mode.Edit)
                btnSelect.Text = Languages.LanguageStrings.Edit;
            else
                btnSelect.Text = Languages.LanguageStrings.Select;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            RaiseSelectAddress();
        }

        private void RaiseSelectAddress()
        {
            if (SelectAddress != null)
                SelectAddress(this, new DeliveryAddressEventArgs(_deliveryAddress));
        }


        public event SelectAddressDelegate SelectAddress;
        public Enums.Mode Mode
        {
            get
            {
                return (_mode);
            }
        }
    }
}