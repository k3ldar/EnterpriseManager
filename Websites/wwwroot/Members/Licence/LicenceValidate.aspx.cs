using System;
using System.Web;

using Website.Library.Classes;
using Library.Utils;
using Shared;

namespace SieraDelta.Website.Members.Licence
{
    public partial class LicenceValidate : BaseWebForm
    {
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                string ipAddress = Request.UserHostAddress.ToString();
                Int64 id = GetFormValue("ID", long.MaxValue);
                string domain = GetFormValue("Domain", String.Empty);
                string crc = Licence.StringCipher.Decrypt(GetFormValue("crc", String.Empty), Licence.StringCipher._webPassword);
                LicenceType type = (LicenceType)GetFormValue("type", 0);

                string[] parts = crc.Split(':');
                //SieraDeltaUtils u = new SieraDeltaUtils();

                DateTime dateSent = SharedUtils.StrToDateTime(parts[0], "en-gb");
                crc = parts[1];

                //as long as the date is within 1 day of current date
                bool Result = Shared.Utilities.DateWithin(dateSent, 1);

                if (Result)
                {
                    Result = Library.BOL.Licencing.Licence.LicenceValid(id, domain, (int)type);
                }

                string result = String.Format("crc={0}\rValid={1}", crc, Result.ToString());
                Response.Write(HttpUtility.UrlEncode(StringCipher.Encrypt(result, StringCipher._webPassword)));
            }
            catch (Exception err)
            {
                Response.Write(String.Format("999#{0}", err.Message));
            }

            Response.End();
        }
    }
}