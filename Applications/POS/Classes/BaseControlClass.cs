/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseControlClass.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Linq;
using System.Xml.Linq;

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
