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
