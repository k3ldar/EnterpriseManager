using System;
using System.Drawing;

using Languages;
using POS.Base.Classes;

namespace POS.Base.Forms
{
    public partial class SplashScreen : BaseForm
    {
        public SplashScreen()
        {
            InitializeComponent();
            lblName.Parent = picSplash;
            lblName.BackColor = Color.Transparent;
            string splashImage = Shared.Utilities.CurrentPath(true) + StringConstants.FILE_SPLASH_IMAGE;

            if (System.IO.File.Exists(splashImage))
            {
                Bitmap bitmap = new Bitmap(splashImage);
                try
                {
                    picSplash.Image = GetTransparentImage(bitmap, 160);
                }
                finally
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }

            lblProgress.Text = LanguageStrings.AppInitialising;
        }

        public void Update(string Text)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        public void Update(string Text, int Pos)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        public void UpdateProgress(int Position)
        {
            Refresh();
        }

        public void Update(int Max, int Position)
        {
        }

        public void UsersLoaded()
        {
            if (this.Disposing || this.IsDisposed)
                return;

            if (this.InvokeRequired)
            {
                try
                {
                    EmptyParamDelegate epd = new EmptyParamDelegate(UsersLoaded);

                    if (!this.IsDisposed)
                        this.Invoke(epd);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains(StringConstants.ERROR_DISPOSED_OBJECT))
                        throw;
                }
            }
        }

        public void AppointmentsLoaded()
        {
            if (this.Disposing || this.IsDisposed)
                return;

            if (this.InvokeRequired)
            {
                try
                {
                    EmptyParamDelegate epd = new EmptyParamDelegate(AppointmentsLoaded);

                    if (!this.IsDisposed)
                        this.Invoke(epd);
                }
                catch (Exception err)
                {
                    if (!err.Message.Contains(StringConstants.ERROR_DISPOSED_OBJECT))
                        throw;
                }
            }
        }

        private Image GetTransparentImage(Image image, int alpha)
        {
            Bitmap output = new Bitmap(image);

            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    Color color = output.GetPixel(x, y);
                    output.SetPixel(x, y, Color.FromArgb(alpha, color.R, color.G, color.B));
                }
            }

            return output;
        }
    }

    public delegate void EmptyParamDelegate();
}
