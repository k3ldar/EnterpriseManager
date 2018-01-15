using System;
using Website;
using lib = Library;
using Library.BOL;

namespace Website.Library.Classes
{
    public class BaseWebFormStaff : BaseWebFormSalesAdvisor 
    {
        #region Private Static Members

        private static lib.WebsiteAdministration _Administration;

        #endregion Private Static Members

        #region Properties

        public lib.WebsiteAdministration WebAdmin
        {
            get
            {
                if (_Administration == null)
                    _Administration = new lib.WebsiteAdministration(GetUser());

                return (_Administration);
            }
        }

        #endregion Properties

        #region Protected Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // if not a member of staff then redirect to diary page
            if (GetUsersMemberLevel() < (int)lib.MemberLevel.StaffMember)
                DoRedirect("/Site-Error/Invalid-Permission/");
        }


        #endregion Protected Methods
    }


}