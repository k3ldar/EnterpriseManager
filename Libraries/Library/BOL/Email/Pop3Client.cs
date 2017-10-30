using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace Library.BOL.Email
{
    [Serializable]
    public class Pop3Client : BaseObject, IDisposable
    {
        public string Host { get; protected set; }
        public int Port { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public bool IsSecure { get; protected set; }
        public TcpClient Client { get; protected set; }
        public Stream ClientStream { get; protected set; }
        public StreamWriter Writer { get; protected set; }
        public StreamReader Reader { get; protected set; }
        private bool disposed = false;
        public Pop3Client(string host, int port, string email, string password) : this(host, port, email, password, false) { }
        public Pop3Client(string host, int port, string email, string password, bool secure)
        {
            Host = host;
            Port = port;
            Email = email;
            Password = password;
            IsSecure = secure;
        }

        public void Connect()
        {
            if (Client == null)
                Client = new TcpClient();
            if (!Client.Connected)
                Client.Connect(Host, Port);
            if (IsSecure)
            {
                SslStream secureStream = new SslStream(Client.GetStream());
                secureStream.AuthenticateAsClient(Host);
                ClientStream = secureStream;
                secureStream = null;
            }
            else
                ClientStream = Client.GetStream();

            Writer = new StreamWriter(ClientStream);
            Reader = new StreamReader(ClientStream);
            ReadLine();
            Login();
        }
        public void Quit()
        {
            if (!IsResponseOk(SendCommand("QUIT")))
                throw new Exception("Problem Quiting");
        }

        public int GetEmailCount()
        {
            int count = 0;
            string response = SendCommand("STAT");
            if (IsResponseOk(response))
            {
                string[] arr = response.Substring(4).Split(' ');
                count = Convert.ToInt32(arr[0]);
            }
            else
                count = -1;
            return count;
        }
        public Email FetchEmail(int emailId)
        {
            if (IsResponseOk(SendCommand("TOP " + emailId + " 0")))
                return new Email(ReadLines());
            else
                return null;
        }
        public List<Email> FetchEmailList(int start, int count)
        {
            List<Email> emails = new List<Email>(count);
            for (int i = start; i < (start + count); i++)
            {
                Email email = FetchEmail(i);
                if (email != null)
                    emails.Add(email);
            }
            return emails;
        }
        
        public string DeleteEmail(int emailId)
        {
            string Result = SendCommand("DELE " + emailId);

            IsResponseOk(Result);
                

            return (Result);
        }

        public List<MessagePart> FetchMessageParts(int emailId)
        {
            if (IsResponseOk(SendCommand("RETR " + emailId)))
                return Util.ParseMessageParts(ReadLines());

            return null;
        }
        public void Close()
        {
            if (Client != null)
            {
                if (Client.Connected)
                    Logout();

                Client.Close();
                Client = null;
            }

            if (ClientStream != null)
            {
                ClientStream.Close();
                ClientStream.Dispose();
                ClientStream = null;
            }

            if (Writer != null)
            {
                Writer.Close();
                Writer.Dispose();
                Writer = null;
            }

            if (Reader != null)
            {
                Reader.Close();
                Reader.Dispose();
                Reader = null;
            }

            disposed = true;
        }

        public void Dispose()
        {
            if (!disposed)
                Close();
#if DEBUG
            System.GC.SuppressFinalize(this);
#endif
        }

        protected void Login()
        {
            if (!IsResponseOk(SendCommand("USER " + Email)) || !IsResponseOk(SendCommand("PASS " + Password)))
                throw new Exception("User/password not accepted");
        }

        protected void Logout()
        {
            SendCommand("RSET");
        }

        protected string SendCommand(string cmdtext)
        {
            Writer.WriteLine(cmdtext);
            Writer.Flush();
            return ReadLine();
        }

        protected string ReadLine()
        {
            return Reader.ReadLine() + "\r\n";
        }

        protected string ReadLines()
        {
            StringBuilder b = new StringBuilder();
            while (true)
            {
                string temp = ReadLine();
                if (temp == ".\r\n" || temp.IndexOf("-ERR") != -1)
                    break;
                b.Append(temp);
            }
            return b.ToString();
        }

        protected static bool IsResponseOk(string response)
        {
            if (response.StartsWith("+OK"))
                return true;
            if (response.StartsWith("-ERR"))
                return false;
            throw new Exception("Cannot understand server response: " + response);
        }

        public string GetMessageBody(Email email, List<MessagePart> parts)
        {
            MessagePart preferredMsgPart = FindMessagePart(parts, "text/html");

            if (preferredMsgPart == null)
                preferredMsgPart = FindMessagePart(parts, "text/plain");
            else
                if (preferredMsgPart == null && parts.Count > 0)
                    preferredMsgPart = parts[0];


            string contentType, charset, contentTransferEncoding, body = null;

            if (preferredMsgPart != null)
            {
                contentType = preferredMsgPart.Headers["Content-Type"];
                charset = "us-ascii";
                contentTransferEncoding = preferredMsgPart.Headers["Content-Transfer-Encoding"];

                Match m = CharsetRegex.Match(contentType);

                if (m.Success)
                    charset = m.Groups["charset"].Value;

                if (contentTransferEncoding != null)
                {
                    if (contentTransferEncoding.ToLower() == "base64")
                        body = DecodeBase64String(charset,
                            preferredMsgPart.MessageText);
                    else
                        if (contentTransferEncoding.ToLower() == "quoted-printable")
                            body = DecodeQuotedPrintableString
                            (preferredMsgPart.MessageText);
                        else
                            body = preferredMsgPart.MessageText;
                }
                else
                    body = preferredMsgPart.MessageText;
            }

            return (body);
        }

        #region Private Methods

        private static Regex CharsetRegex = new Regex("charset=\"?(?<charset>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static Regex QuotedPrintableRegex = new Regex("=(?<hexchars>[0-9a-fA-F]{2,2})", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static Regex UrlRegex = new Regex("(?<url>https?://[^\\s\"]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static Regex FilenameRegex = new Regex("filename=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static Regex NameRegex = new Regex("name=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private Decoder GetDecoder(string charset)
        {
            Decoder decoder;
            switch (charset.ToLower())
            {
                case "utf-7":
                    decoder = Encoding.UTF7.GetDecoder();
                    break;
                case "utf-8":
                    decoder = Encoding.UTF8.GetDecoder();
                    break;
                case "us-ascii":
                    decoder = Encoding.ASCII.GetDecoder();
                    break;
                case "iso-8859-1":
                    decoder = Encoding.ASCII.GetDecoder();
                    break;
                default:
                    decoder = Encoding.ASCII.GetDecoder();
                    break;
            }
            return decoder;
        }

        private string DecodeBase64String(string charset, string encodedString)
        {
            Decoder decoder = GetDecoder(charset);
            byte[] buffer = Convert.FromBase64String(encodedString);
            char[] chararr = new char[decoder.GetCharCount(buffer, 0, buffer.Length)];
            decoder.GetChars(buffer, 0, buffer.Length, chararr, 0);
            return new string(chararr);
        }

        private string DecodeQuotedPrintableString(string encodedString)
        {
            StringBuilder b = new StringBuilder();
            int startIndx = 0;
            MatchCollection matches = QuotedPrintableRegex.Matches(encodedString);
            for (int i = 0; i < matches.Count; i++)
            {
                Match m = matches[i];
                string hexchars = m.Groups["hexchars"].Value;
                int charcode = Convert.ToInt32(hexchars, 16);
                char c = (char)charcode;
                if (m.Index > 0)
                    b.Append(encodedString.Substring(startIndx,
                            (m.Index - startIndx)));
                b.Append(c);
                startIndx = m.Index + 3;
            }
            if (startIndx < encodedString.Length)
                b.Append(encodedString.Substring(startIndx));
            return Regex.Replace(b.ToString(),
            "=\r\n", "");
        }

        private string ListAttachments(List<MessagePart> msgParts)
        {
            bool attachmentsFound = false;
            StringBuilder b = new StringBuilder();
            b.Append("<ol>");
            foreach (MessagePart p in msgParts)
            {
                string contentType = p.Headers["Content-Type"];
                string contentDisposition = p.Headers["Content-Disposition"];
                Match m;
                if (contentDisposition != null)
                {
                    m = FilenameRegex.Match(contentDisposition);
                    if (m.Success)
                    {
                        attachmentsFound = true;
                        b.Append("<li>").Append(m.Groups
                        ["filename"].Value).Append("</li>");
                    }
                }
                else if (contentType != null)
                {
                    m = NameRegex.Match(contentType);
                    if (m.Success)
                    {
                        attachmentsFound = true;
                        b.Append("<li>").Append(m.Groups
                        ["filename"].Value).Append("</li>");
                    }
                }
            }

            b.Append("</ol>");

            if (attachmentsFound)
                return (b.ToString());

            return (String.Empty);
        }

        private MessagePart FindMessagePart(List<MessagePart> msgParts, string contentType)
        {
            foreach (MessagePart p in msgParts)
                if (p.ContentType != null && p.ContentType.IndexOf(contentType) != -1)
                    return p;
            return null;
        }

        private string FormatUrls(string plainText)
        {
            string replacementLink = "<a href=\"${url}\">${url}</a>";
            return UrlRegex.Replace(plainText, replacementLink);
        }

        #endregion Private Methods
    }

    [Serializable]
    public class Email
    {
        public NameValueCollection Headers { get; protected set; }
        public string ContentType { get; protected set; }
        public DateTime UtcDateTime { get; protected set; }
        public string From { get; protected set; }
        public string To { get; protected set; }
        public string Subject { get; protected set; }
        public string MessageID { get; protected set; }
        public Email(string emailText)
        {
            Headers = Util.ParseHeaders(emailText);
            ContentType = Headers["Content-Type"];
            From = Headers["From"];
            To = Headers["To"];
            Subject = Headers["Subject"];
            MessageID = Headers["Message-ID"];
            if (Headers["Date"] != null)
                try
                {
                    UtcDateTime = Util.ConvertStrToUtcDateTime(Headers["Date"]);
                }
                catch (FormatException)
                {
                    UtcDateTime = DateTime.MinValue;
                }
            else
                UtcDateTime = DateTime.MinValue;
        }
    }

    [Serializable]
    public class MessagePart
    {
        public NameValueCollection Headers { get; protected set; }
        public string ContentType { get; protected set; }
        public string MessageText { get; protected set; }
        public MessagePart(NameValueCollection headers, string messageText)
        {
            Headers = headers;
            ContentType = Headers["Content-Type"];
            MessageText = messageText;
        }
    }

    [Serializable]
    public class Util
    {
        protected static Regex BoundaryRegex = new Regex("Content-Type: multipart(?:/\\S+;)" + "\\s+[^\r\n]*boundary=\"?(?<boundary>" + "[^\"\r\n]+)\"?\r\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        protected static Regex UtcDateTimeRegex = new Regex(@"^(?:\w+,\s+)?(?<day>\d+)\s+(?<month>\w+)\s+(?<year>\d+)\s+(?<hour>\d{1,2})" + @":(?<minute>\d{1,2}):(?<second>\d{1,2})\s+(?<offsetsign>\-|\+)(?<offsethours>" + @"\d{2,2})(?<offsetminutes>\d{2,2})(?:.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static NameValueCollection ParseHeaders(string headerText)
        {
            NameValueCollection headers = new NameValueCollection();
            StringReader reader = new StringReader(headerText);
            string line;
            string headerName = null, headerValue;
            int colonIndx;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                    break;
                if (Char.IsLetterOrDigit(line[0]) && (colonIndx = line.IndexOf(':')) != -1)
                {
                    headerName = line.Substring(0, colonIndx);
                    headerValue = line.Substring(colonIndx + 1).Trim();
                    headers.Add(headerName, headerValue);
                }
                else if (headerName != null)
                    headers[headerName] += " " + line.Trim();
                else
                    throw new FormatException("Could not parse headers");
            }
            return headers;
        }
        public static List<MessagePart> ParseMessageParts(string emailText)
        {
            List<MessagePart> messageParts = new List<MessagePart>();
            int newLinesIndx = emailText.IndexOf("\r\n\r\n");
            Match m = BoundaryRegex.Match(emailText);
            if (m.Index < emailText.IndexOf("\r\n\r\n") && m.Success)
            {
                string boundary = m.Groups["boundary"].Value;
                string startingBoundary = "\r\n--" + boundary;
                int startingBoundaryIndx = -1;
                while (true)
                {
                    if (startingBoundaryIndx == -1)
                        startingBoundaryIndx = emailText.IndexOf(startingBoundary);
                    if (startingBoundaryIndx != -1)
                    {
                        int nextBoundaryIndx = emailText.IndexOf(startingBoundary, startingBoundaryIndx + startingBoundary.Length);
                        if (nextBoundaryIndx != -1 && nextBoundaryIndx != startingBoundaryIndx)
                        {
                            string multipartMsg = emailText.Substring(startingBoundaryIndx + startingBoundary.Length, (nextBoundaryIndx - startingBoundaryIndx - startingBoundary.Length));
                            int headersIndx = multipartMsg.IndexOf("\r\n\r\n");
                            if (headersIndx == -1)
                                throw new FormatException("Incompatible multipart message format");
                            string bodyText = multipartMsg.Substring(headersIndx).Trim();
                            NameValueCollection headers = Util.ParseHeaders(multipartMsg.Trim());
                            messageParts.Add(new MessagePart(headers, bodyText));
                        }
                        else
                            break;
                        startingBoundaryIndx = nextBoundaryIndx;
                    }
                    else
                        break;
                }
                if (newLinesIndx != -1)
                {
                    string emailBodyText = emailText.Substring(newLinesIndx + 1);
                }
            }
            else
            {
                int headersIndx = emailText.IndexOf("\r\n\r\n");
                if (headersIndx == -1)
                    throw new FormatException("Incompatible multipart message format");
                string bodyText = emailText.Substring(headersIndx).Trim();
                NameValueCollection headers = Util.ParseHeaders(emailText);
                messageParts.Add(new MessagePart(headers, bodyText));
            }
            return messageParts;
        }
        public static DateTime ConvertStrToUtcDateTime(string str)
        {
            Match m = UtcDateTimeRegex.Match(str);
            int day, month, year, hour, min, sec;
            if (m.Success)
            {
                day = Convert.ToInt32(m.Groups["day"].Value);
                year = Convert.ToInt32(m.Groups["year"].Value);
                hour = Convert.ToInt32(m.Groups["hour"].Value);
                min = Convert.ToInt32(m.Groups["minute"].Value);
                sec = Convert.ToInt32(m.Groups["second"].Value);
                switch (m.Groups["month"].Value)
                {
                    case "Jan":
                        month = 1;
                        break;
                    case "Feb":
                        month = 2;
                        break;
                    case "Mar":
                        month = 3;
                        break;
                    case "Apr":
                        month = 4;
                        break;
                    case "May":
                        month = 5;
                        break;
                    case "Jun":
                        month = 6;
                        break;
                    case "Jul":
                        month = 7;
                        break;
                    case "Aug":
                        month = 8;
                        break;
                    case "Sep":
                        month = 9;
                        break;
                    case "Oct":
                        month = 10;
                        break;
                    case "Nov":
                        month = 11;
                        break;
                    case "Dec":
                        month = 12;
                        break;
                    default:
                        throw new FormatException("Unknown month.");
                }
                string offsetSign = m.Groups["offsetsign"].Value;
                int offsetHours = Convert.ToInt32(m.Groups["offsethours"].Value);
                int offsetMinutes = Convert.ToInt32(m.Groups["offsetminutes"].Value);
                DateTime dt = new DateTime(year, month, day, hour, min, sec);
                if (offsetSign == "+")
                {
                    dt.AddHours(offsetHours);
                    dt.AddMinutes(offsetMinutes);
                }
                else if (offsetSign == "-")
                {
                    dt.AddHours(-offsetHours);
                    dt.AddMinutes(-offsetMinutes);
                }
                return dt;
            }
            throw new FormatException("Incompatible date/time string format");
        }
    }
}
