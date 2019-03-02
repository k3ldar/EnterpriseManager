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
 *  File: SageUsers.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using SharedBase;
using SharedBase.BOL.Users;
using SharedBase.BOL.Invoices;

using POS.Base.Classes;

namespace POS.Export
{
    public class SageUsers
    {
        #region Private / Protected Methods

        private string _fileName;
        private ProcessStatuses _statuses;
        private User _user;

        #endregion Private / Protected Methods

        #region Constructors / Destructors

        public SageUsers(User user, string FileName, ProcessStatuses processStatuses)
        {
            _user = user;
            _fileName = FileName;
            _statuses = processStatuses;
        }

        #endregion Constructors / Destructors

        #region Public Methods

        public int Execute(DateTime dateFrom)
        {
            int Result = 0;

            // delete file if already exists
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            StreamWriter sw = new StreamWriter(_fileName);
            try
            {
                WriteHeader(sw);
                Result = WriteRecords(sw, dateFrom);
            }
            catch(Exception err)
            {
                if (err.Message.Contains(StringConstants.ERROR_USED_BY_OTHER_PROCESSS))
                {
                    MessageBox.Show(Languages.LanguageStrings.AppErrorAlreadyOpen, Languages.LanguageStrings.AppError, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(err.Message, Languages.LanguageStrings.AppError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                sw.Close();
                sw.Dispose();
                sw = null;
            }

            return (Result);
        }

        #endregion Public Methods

        #region Private Methods

        private void WriteHeader(StreamWriter sw)
        {
            //header details
            string sHeader = StringConstants.EXPORT_HEADER_SAGE_USERS;
            sw.WriteLine(sHeader);

        }


        private int WriteRecords(StreamWriter sw, DateTime dateFrom)
        {
            int Result = 0;

            Invoices invoices = Invoices.InvoicesGet(_user, dateFrom, DateTime.Now.Date,
                ProcessStatuses.Processing | ProcessStatuses.OnHold | ProcessStatuses.OrderReceived | ProcessStatuses.Dispatched, 
                -1, null, false);

            List<string> processedIDList = new List<string>();

            foreach (Invoice invoice in invoices)
            {
                string userID = invoice.User.ID.ToString();

                if (userID.Length > 8)
                {
                    //if (userID.Substring(1, 2) == "00")
                    //    userID = "X" + userID.Substring(0, 1) + userID.Substring(3);

                    int count = 0;
                    char previous = char.MinValue;
                    int startpos = -1;
                    int step = 0;

                    foreach (char c in userID)
                    {
                        if (previous == char.MinValue)
                            previous = c;

                        if (c == '0')
                        {
                            if (count == 0)
                                startpos = step;

                            count++;
                        }

                        step++;
                    }

                    if (count > 0)
                        userID = userID.Substring(0, startpos) + "x" + count.ToString() + userID.Substring(startpos + count);
                }

                if (!processedIDList.Contains(userID))
                {
                    string sLine = String.Format(StringConstants.EXPORT_LINE_SAGE_USERS,
                        userID, 
                        ProcessRecordValue(invoice.User.UserName), 
                        ProcessRecordValue(invoice.User.AddressLine1), 
                        ProcessRecordValue(invoice.User.AddressLine2), 
                        ProcessRecordValue(invoice.User.City),
                        ProcessRecordValue(invoice.User.County), 
                        ProcessRecordValue(invoice.User.PostCode), 
                        ProcessRecordValue(invoice.User.UserName), 
                        ProcessRecordValue(invoice.User.Telephone), 
                        ProcessRecordValue(invoice.User.Email),
                        ProcessRecordValue(invoice.User.Country.CountryCode));
                    sw.WriteLine(sLine);
                    Result++;
                    processedIDList.Add(userID);
                }
            }

            return (Result);
        }

        private string ProcessRecordValue(string record)
        {
            return (record.Replace("\r", "").Replace("\n", "").Replace("\r\n", " "));
        }
        #endregion Private Methods
    }
}