using System;

using Website.Library.Classes;

namespace SieraDelta.Website.Basket
{
    public partial class BasketSignIn : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetUser() != null)
                DoRedirect("/Shopping/Basket/Delivery-Address/", true);

            CreateAccount1.AfterCreateAccount += new Members.Controls.CreateAccount.AfterCreateAccountDelegate(CreateAccount1_AfterCreateAccount);
            MemberLogin1.AfterLogin += new Members.Controls.MemberLogin.AfterLoginArgs(MemberLogin1_AfterLogin);
        }

        private void MemberLogin1_AfterLogin(object sender, EventArgs e)
        {
            DoRedirect("/Shopping/Basket/Delivery-Address/", false);
        }

        private void CreateAccount1_AfterCreateAccount(object sender, Members.Controls.CreateAccount.CreateAccountArgs e)
        {
            //if the user did not login then will be automatically redirected to login page
            DoRedirect("/Shopping/Basket/Delivery-Address/", false);
        }
    }
}