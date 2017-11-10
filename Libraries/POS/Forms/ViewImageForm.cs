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
 *  File: ViewImageForm.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Base.Forms
{
    public partial class ViewImageForm : BaseForm
    {
        #region Private Members

        private Image _viewImage = null;

        #endregion Private Members

        #region Constructors

        public ViewImageForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            HelpTopic = Base.Classes.HelpTopics.StaffExpensesViewReceipt;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static void ShowImage(string title, Image image)
        {
            ViewImageForm frm = new ViewImageForm();
            try
            {
                frm.Text = title;
                frm.ViewImage = image;
                frm.ShowDialog();
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }
        }

        #endregion Static Methods

        #region Properties

        public Image ViewImage
        {
            get
            {
                return (_viewImage);
            }

            set
            {
                picture.Image = value;
                _viewImage = value;
            }
        }

        #endregion Properties

        #region Private Methods

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (_viewImage == null)
                return;

            Bitmap bmpImage = new Bitmap(_viewImage);
            Point mouseLocation = picture.PointToClient(Cursor.Position);
            Rectangle zoomRect = new Rectangle(
                Shared.Utilities.CheckMinMax(mouseLocation.X - 40, 0, mouseLocation.X),
                Shared.Utilities.CheckMinMax(mouseLocation.Y - 40, 0, mouseLocation.Y),
                80, 80);

            while (zoomRect.Right > bmpImage.Width)
            {
                zoomRect.X = zoomRect.X - 1;
            }

            while (zoomRect.Bottom > bmpImage.Height)
            {
                zoomRect.Y = zoomRect.Y - 1;
            }

            try
            {
                Image zoomed = bmpImage.Clone(zoomRect, bmpImage.PixelFormat);
                picZoom.Image = zoomed;
            }
            catch (OutOfMemoryException)
            {
                // do nothing, user has to move mouse
            }
        }

        #endregion Private Methods
    }
}
