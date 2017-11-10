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
 *  File: WaitInputDialog.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

namespace SieraDelta.POS.Forms
{
    public partial class WaitInputDialog : SieraDelta.Controls.Forms.BaseForm
    {
        private static WaitInputDialog _waitDialog = null;

        public WaitInputDialog()
        {
            InitializeComponent();
        }

        #region Static Methods

        public static void ShowWaitScreen()
        {
            if (_waitDialog == null)
            {
                _waitDialog = new WaitInputDialog();
                _waitDialog.Show();
                //System.Threading.Thread.CurrentThread.
            }
        }


        public static void HideWaitScreen()
        {
            if (_waitDialog != null)
            {
                _waitDialog.Close();
                _waitDialog.Dispose();
                _waitDialog = null;
            }
        }

        public static void UpdateWaitScreen(string text)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text);
            }
        }


        public static void UpdateWaitScreen(string text, int position)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text, position);
            }
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppPleaseWait;
        }

        #endregion Overridden Methods

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
    }
}
