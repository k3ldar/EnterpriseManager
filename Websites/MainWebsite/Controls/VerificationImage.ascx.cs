using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Heavenskincare.Website;
using Website.Library.Classes;
using Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
    public partial class VerificationImage : BaseControlClass
    {
        private Random random = new Random();
        private bool _isValid;

        public bool IsValid
        {
            get
            {
                return (_isValid);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblValid.Text = Languages.LanguageStrings.CodeNotValid;
            lblValid.Visible = false;

            if (!this.IsPostBack)
            {
                // Create a random code and store it in the Session object.
                this.Session["CaptchaImageText"] = GenerateRandomCode();
            }
            else
            {
                // On a postback, check the user input.
                if (Session["CaptchaImageText"] != null && this.txtValidationCode.Text == this.Session["CaptchaImageText"].ToString())
                {
                    // Display an informational message.
                    _isValid = true;
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                }
                else
                {
                    // Display an error message.
                    lblValid.Visible = true;

                    // Clear the input and create a new random code.
                    this.Session["CaptchaImageText"] = GenerateRandomCode();
                    _isValid = false;
                }

                this.txtValidationCode.Text = "";
            }

            string url = String.Empty;

            url = String.Format("{1}/Controls/JpegImage.aspx?ID={0}", GenerateRandomCode(), Global.RootURL);

            if (!Request.IsLocal && Request.IsSecureConnection)
                url = url.ToLower().Replace("http://", "https://");

            Image1.ImageUrl = url;
            Image1.EnableViewState = false;
        }

        public void Refresh()
        {

        }

        private string GenerateRandomCode()
        {
            string s = "";
            for (int i = 0; i < 6; i++)
                s = String.Concat(s, this.random.Next(10).ToString());
            return s;
        }

    }
}