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
 *  File: XMLManipulation.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Xml;

namespace POS.Base.Classes
{
    public static class XMLManipulation
    {
        public static string GetXMLValue(string configFile, string parentName, string keyName, string defaultValue)
        {
            string Result = defaultValue;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(configFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == StringConstants.XML_ROOT_NODE_NAME)
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == parentName)
                    {
                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == keyName)
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

        public static int GetXMLValue(string ConfigFile, string ParentName, string KeyName, int defaultValue)
        {
            int Result = defaultValue;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ConfigFile);
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
                                Result = Convert.ToInt32(Item.InnerText);
                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

        public static void SetXMLValue(string ConfigFile, string ParentName, string KeyName, string Value)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(ConfigFile);
            XmlNode Root = xmldoc.DocumentElement;
            bool FoundParent = false;
            bool Found = false;
            XmlNode xmlParentNode = null;

            if (Root != null & Root.Name == StringConstants.XML_ROOT_NODE_NAME)
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == ParentName)
                    {
                        FoundParent = true;
                        xmlParentNode = Child;

                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == KeyName)
                            {
                                Item.InnerText = Value;
                                Found = true;
                                xmldoc.Save(ConfigFile);
                            }
                        }
                    }
                }
            }

            if (!Found)
            {
                if (!FoundParent)
                {
                    xmlParentNode = xmldoc.CreateNode(XmlNodeType.Element, String.Empty, ParentName, null);
                    Root.AppendChild(xmlParentNode);
                }

                XmlElement appendedKeyName = xmldoc.CreateElement(KeyName);
                XmlText xmlKeyName = xmldoc.CreateTextNode(Value);
                appendedKeyName.AppendChild(xmlKeyName);
                xmlParentNode.AppendChild(appendedKeyName);

                xmldoc.Save(ConfigFile);
            }
        }
    }
}
