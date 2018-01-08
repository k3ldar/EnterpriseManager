using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.TagLines;

namespace SieraDelta.Website.Controls
{
    public partial class TagLineControl : BaseControlClass
    {
        #region Private Members

        private TagLine _tagLine;

        #endregion Private Members

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            DoRedirect(String.Format("/Staff/Admin/TagLines/EditTagLine.aspx?ID={0}", _tagLine.ID));
        }

        #region Public Methods

        public void Refresh(TagLine tagLine)
        {
            _tagLine = tagLine;
            pTag.InnerText = _tagLine.Text;
        }

        #endregion Public Methods
    }
}