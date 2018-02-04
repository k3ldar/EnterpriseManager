using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SieraDelta.Website.Controls
{
    public partial class StatisticsInfo : System.Web.UI.UserControl
    {
        #region Private Members

        private Int64 _currentlyBanned = 0;
        private Int64 _previouslyBanned = 0;

        #endregion Private Members


        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Text = Languages.LanguageStrings.AppMenuButtonClose;

            //Library.BOL.IPAddresses.IPAddresses.CurrentStatistics(ref _currentlyBanned, ref _previouslyBanned);

        }


        protected string IntrusionsStatistics()
        {
            string Result = String.Format("<br />{0}: {1}<br />{2}: {3}",
                Languages.LanguageStrings.InstrusionsPrevented, _previouslyBanned,
                Languages.LanguageStrings.IntrusionsActivelyPrevented, _currentlyBanned);

            return (Result);
        }

    }
}