using System;
using lib = Library;

namespace Website.Library.Classes
{
	/// <summary>
	/// Summary description for BaseWebFormSalonOwner.
	/// </summary>
	public class BaseWebFormSalonOwner : BaseWebFormMember
	{
        private static lib.SalonUser _SalonUser;

        public lib.SalonUser SalonMember
        {
            get
            {
                if (_SalonUser == null)
                    _SalonUser = new lib.SalonUser();

                return (_SalonUser);
            }
        }

		public BaseWebFormSalonOwner()
		{

        }


		protected override void OnLoad(EventArgs e)
		{
            if (UserIsLoggedOn())
            {
                if (GetUsersMemberLevel() < (int)lib.MemberLevel.Distributor)
                    DoRedirect("/Error/InvalidPermissions.aspx");
            }
            else
            {
                DoRedirect();
            }

            base.OnLoad(e);
        }

	}
}
