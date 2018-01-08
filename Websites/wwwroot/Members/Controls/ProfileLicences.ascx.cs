using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Website.Library.Classes;

using Library.Utils;
using Library.BOL.Licencing;

namespace SieraDelta.Website.Members.Controls
{
    public partial class ProfileLicences : BaseControlClass
    {
        private Library.BOL.Licencing.Licences _licences;

        protected void Page_Load(object sender, EventArgs e)
        {
            _licences = Library.BOL.Licencing.Licences.Get(GetUser());

            BuildLicences();
        }

        private void BuildLicences()
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();

            int Start = GetFormValue("Page", 1);

            int Finish = (Start * 10) - 1;
            Start = Finish - 9;
            int i = 0;

            foreach (Library.BOL.Licencing.Licence licence in _licences)
            {
                if (i >= Start && i <= Finish)
                {
                    HtmlTableRow r = new HtmlTableRow();
                    tblInvoices.Rows.Add(r);

                    HtmlTableCell cDomain = new HtmlTableCell();
                    cDomain.InnerText = String.IsNullOrEmpty(licence.Domain) ? Languages.LanguageStrings.LicenceDomainNotSet : licence.Domain; 
                    r.Cells.Add(cDomain);
                    
                    HtmlTableCell cType = new HtmlTableCell();
                    cType.InnerText = licence.LicenceTypeText;
                    r.Cells.Add(cType);

                    HtmlTableCell cActive = new HtmlTableCell();
                    cActive.InnerText = licence.IsValid && licence.Expires >= DateTime.Now ? Languages.LanguageStrings.Yes : Languages.LanguageStrings.No;
                    r.Cells.Add(cActive);

                    HtmlTableCell cExpires = new HtmlTableCell();
                    cExpires.InnerText = SharedUtils.DateToStr(licence.Expires, WebCulture);
                    r.Cells.Add(cExpires);

                    HtmlTableCell cEdit = new HtmlTableCell();
                    cEdit.InnerHtml = String.Format("<a href=\"/Members/LicenceEdit.aspx?id={0}\">{1}</a>", licence.ID, Languages.LanguageStrings.View);
                    r.Cells.Add(cEdit);
                }

                i++;
            }
        }
    }
}