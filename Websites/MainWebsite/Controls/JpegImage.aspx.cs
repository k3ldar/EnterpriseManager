using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Website.Library.Classes;

namespace Heavenskincare.WebsiteTemplate.Controls
{
	public class JpegImage : BaseWebForm
	{
        private void Page_Load(object sender, System.EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
		{
			// Create a CAPTCHA image using the text stored in the Session object.
            if (this.Session["CaptchaImageText"] != null)
            {
                CaptchaImage ci = new CaptchaImage(this.Session["CaptchaImageText"].ToString(), 200, 50, "Century Schoolbook");
                try
                {
                    // Change the response headers to output a JPEG image.
                    this.Response.Clear();
                    this.Response.ContentType = "image/jpeg";

                    // Write the image to the response stream in JPEG format.
                    ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains("Specified method is not supported."))
                        throw;
                }
                finally
                {
                    // Dispose of the CAPTCHA image object.
                    ci.Dispose();
                }
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
