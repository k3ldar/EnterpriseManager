using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class MonthToDate : System.Web.UI.UserControl
    {
        public global::System.Web.UI.HtmlControls.HtmlGenericControl hMTD;

        public global::System.Web.UI.WebControls.Table tblMonthToDate;
        public global::System.Web.UI.WebControls.TableHeaderRow TableHeaderRow5;
        public global::System.Web.UI.WebControls.TableRow TableRowCurrent;
        public global::System.Web.UI.WebControls.TableRow TableRowPrevious;
        public global::System.Web.UI.WebControls.TableRow TableRowDifference;
        public global::System.Web.UI.WebControls.TableRow TableRowPercent;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}