using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library;
using Library.Utils;

namespace SieraDelta.Website.Search
{
    public partial class SearchResults : BaseWebForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string searchTerms = GetFormValue("search");

                if (!String.IsNullOrEmpty(searchTerms))
                    DoSearch(searchTerms, true);

                txtSearchTerms.Text = searchTerms;
                btnSearch.Text = Languages.LanguageStrings.Search;
                btnSearch_Click(sender, e);
            }
        }

        #region Protected Methods

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerms = txtSearchTerms.Text;

            sResults.InnerHtml = DoSearch(searchTerms, true);

            if (txtSearchTerms.Text != searchTerms)
                txtSearchTerms.Text = searchTerms;

        }

        #endregion Protected Methods
    }
}