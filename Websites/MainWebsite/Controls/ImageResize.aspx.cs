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
    public partial class ImageResize : BaseWebForm
    {
        protected override void OnLoad(EventArgs e)
        {
            string imageFile = GetFormValue("image");
            int newWidth = GetFormValue("width", 0);
            int newHeight = GetFormValue("height", 0);

            if (newWidth > 0 && newHeight > 0)
            {
                string localPath = Global.Path + new Uri(imageFile).LocalPath.Replace("/", "\\");

                if (System.IO.File.Exists(localPath))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(localPath);
                    try
                    {
                        System.Drawing.Bitmap Result = new System.Drawing.Bitmap(newWidth, newHeight);
                        try
                        {
                            Result.SetResolution(300, 300);
                            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Result);
                            try
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                                // Resize the original
                                g.DrawImage(image, 0, 0, newWidth, newHeight);
                            }
                            finally
                            {
                                g.Dispose();
                                g = null;
                            }

                            this.Response.Clear();
                            this.Response.ContentType = "image/jpeg";

                            // Write the image to the response stream in JPEG format.
                            Result.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                        }
                        finally
                        {
                            Result.Dispose();
                            Result = null;
                        }
                    }
                    finally
                    {
                        image.Dispose();
                        image = null;
                    }
                }
            }
        }
    }
}