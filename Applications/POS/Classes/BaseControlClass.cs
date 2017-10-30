using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

using POS.Base.Classes;


namespace PointOfSale.Classes
{
    public class BaseControlClass : SharedControls.BaseControl
    {
        public BaseControlClass()
        {

        }


        protected override string GetHintText(string controlName, string subControlName)
        {
            string Result = Languages.LanguageStrings.AppNoHintText;

            if(String.IsNullOrEmpty(controlName) || String.IsNullOrEmpty(subControlName))
                return (Result);

            XDocument xdoc = XDocument.Load(StringConstants.FILE_HINTS);
            
            if (xdoc.Root.Element(controlName).Elements(subControlName).SingleOrDefault() != null)
                Result = xdoc.Root.Element(controlName).Elements(subControlName).SingleOrDefault().Value;

            Result = Result.Replace(StringConstants.SYMBOL_CRLF_DOUBLE, StringConstants.SYMBOL_CRLF);

            return (Result);

        }

        #region Overridden Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        #endregion Overridden Methods

        #region Private Methods


        #endregion Private Methods
    }
}
