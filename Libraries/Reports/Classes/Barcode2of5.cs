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
 *  File: Barcode2of5.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Reports.Classes
{
    class Barcode2of5
    {
        public static Bitmap Print2of5Interleaved(string content)
        {
            string Content = content;
            string CheckSum = CalcCheckSum(Content);
            string startcode = "1010";
            string stopcode = "1101";
            int startX = 0;
            int startY = 0;
            int endY = startY + 40;
            int curX;
            int sectionIndex = 0;
            int pairIndex = 0;
            int barIndex = 0;
            int spaceIndex = 0;

            Graphics g;
            Bitmap bmp = new Bitmap(145, 50);
            g = Graphics.FromImage(bmp);

            curX = startX;
            Content = Content + CheckSum;
            if ((Content.Length % 2) != 0)
            {
                //odd number, fill in a leading zero
                Content = "0" + Content;
            }
            //draw the start marker
            foreach (char digit in startcode)
            {
                if (digit == '1')
                {
                    g.DrawLine(Pens.Black, curX, startY, curX, endY);
                    curX += 1;
                }
                else
                {
                    curX += 1;
                }
            }
            //draw the content
            for (int i = 0; i < Content.Length; i += 2)
            {
                string pair = Content.Substring(i, 2);
                string barPattern = Get2of5Pattern(pair.Substring(0, 1));
                string spacePattern = Get2of5Pattern(pair.Substring(1, 1));
                barIndex = 0;
                spaceIndex = 0;
                sectionIndex = 0;
                while (sectionIndex < 10)
                {
                    if ((sectionIndex % 2) == 0)
                    {
                        //bar 0,2,4,6,8 positions
                        pairIndex = 0;
                        if (barPattern.Substring(barIndex, 1) == "W")
                        {
                            //draw wide bar
                            while (pairIndex < 2)
                            {
                                g.DrawLine(Pens.Black, curX + pairIndex, startY, curX + pairIndex, endY);
                                pairIndex++;
                            }
                            curX = curX + 2;
                        }
                        else
                        {
                            //draw narrow bar
                            g.DrawLine(Pens.Black, curX + pairIndex, startY, curX + pairIndex, endY);
                            curX = curX + 1;
                        }
                        barIndex++;
                    }
                    else
                    {
                        //space 1,3,5,7,8 positions
                        if (spacePattern.Substring(spaceIndex, 1) == "W")
                        {
                            //simulate drawing a wide white space
                            curX = curX + 2;
                        }
                        else
                        {
                            //simulate drawing a narrow white space
                            curX = curX + 1;
                        }
                        spaceIndex++;
                    }
                    sectionIndex += 1;
                }
            }
            //draw the stop marker
            foreach (char digit in stopcode)
            {
                if (digit == '1')
                {
                    g.DrawLine(Pens.Black, curX, startY, curX, endY);
                    curX += 1;
                }
                else
                {
                    curX += 1;
                }
            }

            return bmp;
        }

        private static string CalcCheckSum(string CheckNum)
        {
            int i;
            int j;
            int checkval = 0;
            j = 3;
            i = CheckNum.Length - 1;
            while (i > 0)
            {
                checkval += Convert.ToInt32(CheckNum.Substring(i, 1)) * j;
                j = j ^ 2;
                i -= 1;
            }

            checkval = (10 - (checkval % 10)) % 10;
            return checkval.ToString();
        }

        private static string Get2of5Pattern(string letter)
        {
            string tmpPattern = "";
            switch (letter)
            {
                case "0":
                    tmpPattern = "NNWWN";
                    break;
                case "1":
                    tmpPattern = "WNNNW";
                    break;
                case "2":
                    tmpPattern = "NWNNW";
                    break;
                case "3":
                    tmpPattern = "WWNNN";
                    break;
                case "4":
                    tmpPattern = "NNWNW";
                    break;
                case "5":
                    tmpPattern = "WNWNN";
                    break;
                case "6":
                    tmpPattern = "NWWNN";
                    break;
                case "7":
                    tmpPattern = "NNNWW";
                    break;
                case "8":
                    tmpPattern = "WNNWN";
                    break;
                case "9":
                    tmpPattern = "NWNWN";
                    break;
            }
            return tmpPattern;
        }
    }
}
