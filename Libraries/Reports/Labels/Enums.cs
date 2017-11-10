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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: Enums.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reports.Labels
{
    public class Enums
    {
        /// <summary>
        /// The page size of the document
        /// See the Switch statement in LabelCreator.CreatePDF() if you add a new one
        /// </summary>
        public enum PageSize
        {
            A4
        }

        /// <summary>
        /// The possible styles for a font
        /// Taken straight from iTextSharp
        /// </summary>
        [Flags]
        public enum FontStyle
        {
            BOLD = 1,
            BOLDITALIC = 3,
            DEFAULTSIZE = 12,
            ITALIC = 2,
            NORMAL = 0,
            STRIKETHRU = 8,
            UNDEFINED = -1,
            UNDERLINE = 4,
        }

        

    }
}
