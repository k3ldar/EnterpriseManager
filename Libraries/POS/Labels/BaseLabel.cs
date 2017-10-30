using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

using POS.Base.Classes;

namespace POS.Base.Labels
{
    public class BaseLabel
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
