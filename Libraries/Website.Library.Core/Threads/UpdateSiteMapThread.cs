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
 *  File: UpdateSiteMapThread.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  17/03/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;

using lib = Library;
using Library.BOL.Websites;

using Shared;

namespace Website.Library.Core.Threads
{
    internal class UpdateSiteMapThread : Shared.Classes.ThreadManager
    {
        internal UpdateSiteMapThread()
            : base(null, new TimeSpan(0, 1, 0))
        {
            RunAtStartup = true;
        }

        protected override bool Run(object parameters)
        {
            // rebuild site map
            string siteMapData = WebsiteSettings.RootPath + "admin\\sitemap.dat";

            if (System.IO.File.Exists(siteMapData))
            {
                string defaultData = Shared.Utilities.FileRead(siteMapData, false).Replace("\n", "");

                string newSiteMapXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \r\n" +
                    "<urlset \r\n" +
                    "      xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" \r\n" +
                    "      xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" \r\n" +
                    "      xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9 \r\n" +
                    "            http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\"> \r\n";


                string[] lines = defaultData.Split('\r');
                string url;

                foreach (string line in lines)
                {
                    if (String.IsNullOrEmpty(line.Trim()) || line.StartsWith("#"))
                        continue;

                    string[] defaultRow = line.Split('#');

                    double prior = Math.Round(lib.Utils.SharedUtils.StrToDblDef(defaultRow[1], 0.5d), 2);

                    if (prior < 0.0d || prior > 1.0d)
                        prior = 0.5d;

                    string priority = prior.ToString();
                    url = HTMLEncode(WebsiteSettings.RootURL + defaultRow[0]);

                    string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>{1}</changefreq>\r\n" +
                        "    <priority>{2}</priority>\r\n  </url>\r\n", url, defaultRow[2], priority);

                    newSiteMapXML += newXMLEntry;
                }


                // products
                lib.BOL.Products.ProductTypes prodTypes = lib.BOL.Products.ProductTypes.Get();

                foreach (lib.BOL.Products.ProductType pType in prodTypes)
                {
                    lib.BOL.Products.Products products = lib.BOL.Products.Products.Get(pType, 1, 1000);

                    foreach (lib.BOL.Products.Product prod in products)
                    {
                        if (prod.VisibleToAllUsers())
                        {
                            switch (prod.PrimaryProduct.Description)
                            {
                                case "Stratosphere":
                                case "MensHeaven":
                                    url = String.Format("{0}/Products/Stratosphere.aspx?ID={1}",
                                        WebsiteSettings.RootURL, prod.ID);
                                    break;
                                default:
                                    url = String.Format("{0}/Products/Product.aspx?ID={1}",
                                        WebsiteSettings.RootURL, prod.ID);
                                    break;
                            }


                            string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>weekly</changefreq>\r\n" +
                                "    <priority>0.7</priority>\r\n  </url>\r\n", HTMLEncode(url));

                            newSiteMapXML += newXMLEntry;

                        }
                    }
                }

                // celebrities
                lib.BOL.Celebrities.Celebrities celebs = lib.BOL.Celebrities.Celebrities.Get();

                foreach (lib.BOL.Celebrities.Celebrity celeb in celebs)
                {
                    url = String.Format("{0}/Celebrities/ViewCeleb.aspx?ID={1}", WebsiteSettings.RootURL, celeb.ID);
                    string newXMLEntry = String.Format("  <url>\r\n    <loc>{0}</loc>\r\n    <changefreq>weekly</changefreq>\r\n" +
                        "    <priority>0.6</priority>\r\n  </url>\r\n", HTMLEncode(url));

                    newSiteMapXML += newXMLEntry;
                }

                // salons


                // distributors

                newSiteMapXML += "</urlset>\r\n";

                Utilities.FileWrite(WebsiteSettings.RootPath + "sitemap_location.xml", newSiteMapXML);

                // update robots.txt
                siteMapData = WebsiteSettings.RootPath + "robots.txt";
                string robots = Utilities.FileRead(siteMapData, true);

                // remove first line, upto first \r\n
                robots = robots.Substring(robots.IndexOf('\r'));
                robots = String.Format("Sitemap: {0}/sitemap_location.xml{1}",
                    WebsiteSettings.RootURL, robots);
                Utilities.FileWrite(siteMapData, robots);
            }

            return (false);
        }

        private static readonly string[] find = { "&", "'", "\"", ">", "<" };
        private static readonly string[] replace = { "&amp;", "&apos;", "&quot;", "&gt;", "&lt;" };

        private string HTMLEncode(string s)
        {
            for (int i = 0; i < find.Length; i++)
            {
                s = s.Replace(find[i], replace[i]);
            }

            return (s);
        }
    }
}
