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
 *  File: BBCode.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Text.RegularExpressions;

namespace Library.Utils
{
    /// <summary>
    /// Manipulates BBCode.
    /// </summary>
    public class BBCode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BBCode()
        {

        }


        /// <summary>
        /// GetFontSize - Retrieves a font size
        /// </summary>
        /// <param name="input">Size of font</param>
        /// <returns>string: Font size</returns>
        static private string GetFontSize(int input)
        {
            switch (input)
            {
                case 1:
                    return "50%";
                case 2:
                    return "70%";
                case 3:
                    return "80%";
                case 4:
                    return "90%";
                case 5:
                default:
                    return "100%";
                case 6:
                    return "120%";
                case 7:
                    return "140%";
                case 8:
                    return "160%";
                case 9:
                    return "180%";
            }
        }

        static private RegexOptions m_options = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline;
        static private Regex r_code2 = new Regex(@"\[code=(?<language>[^\]]*)\](?<inner>(.*?))\[/code\]", m_options);
        static private Regex r_code1 = new Regex(@"\[code\](?<inner>(.*?))\[/code\]", m_options);
        static private Regex r_size = new Regex(@"\[size=(?<size>[^\]]*)\](?<inner>(.*?))\[/size\]", m_options);
        static private Regex r_bold = new Regex(@"\[B[^\]]*\](?<inner>(.*?))\[/B\]", m_options);
        static private Regex r_strike = new Regex(@"\[S[^\]]*\](?<inner>(.*?))\[/S\]", m_options);
        static private Regex r_italic = new Regex(@"\[I[^\]]*\](?<inner>(.*?))\[/I\]", m_options);
        static private Regex r_underline = new Regex(@"\[U[^\]]*\](?<inner>(.*?))\[/U\]", m_options);
        static private Regex r_email2 = new Regex(@"\[email=(?<email>[^\]]*)\](?<inner>(.*?))\[/email\]", m_options);
        static private Regex r_email1 = new Regex(@"\[email[^\]]*\](?<inner>(.*?))\[/email\]", m_options);
        static private Regex r_url1 = new Regex(@"\[url[^\]]*\](?<http>(http://)|(https://)|(ftp://))?(?<inner>(.*?))\[/url\]", m_options);
        static private Regex r_url2 = new Regex(@"\[url=(?<http>(http://)|(https://)|(ftp://))?(?<url>[^\]]*)\](?<inner>(.*?))\[/url\]", m_options);
        static private Regex r_url3 = new Regex(@"\[link[^\]]*\](?<http>(http://)|(https://)|(ftp://))?(?<inner>(.*?))\[/link\]", m_options);
        static private Regex r_url4 = new Regex(@"\[link=(?<http>(http://)|(https://)|(ftp://))?(?<url>[^\]]*)\](?<inner>(.*?))\[/link\]", m_options);
        static private Regex r_font = new Regex(@"\[font=(?<font>[^\]]*)\](?<inner>(.*?))\[/font\]", m_options);
        static private Regex r_color = new Regex(@"\[color=(?<color>[^\]]*)\](?<inner>(.*?))\[/color\]", m_options);
        static private Regex r_bullet = new Regex(@"\[\*\]", m_options);
        static private Regex r_list4 = new Regex(@"\[list=i\](?<inner>(.*?))\[/list\]", m_options);
        static private Regex r_list3 = new Regex(@"\[list=a\](?<inner>(.*?))\[/list\]", m_options);
        static private Regex r_list2 = new Regex(@"\[list=1\](?<inner>(.*?))\[/list\]", m_options);
        static private Regex r_list1 = new Regex(@"\[list\](?<inner>(.*?))\[/list\]", m_options);
        static private Regex r_center = new Regex(@"\[center\](?<inner>(.*?))\[/center\]", m_options);
        static private Regex r_left = new Regex(@"\[left\](?<inner>(.*?))\[/left\]", m_options);
        static private Regex r_right = new Regex(@"\[right\](?<inner>(.*?))\[/right\]", m_options);
        static private Regex r_quote2 = new Regex(@"\[quote=(?<quote>[^\]]*)\](?<inner>(.*?))\[/quote\]", m_options);
        static private Regex r_quote1 = new Regex(@"\[quote\](?<inner>(.*?))\[/quote\]", m_options);
        static private Regex r_hr = new Regex("^[-][-][-][-][-]*[\r]?[\n]", m_options);
        static private Regex r_br = new Regex("[\r]?\n", m_options);
        static private Regex r_img = new Regex(@"\[img[^\]]*\](?<inner>(.*?))\[/img\]", m_options);
        static private Regex r_topic = new Regex(@"\[topic=(?<topic>[^\]]*)\](?<inner>(.*?))\[/topic\]", m_options);
        static private Regex r_paragraph = new Regex(@"\[para=(?<class>[^\]]*)\](?<inner>(.*?))\[/para\]", m_options);

        /// <summary>
        /// Converts raw text into HTML text using specified options
        /// </summary>
        /// <param name="URL">URL for board</param>
        /// <param name="session">Current users session information</param>
        /// <param name="bbcode">BBCode to be converted</param>
        /// <param name="ShowSmilies">Depicts wether Smilies will be shown</param>
        /// <param name="ShowImages">Depicts wether Images will be shown</param>
        /// <param name="ShowBBCode">Depicts wether BBCode will be shown</param>
        /// <returns>string: Formatted text</returns>
        //static public string MakeHtml(string URL, string bbcode, bool DoFormatting)
        static public string MakeHtml(string URL,
            string bbcode, bool ShowSmilies, bool ShowImages, bool ShowBBCode)
        {
            System.Collections.ArrayList codes = new System.Collections.ArrayList();
            const string codeFormat = ".code@{0}.";

            Match m = r_code2.Match(bbcode);
            int nCodes = 0;
            if (ShowBBCode)
            {
                while (m.Success)
                {
                    string before_replace = m.Groups[0].Value;
                    string after_replace = m.Groups["inner"].Value;

                    //					try
                    //					{
                    //HighLighter hl = new HighLighter();
                    //hl.ReplaceEnter = true;
                    //after_replace = hl.colorText(after_replace, m.Groups["language"].Value);
                    //					}
                    //					catch 
                    //					{
                    after_replace = ReplaceHTMLElements(after_replace);
                    //					}

                    bbcode = bbcode.Replace(before_replace, string.Format(codeFormat, nCodes++));
                    codes.Add(string.Format("<div class='code'><b>Code:</b><div class='innercode'>{0}</div></div>", after_replace));
                    m = r_code2.Match(bbcode);
                }

                m = r_code1.Match(bbcode);
                while (m.Success)
                {
                    string before_replace = m.Groups[0].Value;
                    string after_replace = ReplaceHTMLElements(m.Groups["inner"].Value);
                    bbcode = bbcode.Replace(before_replace, string.Format(codeFormat, nCodes++));
                    codes.Add(string.Format("<div class='code'><b>Code:</b><div class='innercode'>{0}</div></div>", after_replace));
                    m = r_code1.Match(bbcode);
                }

                m = r_size.Match(bbcode);

                while (m.Success)
                {
                    int i = SharedUtils.StrToIntDef(m.Groups["size"].Value, -1);
                    string tmp;
                    if (i < 1)
                        tmp = m.Groups["inner"].Value;
                    else if (i > 9)
                        tmp = string.Format("<span style=\"font-size:{1}\">{0}</span>", m.Groups["inner"].Value, GetFontSize(9));
                    else
                        tmp = string.Format("<span style=\"font-size:{1}\">{0}</span>", m.Groups["inner"].Value, GetFontSize(i));
                    bbcode = bbcode.Substring(0, m.Groups[0].Index) + tmp + bbcode.Substring(m.Groups[0].Index + m.Groups[0].Length);
                    m = r_size.Match(bbcode);
                }

                //if (DoFormatting)
                NestedReplace(ref bbcode, r_bold, "<strong>${inner}</strong>");
                NestedReplace(ref bbcode, r_strike, "<s>${inner}</s>");
                NestedReplace(ref bbcode, r_italic, "<i>${inner}</i>");
                NestedReplace(ref bbcode, r_underline, "<u>${inner}</u>");

                // e-mails
                NestedReplace(ref bbcode, r_email2, "<a href=\"mailto:${email}\">${inner}</a>", new string[] { "email" });
                NestedReplace(ref bbcode, r_email1, "<a href=\"mailto:${inner}\">${inner}</a>");

                // urls
                NestedReplace(ref bbcode, r_url2, "<a href=\"${http}${url}\" target=\"_blank\">${inner}</a>", new string[] { "url", "http" }, new string[] { "", "http://" });
                NestedReplace(ref bbcode, r_url1, "<a href=\"${http}${inner}\" target=\"_blank\">${http}${inner}</a>", new string[] { "http" }, new string[] { "http://" });
                NestedReplace(ref bbcode, r_url4, "<a href=\"${url}\">${inner}</a>", new string[] { "url" }, new string[] { "" });
                NestedReplace(ref bbcode, r_url3, "<a href=\"${inner}\">${inner}</a>", new string[] { "" }, new string[] { "" });

                // font
                NestedReplace(ref bbcode, r_font, "<span style=\"font-family:${font}\">${inner}</span>", new string[] { "font" });
                NestedReplace(ref bbcode, r_color, "<span style=\"color:${color}\">${inner}</span>", new string[] { "color" });

                // bullets
                bbcode = r_bullet.Replace(bbcode, "<li>");
                NestedReplace(ref bbcode, r_list4, "<ol type=\"i\">${inner}</ol>");
                NestedReplace(ref bbcode, r_list3, "<ol type=\"a\">${inner}</ol>");
                NestedReplace(ref bbcode, r_list2, "<ol>${inner}</ol>");
                NestedReplace(ref bbcode, r_list1, "<ul>${inner}</ul>");

                // alignment
                NestedReplace(ref bbcode, r_center, "<div align=\"center\">${inner}</div>");
                NestedReplace(ref bbcode, r_left, "<div align=\"left\">${inner}</div>");
                NestedReplace(ref bbcode, r_right, "<div align=\"right\">${inner}</div>");

                bbcode = r_hr.Replace(bbcode, "<hr noshade/>");
                bbcode = r_br.Replace(bbcode, "<br />");
            }


            //UPDATED: Moved the show images outside of the ShowBBCode block
            // image
            if (ShowImages)
            {
                NestedReplace(ref bbcode, r_img, "<img src=\"${inner}\"/ border=\"0\">");
                //				bbcode = r_hr.Replace(bbcode, "<hr noshade/>");
                //				bbcode = r_br.Replace(bbcode, "<br/>");
            }


            //			if (ShowSmilies)
            //			{
            //				Smilies smilies = new Smilies(URL);
            //				bbcode = smilies.ReplaceSmilies(bbcode);
            //			}

            // Quotes
            while (r_quote2.IsMatch(bbcode))
                bbcode = r_quote2.Replace(bbcode, "<div class='quote'><b>${quote} " + "Wrote" + ":</b><div class='innerquote'>${inner}</div></div>");

            while (r_quote1.IsMatch(bbcode))
                bbcode = r_quote1.Replace(bbcode, "<div class='quote'><b>" + "Quote" + ":</b><div class='innerquote'>${inner}</div></div>");

            // paragraphs
            while (r_paragraph.IsMatch(bbcode))
                bbcode = r_paragraph.Replace(bbcode, "<p class='${class}'>${inner}</p>");

            m = r_topic.Match(bbcode);

            while (m.Success)
            {
                string link = URL + "/ViewTopic.aspx?id=" + m.Groups["topic"];
                bbcode = bbcode.Replace(m.Groups[0].ToString(), string.Format("<a href=\"{0}\">{1}</a>", link, m.Groups["inner"]));
                m = r_topic.Match(bbcode);
            }

            while (nCodes > 0)
            {
                bbcode = bbcode.Replace(string.Format(codeFormat, --nCodes), codes[nCodes].ToString());
            }

            return bbcode;
        }


        /// <summary>
        /// NewstedReplace - Replaces text in nested blocks
        /// </summary>
        /// <param name="refText"></param>
        /// <param name="regexMatch"></param>
        /// <param name="strReplace"></param>
        /// <param name="Variables"></param>
        /// <param name="VarDefaults"></param>
        static protected void NestedReplace(ref string refText, Regex regexMatch, string strReplace, string[] Variables, string[] VarDefaults)
        {
            Match m = regexMatch.Match(refText);
            while (m.Success)
            {
                string tStr = strReplace;
                int i = 0;

                foreach (string tVar in Variables)
                {
                    string tValue = m.Groups[tVar].Value;
                    if (tValue.Length == 0)
                    {
                        // use default instead
                        tValue = VarDefaults[i];
                    }
                    tStr = tStr.Replace("${" + tVar + "}", tValue);
                    i++;
                }

                tStr = tStr.Replace("${inner}", m.Groups["inner"].Value);

                refText = refText.Substring(0, m.Groups[0].Index) + tStr + refText.Substring(m.Groups[0].Index + m.Groups[0].Length);
                m = regexMatch.Match(refText);
            }
        }


        /// <summary>
        /// NewstedReplace - Replaces text in nested blocks
        /// </summary>
        /// <param name="refText"></param>
        /// <param name="regexMatch"></param>
        /// <param name="strReplace"></param>
        /// <param name="Variables"></param>
        static protected void NestedReplace(ref string refText, Regex regexMatch, string strReplace, string[] Variables)
        {
            Match m = regexMatch.Match(refText);
            while (m.Success)
            {
                string tStr = strReplace;

                foreach (string tVar in Variables)
                {
                    tStr = tStr.Replace("${" + tVar + "}", m.Groups[tVar].Value);
                }

                tStr = tStr.Replace("${inner}", m.Groups["inner"].Value);

                refText = refText.Substring(0, m.Groups[0].Index) + tStr + refText.Substring(m.Groups[0].Index + m.Groups[0].Length);
                m = regexMatch.Match(refText);
            }
        }


        /// <summary>
        /// NewstedReplace - Replaces text in nested blocks
        /// </summary>
        /// <param name="refText"></param>
        /// <param name="regexMatch"></param>
        /// <param name="strReplace"></param>
        static protected void NestedReplace(ref string refText, Regex regexMatch, string strReplace)
        {
            Match m = regexMatch.Match(refText);
            while (m.Success)
            {
                string tStr = strReplace.Replace("${inner}", m.Groups["inner"].Value);
                refText = refText.Substring(0, m.Groups[0].Index) + tStr + refText.Substring(m.Groups[0].Index + m.Groups[0].Length);
                m = regexMatch.Match(refText);
            }
        }



        /// <summary>
        /// Replaces HTML Elements with a text block
        /// </summary>
        /// <param name="S">Text where elements are to be replaced</param>
        /// <returns>string: <B>S</B> with html elements replaced</returns>
        static public string ReplaceHTMLElements(string S)
        {
            string Result = S;
            string[] Find = new string[5] { "  ", "  ", "<", ">", "\"" };
            string[] Replace = new string[5] { "&nbsp; ", " &nbsp;", "&lt;", "&gt;", "&quot;" };

            for (int i = 0; i < Find.Length; i++)
                Result = Result.Replace(Find[i], Replace[i]);

            return (Result);
        }


        /// <summary>
        /// Converts html codes to html
        /// </summary>
        /// <param name="S">Text where elements are to be replaced</param>
        /// <returns>string: <B>S</B> with html elements replaced</returns>
        static public string ConvertToHTML(string S)
        {
            string Result = S;
            string[] Replace = new string[7] { "  ", "  ", "<", ">", "\"", "[", "]" };
            string[] Find = new string[7] { "&nbsp; ", " &nbsp;", "&lt;", "&gt;", "&quot;", "&#91;", "&#93'" };

            for (int i = 0; i < Find.Length; i++)
                Result = Result.Replace(Find[i], Replace[i]);

            return (Result);
        }
    }
}
