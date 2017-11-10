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
 *  File: StringExtender.cs
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

namespace Library.ClassExtenders
{
    public static class StringExtender
    {
        public static string[] Split(this string s, int maxLength, bool wholeWords)
        {
            string[] results = new string[Math.Abs(s.Length / (maxLength - 10)) + 1];

            string[] words = s.Split(' ');
            int currIndex = 0;

            foreach (string word in words)
            {
                if (results[currIndex] == null)
                    results[currIndex] = String.Empty;

                if ((results[currIndex].Length + (word.Length + 1)) > maxLength)
                {
                    results[currIndex] = results[currIndex].Trim();
                    currIndex++;
                }

                results[currIndex] += " " + word;
            }

            currIndex = 0;

            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] != null)
                    currIndex = i;
            }

            string[] Result = new string[currIndex + 1];

            for (int j = 0; j < Result.Length; j++)
            {
                Result[j] = results[j].Trim();
            }

            return (Result);
        }

        /// <summary>Returns a string array that contains the substrings in this string that are seperated a given fixed length.</summary>
        /// <param name="s">This string object.</param>
        /// <param name="length">Size of each substring.
        ///     <para>CASE: length &gt; 0 , RESULT: String is split from left to right.</para>
        ///     <para>CASE: length == 0 , RESULT: String is returned as the only entry in the array.</para>
        ///     <para>CASE: length &lt; 0 , RESULT: String is split from right to left.</para>
        /// </param>
        /// <returns>String array that has been split into substrings of equal length.</returns>
        /// <example>
        ///     <code>
        ///         string s = "1234567890";
        ///         string[] a = s.Split(4); // a == { "1234", "5678", "90" }
        ///     </code>
        /// </example>            
        public static string[] Split(this string s, int length)
        {
            System.Globalization.StringInfo str = new System.Globalization.StringInfo(s);

            int lengthAbs = Math.Abs(length);

            if (str == null || str.LengthInTextElements == 0 || lengthAbs == 0 || str.LengthInTextElements <= lengthAbs)
                return new string[] { str.ToString() };

            string[] array = new string[(str.LengthInTextElements % lengthAbs == 0 ? str.LengthInTextElements / lengthAbs : (str.LengthInTextElements / lengthAbs) + 1)];

            if (length > 0)
                for (int iStr = 0, iArray = 0; iStr < str.LengthInTextElements && iArray < array.Length; iStr += lengthAbs, iArray++)
                    array[iArray] = str.SubstringByTextElements(iStr, (str.LengthInTextElements - iStr < lengthAbs ? str.LengthInTextElements - iStr : lengthAbs));
            else // if (length < 0)
                for (int iStr = str.LengthInTextElements - 1, iArray = array.Length - 1; iStr >= 0 && iArray >= 0; iStr -= lengthAbs, iArray--)
                    array[iArray] = str.SubstringByTextElements((iStr - lengthAbs < 0 ? 0 : iStr - lengthAbs + 1), (iStr - lengthAbs < 0 ? iStr + 1 : lengthAbs));

            return array;
        }
    }

}
