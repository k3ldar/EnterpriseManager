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
 *  File: SplashScreen.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
