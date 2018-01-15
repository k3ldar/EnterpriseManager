using System;

using Website;
using lib = Library;
using Library.Utils;
using Library.BOL;

namespace Website.Library.Classes
{
	/// <summary>
	/// Summary description for AdminClass.
	/// </summary>
	public class BaseWebFormAdmin : BaseWebFormStaff
    {
        #region Properties

        public bool IsUpdateOnly
		{
			get
			{
				return (GetUsersMemberLevel() == 9);
			}
		}


		public bool IsReadOnly
		{
			get
			{
				return (GetUsersMemberLevel() == 8);
			}
		}


		#endregion Properties

		#region Public Methods

		public BaseWebFormAdmin()
		{

		}


		#endregion Public Methods

		#region Protected Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

            lib.MemberLevel level = GetUser().MemberLevel;

            if (level < lib.MemberLevel.AdminReadOnly)
				DoRedirect("/Site-Error/Invalid-Permission/");
		}


		#endregion Protected Methods
	}
}
