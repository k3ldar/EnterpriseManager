using System;
using Website;
using lib = Library;
using Library.BOL;

namespace Website.Library.Classes
{
    public class BaseWebFormSalesAdvisor : BaseWebFormSalonOwner
    {
        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // if not a member of staff then redirect to diary page
            if (GetUsersMemberLevel() < (int)lib.MemberLevel.SalesAdvisor)
                DoRedirect("/Error/InvalidPermissions.aspx");
        }


        #endregion Protected Methods
    }
}
