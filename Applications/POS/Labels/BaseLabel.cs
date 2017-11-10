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
 *  Copyright (c) 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseLabel.cs
 *
 *  Created: 09/06/2017
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  09/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using Heavenskincare.PointOfSale.Classes;
using SieraDelta.POS.Classes;

namespace Heavenskincare.PointOfSale.Labels
{
    class BaseLabel
    {

        internal static string CurrentPath
        {
            get
            {
                string Result = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                Result = Path.GetDirectoryName(Result);
                return (Result.Substring(6));
            }
        }

        internal string GetXMLValue(string ParentName, string KeyName)
        {
            string Result = String.Empty;


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(CurrentPath + StringConstants.FILE_CONFIG);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == StringConstants.XML_ROOT_NODE_NAME)
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == ParentName)
                    {
                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == KeyName)
                            {
                                Result = Item.InnerText;
                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

    }
}
