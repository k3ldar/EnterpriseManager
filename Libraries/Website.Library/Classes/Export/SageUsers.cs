using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;

using Website;
using Library.BOL.Users;
using Library.BOL.Invoices;
using Library;


namespace Classes.Export
{
    public class SageUsers
    {
        public const string EXPORT_HEADER_SAGE_USERS = "\"Account Reference\",\"Account Name\",\"Street 1\",\"Street 2\",\"Town\",\"County\",\"Postcode\",\"Contact Name\",\"Telephone Number\",\"EMail\",\"Country Code\"";
        public const string EXPORT_LINE_SAGE_USERS = "\"W{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"";

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

        public int Execute()
        {
            int Result = 0;

            // delete file if already exists
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            StreamWriter sw = new StreamWriter(_fileName);
            try
            {
                WriteHeader(sw);
                Result = WriteRecords(sw);
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
            string sHeader = EXPORT_HEADER_SAGE_USERS;
            sw.WriteLine(sHeader);

        }


        private int WriteRecords(StreamWriter sw)
        {
            int Result = 0;

            Invoices invoices = Invoices.InvoicesGetAll(_user, _statuses);

            foreach (Invoice invoice in invoices)
            {

                string sLine = String.Format(EXPORT_LINE_SAGE_USERS,
                    invoice.User.ID, invoice.User.UserName, invoice.User.AddressLine1, invoice.User.AddressLine2, invoice.User.City,
                    invoice.User.County, invoice.User.PostCode, invoice.User.UserName, invoice.User.Telephone, invoice.User.Email,
                    invoice.User.Country.CountryCode);
                sw.WriteLine(sLine);
                Result++;
            }

            return (Result);
        }

        #endregion Private Methods
    }
}