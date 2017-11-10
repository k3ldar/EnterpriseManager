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
 *  File: XML.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace Library
{
    public static class XML
    {
        /// <summary>
        /// Set's an XML value in a file
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <param name="parentName"></param>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static void SetXMLValue(string xmlFile, string parentName, string keyName, string value)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            XmlNode Root = xmldoc.DocumentElement;
            bool FoundParent = false;
            bool Found = false;
            XmlNode xmlParentNode = null;

            if (Root != null & Root.Name == "SieraDelta")
            {
                for (int i = 0; i <= Root.ChildNodes.Count - 1; i++)
                {
                    XmlNode Child = Root.ChildNodes[i];

                    if (Child.Name == parentName)
                    {
                        FoundParent = true;
                        xmlParentNode = Child;

                        for (int j = 0; j <= Child.ChildNodes.Count - 1; j++)
                        {
                            XmlNode Item = Child.ChildNodes[j];

                            if (Item.Name == keyName)
                            {
                                Item.InnerText = value;
                                Found = true;
                                xmldoc.Save(xmlFile);
                            }
                        }
                    }
                }
            }

            if (!Found)
            {
                if (!FoundParent)
                {
                    xmlParentNode = xmldoc.CreateNode(XmlNodeType.Element, "", parentName, null);
                    //XmlElement appendedParentName = xmldoc.CreateElement(ParentName);
                    Root.AppendChild(xmlParentNode);
                }

                XmlElement appendedKeyName = xmldoc.CreateElement(keyName);
                XmlText xmlKeyName = xmldoc.CreateTextNode(value);
                appendedKeyName.AppendChild(xmlKeyName);
                xmlParentNode.AppendChild(appendedKeyName);

                xmldoc.Save(xmlFile);
            }
        }

        public static long GetXMLValue(string xmlFile, string parentName, string keyName, Int64 defaultValue)
        {
            try
            {
                return (Convert.ToInt64(GetXMLValue(xmlFile, parentName, keyName)));
            }
            catch
            {
                return (defaultValue);
            }
        }

        public static bool GetXMLValue(string xmlFile, string parentName, string keyName, bool defaultValue)
        {
            try
            {
                return (Convert.ToBoolean(GetXMLValue(xmlFile, parentName, keyName)));
            }
            catch
            {
                return (defaultValue);
            }
        }

        public static int GetXMLValue(string xmlFile, string parentName, string keyName, int defaultValue)
        {
            int Result = defaultValue;


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
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
                                try
                                {
                                    Result = Convert.ToInt32(Item.InnerText);
                                }
                                catch
                                {
                                    Result = defaultValue;
                                }

                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

        public static DateTime GetXMLValue(string xmlFile, string parentName, string keyName, DateTime defaultValue)
        {
            DateTime Result = defaultValue;


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
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
                                try
                                {
                                    Result = Convert.ToDateTime(Item.InnerText);
                                }
                                catch
                                {
                                    Result = defaultValue;
                                }

                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

        public static string GetXMLValue(string xmlFile, string parentName, string keyName, string defaultValue)
        {
            string Result = defaultValue;


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
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
                                try
                                {
                                    Result = Item.InnerText;
                                }
                                catch
                                {
                                    Result = defaultValue;
                                }

                                return (Result);
                            }
                        }
                    }
                }
            }

            return (Result);
        }

        public static string GetXMLValue(string xmlFile, string parentName, string keyName)
        {
            string Result = "";


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlFile);
            XmlNode Root = xmldoc.DocumentElement;

            if (Root != null & Root.Name == "SieraDelta")
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

    }
}
